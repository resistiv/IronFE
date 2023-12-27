using System.IO;

namespace IronFE.Encoding.Compression
{
    /// <summary>
    /// Decodes an RLE90-encoded stream of data.
    /// </summary>
    /// <remarks>
    /// Adapted from Just Solve the File Format Problem's <see href="http://fileformats.archiveteam.org/wiki/RLE90">RLE90</see> page.
    /// </remarks>
    public class Rle90Decoder : Decoder
    {
        private const byte RleMarker = 0x90;

        private readonly bool bufferLiteralMarker;
        private readonly long streamEnd;
        private readonly BinaryReader reader;

        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rle90Decoder"/> class over a specified <see cref="Stream"/> which will assume the rest of the stream is encoded and will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="bufferLiteralMarker">Whether or not to buffer a literal RLE marker as the previous byte when decoding.</param>
        public Rle90Decoder(Stream stream, bool bufferLiteralMarker)
            : base(stream)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rle90Decoder"/> class over a specified <see cref="Stream"/> of a given length which will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        /// <param name="bufferLiteralMarker">Whether or not to buffer a literal RLE marker as the previous byte when decoding.</param>
        public Rle90Decoder(Stream stream, long streamLength, bool bufferLiteralMarker)
            : base(stream, streamLength)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rle90Decoder"/> class over a specified <see cref="Stream"/> which will be left open by the instance.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        /// <param name="bufferLiteralMarker">Whether or not to buffer a literal RLE marker as the previous byte when decoding.</param>
        public Rle90Decoder(Stream stream, long streamLength, bool leaveOpen, bool bufferLiteralMarker)
            : base(stream, streamLength, leaveOpen)
        {
            this.bufferLiteralMarker = bufferLiteralMarker;
            streamEnd = BaseStream.Position + StreamLength;
            reader = new BinaryReader(BaseStream, System.Text.Encoding.Default, true);
        }

        /// <summary>
        /// Decodes the underlying RLE90-encoded <see cref="Stream"/> of this <see cref="Rle90Decoder"/> and writes the output to <paramref name="outStream"/>.
        /// </summary>
        /// <param name="outStream">A <see cref="Stream"/> to write decoded output to.</param>
        /// <exception cref="EndOfStreamException">Thrown when the end of stream is reached after reading the RLE marker.</exception>
        public override void Decode(ref Stream outStream)
        {
            byte lastByte = 0x00;

            // Read until end of stream
            while (reader.BaseStream.Position < streamEnd)
            {
                byte currentByte = reader.ReadByte();

                // Encoded
                if (currentByte == RleMarker)
                {
                    if (reader.BaseStream.Position == streamEnd)
                    {
                        throw new EndOfStreamException("Unexpected end of RLE90 stream.");
                    }

                    byte runLength = reader.ReadByte();

                    // Literal 0x90 edge case
                    if (runLength == 0)
                    {
                        outStream.WriteByte(currentByte);

                        if (bufferLiteralMarker)
                        {
                            lastByte = currentByte;
                        }
                    }

                    // Encoded run
                    else
                    {
                        // Decrement immediately since one copy of the last byte was already written (that's why it's the last byte)
                        while (--runLength > 0)
                        {
                            outStream.WriteByte(lastByte);
                        }
                    }
                }

                // Literal
                else
                {
                    outStream.WriteByte(currentByte);
                    lastByte = currentByte;
                }
            }
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
    }
}
