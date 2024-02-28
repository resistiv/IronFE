using System;
using System.IO;

namespace IronFE.Encoding
{
    public abstract class DecodingStream : Stream
    {
        protected const int DefaultBufferSize = 8192;

        protected readonly Stream stream;
        protected readonly bool leaveOpen;

        protected DecodingStream(Stream stream)
            : this(stream, false)
        {
        }

        protected DecodingStream(Stream stream, bool leaveOpen)
        {
            if (!stream.CanRead)
            {
                throw new ArgumentException("", nameof(stream));
            }
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
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
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }
    }
}
