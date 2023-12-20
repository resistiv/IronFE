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
