using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IronFE.Test
{
    /// <summary>
    /// Tests functionality of all pre-defined CRC configurations.
    /// </summary>
    [TestClass]
    public class CrcTester
    {
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(CrcType.Crc16Arc);
            string test = "123456789";

            foreach (char c in test)
            {
                arc.UpdateCrc(Convert.ToByte(c));
            }

            Assert.AreEqual((ushort)(arc.Result & 0xFFFF), (ushort)0xBB3D);
        }

        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(CrcType.Crc16Xmodem);
            string test = "123456789";

            foreach (char c in test)
            {
                xmodem.UpdateCrc(Convert.ToByte(c));
            }

            Assert.AreEqual((ushort)(xmodem.Result & 0xFFFF), (ushort)0x31C3);
        }
    }
}
