using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Provides a mechanism for decoding an encoded stream of data.
    /// </summary>
    public abstract class Encoder : Coder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Encoder"/> class over a specified <see cref="Stream"/> which will assume the rest of the stream is to be encoded and will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be encoded.</param>
        public Encoder(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Encoder"/> class over a specified <see cref="Stream"/> of a given length which will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be encoded.</param>
        /// <param name="streamLength">The length of the data section to be encoded in <paramref name="stream"/>.</param>
        public Encoder(Stream stream, long streamLength)
            : base(stream, streamLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Encoder"/> class over a specified <see cref="Stream"/> which will be left open by the instance.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be encoded.</param>
        /// <param name="streamLength">The length of the data section to be encoded in <paramref name="stream"/>.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public Encoder(Stream stream, long streamLength, bool leaveOpen)
            : base(stream, streamLength, leaveOpen)
        {
        }

        /// <summary>
        /// Encodes the underlying <see cref="Stream"/> of this <see cref="Encoder"/> and writes the output to <paramref name="outStream"/>.
        /// </summary>
        /// <param name="outStream">A <see cref="Stream"/> to write encoded output to.</param>
        public abstract void Encode(ref Stream outStream);
    }
}
