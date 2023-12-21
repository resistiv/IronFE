using System.Text;
using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.HashTests
{
    /// <summary>
    /// Tests functionality of pre-defined CRC-8 configurations.
    /// </summary>
    [TestClass]
    public class Crc8Tests
    {
        private static readonly byte[] CheckString = Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-8/AUTOSAR CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Autosar()
        {
            Crc autosar = new(Crc8.Autosar);
            autosar.Update(CheckString);
            Assert.AreEqual((byte)0xDF, (byte)autosar.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/BLUETOOTH CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Bluetooth()
        {
            Crc bluetooth = new(Crc8.Bluetooth);
            bluetooth.Update(CheckString);
            Assert.AreEqual((byte)0x26, (byte)bluetooth.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/CDMA2000 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Cdma2000()
        {
            Crc cdma2000 = new(Crc8.Cdma2000);
            cdma2000.Update(CheckString);
            Assert.AreEqual((byte)0xDA, (byte)cdma2000.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/DARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Darc()
        {
            Crc darc = new(Crc8.Darc);
            darc.Update(CheckString);
            Assert.AreEqual((byte)0x15, (byte)darc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/DVB-S2 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8DvbS2()
        {
            Crc dvbS2 = new(Crc8.DvbS2);
            dvbS2.Update(CheckString);
            Assert.AreEqual((byte)0xBC, (byte)dvbS2.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/GSM-A CRC.
        /// </summary>
        [TestMethod]
        public void Crc8GsmA()
        {
            Crc gsmA = new(Crc8.GsmA);
            gsmA.Update(CheckString);
            Assert.AreEqual((byte)0x37, (byte)gsmA.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/GSM-B CRC.
        /// </summary>
        [TestMethod]
        public void Crc8GsmB()
        {
            Crc gsmB = new(Crc8.GsmB);
            gsmB.Update(CheckString);
            Assert.AreEqual((byte)0x94, (byte)gsmB.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/HITAG CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Hitag()
        {
            Crc hitag = new(Crc8.Hitag);
            hitag.Update(CheckString);
            Assert.AreEqual((byte)0xB4, (byte)hitag.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/I-432-1 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8I4321()
        {
            Crc i4321 = new(Crc8.I4321);
            i4321.Update(CheckString);
            Assert.AreEqual((byte)0xA1, (byte)i4321.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/I-CODE CRC.
        /// </summary>
        [TestMethod]
        public void Crc8ICode()
        {
            Crc iCode = new(Crc8.ICode);
            iCode.Update(CheckString);
            Assert.AreEqual((byte)0x7E, (byte)iCode.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/LTE CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Lte()
        {
            Crc lte = new(Crc8.Lte);
            lte.Update(CheckString);
            Assert.AreEqual((byte)0xEA, (byte)lte.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/MAXIM-DOW CRC.
        /// </summary>
        [TestMethod]
        public void Crc8MaximDow()
        {
            Crc maximDow = new(Crc8.MaximDow);
            maximDow.Update(CheckString);
            Assert.AreEqual((byte)0xA1, (byte)maximDow.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/MIFARE-MAD CRC.
        /// </summary>
        [TestMethod]
        public void Crc8MifareMad()
        {
            Crc mifareMad = new(Crc8.MifareMad);
            mifareMad.Update(CheckString);
            Assert.AreEqual((byte)0x99, (byte)mifareMad.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/NRSC-5 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Nrsc5()
        {
            Crc nrsc5 = new(Crc8.Nrsc5);
            nrsc5.Update(CheckString);
            Assert.AreEqual((byte)0xF7, (byte)nrsc5.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/OPENSAFETY CRC.
        /// </summary>
        [TestMethod]
        public void Crc8OpenSafety()
        {
            Crc openSafety = new(Crc8.OpenSafety);
            openSafety.Update(CheckString);
            Assert.AreEqual((byte)0x3E, (byte)openSafety.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/ROHC CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Rohc()
        {
            Crc rohc = new(Crc8.Rohc);
            rohc.Update(CheckString);
            Assert.AreEqual((byte)0xD0, (byte)rohc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/SAE-J1850 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8SaeJ1850()
        {
            Crc saeJ1850 = new(Crc8.SaeJ1850);
            saeJ1850.Update(CheckString);
            Assert.AreEqual((byte)0x4B, (byte)saeJ1850.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/SMBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc8SmBus()
        {
            Crc smBus = new(Crc8.SmBus);
            smBus.Update(CheckString);
            Assert.AreEqual((byte)0xF4, (byte)smBus.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/TECH-3250 CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Tech3250()
        {
            Crc tech3250 = new(Crc8.Tech3250);
            tech3250.Update(CheckString);
            Assert.AreEqual((byte)0x97, (byte)tech3250.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-8/WCDMA CRC.
        /// </summary>
        [TestMethod]
        public void Crc8Wcdma()
        {
            Crc wcdma = new(Crc8.Wcdma);
            wcdma.Update(CheckString);
            Assert.AreEqual((byte)0x25, (byte)wcdma.Result);
        }
    }
}
