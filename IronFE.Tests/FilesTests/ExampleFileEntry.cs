using System.IO;
using IronFE.Files;

namespace IronFE.Tests.FilesTests
{
    /// <summary>
    /// An example file entry class for the purposes of testing the base abstract class.
    /// </summary>
    internal class ExampleFileEntry : FileEntryBase
    {
        /// <inheritdoc/>
        public ExampleFileEntry(string directoryName)
            : base(directoryName)
        {
        }

        /// <inheritdoc/>
        public ExampleFileEntry(string fileName, Stream sourceStream)
            : base(fileName, sourceStream)
        {
        }

        /// <inheritdoc/>
        public override void SaveToStream(Stream outputStream)
        {
            throw new System.NotImplementedException();
        }
    }
}
