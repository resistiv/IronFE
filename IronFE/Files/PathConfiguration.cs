namespace IronFE.Files
{
    /// <summary>
    /// Stores a configuration for reconstructing a file path.
    /// </summary>
    public class PathConfiguration
    {
        /// <summary>
        /// Gets the path separator of this <see cref="PathConfiguration"/>.
        /// </summary>
        public string PathSeparator { get; init; } = string.Empty;

        /// <summary>
        /// Gets a string to prefix a root entry name with.
        /// </summary>
        public string RootPrefix { get; init; } = string.Empty;

        /// <summary>
        /// Gets a string to append to the root <see cref="FileEntryBase"/> name.
        /// </summary>
        public string RootSuffix { get; init; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether to append a <see cref="PathSeparator"/> to a directory if it is the last item in the full path..
        /// </summary>
        public bool UseSeparatorAfterTerminalDirectories { get; init; } = false;

        /// <summary>
        /// Gets a value indicating whether to append a <see cref="PathSeparator"/> to the root <see cref="FileEntryBase"/>.
        /// </summary>
        public bool UseSeparatorAfterRoot { get; init; } = false;
    }
}
