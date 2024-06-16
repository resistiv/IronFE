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
        private readonly bool isDir = false;
        private readonly Stream? sourceStream;
        private string entryName;
        private FileEntryBase? parentEntry = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntryBase"/> class as a directory.
        /// </summary>
        /// <param name="directoryName">The name of this virtual directory.</param>
        public FileEntryBase(string directoryName)
        {
            entryName = directoryName;
            sourceStream = null;
            isDir = true;
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
        }

        /// <summary>
        /// Gets or sets the name of this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when setting with a name that would conflict with a sibling <see cref="FileEntryBase"/>'s name.</exception>
        /// <exception cref="ArgumentNullException">Thrown when setting with a value that is <see langword="null"/>.</exception>
        public string Name
        {
            get
            {
                return entryName;
            }

            set
            {
                // Need to have a name!
                ArgumentNullException.ThrowIfNull(value);

                // Ensure the rename does not result in siblings with the same names
                if (parentEntry is not null)
                {
                    CheckSiblingNameConflict(value, parentEntry.childEntries);
                }

                entryName = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="FileEntryBase"/> is designated as a directory.
        /// </summary>
        public bool IsDirectory => isDir;

        /// <summary>
        /// Gets the underlying data <see cref="System.IO.Stream"/> of this <see cref="FileEntryBase"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when accessed on a <see cref="FileEntryBase"/> that is a directory.</exception>
        public Stream Stream => !isDir ? sourceStream : throw new NotSupportedException(Properties.Strings.FileEntryBaseFileOperationNotSupported);

        /// <summary>
        /// Gets or sets the parent <see cref="FileEntryBase"/> of this <see cref="FileEntryBase"/>.
        /// </summary>
        public FileEntryBase? Parent
        {
            get { return parentEntry; }
            set { parentEntry = value; }
        }

        /// <summary>
        /// Gets the children of this <see cref="FileEntryBase"/>.
        /// </summary>
        public FileEntryBase[] Children => [.. childEntries];

        /// <summary>
        /// Adds a <see cref="FileEntryBase"/> to this <see cref="FileEntryBase"/>'s children, while setting this <see cref="FileEntryBase"/> as its parent.
        /// </summary>
        /// <param name="entry">A <see cref="FileEntryBase"/> to add to the children of this <see cref="FileEntryBase"/>.</param>
        /// <exception cref="NotSupportedException">Thrown if this <see cref="FileEntryBase"/> is not a directory.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="entry"/> and a direct ancestor (including this <see cref="FileEntryBase"/>) are the same instance.</exception>
        public void AddChild(FileEntryBase entry)
        {
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

            childEntries.AddLast(entry);
            entry.Parent = this;
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
                return childEntries.Remove(child);
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

            return childEntries.Remove(child);
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
