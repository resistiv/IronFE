using System.Text;
using System.Xml.Linq;
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
