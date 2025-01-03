﻿using System;
using System.IO;
using IronFE.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.FilesTests
{
    /// <summary>
    /// Tests functionality of the <see cref="FileEntryBase"/> class (via <see cref="ExampleFileEntry"/>).
    /// </summary>
    [TestClass]
    public class FileEntryBaseTests
    {
        // Constants
        private const string DirAName = "DirA";
        private const string DirBName = "DirB";
        private const string DirCName = "DirC";
        private const string FileAName = "a.file";
        private const string FileBName = "b.file";
        private const string FileCName = "c.file";

        // Private members
        private ExampleFileEntry directoryA;
        private ExampleFileEntry directoryB;
        private ExampleFileEntry directoryC;
        private ExampleFileEntry fileA;
        private ExampleFileEntry fileB;
        private ExampleFileEntry fileC;

        /// <summary>
        /// Initializes a nested virtual file system of <see cref="ExampleFileEntry"/> objects for usage in tests.
        /// </summary>
        [TestInitialize]
        public void CreateVirtualFileSystem()
        {
            // Create entries
            directoryA = new ExampleFileEntry(DirAName);
            directoryB = new ExampleFileEntry(DirBName);
            directoryC = new ExampleFileEntry(DirCName);
            fileA = new ExampleFileEntry(FileAName, new MemoryStream());
            fileB = new ExampleFileEntry(FileBName, new MemoryStream());
            fileC = new ExampleFileEntry(FileCName, new MemoryStream());

            // Nest them!
            directoryA.AddChild(directoryB);
            directoryB.AddChild(directoryC);
            directoryC.AddChild(fileA);
            directoryC.AddChild(fileB);
            directoryC.AddChild(fileC);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.Name"/> property.
        /// </summary>
        [TestMethod]
        public void NameGet()
        {
            // Directories
            Assert.AreEqual(DirAName, directoryA.Name);
            Assert.AreEqual(DirBName, directoryB.Name);
            Assert.AreEqual(DirCName, directoryC.Name);

            // Files
            Assert.AreEqual(FileAName, fileA.Name);
            Assert.AreEqual(FileBName, fileB.Name);
            Assert.AreEqual(FileCName, fileC.Name);
        }

        /// <summary>
        /// Tests the functionality of setting the <see cref="FileEntryBase.Name"/> property to a valid name.
        /// </summary>
        [TestMethod]
        public void NameSetValid()
        {
            // Directories
            directoryA.Name = "DirD";
            directoryB.Name = "DirE";
            directoryC.Name = "DirF";
            Assert.AreEqual("DirD", directoryA.Name);
            Assert.AreEqual("DirE", directoryB.Name);
            Assert.AreEqual("DirF", directoryC.Name);

            // Files
            fileA.Name = "g.file";
            fileB.Name = "h.file";
            fileC.Name = "i.file";
            Assert.AreEqual("g.file", fileA.Name);
            Assert.AreEqual("h.file", fileB.Name);
            Assert.AreEqual("i.file", fileC.Name);
        }

        /// <summary>
        /// Tests the functionality of setting the <see cref="FileEntryBase.Name"/> property to <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void NameSetNull()
        {
            // Directories
            Assert.ThrowsException<ArgumentNullException>(() => directoryA.Name = null);
            Assert.ThrowsException<ArgumentNullException>(() => directoryB.Name = null);
            Assert.ThrowsException<ArgumentNullException>(() => directoryC.Name = null);

            // Files
            Assert.ThrowsException<ArgumentNullException>(() => fileA.Name = null);
            Assert.ThrowsException<ArgumentNullException>(() => fileB.Name = null);
            Assert.ThrowsException<ArgumentNullException>(() => fileC.Name = null);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.FullPath"/> property.
        /// </summary>
        [TestMethod]
        public void FullPath()
        {
            // Directories
            string expectedDirA = $"{DirAName}";
            string expectedDirB = $"{DirAName}{FileEntryBase.PathSeparator}{DirBName}";
            string expectedDirC = $"{DirAName}{FileEntryBase.PathSeparator}{DirBName}{FileEntryBase.PathSeparator}{DirCName}";
            Assert.AreEqual(expectedDirA, directoryA.FullPath);
            Assert.AreEqual(expectedDirB, directoryB.FullPath);
            Assert.AreEqual(expectedDirC, directoryC.FullPath);

            // Files
            string expectedFileBase = $"{DirAName}{FileEntryBase.PathSeparator}{DirBName}{FileEntryBase.PathSeparator}{DirCName}{FileEntryBase.PathSeparator}";
            Assert.AreEqual($"{expectedFileBase}{FileAName}", fileA.FullPath);
            Assert.AreEqual($"{expectedFileBase}{FileBName}", fileB.FullPath);
            Assert.AreEqual($"{expectedFileBase}{FileCName}", fileC.FullPath);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.IsDirectory"/> property.
        /// </summary>
        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsTrue(directoryA.IsDirectory);
            Assert.IsTrue(directoryB.IsDirectory);
            Assert.IsTrue(directoryC.IsDirectory);
            Assert.IsFalse(fileA.IsDirectory);
            Assert.IsFalse(fileB.IsDirectory);
            Assert.IsFalse(fileC.IsDirectory);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.Stream"/> property.
        /// </summary>
        [TestMethod]
        public void Stream()
        {
            Assert.ThrowsException<NotSupportedException>(() => directoryA.Stream);
            Assert.ThrowsException<NotSupportedException>(() => directoryB.Stream);
            Assert.ThrowsException<NotSupportedException>(() => directoryC.Stream);
            Assert.IsNotNull(fileA.Stream);
            Assert.IsNotNull(fileB.Stream);
            Assert.IsNotNull(fileC.Stream);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.Parent"/> property.
        /// </summary>
        [TestMethod]
        public void Parent()
        {
            Assert.IsNull(directoryA.Parent);
            Assert.ReferenceEquals(directoryA, directoryB.Parent);
            Assert.ReferenceEquals(directoryB, directoryC.Parent);
            Assert.ReferenceEquals(directoryC, fileA.Parent);
            Assert.ReferenceEquals(directoryC, fileB.Parent);
            Assert.ReferenceEquals(directoryC, fileC.Parent);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.Children"/> property.
        /// </summary>
        [TestMethod]
        public void Children()
        {
            CollectionAssert.AreEqual(new FileEntryBase[] { directoryB }, directoryA.Children);
            CollectionAssert.AreEqual(new FileEntryBase[] { directoryC }, directoryB.Children);
            CollectionAssert.AreEqual(new FileEntryBase[] { fileA, fileB, fileC }, directoryC.Children);
        }

        /// <summary>
        /// Tests the functionality of getting the <see cref="FileEntryBase.Children"/> property invalidly from a file entry.
        /// </summary>
        [TestMethod]
        public void ChildrenInvalidOnFile()
        {
            Assert.ThrowsException<NotSupportedException>(() => fileA.Children);
            Assert.ThrowsException<NotSupportedException>(() => fileB.Children);
            Assert.ThrowsException<NotSupportedException>(() => fileC.Children);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.AddChild(FileEntryBase)"/> method when invalidly adding a child entry to a file entry.
        /// </summary>
        [TestMethod]
        public void AddChildInvalidAddToFile()
        {
            ExampleFileEntry fileEntry = new("z.file", new MemoryStream());
            ExampleFileEntry dirEntry = new("DirZ");
            Assert.ThrowsException<NotSupportedException>(() => fileA.AddChild(fileEntry));
            Assert.ThrowsException<NotSupportedException>(() => fileA.AddChild(dirEntry));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.AddChild(FileEntryBase)"/> method when invalidly adding a director ancestor to another entry.
        /// </summary>
        [TestMethod]
        public void AddChildInvalidAddDirectAncestor()
        {
            // Trying to add a directory ancestor as a child is
            // invalid, as it would create a loop in the file system.
            Assert.ThrowsException<InvalidOperationException>(() => directoryC.AddChild(directoryA));
            Assert.ThrowsException<InvalidOperationException>(() => directoryC.AddChild(directoryB));
            Assert.ThrowsException<InvalidOperationException>(() => directoryB.AddChild(directoryA));
            Assert.ThrowsException<InvalidOperationException>(() => directoryA.AddChild(directoryA));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.AddChild(FileEntryBase)"/> method when invalidly adding a child with a name conflict.
        /// </summary>
        [TestMethod]
        public void AddChildInvalidNameConflict()
        {
            ExampleFileEntry fileEntry = new(FileAName, new MemoryStream());
            Assert.ThrowsException<InvalidOperationException>(() => directoryC.AddChild(fileEntry));

            ExampleFileEntry dirEntry = new(DirBName);
            Assert.ThrowsException<InvalidOperationException>(() => directoryA.AddChild(dirEntry));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.GetChild(string)"/> method.
        /// </summary>
        [TestMethod]
        public void GetChild()
        {
            // Directories
            Assert.ReferenceEquals(directoryB, directoryA.GetChild(DirBName));
            Assert.ReferenceEquals(directoryC, directoryB.GetChild(DirCName));

            // Files
            Assert.ReferenceEquals(fileA, directoryC.GetChild(FileAName));
            Assert.ReferenceEquals(fileB, directoryC.GetChild(FileBName));
            Assert.ReferenceEquals(fileC, directoryC.GetChild(FileCName));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.GetChild(string)"/> method using the name of a child that isn't present in the child entries.
        /// </summary>
        [TestMethod]
        public void GetChildNotPresent()
        {
            // Directories (not directly a child of the called node)
            Assert.IsNull(directoryA.GetChild(DirCName));

            // Directories (non-existent)
            Assert.IsNull(directoryA.GetChild("DirX"));
            Assert.IsNull(directoryB.GetChild("DirY"));
            Assert.IsNull(directoryB.GetChild("DirZ"));

            // Files (not a direct child)
            Assert.IsNull(directoryA.GetChild(FileAName));
            Assert.IsNull(directoryA.GetChild(FileBName));
            Assert.IsNull(directoryA.GetChild(FileCName));
            Assert.IsNull(directoryB.GetChild(FileAName));
            Assert.IsNull(directoryB.GetChild(FileBName));
            Assert.IsNull(directoryB.GetChild(FileCName));

            // Files (non-existent)
            Assert.IsNull(directoryC.GetChild("x.file"));
            Assert.IsNull(directoryC.GetChild("y.file"));
            Assert.IsNull(directoryC.GetChild("z.file"));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.GetChild(string)"/> method using an invalid name.
        /// </summary>
        [TestMethod]
        public void GetChildInvalidName()
        {
            Assert.IsNull(directoryA.GetChild(string.Empty));
            Assert.IsNull(directoryA.GetChild(null));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(FileEntryBase)"/> method.
        /// </summary>
        [TestMethod]
        public void RemoveChildFileEntryBase()
        {
            // Files
            Assert.IsTrue(directoryC.RemoveChild(fileA));
            Assert.IsTrue(directoryC.RemoveChild(fileB));
            Assert.IsTrue(directoryC.RemoveChild(fileC));
            Assert.IsNull(directoryC.GetChild(FileAName));
            Assert.IsNull(directoryC.GetChild(FileBName));
            Assert.IsNull(directoryC.GetChild(FileCName));
            Assert.IsNull(fileA.Parent);
            Assert.IsNull(fileB.Parent);
            Assert.IsNull(fileC.Parent);

            // Directories
            Assert.IsTrue(directoryB.RemoveChild(directoryC));
            Assert.IsNull(directoryB.GetChild(DirCName));
            Assert.IsNull(directoryC.Parent);

            Assert.IsTrue(directoryA.RemoveChild(directoryB));
            Assert.IsNull(directoryA.GetChild(DirBName));
            Assert.IsNull(directoryB.Parent);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(FileEntryBase)"/> method when the given <see cref="FileEntryBase"/> is not a child of the called object.
        /// </summary>
        [TestMethod]
        public void RemoveChildFileEntryBaseNotAChild()
        {
            // Files
            Assert.IsFalse(directoryB.RemoveChild(fileA));
            Assert.IsFalse(directoryB.RemoveChild(fileB));
            Assert.IsFalse(directoryB.RemoveChild(fileC));
            Assert.IsNotNull(directoryC.GetChild(FileAName));
            Assert.IsNotNull(directoryC.GetChild(FileBName));
            Assert.IsNotNull(directoryC.GetChild(FileCName));
            Assert.IsNotNull(fileA.Parent);
            Assert.IsNotNull(fileB.Parent);
            Assert.IsNotNull(fileC.Parent);

            // Directories
            Assert.IsFalse(directoryC.RemoveChild(directoryC));
            Assert.IsNotNull(directoryB.GetChild(DirCName));
            Assert.IsNotNull(directoryC.Parent);

            Assert.IsFalse(directoryB.RemoveChild(directoryB));
            Assert.IsNotNull(directoryA.GetChild(DirBName));
            Assert.IsNotNull(directoryB.Parent);

            Assert.IsFalse(directoryC.RemoveChild(directoryB));
            Assert.IsNotNull(directoryA.GetChild(DirBName));
            Assert.IsNotNull(directoryB.Parent);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(FileEntryBase)"/> method when the given <see cref="FileEntryBase"/> is null.
        /// </summary>
        [TestMethod]
        public void RemoveChildFileEntryBaseNull()
        {
            Assert.IsFalse(directoryA.RemoveChild((FileEntryBase)null));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(FileEntryBase)"/> method when the called <see cref="FileEntryBase"/> is not a directory.
        /// </summary>
        [TestMethod]
        public void RemoveChildFileEntryBaseRemoveFromFile()
        {
            Assert.ThrowsException<NotSupportedException>(() => fileA.RemoveChild(fileA));
            Assert.ThrowsException<NotSupportedException>(() => fileB.RemoveChild(directoryA));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(string)"/> method.
        /// </summary>
        [TestMethod]
        public void RemoveChildString()
        {
            // Files
            Assert.IsTrue(directoryC.RemoveChild(FileAName));
            Assert.IsTrue(directoryC.RemoveChild(FileBName));
            Assert.IsTrue(directoryC.RemoveChild(FileCName));
            Assert.IsNull(directoryC.GetChild(FileAName));
            Assert.IsNull(directoryC.GetChild(FileBName));
            Assert.IsNull(directoryC.GetChild(FileCName));
            Assert.IsNull(fileA.Parent);
            Assert.IsNull(fileB.Parent);
            Assert.IsNull(fileC.Parent);

            // Directories
            Assert.IsTrue(directoryB.RemoveChild(DirCName));
            Assert.IsNull(directoryB.GetChild(DirCName));
            Assert.IsNull(directoryC.Parent);

            Assert.IsTrue(directoryA.RemoveChild(DirBName));
            Assert.IsNull(directoryA.GetChild(DirBName));
            Assert.IsNull(directoryB.Parent);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(string)"/> method when the given entry name is not a child of the called object.
        /// </summary>
        [TestMethod]
        public void RemoveChildStringNotAChild()
        {
            // Files
            Assert.IsFalse(directoryB.RemoveChild(FileAName));
            Assert.IsFalse(directoryB.RemoveChild(FileBName));
            Assert.IsFalse(directoryB.RemoveChild(FileCName));
            Assert.IsNotNull(directoryC.GetChild(FileAName));
            Assert.IsNotNull(directoryC.GetChild(FileBName));
            Assert.IsNotNull(directoryC.GetChild(FileCName));
            Assert.IsNotNull(fileA.Parent);
            Assert.IsNotNull(fileB.Parent);
            Assert.IsNotNull(fileC.Parent);

            // Directories
            Assert.IsFalse(directoryC.RemoveChild(DirCName));
            Assert.IsNotNull(directoryB.GetChild(DirCName));
            Assert.IsNotNull(directoryC.Parent);

            Assert.IsFalse(directoryB.RemoveChild(DirBName));
            Assert.IsNotNull(directoryA.GetChild(DirBName));
            Assert.IsNotNull(directoryB.Parent);

            Assert.IsFalse(directoryC.RemoveChild(DirBName));
            Assert.IsNotNull(directoryA.GetChild(DirBName));
            Assert.IsNotNull(directoryB.Parent);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(string)"/> method when the given entry name is null.
        /// </summary>
        [TestMethod]
        public void RemoveChildStringNull()
        {
            Assert.IsFalse(directoryA.RemoveChild((string)null));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.RemoveChild(string)"/> method when the called <see cref="FileEntryBase"/> is not a directory.
        /// </summary>
        [TestMethod]
        public void RemoveChildStringRemoveFromFile()
        {
            Assert.ThrowsException<NotSupportedException>(() => fileA.RemoveChild(FileAName));
            Assert.ThrowsException<NotSupportedException>(() => fileB.RemoveChild(DirAName));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="FileEntryBase.InsertChild(FileEntryBase, int)"/> method.
        /// </summary>
        /// <remarks>There aren't any other InsertChild() tests because all functionality is covered within the AddChild() tests; AddChild() is just a wrapper for inserting a child to the end of a list.</remarks>
        [TestMethod]
        public void InsertChild()
        {
            ExampleFileEntry fileZ = new("z.file", new MemoryStream());
            directoryC.InsertChild(fileZ, 2);
            Assert.AreEqual(2, Array.IndexOf(directoryC.Children, fileZ));

            ExampleFileEntry dirZ = new("DirZ");
            directoryA.InsertChild(dirZ, 1);
            Assert.AreEqual(1, Array.IndexOf(directoryA.Children, dirZ));
        }
    }
}
