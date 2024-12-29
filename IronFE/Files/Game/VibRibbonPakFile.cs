using System.IO;
using System.Text;

namespace IronFE.Files.Game
{
    /// <summary>
    /// Represents a Vib-Ribbon PAK file.
    /// </summary>
    public sealed class VibRibbonPakFile : FileBase
    {
        private readonly uint fileCount;
        private readonly uint[] entryOffsets;

        /// <summary>
        /// Initializes a new instance of the <see cref="VibRibbonPakFile"/> class.
        /// </summary>
        /// <param name="filePath">A path to the file to open and associate with this <see cref="VibRibbonPakFile"/> object.</param>
        public VibRibbonPakFile(string filePath)
            : base(filePath)
        {
            using BinaryReader binaryReader = new(Stream, System.Text.Encoding.ASCII, true);

            // Create root node
            Root = new VibRibbonPakEntry(Path.GetFileName(filePath));

            // Read file count
            fileCount = binaryReader.ReadUInt32();

            // Read table of contents
            entryOffsets = new uint[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                entryOffsets[i] = binaryReader.ReadUInt32();
            }

            // Read file entries
            for (int i = 0; i < fileCount; i++)
            {
                // Seek to entry
                binaryReader.BaseStream.Seek(entryOffsets[i], SeekOrigin.Begin);

                // Read file name
                char c;
                StringBuilder sb = new();
                while ((c = binaryReader.ReadChar()) != '\0')
                {
                    sb.Append(c);
                }

                // Skip past name padding
                string fileName = sb.ToString();
                binaryReader.BaseStream.Seek(3 - (fileName.Length % 4), SeekOrigin.Current);

                // Construct directory structure from path
                VibRibbonPakEntry file = CreateEntryFromPath(fileName);
                file.Size = binaryReader.ReadUInt32();
                file.Offset = entryOffsets[i];
                file.HeaderSize = (uint)(binaryReader.BaseStream.Position - file.Offset);
            }
        }

        /// <inheritdoc/>
        public override string FormatName => "Vib-Ribbon PAK";

        /// <summary>
        /// Gets the number of files in this <see cref="VibRibbonPakFile"/>.
        /// </summary>
        public uint FileCount => fileCount;

        /// <summary>
        /// Creates a file <see cref="VibRibbonPakEntry"/> and all of its proceeding directory nodes from a file path.
        /// </summary>
        /// <param name="filePath">A file path to use to create the chain of necessary <see cref="VibRibbonPakEntry"/> objects.</param>
        /// <returns>The resulting file <see cref="VibRibbonPakEntry"/> object.</returns>
        private VibRibbonPakEntry CreateEntryFromPath(string filePath)
        {
            VibRibbonPakEntry currentEntry = Root as VibRibbonPakEntry ?? throw new InvalidDataException();

            while (filePath.Length != 0)
            {
                int delimiterIndex = filePath.IndexOf('/');

                // Final element of path, file!
                if (delimiterIndex == -1)
                {
                    // Create file and add to final directory
                    VibRibbonPakEntry tempEntry = new(filePath, Stream);
                    currentEntry.AddChild(tempEntry);
                    currentEntry = tempEntry;
                    filePath = string.Empty;
                }

                // Directory
                else
                {
                    // Get left-most path element
                    string currentDir = filePath[..delimiterIndex];

                    // Does it not already exist?
                    if (currentEntry.GetChild(currentDir) is not VibRibbonPakEntry tempEntry)
                    {
                        tempEntry = new(currentDir);
                        currentEntry.AddChild(tempEntry);
                    }

                    // Update current entry and delete previous path element
                    currentEntry = tempEntry;
                    filePath = filePath[(delimiterIndex + 1)..];
                }
            }

            return currentEntry;
        }
    }
}
