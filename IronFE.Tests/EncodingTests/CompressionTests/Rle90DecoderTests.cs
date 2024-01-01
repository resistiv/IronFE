using System.IO;
using IronFE.Encoding.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests.CompressionTests
{
    /// <summary>
    /// Tests functionality of the <see cref="Rle90Decoder"/> class.
    /// </summary>
    [TestClass]
    [DeploymentItem(@"TestData\Encoding\Compression\Rle90ArcEncoded.bin", "TestData")]
    public class Rle90DecoderTests : EncodingTests
    {
        /// <summary>
        /// Tests the functionality of the <see cref="Rle90Decoder.Decode(Stream)"/> function given ARC-compressed data.
        /// </summary>
        [TestMethod]
        public void DecodeRle90Arc()
        {
            /*
             * The test data for this test was generated using a modified
             * version of SEA's ARC 5.21p, the modification being that the
             * output was forced to be compression method 3 (just RLE90). The
             * file InputData.bin was fed through ARC and the resulting file
             * was stripped of the ARC header and archive end marker.
             */

            MemoryStream encodedStream = new(File.ReadAllBytes(@"TestData\Rle90ArcEncoded.bin"));
            MemoryStream decodedStream = new();

            Rle90Decoder decoder = new(encodedStream, false);
            decoder.Decode(decodedStream);

            decoder.Dispose();
            encodedStream.Dispose();

            CollectionAssert.AreEqual(InputData, decodedStream.ToArray());
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90Decoder.Decode(Stream)"/> function given BinHex-encoded data.
        /// </summary>
        [TestMethod]
        public void DecodeRle90BinHex()
        {
            /*
             * TODO: Find a BinHex program that natively behaves as expected;
             * it seems that most implementations use the same approach as ARC,
             * in that they don't buffer the RLE marker and run it if a run is
             * indeed found. macutils, binhex.py (and binascii, by extension),
             * and others have all displayed this behaviour.
             */

            throw new System.NotImplementedException();
        }
    }
}
