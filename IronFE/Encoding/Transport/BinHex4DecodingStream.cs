using System.IO;

namespace IronFE.Encoding.Transport
{
    /// <summary>
    /// Decodes BinHex 4.0-encoded data from an underlying <see cref="Stream"/>.
    /// </summary>
    public sealed class BinHex4DecodingStream : DecodingStream
    {
        private const byte StreamMarker = 0x3A; // ':'
        private const byte InvalidTableEntry = 0x40; // '@'
        private const string CharBank = "!\"#$%&'()*+,-012345689@ABCDEFGHIJKLMNPQRSTUVXYZ[`abcdefhijklmpqr";

        private static readonly byte[] SixBitTable;

        private int bitBuffer = 0;
        private int bitsLeft = 0;
        private bool eosEncountered = false;

        /// <summary>
        /// Initializes static members of the <see cref="BinHex4DecodingStream"/> class, particularly the 6-bit table used in decoding.
        /// </summary>
        static BinHex4DecodingStream()
        {
            SixBitTable = new byte[256];

            // Fill with invalid entries
            for (int i = 0; i < SixBitTable.Length; i++)
            {
                SixBitTable[i] = InvalidTableEntry;
            }

            // Write over valid entries with appropriate values
            for (byte i = 0; i < CharBank.Length; i++)
            {
                SixBitTable[CharBank[i]] = i;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinHex4DecodingStream"/> class over a specified <see cref="Stream"/>, which will close the underlying stream when disposed.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing BinHex 4.0-encoded data to be decoded.</param>
        public BinHex4DecodingStream(Stream stream)
            : this(stream, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinHex4DecodingStream"/> class over a specified <see cref="Stream"/>, which can be closed or left open upon disposal.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing BinHex 4.0-encoded data to be decoded.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public BinHex4DecodingStream(Stream stream, bool leaveOpen)
            : base(stream, leaveOpen)
        {
            // Read in first byte to ensure reader state is normalized (only need to look for end)
            int b;
            if ((b = stream.ReadByte()) == -1 || (byte)b != StreamMarker)
            {
                throw new InvalidDataException(Properties.Strings.BinHex4ExpectedMarkerAtBeginning);
            }
        }

        /// <inheritdoc/>
        protected override int ReadInternal(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;

            while (bytesRead < count)
            {
                byte currentByte;
                int b;
                if (!eosEncountered && (b = BaseStream.ReadByte()) != -1)
                {
                    currentByte = (byte)b;
                }
                else
                {
                    // We've already read everything!
                    if (eosEncountered)
                    {
                        return bytesRead;
                    }
                    else
                    {
                        // We haven't read everything, but we hit the end anyways...
                        throw new EndOfStreamException(Properties.Strings.BinHex4UnexpectedEndOfStream);
                    }
                }

                switch (currentByte)
                {
                    // Skip line breaks
                    case (byte)'\n':
                    case (byte)'\r':
                        continue;

                    // Proper end of stream, return what we have!
                    case StreamMarker:
                        eosEncountered = true;
                        return bytesRead;

                    // Need to decode!
                    default:
                        // Get 6 bits from table
                        int bits = SixBitTable[currentByte];
                        if (bits == InvalidTableEntry)
                        {
                            throw new InvalidDataException(string.Format(Properties.Strings.BinHex4UnexpectedCharacter, (char)currentByte));
                        }

                        // Load in the new bits
                        bitBuffer = (bitBuffer << 6) | bits;
                        bitsLeft += 6;

                        // Do we have enough for a byte?
                        if (bitsLeft >= 8)
                        {
                            bitsLeft -= 8;
                            buffer[offset + bytesRead++] = (byte)((bitBuffer >> bitsLeft) & 0xFF);
                            bitBuffer &= (1 << bitsLeft) - 1;
                        }

                        break;
                }
            }

            return bytesRead;
        }
    }
}
