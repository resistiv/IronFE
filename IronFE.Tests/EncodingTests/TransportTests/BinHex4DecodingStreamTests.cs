using System;
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
    [DeploymentItem("TestData/Encoding/Transport/BinHex4NoMarkerStart.bin", "TestData")]
    [DeploymentItem("TestData/Encoding/Transport/BinHex4NoMarkerEnd.bin", "TestData")]
    [DeploymentItem("TestData/Encoding/Transport/BinHex4Small.bin", "TestData")]
    [DeploymentItem("TestData/Encoding/Transport/BinHex4AllInvalid.bin", "TestData")]
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

            FileStream binhex4File = File.OpenRead("TestData/BinHex4Small.bin");
            byte[] buffer = new byte[3 + overreadAmount];
            using (BinHex4DecodingStream decoder = new(binhex4File))
            {
                // Specifically overread data, should not cause an error
                int result = decoder.Read(buffer, 0, 3 + overreadAmount);
                Assert.AreEqual(3, result);
            }
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.ReadInternal(byte[], int, int)"/> method and how it handles reading after encountering the EOS marker.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4EndOfStream()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4Small.bin");
            using BinHex4DecodingStream decoder = new(binhex4File);

            // Read entire file
            int result = decoder.Read(_ = new byte[3], 0, 3);
            Assert.AreEqual(3, result);

            // Attempt to read past end of stream, handle gracefully, should return 0 bytes read
            result = decoder.Read(_ = new byte[1], 0, 1);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.BinHex4DecodingStream(Stream)"/> method and how it handles a BinHex 4 stream that doesn't start with the required stream marker.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4NoMarkerStart()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4NoMarkerStart.bin");
            BinHex4DecodingStream decoder;
            Assert.ThrowsException<InvalidDataException>(() => decoder = new(binhex4File));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.BinHex4DecodingStream(Stream)"/> method and how it handles a BinHex 4 stream that doesn't end with the required stream marker.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4NoMarkerEnd()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4NoMarkerEnd.bin");
            using BinHex4DecodingStream decoder = new(binhex4File);

            // Input data is 4 bytes encoded, 3 bytes decoded, so attempt to
            // overread an extra byte with no end marker.
            byte[] buffer = new byte[4];
            Assert.ThrowsException<EndOfStreamException>(() => decoder.Read(buffer, 0, 4));
        }

        /// <summary>
        /// Tests the functionality of the <see cref="BinHex4DecodingStream.BinHex4DecodingStream(Stream)"/> method and how it handles a BinHex 4 stream that doesn't end with the required stream marker.
        /// </summary>
        [TestMethod]
        public void DecodeBinHex4AllInvalid()
        {
            FileStream binhex4File = File.OpenRead("TestData/BinHex4AllInvalid.bin");
            using BinHex4DecodingStream decoder = new(binhex4File);

            // Input data is all 189 invalid bytes, so just read them one by one and catch.
            // This made me think a bit about how errors in the stream should be handled;
            // in this case, they throw an exception on read and interrupt the read process,
            // resulting in no data returned. I'm not sure if this is a good approach or not...
            for (int i = 0; i < 189; i++)
            {
                Assert.ThrowsException<InvalidDataException>(() => decoder.Read(_ = new byte[1], 0, 1));
            }
        }
    }
}
