using System.IO;
using IronFE.Files;

namespace IronFE.Tests.FilesTests
{
    /// <summary>
    /// An example file entry class for the purposes of testing the base abstract class.
    /// </summary>
    internal class ExampleFileEntry : FileEntryBase
    {
        private static readonly PathConfiguration EfePathConfiguration = new()
        {
            PathSeparator = FileEntryBaseTests.PathSeparator,
            RootPrefix = FileEntryBaseTests.RootPrefix,
            RootSuffix = FileEntryBaseTests.RootSuffix,
            UseSeparatorAfterTerminalDirectories = FileEntryBaseTests.UseSeparatorAfterTerminalDirectories,

        };

        /// <inheritdoc/>
        public ExampleFileEntry()
            : base()
        {
        }

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
        protected override PathConfiguration PathConfiguration => EfePathConfiguration;

        /// <inheritdoc/>
        public override void SaveToStream(Stream outputStream)
        {
            throw new System.NotImplementedException();
        }
    }
}
