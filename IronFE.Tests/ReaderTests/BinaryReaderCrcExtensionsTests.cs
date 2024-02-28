using System.IO;
using IronFE.Hash;
using IronFE.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.ReaderTests
{
    /// <summary>
    /// Tests functionality of <see cref="BinaryReader"/> <see cref="Crc"/> extension methods.
    /// </summary>
    [TestClass]
    public class BinaryReaderCrcExtensionsTests
    {
        // Decimal bytes: 1.125M
        private readonly byte[] data = { 0x65, 0x04, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x03, 0 };

        // Calculated externally using 7zip's CRC-32
        private readonly uint expectedCrc = 0x0EF22D64U;

        private BinaryReader reader = null;
        private Crc crc = null;

        /// <summary>
        /// Initializes the <see cref="BinaryReader"/> and <see cref="Crc"/> for a test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            reader = new BinaryReader(new MemoryStream(data));
            crc = new(Crc32.IsoHdlc);
        }

        /// <summary>
        /// Cleans up after a test.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            reader.Dispose();
            reader = null;
            crc = null;
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadByte(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadByteWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadByte(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadSByte(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadSByteWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadSByte(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadBoolean(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadBooleanWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadBoolean(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadBytes(BinaryReader, int, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadBytesWithCrc()
        {
            _ = reader.ReadBytes(data.Length, crc);

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt16(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt16WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(short); i++)
            {
                _ = reader.ReadInt16(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt16(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt16WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(short); i++)
            {
                _ = reader.ReadUInt16(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt32(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt32WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(int); i++)
            {
                _ = reader.ReadInt32(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt32(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt32WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(int); i++)
            {
                _ = reader.ReadUInt32(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt64(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt64WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(long); i++)
            {
                _ = reader.ReadInt64(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt64(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt64WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(long); i++)
            {
                _ = reader.ReadUInt64(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadHalf(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadHalfWithCrc()
        {
            // Use sizeof ushort because Half cannot be sized safely
            for (int i = 0; i < data.Length / sizeof(ushort); i++)
            {
                _ = reader.ReadHalf(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadSingle(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadSingleWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(float); i++)
            {
                _ = reader.ReadSingle(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadDouble(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadDoubleWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(double); i++)
            {
                _ = reader.ReadDouble(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadDecimal(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadDecimalWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(decimal); i++)
            {
                _ = reader.ReadDecimal(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }
    }
}
