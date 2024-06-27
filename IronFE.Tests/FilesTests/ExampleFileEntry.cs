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
        public override string PathSeparator => FileEntryBaseTests.PathSeparator;

        /// <inheritdoc/>
        public override string RootPrefix => FileEntryBaseTests.RootPrefix;

        /// <inheritdoc/>
        public override string RootSuffix => FileEntryBaseTests.RootSuffix;

        /// <inheritdoc/>
        public override bool UseSeparatorAfterTerminalDirectories => FileEntryBaseTests.UseSeparatorAfterTerminalDirectories;
    }
}
