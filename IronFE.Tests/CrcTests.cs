using System;
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
        private const string CheckString = "123456789";

        /// <summary>
        /// Tests the functionality of the CRC-16/ARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(CrcType.Crc16Arc);
            UpdateWithCheckString(arc);
            Assert.AreEqual((ushort)(arc.Result & 0xFFFF), (ushort)0xBB3D);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/XMODEM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(CrcType.Crc16Xmodem);
            UpdateWithCheckString(xmodem);
            Assert.AreEqual((ushort)(xmodem.Result & 0xFFFF), (ushort)0x31C3);
        }

        /// <summary>
        /// Updates a <see cref="Crc"/>'s value with the default check string.
        /// </summary>
        /// <param name="crc">A <see cref="Crc"/> to update.</param>
        private static void UpdateWithCheckString(Crc crc)
        {
            foreach (char c in CheckString)
            {
                crc.UpdateCrc(Convert.ToByte(c));
            }
        }
    }
}
