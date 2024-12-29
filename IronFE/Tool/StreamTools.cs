using System.IO;

namespace IronFE.Tool
{
    /// <summary>
    /// Handles <see cref="Stream"/> objects.
    /// </summary>
    public static class StreamTools
    {
        private const int BufferSize = 16384;

        /// <summary>
        /// Copies a part of a <see cref="Stream"/> to another <see cref="Stream"/> given a size.
        /// </summary>
        /// <param name="inStream">The input <see cref="Stream"/> to read from.</param>
        /// <param name="outStream">The output <see cref="Stream"/> to write to.</param>
        /// <param name="size">The size, in bytes, to copy.</param>
        public static void CopyBytes(Stream inStream, Stream outStream, long size)
        {
            byte[] buffer = new byte[BufferSize];
            int bytesRead;
            int bytesToRead = size % BufferSize == 0
                ? BufferSize
                : (int)(size % BufferSize);

            // Read bytes to buffer
            while (size > 0 && (bytesRead = inStream.Read(buffer, 0, bytesToRead)) > 0)
            {
                // Write to output
                outStream.Write(buffer, 0, bytesRead);
                size -= bytesRead;
                bytesToRead = size % BufferSize == 0
                    ? BufferSize
                    : (int)(size % BufferSize);
            }
        }
    }
}
