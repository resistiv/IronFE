using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Provides a mechanism for decoding an encoded stream of data.
    /// </summary>
    public abstract class Decoder : Coder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> which will assume the rest of the stream is encoded and will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        public Decoder(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> of a given length which will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        public Decoder(Stream stream, long streamLength)
            : base(stream, streamLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> which will be left open by the instance.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public Decoder(Stream stream, long streamLength, bool leaveOpen)
            : base(stream, streamLength, leaveOpen)
        {
        }

        /// <summary>
        /// Decodes the underlying <see cref="Stream"/> of this <see cref="Decoder"/> and writes the output to <paramref name="outStream"/>.
        /// </summary>
        /// <param name="outStream">A <see cref="Stream"/> to write decoded output to.</param>
        public abstract void Decode(Stream outStream);
    }
}
