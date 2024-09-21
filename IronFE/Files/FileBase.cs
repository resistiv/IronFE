using System.IO;

namespace IronFE.Files
{
    /// <summary>
    /// Represents a generic file format.
    /// </summary>
    public abstract class FileBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileBase"/> class.
        /// </summary>
        /// <param name="filePath">A path to the file to open and associate with this <see cref="FileBase"/> object.</param>
        protected FileBase(string filePath)
        {
            Stream = File.Open(filePath, FileMode.OpenOrCreate);
            FileInfo fileInfo = new(filePath);
            FullPath = fileInfo.FullName;
            Name = fileInfo.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBase"/> class.
        /// </summary>
        /// <param name="inputStream">A <see cref="System.IO.Stream"/> containing the data of the file.</param>
        /// <param name="filePath">The absolute path of the file.</param>
        /// <param name="fileName">The name of the file.</param>
        protected FileBase(Stream inputStream, string filePath, string fileName)
        {
            Stream = inputStream;
            FullPath = filePath;
            Name = fileName;
        }

        /// <summary>
        /// Gets the <see cref="System.IO.Stream"/> associated with this <see cref="FileBase"/> object.
        /// </summary>
        public Stream Stream { get; }

        /// <summary>
        /// Gets the full path of the underlying file of this <see cref="FileBase"/> object.
        /// </summary>
        public string FullPath { get; }

        /// <summary>
        /// Gets the file name of the underlying file of this <see cref="FileBase"/> object.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the root <see cref="FileEntryBase"/> contained within this <see cref="FileBase"/> object.
        /// </summary>
        public FileEntryBase? Root { get; protected set; }

        /// <summary>
        /// Gets the format name of this <see cref="FileBase"/> object.
        /// </summary>
        public abstract string FormatName { get; }
    }
}
