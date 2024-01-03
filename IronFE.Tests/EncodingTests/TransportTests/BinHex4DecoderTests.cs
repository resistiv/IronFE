using System.IO;
using IronFE.Encoding.Transport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests.TransportTests
{
    /// <summary>
    /// Tests functionality of the <see cref="BinHex4Decoder"/> class.
    /// </summary>
    [TestClass]
    [DeploymentItem("TestData/Encoding/Transport/BinHex4Encoded.bin", "TestData")]
    public class BinHex4DecoderTests : EncodingTests
    {
        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4Decoder.Decode(Stream)"/> method.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4()
        {
            /*
             * The test data for this test was created using a modified version
             * of macutils' binhex program which only processed the data fork
             * and only performed the BinHex-ing, no RLE or structure added to
             * the underlying data.
             */

            MemoryStream encodedStream = new(File.ReadAllBytes("TestData/BinHex4Encoded.bin"));
            MemoryStream decodedStream = new();

            BinHex4Decoder decoder = new(encodedStream);
            decoder.Decode(decodedStream);

            decoder.Dispose();
            encodedStream.Dispose();

            CollectionAssert.AreEqual(InputData, decodedStream.ToArray());
        }
    }
}
