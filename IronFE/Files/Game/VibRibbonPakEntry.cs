using System;
using System.IO;
using IronFE.Tool;

namespace IronFE.Files.Game
{
    /// <summary>
    /// Represents a Vib-Ribbon PAK entry.
    /// </summary>
    public sealed class VibRibbonPakEntry : FileEntryBase
    {
        /// <inheritdoc/>
        public VibRibbonPakEntry(string directoryName)
            : base(directoryName)
        {
        }

        /// <inheritdoc/>
        public VibRibbonPakEntry(string fileName, Stream sourceStream)
            : base(fileName, sourceStream)
        {
        }

        /// <summary>
        /// Gets the offset of this <see cref="VibRibbonPakEntry"/>.
        /// </summary>
        public uint Offset { get; internal set; }

        /// <summary>
        /// Gets the size of this <see cref="VibRibbonPakEntry"/>.
        /// </summary>
        public uint Size { get; internal set; }

        /// <summary>
        /// Gets or sets the size of this <see cref="VibRibbonPakEntry"/>'s entry header.
        /// </summary>
        internal uint HeaderSize { get; set; }

        /// <inheritdoc/>
        public override void SaveToStream(Stream outputStream)
        {
            if (IsDirectory)
            {
                throw new InvalidOperationException(Properties.Strings.FileEntryBaseFileOperationNotSupported);
            }

            // Seek to source data offset and extract
            Stream.Seek(Offset + HeaderSize, SeekOrigin.Begin);
            StreamTools.CopyBytes(Stream, outputStream, Size);
        }
    }
}
