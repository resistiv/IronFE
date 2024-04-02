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

            FileStream rle90File = File.OpenRead("TestData/Rle90ArcEncoded.bin");
            byte[] buffer = new byte[InputData.Length];
            using (Rle90DecodingStream decoder = new(rle90File, false))
            {
                decoder.Read(buffer, 0, InputData.Length);
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given ARC-compressed data read in a piecewise manner.
        /// </summary>
        /// <remarks>
        /// The goal of this test is to evaluate the buffering system the ReadInternal() function implements in order to ensure no errors occur with read boundaries.
        /// </remarks>
        [TestMethod]
        public void DecodeRle90ArcPiecewise()
        {
            FileStream rle90File = File.OpenRead("TestData/Rle90ArcEncoded.bin");
            byte[] buffer = new byte[InputData.Length];
            using (Rle90DecodingStream decoder = new(rle90File, false))
            {
                for (int i = 0; i < InputData.Length; i++)
                {
                    decoder.Read(buffer, i, 1);
                }
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given BinHex-compressed data read in full.
        /// </summary>
        [TestMethod]
        public void DecodeRle90BinHexFull()
        {
            /*
             * TODO: Find a BinHex program that natively behaves as expected;
             * it seems that most implementations use the same approach as ARC,
             * in that they don't buffer the RLE marker and run it if a run is
             * indeed found. macutils, binhex.py (and binascii, by extension),
             * and others have all displayed this behaviour.
             * For now, we'll once again abuse ARC 5.21p to do our bidding
             * (output method 3 and buffer RLE marker when compressing).
             */

            FileStream rle90File = File.OpenRead("TestData/Rle90BinHexEncoded.bin");
            byte[] buffer = new byte[InputData.Length];
            using (Rle90DecodingStream decoder = new(rle90File, true))
            {
                decoder.Read(buffer, 0, InputData.Length);
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given BinHex-compressed data read in a piecewise manner.
        /// </summary>
        /// <remarks>
        /// The goal of this test is to evaluate the buffering system the ReadInternal() function implements in order to ensure no errors occur with read boundaries.
        /// </remarks>
        [TestMethod]
        public void DecodeRle90BinHexPiecewise()
        {
            FileStream rle90File = File.OpenRead("TestData/Rle90BinHexEncoded.bin");
            byte[] buffer = new byte[InputData.Length];
            using (Rle90DecodingStream decoder = new(rle90File, true))
            {
                for (int i = 0; i < InputData.Length; i++)
                {
                    decoder.Read(buffer, i, 1);
                }
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method and how it handles overreading.
        /// </summary>
        [TestMethod]
        public void DecodeRle90Overread()
        {
            int overreadAmount = 256;

            FileStream rle90File = File.OpenRead("TestData/Rle90BinHexEncoded.bin");
            byte[] buffer = new byte[InputData.Length + overreadAmount];
            using (Rle90DecodingStream decoder = new(rle90File, true))
            {
                // Specifically overread data, should not cause an error
                int result = decoder.Read(buffer, 0, InputData.Length + overreadAmount);
                Assert.AreEqual(InputData.Length, result);
            }

            CollectionAssert.AreEqual(InputData, buffer[..InputData.Length]);
        }
    }
}
