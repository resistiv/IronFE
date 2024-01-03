using System.IO;

namespace IronFE.Encoding.Transport
{
    /// <summary>
    /// Decodes a BinHex 4.0-encoded stream of data.
    /// </summary>
    public class BinHex4Decoder : Decoder
    {
        private const byte StreamMarker = 0x3A; // ':'
        private const byte InvalidTableEntry = 0x40; // '@'
        private const string CharBank = "!\"#$%&'()*+,-012345689@ABCDEFGHIJKLMNPQRSTUVXYZ[`abcdefhijklmpqr";

        private static readonly byte[] SixBitTable;

        private readonly long streamEnd;
        private readonly BinaryReader reader;

        private bool disposed = false;

        /// <summary>
        /// Initializes static members of the <see cref="BinHex4Decoder"/> class.
        /// </summary>
        static BinHex4Decoder()
        {
            SixBitTable = GenerateSixBitTable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinHex4Decoder"/> class over a specified <see cref="Stream"/> which will assume the rest of the stream is encoded and will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        public BinHex4Decoder(Stream stream)
            : base(stream)
        {
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinHex4Decoder"/> class over a specified <see cref="Stream"/> of a given length which will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        public BinHex4Decoder(Stream stream, long streamLength)
            : base(stream, streamLength)
        {
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinHex4Decoder"/> class over a specified <see cref="Stream"/> which will be left open by the instance.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public BinHex4Decoder(Stream stream, long streamLength, bool leaveOpen)
            : base(stream, streamLength, leaveOpen)
        {
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Decodes the underlying BinHex-encoded <see cref="Stream"/> of this <see cref="BinHex4Decoder"/> and writes the output to <paramref name="outStream"/>.
        /// </summary>
        /// <param name="outStream">A <see cref="Stream"/> to write decoded output to.</param>
        public override void Decode(Stream outStream)
        {
            if (reader.ReadByte() != StreamMarker)
            {
                throw new InvalidDataException("Expected BinHex 4.0 marker at the beginning of stream.");
            }

            int bitBuffer = 0;
            int bitsLeft = 0;
            byte currentByte;
            while (reader.BaseStream.Position < streamEnd)
            {
                currentByte = reader.ReadByte();

                // Line breaks
                if ((char)currentByte == '\n' || (char)currentByte == '\r')
                {
                    continue;
                }

                // EOS
                if (currentByte == StreamMarker)
                {
                    return;
                }

                // Get lower 6 bits from table
                int bits = SixBitTable[currentByte];
                if (bits == InvalidTableEntry)
                {
                    throw new InvalidDataException($"Unexpected character '{(char)currentByte}' in BinHex 4.0 stream.");
                }

                // Load in the new bits
                bitBuffer = (bitBuffer << 6) | bits;
                bitsLeft += 6;

                // Do we have enough for a byte?
                if (bitsLeft >= 8)
                {
                    bitsLeft -= 8;
                    outStream.WriteByte((byte)((bitBuffer >> bitsLeft) & 0xFF));
                    bitBuffer &= (1 << bitsLeft) - 1;
                }
            }

            throw new InvalidDataException("Expected BinHex 4.0 marker at the end of stream.");
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    reader.Dispose();
                }
            }

            disposed = true;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Generates a table of six-bit values used for decoding BinHex-encoded characters.
        /// </summary>
        /// <returns>An array of 256 <see cref="byte"/>s containing translation values for encoded characters.</returns>
        private static byte[] GenerateSixBitTable()
        {
            byte[] table = new byte[256];

            // Fill with invalid entries
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = InvalidTableEntry;
            }

            // Write over valid entries with appropriate values
            for (byte i = 0; i < CharBank.Length; i++)
            {
                table[CharBank[i]] = i;
            }

            return table;
        }
    }
}
