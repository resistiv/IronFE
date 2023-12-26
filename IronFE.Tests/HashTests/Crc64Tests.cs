using IronFE.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.HashTests
{
    /// <summary>
    /// Tests functionality of pre-defined CRC-64 configurations.
    /// </summary>
    [TestClass]
    public class Crc64Tests
    {
        private static readonly byte[] CheckString = System.Text.Encoding.ASCII.GetBytes("123456789");

        /// <summary>
        /// Tests the functionality of the CRC-64/ECMA-182 CRC.
        /// </summary>
        [TestMethod]
        public void Crc64Ecma182()
        {
            Crc ecma182 = new(Crc64.Ecma182);
            ecma182.Update(CheckString);
            Assert.AreEqual(0x6C40DF5F0B497347UL, ecma182.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-64/GO-ISO CRC.
        /// </summary>
        [TestMethod]
        public void Crc64GoIso()
        {
            Crc goIso = new(Crc64.GoIso);
            goIso.Update(CheckString);
            Assert.AreEqual(0xB90956C775A41001UL, goIso.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-64/MS CRC.
        /// </summary>
        [TestMethod]
        public void Crc64Ms()
        {
            Crc ms = new(Crc64.Ms);
            ms.Update(CheckString);
            Assert.AreEqual(0x75D4B74F024ECEEAUL, ms.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-64/REDIS CRC.
        /// </summary>
        [TestMethod]
        public void Crc64Redis()
        {
            Crc redis = new(Crc64.Redis);
            redis.Update(CheckString);
            Assert.AreEqual(0xE9C6D914C4B8d9CAUL, redis.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-64/WE CRC.
        /// </summary>
        [TestMethod]
        public void Crc64We()
        {
            Crc we = new(Crc64.We);
            we.Update(CheckString);
            Assert.AreEqual(0x62EC59E3F1A4F00AUL, we.Result);
        }

        /// <summary>
        /// Tests the functionality of the CRC-64/XZ CRC.
        /// </summary>
        [TestMethod]
        public void Crc64Xz()
        {
            Crc xz = new(Crc64.Xz);
            xz.Update(CheckString);
            Assert.AreEqual(0x995DC9BBDF1939FAUL, xz.Result);
        }
    }
}
