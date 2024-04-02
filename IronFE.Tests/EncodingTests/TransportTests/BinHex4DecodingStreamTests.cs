using System.IO;
using IronFE.Encoding.Transport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests.TransportTests
{
    /// <summary>
    /// Tests functionality of the <see cref="BinHex4DecodingStream"/> class.
    /// </summary>
    [TestClass]
    [DeploymentItem("TestData/Encoding/Transport/BinHex4Encoded.bin", "TestData")]
    public class BinHex4DecodingStreamTests : EncodingTests
    {
        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.ReadInternal(byte[], int, int)"/> method in full.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4Full()
        {
            /*
             * The test data for this test was created using a modified version
             * of macutils' binhex program which only processed the data fork
             * and only performed the BinHex-ing, no RLE or structure added to
             * the underlying data.
             */

            FileStream binhex4File = File.OpenRead("TestData/BinHex4Encoded.bin");
            byte[] buffer = new byte[InputData.Length];
            using (BinHex4DecodingStream decoder = new(binhex4File))
            {
                int result = decoder.Read(buffer, 0, InputData.Length);
                Assert.AreEqual(InputData.Length, result);
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.ReadInternal(byte[], int, int)"/> method in a piecewise manner.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4Piecewise()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4Encoded.bin");
            byte[] buffer = new byte[1];
            using BinHex4DecodingStream decoder = new(binhex4File);

            for (int i = 0; i < InputData.Length; i++)
            {
                decoder.Read(buffer, 0, 1);
                Assert.AreEqual(InputData[i], buffer[0]);
            }
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.ReadInternal(byte[], int, int)"/> method and how it handles overreading.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4Overread()
        {
            int overreadAmount = 256;

            FileStream binhex4File = File.OpenRead("TestData/BinHex4Encoded.bin");
            byte[] buffer = new byte[InputData.Length + overreadAmount];
            using (BinHex4DecodingStream decoder = new(binhex4File))
            {
                // Specifically overread data, should not cause an error
                int result = decoder.Read(buffer, 0, InputData.Length + overreadAmount);
                Assert.AreEqual(InputData.Length, result);
            }

            CollectionAssert.AreEqual(InputData, buffer[..InputData.Length]);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.ReadInternal(byte[], int, int)"/> method and how it handles reading after encountering the EOS marker.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4EndOfStream()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4Encoded.bin");
            using BinHex4DecodingStream decoder = new(binhex4File);

            // Read entire file
            int result = decoder.Read(_ = new byte[InputData.Length], 0, InputData.Length);
            Assert.AreEqual(InputData.Length, result);

            // Attempt to read past end of stream, handle gracefully, should return 0 bytes read
            result = decoder.Read(_ = new byte[1], 0, 1);
            Assert.AreEqual(0, result);
        }
    }
}
