using System.Text;
using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests
{
    /// <summary>
    /// Tests functionality of pre-defined CRC-16 configurations.
    /// </summary>
    [TestClass]
    public class Crc16Tests
    {
        private static readonly byte[] CheckString = Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-16/ARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(CrcType.Crc16Arc);
            arc.Update(CheckString);
            Assert.AreEqual((ushort)0xBB3D, (ushort)(arc.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CDMA2000 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cdma2000()
        {
            Crc cdma2000 = new(CrcType.Crc16Cdma2000);
            cdma2000.Update(CheckString);
            Assert.AreEqual((ushort)0x4C06, (ushort)(cdma2000.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CMS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cms()
        {
            Crc cms = new(CrcType.Crc16Cms);
            cms.Update(CheckString);
            Assert.AreEqual((ushort)0xAEE7, (ushort)(cms.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DDS-110 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dds110()
        {
            Crc dds110 = new(CrcType.Crc16Dds110);
            dds110.Update(CheckString);
            Assert.AreEqual((ushort)0x9ECF, (ushort)(dds110.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-R CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectR()
        {
            Crc dectR = new(CrcType.Crc16DectR);
            dectR.Update(CheckString);
            Assert.AreEqual((ushort)0x007E, (ushort)(dectR.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-X CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectX()
        {
            Crc dectX = new(CrcType.Crc16DectX);
            dectX.Update(CheckString);
            Assert.AreEqual((ushort)0x007F, (ushort)(dectX.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DNP CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dnp()
        {
            Crc dnp = new(CrcType.Crc16Dnp);
            dnp.Update(CheckString);
            Assert.AreEqual((ushort)0xEA82, (ushort)(dnp.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/EN-13757 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16En13757()
        {
            Crc en13757 = new(CrcType.Crc16En13757);
            en13757.Update(CheckString);
            Assert.AreEqual((ushort)0xC2B7, (ushort)(en13757.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GENIBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Genibus()
        {
            Crc genibus = new(CrcType.Crc16Genibus);
            genibus.Update(CheckString);
            Assert.AreEqual((ushort)0xD64E, (ushort)(genibus.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GSM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Gsm()
        {
            Crc gsm = new(CrcType.Crc16Gsm);
            gsm.Update(CheckString);
            Assert.AreEqual((ushort)0xCE3C, (ushort)(gsm.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/IBM-3740 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Ibm3740()
        {
            Crc ibm3740 = new(CrcType.Crc16Ibm3740);
            ibm3740.Update(CheckString);
            Assert.AreEqual((ushort)0x29B1, (ushort)(ibm3740.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/IBM-SDLC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16IbmSdlc()
        {
            Crc ibmSdlc = new(CrcType.Crc16IbmSdlc);
            ibmSdlc.Update(CheckString);
            Assert.AreEqual((ushort)0x906E, (ushort)(ibmSdlc.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/ISO-IEC-14443-3-A CRC.
        /// </summary>
        [TestMethod]
        public void Crc16IsoIec144433A()
        {
            Crc isoIec144433A = new(CrcType.Crc16IsoIec144433A);
            isoIec144433A.Update(CheckString);
            Assert.AreEqual((ushort)0xBF05, (ushort)(isoIec144433A.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/KERMIT CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Kermit()
        {
            Crc kermit = new(CrcType.Crc16Kermit);
            kermit.Update(CheckString);
            Assert.AreEqual((ushort)0x2189, (ushort)(kermit.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/LJ1200 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Lj1200()
        {
            Crc lj1200 = new(CrcType.Crc16Lj1200);
            lj1200.Update(CheckString);
            Assert.AreEqual((ushort)0xBDF4, (ushort)(lj1200.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/M17 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16M17()
        {
            Crc m17 = new(CrcType.Crc16M17);
            m17.Update(CheckString);
            Assert.AreEqual((ushort)0x772B, (ushort)(m17.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/XMODEM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(CrcType.Crc16Xmodem);
            xmodem.Update(CheckString);
            Assert.AreEqual((ushort)0x31C3, (ushort)(xmodem.Result & 0xFFFF));
        }
    }
}
