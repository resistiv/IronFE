using System;
using System.IO;

namespace IronFE.Encoding
{
    public abstract class DecodingStream : Stream
    {
        protected const int DefaultBufferSize = 8192;

        protected readonly bool leaveOpen;

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

            BaseStream = stream;
            this.leaveOpen = leaveOpen;
        }

        public Stream BaseStream { get; }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        public override long Position
        {
            get => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
            set => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
        }

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        public override void SetLength(long value)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException(Properties.Strings.DecodingStreamNotSupported);
    }
}
