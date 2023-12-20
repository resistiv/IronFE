using System.Text;
using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests
{
    /// <summary>
    /// Tests functionality of all pre-defined CRC configurations.
    /// </summary>
    [TestClass]
    public class CrcTests
    {
        private static readonly byte[] CheckString = Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-16/ARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(CrcType.Crc16Arc);
            Crc arcTable = new(CrcType.Crc16Arc, false);

            arc.Update(CheckString);
            arcTable.Update(CheckString);

            Assert.AreEqual((ushort)0xBB3D, (ushort)(arc.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xBB3D, (ushort)(arcTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CDMA2000 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cdma2000()
        {
            Crc cdma2000 = new(CrcType.Crc16Cdma2000);
            Crc cdma2000Table = new(CrcType.Crc16Cdma2000, false);

            cdma2000.Update(CheckString);
            cdma2000Table.Update(CheckString);

            Assert.AreEqual((ushort)0x4C06, (ushort)(cdma2000.Result & 0xFFFF));
            Assert.AreEqual((ushort)0x4C06, (ushort)(cdma2000Table.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CMS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cms()
        {
            Crc cms = new(CrcType.Crc16Cms);
            Crc cmsTable = new(CrcType.Crc16Cms, false);

            cms.Update(CheckString);
            cmsTable.Update(CheckString);

            Assert.AreEqual((ushort)0xAEE7, (ushort)(cms.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xAEE7, (ushort)(cmsTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DDS-110 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dds110()
        {
            Crc dds110 = new(CrcType.Crc16Dds110);
            Crc dds110Table = new(CrcType.Crc16Dds110, false);

            dds110.Update(CheckString);
            dds110Table.Update(CheckString);

            Assert.AreEqual((ushort)0x9ECF, (ushort)(dds110.Result & 0xFFFF));
            Assert.AreEqual((ushort)0x9ECF, (ushort)(dds110Table.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-R CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectR()
        {
            Crc dectR = new(CrcType.Crc16DectR);
            Crc dectRTable = new(CrcType.Crc16DectR, false);

            dectR.Update(CheckString);
            dectRTable.Update(CheckString);

            Assert.AreEqual((ushort)0x007E, (ushort)(dectR.Result & 0xFFFF));
            Assert.AreEqual((ushort)0x007E, (ushort)(dectRTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-X CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectX()
        {
            Crc dectX = new(CrcType.Crc16DectX);
            Crc dectXTable = new(CrcType.Crc16DectX, false);

            dectX.Update(CheckString);
            dectXTable.Update(CheckString);

            Assert.AreEqual((ushort)0x007F, (ushort)(dectX.Result & 0xFFFF));
            Assert.AreEqual((ushort)0x007F, (ushort)(dectXTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DNP CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dnp()
        {
            Crc dnp = new(CrcType.Crc16Dnp);
            Crc dnpTable = new(CrcType.Crc16Dnp, false);

            dnp.Update(CheckString);
            dnpTable.Update(CheckString);

            Assert.AreEqual((ushort)0xEA82, (ushort)(dnp.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xEA82, (ushort)(dnpTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/EN-13757 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16En13757()
        {
            Crc en13757 = new(CrcType.Crc16En13757);
            Crc en13757Table = new(CrcType.Crc16En13757, false);

            en13757.Update(CheckString);
            en13757Table.Update(CheckString);

            Assert.AreEqual((ushort)0xC2B7, (ushort)(en13757.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xC2B7, (ushort)(en13757Table.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GENIBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Genibus()
        {
            Crc genibus = new(CrcType.Crc16Genibus);
            Crc genibusTable = new(CrcType.Crc16Genibus, false);

            genibus.Update(CheckString);
            genibusTable.Update(CheckString);

            Assert.AreEqual((ushort)0xD64E, (ushort)(genibus.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xD64E, (ushort)(genibusTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GSM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Gsm()
        {
            Crc gsm = new(CrcType.Crc16Gsm);
            Crc gsmTable = new(CrcType.Crc16Gsm, false);

            gsm.Update(CheckString);
            gsmTable.Update(CheckString);

            Assert.AreEqual((ushort)0xCE3C, (ushort)(gsm.Result & 0xFFFF));
            Assert.AreEqual((ushort)0xCE3C, (ushort)(gsmTable.Result & 0xFFFF));
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/XMODEM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(CrcType.Crc16Xmodem);
            Crc xmodemTable = new(CrcType.Crc16Xmodem, false);

            xmodem.Update(CheckString);
            xmodemTable.Update(CheckString);

            Assert.AreEqual((ushort)0x31C3, (ushort)(xmodem.Result & 0xFFFF));
            Assert.AreEqual((ushort)0x31C3, (ushort)(xmodemTable.Result & 0xFFFF));
        }
    }
}
