﻿using System;
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
            : this(stream, false, bufferLiteralMarker)
        {
        }

        public Rle90DecodingStream(Stream stream, bool bufferLiteralMarker, bool leaveOpen)
            : base(stream, leaveOpen)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, leaveOpen);
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
                        // We have already output one byte (lastByte) in the run
                        runLength--;

                        // Read to output buffer while we have space
                        byte i;
                        for (i = 0; i < runLength && bytesRead < count; i++)
                        {
                            buffer[offset + (bytesRead++)] = lastByte;
                        }
                        runLength -= i;

                        // Excess bytes, read into internal buffer
                        if (runLength != 0)
                        {
                            bufferedBytes = new byte[runLength];
                            for (i = 0; i < runLength; i++)
                            {
                                bufferedBytes[i] = lastByte;
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