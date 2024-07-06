using System.IO;

namespace IronFE.Files
{
    /// <summary>
    /// Represents a generic file format.
    /// </summary>
    public abstract class FileBase
    {
        // Private members
        private readonly Stream fileStream;
        private readonly string fileFullPath;
        private readonly string fileName;
        private FileEntryBase? rootEntry = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBase"/> class.
        /// </summary>
        /// <param name="filePath">A path to the file to open and associate with this <see cref="FileBase"/> object.</param>
        protected FileBase(string filePath)
        {
            fileStream = File.Open(filePath, FileMode.OpenOrCreate);

            FileInfo fileInfo = new(filePath);
            fileFullPath = fileInfo.FullName;
            fileName = fileInfo.Name;
        }

        /// <summary>
        /// Gets the <see cref="System.IO.Stream"/> associated with this <see cref="FileBase"/> object.
        /// </summary>
        public Stream Stream => fileStream;

        /// <summary>
        /// Gets the full path of the underlying file of this <see cref="FileBase"/> object.
        /// </summary>
        public string FullPath => fileFullPath;

        /// <summary>
        /// Gets the file name of the underlying file of this <see cref="FileBase"/> object.
        /// </summary>
        public string Name => fileName;

        /// <summary>
        /// Gets or sets the root <see cref="FileEntryBase"/> contained within this <see cref="FileBase"/> object.
        /// </summary>
        public FileEntryBase? Root
        {
            get { return rootEntry; }
            set { rootEntry = value; }
        }

        /// <summary>
        /// Gets the format name of this <see cref="FileBase"/> object.
        /// </summary>
        public abstract string FormatName { get; }
    }
}
