using System;
using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Decodes RLE90-encoded data from an underlying <see cref="Stream"/>.
    /// </summary>
    public sealed class Rle90DecodingStream : DecodingStream
    {
        private const byte RleMarker = 0x90;

        private readonly bool bufferLiteralMarker;
        private byte[]? bufferedBytes = null;
        private int lastByte = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rle90DecodingStream"/> class over a specified <see cref="Stream"/>, which will close the underlying stream when disposed.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing RLE90-encoded data to be decoded.</param>
        /// <param name="bufferLiteralMarker">Whether or not to buffer a literal RLE marker as the previous byte when decoding (<c>true</c> for BinHex, <c>false</c> for ARC).</param>
        public Rle90DecodingStream(Stream stream, bool bufferLiteralMarker)
            : this(stream, bufferLiteralMarker, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rle90DecodingStream"/> class over a specified <see cref="Stream"/>, which can be closed or left open upon disposal.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing RLE90-encoded data to be decoded.</param>
        /// <param name="bufferLiteralMarker">Whether or not to buffer a literal RLE marker as the previous byte when decoding (<c>true</c> for BinHex, <c>false</c> for ARC).</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public Rle90DecodingStream(Stream stream, bool bufferLiteralMarker, bool leaveOpen)
            : base(stream, leaveOpen)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
        }

        /// <inheritdoc/>
        protected override int ReadInternal(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;

            // Check if there are previously buffered bytes from another read
            if (bufferedBytes is not null)
            {
                // We have enough from the buffer, no need to read
                if (bufferedBytes.Length >= count)
                {
                    Array.Copy(bufferedBytes, 0, buffer, offset, count);
                    bufferedBytes = bufferedBytes.Length == count ? null : bufferedBytes[count..];
                    return count;
                }

                // We can take a bit from the buffer, but will still need to read
                else // if (bufferedBytes.Length < count)
                {
                    Array.Copy(bufferedBytes, 0, buffer, offset, bufferedBytes.Length);
                    bytesRead += bufferedBytes.Length;
                    bufferedBytes = null;
                }
            }

            while (bytesRead < count)
            {
                byte currentByte;
                int b;
                if ((b = BaseStream.ReadByte()) != -1)
                {
                    currentByte = (byte)b;
                }
                else
                {
                    // Nothing left to read...
                    return bytesRead;
                }

                // Encoded run
                if (currentByte == RleMarker)
                {
                    byte runLength;
                    if ((b = BaseStream.ReadByte()) != -1)
                    {
                        runLength = (byte)b;
                    }
                    else
                    {
                        throw new InvalidDataException(Properties.Strings.Rle90EosExpectedRunLength);
                    }

                    // Literal 0x90 edge case
                    if (runLength == 0)
                    {
                        buffer[offset + (bytesRead++)] = currentByte;

                        if (bufferLiteralMarker)
                        {
                            lastByte = currentByte;
                        }
                    }

                    // Encoded run
                    else
                    {
                        // Have we actually buffered a byte to run yet?
                        if (lastByte == -1)
                        {
                            throw new InvalidDataException(Properties.Strings.Rle90RunBeforeLiteral);
                        }

                        // We have already output one byte (lastByte) in the run
                        runLength--;

                        // Read to output buffer while we have space
                        byte i;
                        for (i = 0; i < runLength && bytesRead < count; i++)
                        {
                            buffer[offset + bytesRead++] = (byte)lastByte;
                        }

                        runLength -= i;

                        // Excess bytes, read into internal buffer
                        if (runLength != 0)
                        {
                            bufferedBytes = new byte[runLength];
                            for (i = 0; i < runLength; i++)
                            {
                                bufferedBytes[i] = (byte)lastByte;
                            }
                        }
                    }
                }

                // Literal
                else
                {
                    buffer[offset + (bytesRead++)] = currentByte;
                    lastByte = currentByte;
                }
            }

            return bytesRead;
        }
    }
}
