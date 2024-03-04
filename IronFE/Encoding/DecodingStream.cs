using System;
using System.IO;

namespace IronFE.Encoding
{
    /// <summary>
    /// Provides a mechanism to decode data from an underlying <see cref="Stream"/>.
    /// </summary>
    public abstract class DecodingStream : Stream
    {
        /// <summary>
        /// The default size of the internal buffer used for residual decoding bytes.
        /// </summary>
        protected const int DefaultBufferSize = 8192;
        protected byte[] buffer;
        protected Stream stream;

        private readonly bool leaveOpen;

        protected DecodingStream(Stream stream)
            : this(stream, false)
        {
        }

        protected DecodingStream(Stream stream, bool leaveOpen)
        {
            ArgumentNullException.ThrowIfNull(stream);

            if (!stream.CanRead)
            {
                throw new ArgumentException(Properties.Strings.DecodingStreamNotSupportedUnreadableStream, nameof(stream));
            }

            this.stream = stream;
            this.leaveOpen = leaveOpen;
            this.buffer = new byte[DefaultBufferSize];
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

        /// <summary>
        /// Reads a sequence of bytes through an internal decoding operation on the underlying <see cref="Stream"/> object.
        /// </summary>
        /// <param name="buffer">An array of <see cref="byte"/>s to output data to.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the underlying <see cref="Stream"/>.</param>
        /// <returns>The total number of bytes read into <paramref name="buffer"/>.</returns>
        protected abstract int ReadInternal(byte[] buffer, int offset, int count);


        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);


        /// <inheritdoc/>
        public override void SetLength(long value)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);


        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
    }
}
