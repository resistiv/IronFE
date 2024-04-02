using System;
using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Provides a mechanism to decode data from an underlying <see cref="Stream"/>.
    /// </summary>
    public abstract class DecodingStream : Stream
    {
        private readonly bool leaveOpen;
        private readonly Stream stream;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecodingStream"/> class over a specified <see cref="Stream"/>, which will close the underlying stream when disposed.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        protected DecodingStream(Stream stream)
            : this(stream, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecodingStream"/> class over a specified <see cref="Stream"/>, which can be closed or left open upon disposal.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing data to be decoded.</param>
        /// <param name="leaveOpen">Whether or not to leave <paramref name="stream"/> open when this instance is disposed.</param>
        protected DecodingStream(Stream stream, bool leaveOpen)
        {
            ArgumentNullException.ThrowIfNull(stream);

            if (!stream.CanRead)
            {
                throw new ArgumentException(Properties.Strings.DecodingStreamNotSupportedUnreadableStream, nameof(stream));
            }

            this.stream = stream;
            this.leaveOpen = leaveOpen;
        }

        /// <summary>
        /// Gets the underlying <see cref="Stream"/> object of this <see cref="DecodingStream"/>.
        /// </summary>
        public Stream BaseStream => stream;

        /// <inheritdoc/>
        public override bool CanRead => true;

        /// <inheritdoc/>
        public override bool CanSeek => false;

        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override long Length => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        /// <inheritdoc/>
        public override long Position
        {
            get => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
            set => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
        }

        /// <inheritdoc/>
        public override void Flush()
        {
            BaseStream.Flush();

            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
        {
            ObjectDisposedException.ThrowIf(stream is null, this);
            ValidateBufferArguments(buffer, offset, count);
            return ReadInternal(buffer, offset, count);
        }

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        /// <inheritdoc/>
        public override void SetLength(long value)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && !leaveOpen)
                {
                    stream.Close();
                }

                disposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Reads a sequence of bytes through an internal decoding operation on the underlying <see cref="Stream"/> object.
        /// </summary>
        /// <param name="buffer">An array of <see cref="byte"/>s to output data to.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the underlying <see cref="Stream"/>.</param>
        /// <returns>The total number of bytes read into <paramref name="buffer"/>.</returns>
        protected abstract int ReadInternal(byte[] buffer, int offset, int count);
    }
}
