using System.IO;
using IronFE.Files.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.FilesTests.GameTests
{
    /// <summary>
    /// Tests functionality of the <see cref="VibRibbonPakFile"/> and <see cref="VibRibbonPakEntry"/> classes.
    /// </summary>
    [TestClass]
    [DeploymentItem("TestData/Files/Game/VibRibbon/MANY_FILES.PAK", "TestData/Files/Game/VibRibbon")]
    [DeploymentItem("TestData/Files/Game/VibRibbon/SINGLE_NESTED_FILE.PAK", "TestData/Files/Game/VibRibbon")]
    [DeploymentItem("TestData/Files/Game/VibRibbon/SINGLE_ROOT_FILE.PAK", "TestData/Files/Game/VibRibbon")]
    [DeploymentItem("TestData/Files/Game/VibRibbon/Source/FILE_A.BIN", "TestData/Files/Game/VibRibbon/Source")]
    [DeploymentItem("TestData/Files/Game/VibRibbon/Source/DIR_A/FILE_B.BIN", "TestData/Files/Game/VibRibbon/Source/DIR_A")]
    [DeploymentItem("TestData/Files/Game/VibRibbon/Source/DIR_A/DIR_B/FILE_C.BIN", "TestData/Files/Game/VibRibbon/Source/DIR_A/DIR_B")]
    public class VibRibbonPakTests
    {
        /// <summary>
        /// Tests the functionality of the <see cref="VibRibbonPakFile"/> class to handle a PAK file containing a single root file.
        /// </summary>
        [TestMethod]
        public void SingleRootFile()
        {
            VibRibbonPakFile singleRootFile = new("TestData/Files/Game/VibRibbon/SINGLE_ROOT_FILE.PAK");

            // Test file properties
            Assert.AreEqual(1U, singleRootFile.FileCount);

            // Get file entry
            VibRibbonPakEntry fileA = (VibRibbonPakEntry)singleRootFile.Root.GetChild("FILE_A.BIN");
            Assert.IsNotNull(fileA);

            // Test file entry properties
            Assert.AreEqual("FILE_A.BIN", fileA.Name);
            Assert.AreEqual("SINGLE_ROOT_FILE.PAK/FILE_A.BIN", fileA.FullPath);
            Assert.AreEqual(8U, fileA.Offset);
            Assert.AreEqual(256U, fileA.Size);

            // Test file data
            MemoryStream fileAData = new(256);
            fileA.SaveToStream(fileAData);
            byte[] fileATrueData = File.ReadAllBytes("TestData/Files/Game/VibRibbon/Source/FILE_A.BIN");
            CollectionAssert.AreEqual(fileATrueData, fileAData.ToArray());
        }

        /// <summary>
        /// Tests the functionality of the <see cref="VibRibbonPakFile"/> class to handle a PAK file containing a single nested file.
        /// </summary>
        [TestMethod]
        public void SingleNestedFile()
        {
            VibRibbonPakFile singleNestedFile = new("TestData/Files/Game/VibRibbon/SINGLE_NESTED_FILE.PAK");

            // Test file properties
            Assert.AreEqual(1U, singleNestedFile.FileCount);

            // Get file entry
            VibRibbonPakEntry dirA = (VibRibbonPakEntry)singleNestedFile.Root.GetChild("DIR_A");
            VibRibbonPakEntry fileB = (VibRibbonPakEntry)dirA.GetChild("FILE_B.BIN");
            Assert.IsNotNull(fileB);

            // Test file entry properties
            Assert.AreEqual("FILE_B.BIN", fileB.Name);
            Assert.AreEqual("SINGLE_NESTED_FILE.PAK/DIR_A/FILE_B.BIN", fileB.FullPath);
            Assert.AreEqual(8U, fileB.Offset);
            Assert.AreEqual(256U, fileB.Size);

            // Test file data
            MemoryStream fileBData = new(256);
            fileB.SaveToStream(fileBData);
            byte[] fileBTrueData = File.ReadAllBytes("TestData/Files/Game/VibRibbon/Source/DIR_A/FILE_B.BIN");
            CollectionAssert.AreEqual(fileBTrueData, fileBData.ToArray());

            // Test directory properties
            Assert.AreEqual("DIR_A", dirA.Name);
            Assert.AreEqual("SINGLE_NESTED_FILE.PAK/DIR_A", dirA.FullPath);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="VibRibbonPakFile"/> class to handle a PAK file containing many files.
        /// </summary>
        [TestMethod]
        public void ManyFiles()
        {
            VibRibbonPakFile manyFiles = new("TestData/Files/Game/VibRibbon/MANY_FILES.PAK");

            // Test file properties
            Assert.AreEqual(3U, manyFiles.FileCount);

            // Get file entries
            VibRibbonPakEntry fileA = (VibRibbonPakEntry)manyFiles.Root.GetChild("FILE_A.BIN");
            Assert.IsNotNull(fileA);
            VibRibbonPakEntry dirA = (VibRibbonPakEntry)manyFiles.Root.GetChild("DIR_A");
            VibRibbonPakEntry fileB = (VibRibbonPakEntry)dirA.GetChild("FILE_B.BIN");
            Assert.IsNotNull(fileB);
            VibRibbonPakEntry dirB = (VibRibbonPakEntry)dirA.GetChild("DIR_B");
            VibRibbonPakEntry fileC = (VibRibbonPakEntry)dirB.GetChild("FILE_C.BIN");
            Assert.IsNotNull(fileC);

            // Test file entry properties
            Assert.AreEqual("FILE_A.BIN", fileA.Name);
            Assert.AreEqual("MANY_FILES.PAK/FILE_A.BIN", fileA.FullPath);
            Assert.AreEqual(16U, fileA.Offset);
            Assert.AreEqual(256U, fileA.Size);
            Assert.AreEqual("FILE_B.BIN", fileB.Name);
            Assert.AreEqual("MANY_FILES.PAK/DIR_A/FILE_B.BIN", fileB.FullPath);
            Assert.AreEqual(288U, fileB.Offset);
            Assert.AreEqual(256U, fileB.Size);
            Assert.AreEqual("FILE_C.BIN", fileC.Name);
            Assert.AreEqual("MANY_FILES.PAK/DIR_A/DIR_B/FILE_C.BIN", fileC.FullPath);
            Assert.AreEqual(568U, fileC.Offset);
            Assert.AreEqual(256U, fileC.Size);

            // Test file data
            byte[] fileATrueData = File.ReadAllBytes("TestData/Files/Game/VibRibbon/Source/FILE_A.BIN");
            byte[] fileBTrueData = File.ReadAllBytes("TestData/Files/Game/VibRibbon/Source/DIR_A/FILE_B.BIN");
            byte[] fileCTrueData = File.ReadAllBytes("TestData/Files/Game/VibRibbon/Source/DIR_A/DIR_B/FILE_C.BIN");
            MemoryStream fileAData = new(256);
            fileA.SaveToStream(fileAData);
            CollectionAssert.AreEqual(fileATrueData, fileAData.ToArray());
            MemoryStream fileBData = new(256);
            fileB.SaveToStream(fileBData);
            CollectionAssert.AreEqual(fileBTrueData, fileBData.ToArray());
            MemoryStream fileCData = new(256);
            fileC.SaveToStream(fileCData);
            CollectionAssert.AreEqual(fileCTrueData, fileCData.ToArray());


            // Test directory properties
            Assert.AreEqual("DIR_A", dirA.Name);
            Assert.AreEqual("MANY_FILES.PAK/DIR_A", dirA.FullPath);
            Assert.AreEqual("DIR_B", dirB.Name);
            Assert.AreEqual("MANY_FILES.PAK/DIR_A/DIR_B", dirB.FullPath);
        }
    }
}
