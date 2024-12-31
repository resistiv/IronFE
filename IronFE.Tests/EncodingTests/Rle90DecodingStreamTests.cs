using System.IO;
using IronFE.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.EncodingTests
{
    /// <summary>
    /// Tests functionality of the <see cref="Rle90DecodingStream"/> class.
    /// </summary>
    [TestClass]
    [DeploymentItem("TestData/Encoding/Rle90/Rle90ArcEncoded.bin", "TestData/Encoding/Rle90")]
    [DeploymentItem("TestData/Encoding/Rle90/Rle90BinHexEncoded.bin", "TestData/Encoding/Rle90")]
    [DeploymentItem("TestData/Encoding/Rle90/Rle90RunBeforeLiteral.bin", "TestData/Encoding/Rle90")]
    [DeploymentItem("TestData/Encoding/Rle90/Rle90NoRunLength.bin", "TestData/Encoding/Rle90")]
    [DeploymentItem("TestData/Encoding/Rle90/Rle90LiteralMarkerRun.bin", "TestData/Encoding/Rle90")]
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

            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90ArcEncoded.bin");
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
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90ArcEncoded.bin");
            byte[] buffer = new byte[1];
            using Rle90DecodingStream decoder = new(rle90File, false);

            for (int i = 0; i < InputData.Length; i++)
            {
                decoder.Read(buffer, 0, 1);
                Assert.AreEqual(InputData[i], buffer[0]);
            }
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

            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90BinHexEncoded.bin");
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
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90BinHexEncoded.bin");
            byte[] buffer = new byte[1];
            using Rle90DecodingStream decoder = new(rle90File, true);

            for (int i = 0; i < InputData.Length; i++)
            {
                decoder.Read(buffer, 0, 1);
                Assert.AreEqual(InputData[i], buffer[0]);
            }
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method and how it handles overreading.
        /// </summary>
        [TestMethod]
        public void DecodeRle90Overread()
        {
            int overreadAmount = 256;

            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90LiteralMarkerRun.bin");
            byte[] buffer = new byte[4 + overreadAmount];

            // No need for exception checking, the assumption is that
            // the Rle90DecodingStream will catch the EOS and simply return
            // the proper amount of bytes read. In this case, we don't
            // compare output because the Arc & BinHex test families cover
            // that.
            using Rle90DecodingStream decoder = new(rle90File, true);
            int result = decoder.Read(buffer, 0, 4 + overreadAmount);
            Assert.AreEqual(4, result);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given data with a run before a literal byte can be buffered.
        /// </summary>
        [TestMethod]
        public void DecodeRle90RunBeforeLiteral()
        {
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90RunBeforeLiteral.bin");
            byte[] buffer = new byte[1];

            using Rle90DecodingStream decoder = new(rle90File, true);
            InvalidDataException exception = Assert.ThrowsException<InvalidDataException>(() => decoder.Read(buffer, 0, 1));
            Assert.AreEqual(Properties.Strings.Rle90RunBeforeLiteral, exception.Message);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given data with a run without a run length (pre-mature EOS).
        /// </summary>
        [TestMethod]
        public void DecodeRle90NoRunLength()
        {
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90NoRunLength.bin");
            byte[] buffer = new byte[2];

            using Rle90DecodingStream decoder = new(rle90File, true);
            InvalidDataException exception = Assert.ThrowsException<InvalidDataException>(() => decoder.Read(buffer, 0, 2));
            Assert.AreEqual(Properties.Strings.Rle90EosExpectedRunLength, exception.Message);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given data with a literal 0x90 marker with a run following it as the only data, using no marker buffering.
        /// </summary>
        [TestMethod]
        public void DecodeRle90ArcLiteralMarkerRun()
        {
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90LiteralMarkerRun.bin");
            byte[] buffer = new byte[4];

            // Since this mode doesn't buffer the literal marker,
            // this should result in the lastByte state variable not being updated,
            // causing a subsequent run to throw an InvalidDataException.
            using Rle90DecodingStream decoder = new(rle90File, false);
            InvalidDataException exception = Assert.ThrowsException<InvalidDataException>(() => decoder.Read(buffer, 0, 4));
            Assert.AreEqual(Properties.Strings.Rle90RunBeforeLiteral, exception.Message);
        }

        /// <summary>
        /// Tests the functionality of the <see cref="Rle90DecodingStream.ReadInternal(byte[], int, int)"/> method given data with a literal 0x90 marker with a run following it as the only data, using marker buffering.
        /// </summary>
        [TestMethod]
        public void DecodeRle90BinHexLiteralMarkerRun()
        {
            FileStream rle90File = File.OpenRead("TestData/Encoding/Rle90/Rle90LiteralMarkerRun.bin");
            byte[] buffer = new byte[4];

            // No need to check for exceptions, this should succeed
            // since the literal marker should be buffered, allowing
            // for a successful run.
            using Rle90DecodingStream decoder = new(rle90File, true);
            decoder.Read(buffer, 0, 4);
        }
    }
}
