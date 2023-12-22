using IronFE.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.ToolTests
{
    /// <summary>
    /// Tests functionality of the <see cref="BitReverser"/> class.
    /// </summary>
    [TestClass]
    public class BitReverserTests
    {
        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseByte(byte)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseByte()
        {
            for (byte b = byte.MinValue; b < byte.MaxValue; b++)
            {
                Assert.AreEqual(BitReverser.ReverseByte(b), (byte)BitReverser.ReverseValue(b, 8));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseSByte(sbyte)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseSByte()
        {
            for (sbyte b = sbyte.MinValue; b < sbyte.MaxValue; b++)
            {
                Assert.AreEqual(BitReverser.ReverseSByte(b), (sbyte)BitReverser.ReverseValue((ulong)b, 8));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseInt16(short)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseInt16()
        {
            for (short s = short.MinValue; s < short.MaxValue; s++)
            {
                Assert.AreEqual(BitReverser.ReverseInt16(s), (short)BitReverser.ReverseValue((ulong)s, 16));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseUInt16(ushort)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseUInt16()
        {
            for (ushort s = ushort.MinValue; s < ushort.MaxValue; s++)
            {
                Assert.AreEqual(BitReverser.ReverseUInt16(s), (ushort)BitReverser.ReverseValue(s, 16));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseInt32(int)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseInt32()
        {
            // These loops are much larger, so we split into two workable groups starting from Min and Max
            for (int i = int.MinValue; i < int.MinValue + short.MaxValue; i++)
            {
                Assert.AreEqual(BitReverser.ReverseInt32(i), (int)BitReverser.ReverseValue((ulong)i, 32));
            }

            for (int i = int.MaxValue; i > int.MaxValue - short.MaxValue; i--)
            {
                Assert.AreEqual(BitReverser.ReverseInt32(i), (int)BitReverser.ReverseValue((ulong)i, 32));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseUInt32(uint)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseUInt32()
        {
            for (uint i = uint.MinValue; i < uint.MinValue + short.MaxValue; i++)
            {
                Assert.AreEqual(BitReverser.ReverseUInt32(i), (uint)BitReverser.ReverseValue(i, 32));
            }

            for (uint i = uint.MaxValue; i > uint.MaxValue - short.MaxValue; i--)
            {
                Assert.AreEqual(BitReverser.ReverseUInt32(i), (uint)BitReverser.ReverseValue(i, 32));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseInt64(long)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseInt64()
        {
            for (long l = long.MinValue; l < long.MinValue + short.MaxValue; l++)
            {
                Assert.AreEqual(BitReverser.ReverseInt64(l), (long)BitReverser.ReverseValue((ulong)l, 64));
            }

            for (long l = long.MaxValue; l > long.MaxValue - short.MaxValue; l--)
            {
                Assert.AreEqual(BitReverser.ReverseInt64(l), (long)BitReverser.ReverseValue((ulong)l, 64));
            }
        }

        /// <summary>
        /// Tests functionality of the <see cref="BitReverser.ReverseUInt64(ulong)"/> method.
        /// </summary>
        [TestMethod]
        public void ReverseUInt64()
        {
            for (ulong l = ulong.MinValue; l < ulong.MinValue + (ulong)short.MaxValue; l++)
            {
                Assert.AreEqual(BitReverser.ReverseUInt64(l), BitReverser.ReverseValue(l, 64));
            }

            for (ulong l = ulong.MaxValue; l > ulong.MaxValue - (ulong)short.MaxValue; l--)
            {
                Assert.AreEqual(BitReverser.ReverseUInt64(l), BitReverser.ReverseValue(l, 64));
            }
        }
    }
}
