using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.HashTests
{
    /// <summary>
    /// Tests functionality of pre-defined CRC-16 configurations.
    /// </summary>
    [TestClass]
    public class Crc16Tests
    {
        private static readonly byte[] CheckString = System.Text.Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-16/ARC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Arc()
        {
            Crc arc = new(Crc16.Arc);
            arc.Update(CheckString);
            Assert.AreEqual((ushort)0xBB3D, (ushort)arc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CDMA2000 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cdma2000()
        {
            Crc cdma2000 = new(Crc16.Cdma2000);
            cdma2000.Update(CheckString);
            Assert.AreEqual((ushort)0x4C06, (ushort)cdma2000.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/CMS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Cms()
        {
            Crc cms = new(Crc16.Cms);
            cms.Update(CheckString);
            Assert.AreEqual((ushort)0xAEE7, (ushort)cms.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DDS-110 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dds110()
        {
            Crc dds110 = new(Crc16.Dds110);
            dds110.Update(CheckString);
            Assert.AreEqual((ushort)0x9ECF, (ushort)dds110.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-R CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectR()
        {
            Crc dectR = new(Crc16.DectR);
            dectR.Update(CheckString);
            Assert.AreEqual((ushort)0x007E, (ushort)dectR.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DECT-X CRC.
        /// </summary>
        [TestMethod]
        public void Crc16DectX()
        {
            Crc dectX = new(Crc16.DectX);
            dectX.Update(CheckString);
            Assert.AreEqual((ushort)0x007F, (ushort)dectX.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/DNP CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Dnp()
        {
            Crc dnp = new(Crc16.Dnp);
            dnp.Update(CheckString);
            Assert.AreEqual((ushort)0xEA82, (ushort)dnp.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/EN-13757 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16En13757()
        {
            Crc en13757 = new(Crc16.En13757);
            en13757.Update(CheckString);
            Assert.AreEqual((ushort)0xC2B7, (ushort)en13757.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GENIBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Genibus()
        {
            Crc genibus = new(Crc16.Genibus);
            genibus.Update(CheckString);
            Assert.AreEqual((ushort)0xD64E, (ushort)genibus.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/GSM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Gsm()
        {
            Crc gsm = new(Crc16.Gsm);
            gsm.Update(CheckString);
            Assert.AreEqual((ushort)0xCE3C, (ushort)gsm.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/IBM-3740 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Ibm3740()
        {
            Crc ibm3740 = new(Crc16.Ibm3740);
            ibm3740.Update(CheckString);
            Assert.AreEqual((ushort)0x29B1, (ushort)ibm3740.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/IBM-SDLC CRC.
        /// </summary>
        [TestMethod]
        public void Crc16IbmSdlc()
        {
            Crc ibmSdlc = new(Crc16.IbmSdlc);
            ibmSdlc.Update(CheckString);
            Assert.AreEqual((ushort)0x906E, (ushort)ibmSdlc.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/ISO-IEC-14443-3-A CRC.
        /// </summary>
        [TestMethod]
        public void Crc16IsoIec144433A()
        {
            Crc isoIec144433A = new(Crc16.IsoIec144433A);
            isoIec144433A.Update(CheckString);
            Assert.AreEqual((ushort)0xBF05, (ushort)isoIec144433A.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/KERMIT CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Kermit()
        {
            Crc kermit = new(Crc16.Kermit);
            kermit.Update(CheckString);
            Assert.AreEqual((ushort)0x2189, (ushort)kermit.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/LJ1200 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Lj1200()
        {
            Crc lj1200 = new(Crc16.Lj1200);
            lj1200.Update(CheckString);
            Assert.AreEqual((ushort)0xBDF4, (ushort)lj1200.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/M17 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16M17()
        {
            Crc m17 = new(Crc16.M17);
            m17.Update(CheckString);
            Assert.AreEqual((ushort)0x772B, (ushort)m17.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/MAXIM-DOW CRC.
        /// </summary>
        [TestMethod]
        public void Crc16MaximDow()
        {
            Crc maximDow = new(Crc16.MaximDow);
            maximDow.Update(CheckString);
            Assert.AreEqual((ushort)0x44C2, (ushort)maximDow.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/MCRF4XX CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Mcrf4xx()
        {
            Crc mcrf4xx = new(Crc16.Mcrf4xx);
            mcrf4xx.Update(CheckString);
            Assert.AreEqual((ushort)0x6F91, (ushort)mcrf4xx.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/MODBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Modbus()
        {
            Crc modbus = new(Crc16.Modbus);
            modbus.Update(CheckString);
            Assert.AreEqual((ushort)0x4B37, (ushort)modbus.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/NRSC-5 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Nrsc5()
        {
            Crc nrsc5 = new(Crc16.Nrsc5);
            nrsc5.Update(CheckString);
            Assert.AreEqual((ushort)0xA066, (ushort)nrsc5.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/OPENSAFETY-A CRC.
        /// </summary>
        [TestMethod]
        public void Crc16OpenSafetyA()
        {
            Crc openSafetyA = new(Crc16.OpenSafetyA);
            openSafetyA.Update(CheckString);
            Assert.AreEqual((ushort)0x5D38, (ushort)openSafetyA.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/OPENSAFETY-B CRC.
        /// </summary>
        [TestMethod]
        public void Crc16OpenSafetyB()
        {
            Crc openSafetyB = new(Crc16.OpenSafetyB);
            openSafetyB.Update(CheckString);
            Assert.AreEqual((ushort)0x20FE, (ushort)openSafetyB.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/PROFIBUS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Profibus()
        {
            Crc profibus = new(Crc16.Profibus);
            profibus.Update(CheckString);
            Assert.AreEqual((ushort)0xA819, (ushort)profibus.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/RIELLO CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Riello()
        {
            Crc riello = new(Crc16.Riello);
            riello.Update(CheckString);
            Assert.AreEqual((ushort)0x63D0, (ushort)riello.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/SPI-FUJITSU CRC.
        /// </summary>
        [TestMethod]
        public void Crc16SpiFujitsu()
        {
            Crc spiFujitsu = new(Crc16.SpiFujitsu);
            spiFujitsu.Update(CheckString);
            Assert.AreEqual((ushort)0xE5CC, (ushort)spiFujitsu.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/T10-DIF CRC.
        /// </summary>
        [TestMethod]
        public void Crc16T10Dif()
        {
            Crc t10Dif = new(Crc16.T10Dif);
            t10Dif.Update(CheckString);
            Assert.AreEqual((ushort)0xD0DB, (ushort)t10Dif.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/TELEDISK CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Teledisk()
        {
            Crc teledisk = new(Crc16.Teledisk);
            teledisk.Update(CheckString);
            Assert.AreEqual((ushort)0x0FB3, (ushort)teledisk.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/TMS37157 CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Tms37157()
        {
            Crc tms37157 = new(Crc16.Tms37157);
            tms37157.Update(CheckString);
            Assert.AreEqual((ushort)0x26B1, (ushort)tms37157.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/UMTS CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Umts()
        {
            Crc umts = new(Crc16.Umts);
            umts.Update(CheckString);
            Assert.AreEqual((ushort)0xFEE8, (ushort)umts.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/USB CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Usb()
        {
            Crc usb = new(Crc16.Usb);
            usb.Update(CheckString);
            Assert.AreEqual((ushort)0xB4C8, (ushort)usb.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-16/XMODEM CRC.
        /// </summary>
        [TestMethod]
        public void Crc16Xmodem()
        {
            Crc xmodem = new(Crc16.Xmodem);
            xmodem.Update(CheckString);
            Assert.AreEqual((ushort)0x31C3, (ushort)xmodem.Result);
        }
    }
}
