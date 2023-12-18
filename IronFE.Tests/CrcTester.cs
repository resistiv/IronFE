using System;
using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Test
{
    /// <summary>
    /// Tests functionality of all pre-defined CRC configurations.
    /// </summary>
    [TestClass]
    public class CrcTester
    {
        private const string CheckString = "123456789";

        /// <summary>
        /// Tests the functionality of the CRC-16/ARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(CrcType.Crc16Arc);

            foreach (char c in CheckString)
            {
                arc.UpdateCrc(Convert.ToByte(c));
            }

            Assert.AreEqual((ushort)(arc.Result & 0xFFFF), (ushort)0xBB3D);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/XMODEM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(CrcType.Crc16Xmodem);

            foreach (char c in CheckString)
            {
                xmodem.UpdateCrc(Convert.ToByte(c));
            }

            Assert.AreEqual((ushort)(xmodem.Result & 0xFFFF), (ushort)0x31C3);
        }
    }
}
