using System;
using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Provides a mechanism for decoding an encoded stream of data.
    /// </summary>
    public abstract class Decoder : IDisposable
    {
        private readonly bool leaveOpen;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> which will assume the rest of the stream is encoded and will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        public Decoder(Stream stream)
            : this(stream, stream.Length - stream.Position)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> of a given length which will not close the stream when disposed of.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        public Decoder(Stream stream, long streamLength)
            : this(stream, streamLength, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Decoder"/> class over a specified <see cref="Stream"/> which will be left open by the instance.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="streamLength">The length of the encoded data section in <paramref name="stream"/>.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        public Decoder(Stream stream, long streamLength, bool leaveOpen)
        {
            BaseStream = stream ?? throw new ArgumentNullException(nameof(stream), "Cannot pass a null Stream to a Decoder.");
            StreamLength = streamLength;
            this.leaveOpen = leaveOpen;
        }

        /// <summary>
        /// Gets the underlying <see cref="Stream"/> of this <see cref="Decoder"/>.
        /// </summary>
        public Stream BaseStream { get; }

        /// <summary>
        /// Gets the length of the encoded data section of the underlying <see cref="Stream"/>.
        /// </summary>
        public long StreamLength { get; }

        /// <summary>
        /// Decodes the underlying <see cref="Stream"/> of this <see cref="Decoder"/> and writes the output to <paramref name="outStream"/>.
        /// </summary>
        /// <param name="outStream">A <see cref="Stream"/> to write decoded output to.</param>
        public abstract void Decode(ref Stream outStream);

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        /// <param name="disposing">Whether or not managed resources are to be disposed of.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && !leaveOpen)
                {
                    BaseStream.Dispose();
                }

                disposed = true;
            }
        }
    }
}
