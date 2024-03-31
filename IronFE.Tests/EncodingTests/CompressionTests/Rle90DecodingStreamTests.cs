using System.IO;
using IronFE.Encoding.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests.CompressionTests
{
    /// <summary>
    /// Tests functionality of the <see cref="Rle90DecodingStream"/> class.
    /// </summary>
    [TestClass]
    [DeploymentItem("TestData/Encoding/Compression/Rle90ArcEncoded.bin", "TestData")]
    [DeploymentItem("TestData/Encoding/Compression/Rle90BinHexEncoded.bin", "TestData")]
    public class Rle90DecodingStreamTests : EncodingTests
    {
        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given ARC-compressed data read in full.
        /// </summary>
        [TestMethod]
        public void DecodeRle90ArcFull()
        {
            /*
             * The test data for this test was generated using a modified
             * version of SEA's ARC 5.21p, the modification being that the
             * output was forced to be compression method 3 (just RLE90). The
             * file InputData.bin was fed through ARC and the resulting file
             * was stripped of the ARC header and archive end marker.
             */

            FileStream rle90file = File.Open("TestData/Rle90ArcEncoded.bin", FileMode.Open);
            Rle90DecodingStream decoder = new(rle90file, false);

            byte[] buffer = new byte[InputData.Length];
            decoder.Read(buffer, 0, InputData.Length);

            CollectionAssert.AreEqual(InputData, buffer);
        }
    }
}
