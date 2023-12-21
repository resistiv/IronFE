using System.Text;
using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.CrcTests
{
    /// <summary>
    /// Tests functionality of pre-defined CRC-32 configurations.
    /// </summary>
    [TestClass]
    public class Crc32Tests
    {
        private static readonly byte[] CheckString = Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-32/AIXM CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Aixm()
        {
            Crc aixm = new(Crc32.Aixm);
            aixm.Update(CheckString);
            Assert.AreEqual(0x3010BF7FU, (uint)aixm.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/AUTOSAR CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Autosar()
        {
            Crc autosar = new(Crc32.Autosar);
            autosar.Update(CheckString);
            Assert.AreEqual(0x1697D06AU, (uint)autosar.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/BASE91-D CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Base91D()
        {
            Crc base91D = new(Crc32.Base91D);
            base91D.Update(CheckString);
            Assert.AreEqual(0x87315576U, (uint)base91D.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/BZIP2 CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Bzip2()
        {
            Crc bzip2 = new(Crc32.Bzip2);
            bzip2.Update(CheckString);
            Assert.AreEqual(0xFC891918U, (uint)bzip2.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/CD-ROM-EDC CRC.
        /// </summary>
        [TestMethod]
        public void Crc32CdRomEdc()
        {
            Crc cdRomEdc = new(Crc32.CdRomEdc);
            cdRomEdc.Update(CheckString);
            Assert.AreEqual(0x6EC2EDC4U, (uint)cdRomEdc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/CKSUM CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Cksum()
        {
            Crc cksum = new(Crc32.Cksum);
            cksum.Update(CheckString);
            Assert.AreEqual(0x765E7680U, (uint)cksum.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/ISCSI CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Iscsi()
        {
            Crc iscsi = new(Crc32.Iscsi);
            iscsi.Update(CheckString);
            Assert.AreEqual(0xE3069283U, (uint)iscsi.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/ISO-HDLC CRC.
        /// </summary>
        [TestMethod]
        public void Crc32IsoHdlc()
        {
            Crc isoHdlc = new(Crc32.IsoHdlc);
            isoHdlc.Update(CheckString);
            Assert.AreEqual(0xCBF43926U, (uint)isoHdlc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/JAMCRC CRC.
        /// </summary>
        [TestMethod]
        public void Crc32JamCrc()
        {
            Crc jamCrc = new(Crc32.JamCrc);
            jamCrc.Update(CheckString);
            Assert.AreEqual(0x340BC6D9U, (uint)jamCrc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/MEF CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Mef()
        {
            Crc mef = new(Crc32.Mef);
            mef.Update(CheckString);
            Assert.AreEqual(0xD2C22F51U, (uint)mef.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/MPEG-2 CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Mpeg2()
        {
            Crc mpeg2 = new(Crc32.Mpeg2);
            mpeg2.Update(CheckString);
            Assert.AreEqual(0x0376E6E7U, (uint)mpeg2.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-32/XFER CRC.
        /// </summary>
        [TestMethod]
        public void Crc32Xfer()
        {
            Crc xfer = new(Crc32.Xfer);
            xfer.Update(CheckString);
            Assert.AreEqual(0xBD0BE338U, (uint)xfer.Result);
        }
    }
}
