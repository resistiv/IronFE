using System;
using System.Collections.Generic;
using System.IO;

namespace IronFE.Encoding.Compression
{
    public sealed class Rle90DecodingStream : DecodingStream
    {
        private const byte RleMarker = 0x90;

        private readonly bool bufferLiteralMarker;
        private readonly BinaryReader reader;

        private byte[]? bufferedBytes = null;

        public Rle90DecodingStream(Stream stream, bool bufferLiteralMarker)
            : base(stream)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        public Rle90DecodingStream(Stream stream, bool leaveOpen, bool bufferLiteralMarker)
            : base(stream, leaveOpen)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

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

            byte lastByte = 0x00;
            while (bytesRead < count)
            {
                byte currentByte;
                try
                {
                    currentByte = reader.ReadByte();
                }
                catch (EndOfStreamException)
                {
                    // Nothing left to read, return what we have
                    return bytesRead;
                }

                // Encoded run
                if (currentByte == RleMarker)
                {
                    byte runLength;
                    try
                    {
                        runLength = reader.ReadByte();
                    }
                    catch (EndOfStreamException)
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
                        while (bytesRead < count && --runLength > 0)
                        {
                            buffer[offset + (bytesRead++)] = lastByte;
                        }

                        // Excess bytes, read into internal buffer
                        if (runLength != 0)
                        {
                            bufferedBytes = new byte[runLength];
                            while (runLength-- > 0)
                            {
                                // IMPLEMENT ME
                            }
                        }
                    }
                }
            }
        }
    }
}
