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
                decoder.Read(buffer, 0, InputData.Length);
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
            byte[] buffer = new byte[InputData.Length];
            using (BinHex4DecodingStream decoder = new(binhex4File))
            {
                for (int i = 0; i < InputData.Length; i++)
                {
                    buffer[i] = (byte)decoder.ReadByte();
                }
            }

            CollectionAssert.AreEqual(InputData, buffer);
        }
    }
}
