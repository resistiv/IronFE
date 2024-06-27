using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IronFE.Files
{
    /// <summary>
    /// Represents a generic entry within a file format.
    /// </summary>
    public abstract class FileEntryBase
    {
        // Private members
        private readonly LinkedList<FileEntryBase> childEntries = [];
        private readonly bool isDir;
        private readonly bool isRoot;
        private readonly Stream? sourceStream;
        private string entryName;
        private FileEntryBase? parentEntry = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntryBase"/> class as a root entry.
        /// </summary>
        /// <remarks>
        /// Root entries behave such that they do not require a name, they cannot be added as a child to another node (<see cref="Parent"/> must always be <see langword="null"/>), and they aren't required to be included in <see cref="FullPath"/>.
        /// </remarks>
        public FileEntryBase()
        {
            entryName = string.Empty;
            sourceStream = null;
            isDir = true;
            isRoot = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntryBase"/> class as a directory.
        /// </summary>
        /// <param name="directoryName">The name of this virtual directory.</param>
        public FileEntryBase(string directoryName)
        {
            entryName = directoryName;
            sourceStream = null;
            isDir = true;
            isRoot = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntryBase"/> class as a file.
        /// </summary>
        /// <param name="fileName">The name of this virtual file.</param>
        /// <param name="sourceStream">The corresponding <see cref="System.IO.Stream"/> where the virtual file's data is located.</param>
        public FileEntryBase(string fileName, Stream sourceStream)
        {
            entryName = fileName;
            this.sourceStream = sourceStream;
            isDir = false;
            isRoot = false;
        }

        /// <summary>
        /// Gets the path separator used by this <see cref="FileEntryBase"/>.
        /// </summary>
        public abstract string PathSeparator { get; }

        /// <summary>
        /// Gets a string to prefix the root <see cref="FileEntryBase"/> name with.
        /// </summary>
        public abstract string RootPrefix { get; }

        /// <summary>
        /// Gets a string to append to the root <see cref="FileEntryBase"/> name.
        /// </summary>
        public abstract string RootSuffix { get; }

        /// <summary>
        /// Gets a value indicating whether to append a <see cref="PathSeparator"/> to a directory if it is the last item in the full path of this <see cref="FileEntryBase"/>.
        /// </summary>
        public abstract bool UseSeparatorAfterTerminalDirectories { get; }

        /// <summary>
        /// Gets or sets the name of this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when setting with a name that would conflict with a sibling <see cref="FileEntryBase"/>'s name.</exception>
        /// <exception cref="ArgumentNullException">Thrown when setting on a root entry with a value that is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when setting on an entry with a value that is <see langword="null"/> or empty.</exception>
        public string Name
        {
            get
            {
                return entryName;
            }

            set
            {
                if (isRoot)
                {
                    // For root, just needs to not be null
                    ArgumentNullException.ThrowIfNull(value);
                }
                else
                {
                    // For file or directory, must be not null and have a value
                    ArgumentException.ThrowIfNullOrEmpty(value);
                }

                // Ensure the rename does not result in siblings with the same names
                if (parentEntry is not null)
                {
                    CheckSiblingNameConflict(value, parentEntry.childEntries);
                }

                entryName = value;
            }
        }

        /// <summary>
        /// Gets the virtual full path of this <see cref="FileEntryBase"/>.
        /// </summary>
        public string FullPath
        {
            get
            {
                return GetFullPath(this, true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="FileEntryBase"/> is designated as a directory.
        /// </summary>
        public bool IsDirectory => isDir;

        /// <summary>
        /// Gets a value indicating whether this <see cref="FileEntryBase"/> is designated as a root entry.
        /// </summary>
        public bool IsRoot => isRoot;

        /// <summary>
        /// Gets the underlying data <see cref="System.IO.Stream"/> of this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when accessed on a <see cref="FileEntryBase"/> that is a directory.</exception>
        public Stream Stream => !isDir ? sourceStream : throw new NotSupportedException(Properties.Strings.FileEntryBaseFileOperationNotSupported);

        /// <summary>
        /// Gets the parent <see cref="FileEntryBase"/> of this <see cref="FileEntryBase"/>, if there is one.
        /// </summary>
        public FileEntryBase? Parent => parentEntry;

        /// <summary>
        /// Gets the children of this <see cref="FileEntryBase"/>.
        /// </summary>
        public FileEntryBase[] Children => [.. childEntries];

        /// <summary>
        /// Adds a <see cref="FileEntryBase"/> to this <see cref="FileEntryBase"/>'s children, while setting this <see cref="FileEntryBase"/> as its parent.
        /// </summary>
        /// <param name="entry">A <see cref="FileEntryBase"/> to add to the children of this <see cref="FileEntryBase"/>.</param>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not a directory.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="entry"/> is a root entry, or if <paramref name="entry"/> and a direct ancestor (including this <see cref="FileEntryBase"/>) are the same instance.</exception>
        public void AddChild(FileEntryBase entry)
        {
            // Root check
            if (entry.IsRoot)
            {
                throw new InvalidOperationException(Properties.Strings.FileEntryBaseCannotAddRootAsChild);
            }

            CheckSupportsDirectoryOperation();

            // Ensure no direct ancestor of this entry is being added,
            // as parent re-assignment will result in a loop in the virtual
            // file system.
            FileEntryBase? ancestor = this;
            while (ancestor is not null)
            {
                if (ReferenceEquals(ancestor, entry))
                {
                    throw new InvalidOperationException(Properties.Strings.FileEntryBaseAddAncestorAsChild);
                }

                ancestor = ancestor.Parent;
            }

            CheckSiblingNameConflict(entry.Name, childEntries);

            // Deattach from parent, add to this entry
            entry.Parent?.childEntries.Remove(entry);
            entry.parentEntry = this;
            childEntries.AddLast(entry);
        }

        /// <summary>
        /// Gets a child <see cref="FileEntryBase"/> with the name <paramref name="childName"/> from this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <param name="childName">The name of the child <see cref="FileEntryBase"/> to get.</param>
        /// <returns>A child <see cref="FileEntryBase"/>, or <see langword="null"/> if a child with the name <paramref name="childName"/> was not found.</returns>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not a directory.</exception>
        public FileEntryBase? GetChild(string childName)
        {
            CheckSupportsDirectoryOperation();

            return childEntries.FirstOrDefault(f => f.Name == childName);
        }

        /// <summary>
        /// Removes a child <see cref="FileEntryBase"/> via its name from this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <param name="childName">The name of the child <see cref="FileEntryBase"/> to remove.</param>
        /// <returns><see langword="true"/> if the child was successfully removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not a directory.</exception>
        public bool RemoveChild(string childName)
        {
            CheckSupportsDirectoryOperation();

            // First attempt to fetch the child by name, then remove if present
            FileEntryBase? child = GetChild(childName);
            if (child is null)
            {
                return false;
            }
            else
            {
                return RemoveChild(child);
            }
        }

        /// <summary>
        /// Removes a child <see cref="FileEntryBase"/> from this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <param name="child">The child <see cref="FileEntryBase"/> to remove.</param>
        /// <returns><see langword="true"/> if <paramref name="child"/> was successfully removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not a directory.</exception>
        public bool RemoveChild(FileEntryBase child)
        {
            CheckSupportsDirectoryOperation();

            bool result = childEntries.Remove(child);
            if (result)
            {
                // Only if the remove was successful do we de-parent this entry
                child.parentEntry = null;
            }

            return result;
        }

        /// <summary>
        /// Recursively constructs the full path of a <see cref="FileEntryBase"/>.
        /// </summary>
        /// <remarks>
        /// Called from <see cref="FullPath"/> in order to identify what element is last in the path (see <paramref name="isOriginEntry"/>).
        /// </remarks>
        /// <param name="fileEntry">The <see cref="FileEntryBase"/> to get the full path of.</param>
        /// <param name="isOriginEntry">Whether <paramref name="fileEntry"/> is the entry that the <see cref="FullPath"/> call originated from.</param>
        /// <returns>The full path of <paramref name="fileEntry"/>.</returns>
        private static string GetFullPath(FileEntryBase fileEntry, bool isOriginEntry)
        {
            string path = string.Empty;

            // Root rules (end of the line, no need for any other calls)
            if (fileEntry.IsRoot)
            {
                path += fileEntry.RootPrefix;
                path += fileEntry.Name;
                path += fileEntry.RootSuffix;

                // Return without recursing
                return path;
            }

            // Next, directory rules
            else if (fileEntry.IsDirectory)
            {
                path += fileEntry.Name;

                // For most cases, directories will take the form Name + PathSeparator
                // However, if a directory entry is the origin and doesn't include a
                // separator, then this condition will be skipped.
                if (!isOriginEntry || fileEntry.UseSeparatorAfterTerminalDirectories)
                {
                    path += fileEntry.PathSeparator;
                }
            }

            // Otherwise, just a file
            else
            {
                path += fileEntry.Name;
            }

            // Finally: if there are parent entries to traverse, work upwards!
            if (fileEntry.Parent is not null)
            {
                return GetFullPath(fileEntry.Parent, false) + path;
            }
            else
            {
                return path;
            }
        }

/// <summary>
        /// Checks <paramref name="name"/> against sibling <see cref="FileEntryBase"/> names and throws an exception if there is a conflict.
        /// </summary>
        /// <param name="name">A possible entry name to check for conflicts.</param>
        /// <param name="siblings">A <see cref="List{T}"/> of sibling <see cref="FileEntryBase"/> objects.</param>
        /// <exception cref="InvalidOperationException">Thrown if there exists a sibling <see cref="FileEntryBase"/> that is already named <paramref name="name"/>.</exception>
        private static void CheckSiblingNameConflict(string name, LinkedList<FileEntryBase> siblings)
        {
            if (siblings.Any(c => c.Name.Equals(name)))
            {
                throw new InvalidOperationException(Properties.Strings.FileEntryBaseSiblingNameConflict);
            }
        }

        /// <summary>
        /// Checks if the current <see cref="FileEntryBase"/> supports directory operations (add/get/remove children, etc.).
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not designated as a directory.</exception>
        private void CheckSupportsDirectoryOperation()
        {
            if (!isDir)
            {
                throw new NotSupportedException(Properties.Strings.FileEntryBaseDirectoryOperationNotSupported);
            }
        }
    }
}
