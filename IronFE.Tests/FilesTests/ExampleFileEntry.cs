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
        protected override string PathSeparator => FileEntryBaseTests.PathSeparator;

        /// <inheritdoc/>
        protected override string RootPrefix => FileEntryBaseTests.RootPrefix;

        /// <inheritdoc/>
        protected override string RootSuffix => FileEntryBaseTests.RootSuffix;

        /// <inheritdoc/>
        protected override bool UseSeparatorAfterTerminalDirectories => FileEntryBaseTests.UseSeparatorAfterTerminalDirectories;

        /// <inheritdoc/>
        protected override bool UseSeparatorAfterRoot => false;
    }
}
