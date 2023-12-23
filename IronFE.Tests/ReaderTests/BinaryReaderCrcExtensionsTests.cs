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
        private readonly byte[] data = [0x65, 0x04, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x03, 0];

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
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadByteWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadByteWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadByteWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadSByteWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadSByteWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadSByteWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadBooleanWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadBooleanWithCrc()
        {
            for (int i = 0; i < data.Length; i++)
            {
                _ = reader.ReadBooleanWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadBytesWithCrc(BinaryReader, int, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadBytesWithCrc()
        {
            _ = reader.ReadBytesWithCrc(data.Length, crc);

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt16WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt16WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(short); i++)
            {
                _ = reader.ReadInt16WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt16WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt16WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(short); i++)
            {
                _ = reader.ReadUInt16WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt32WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt32WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(int); i++)
            {
                _ = reader.ReadInt32WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt32WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt32WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(int); i++)
            {
                _ = reader.ReadUInt32WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadInt64WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadInt64WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(long); i++)
            {
                _ = reader.ReadInt64WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadUInt64WithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadUInt64WithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(long); i++)
            {
                _ = reader.ReadUInt64WithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadHalfWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadHalfWithCrc()
        {
            // Use sizeof ushort because Half cannot be sized safely
            for (int i = 0; i < data.Length / sizeof(ushort); i++)
            {
                _ = reader.ReadHalfWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadSingleWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadSingleWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(float); i++)
            {
                _ = reader.ReadSingleWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadDoubleWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadDoubleWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(double); i++)
            {
                _ = reader.ReadDoubleWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }

        /// <summary>
        /// Tests the functionality of <see cref="BinaryReaderCrcExtensions.ReadDecimalWithCrc(BinaryReader, Crc)"/>.
        /// </summary>
        [TestMethod]
        public void ReadDecimalWithCrc()
        {
            for (int i = 0; i < data.Length / sizeof(decimal); i++)
            {
                _ = reader.ReadDecimalWithCrc(crc);
            }

            Assert.AreEqual(expectedCrc, (uint)crc.Result);
        }
    }
}
