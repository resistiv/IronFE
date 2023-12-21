using Microsoft.Win32;

namespace IronFE.Tool
{
    /// <summary>
    /// Handles bit reversing across primitive data types.
    /// </summary>
    /// <remarks>
    /// This class is not an endianness converter; it reverses/reflects the <i>bits</i> of data types, rather than the <i>bytes</i>.
    /// </remarks>
    public static class BitReverser
    {
        private static readonly byte[] ReverseByteTable =
        {
            0x00, 0x80, 0x40, 0xC0, 0x20, 0xA0, 0x60, 0xE0, 0x10, 0x90, 0x50, 0xD0, 0x30, 0xB0, 0x70, 0xF0,
            0x08, 0x88, 0x48, 0xC8, 0x28, 0xA8, 0x68, 0xE8, 0x18, 0x98, 0x58, 0xD8, 0x38, 0xB8, 0x78, 0xF8,
            0x04, 0x84, 0x44, 0xC4, 0x24, 0xA4, 0x64, 0xE4, 0x14, 0x94, 0x54, 0xD4, 0x34, 0xB4, 0x74, 0xF4,
            0x0C, 0x8C, 0x4C, 0xCC, 0x2C, 0xAC, 0x6C, 0xEC, 0x1C, 0x9C, 0x5C, 0xDC, 0x3C, 0xBC, 0x7C, 0xFC,
            0x02, 0x82, 0x42, 0xC2, 0x22, 0xA2, 0x62, 0xE2, 0x12, 0x92, 0x52, 0xD2, 0x32, 0xB2, 0x72, 0xF2,
            0x0A, 0x8A, 0x4A, 0xCA, 0x2A, 0xAA, 0x6A, 0xEA, 0x1A, 0x9A, 0x5A, 0xDA, 0x3A, 0xBA, 0x7A, 0xFA,
            0x06, 0x86, 0x46, 0xC6, 0x26, 0xA6, 0x66, 0xE6, 0x16, 0x96, 0x56, 0xD6, 0x36, 0xB6, 0x76, 0xF6,
            0x0E, 0x8E, 0x4E, 0xCE, 0x2E, 0xAE, 0x6E, 0xEE, 0x1E, 0x9E, 0x5E, 0xDE, 0x3E, 0xBE, 0x7E, 0xFE,
            0x01, 0x81, 0x41, 0xC1, 0x21, 0xA1, 0x61, 0xE1, 0x11, 0x91, 0x51, 0xD1, 0x31, 0xB1, 0x71, 0xF1,
            0x09, 0x89, 0x49, 0xC9, 0x29, 0xA9, 0x69, 0xE9, 0x19, 0x99, 0x59, 0xD9, 0x39, 0xB9, 0x79, 0xF9,
            0x05, 0x85, 0x45, 0xC5, 0x25, 0xA5, 0x65, 0xE5, 0x15, 0x95, 0x55, 0xD5, 0x35, 0xB5, 0x75, 0xF5,
            0x0D, 0x8D, 0x4D, 0xCD, 0x2D, 0xAD, 0x6D, 0xED, 0x1D, 0x9D, 0x5D, 0xDD, 0x3D, 0xBD, 0x7D, 0xFD,
            0x03, 0x83, 0x43, 0xC3, 0x23, 0xA3, 0x63, 0xE3, 0x13, 0x93, 0x53, 0xD3, 0x33, 0xB3, 0x73, 0xF3,
            0x0B, 0x8B, 0x4B, 0xCB, 0x2B, 0xAB, 0x6B, 0xEB, 0x1B, 0x9B, 0x5B, 0xDB, 0x3B, 0xBB, 0x7B, 0xFB,
            0x07, 0x87, 0x47, 0xC7, 0x27, 0xA7, 0x67, 0xE7, 0x17, 0x97, 0x57, 0xD7, 0x37, 0xB7, 0x77, 0xF7,
            0x0F, 0x8F, 0x4F, 0xCF, 0x2F, 0xAF, 0x6F, 0xEF, 0x1F, 0x9F, 0x5F, 0xDF, 0x3F, 0xBF, 0x7F, 0xFF,
        };

        /// <summary>
        /// Reverses the bits of a <see cref="byte"/>.
        /// </summary>
        /// <param name="b">A <see cref="byte"/> to reverse.</param>
        /// <returns>A reversed <see cref="byte"/>.</returns>
        public static byte ReverseByte(byte b)
            => ReverseByteTable[b];

        /// <summary>
        /// Reverses the bits of an <see cref="sbyte"/>.
        /// </summary>
        /// <param name="b">An <see cref="sbyte"/> to reverse.</param>
        /// <returns>A reversed <see cref="sbyte"/>.</returns>
        public static sbyte ReverseSByte(sbyte b)
            => (sbyte)ReverseByteTable[b & 0xFF];

        /// <summary>
        /// Reverses the bits of a <see cref="short"/>.
        /// </summary>
        /// <param name="s">A <see cref="short"/> to reverse.</param>
        /// <returns>A reversed <see cref="short"/>.</returns>
        public static short ReverseInt16(short s)
            => (short)(ReverseByteTable[s & 0xFF] << 8 |
                       ReverseByteTable[(s >> 8) & 0xFF]);

        /// <summary>
        /// Reverses the bits of a <see cref="ushort"/>.
        /// </summary>
        /// <param name="s">A <see cref="ushort"/> to reverse.</param>
        /// <returns>A reversed <see cref="ushort"/>.</returns>
        public static ushort ReverseUInt16(ushort s)
            => (ushort)(ReverseByteTable[s & 0xFF] << 8 |
                       ReverseByteTable[(s >> 8) & 0xFF]);

        /// <summary>
        /// Reverses the bits of an <see cref="int"/>.
        /// </summary>
        /// <param name="i">An <see cref="int"/> to reverse.</param>
        /// <returns>A reversed <see cref="int"/>.</returns>
        public static int ReverseInt32(int i)
            => ReverseByteTable[i & 0xFF] << 24 |
               ReverseByteTable[(i >> 8) & 0xFF] << 16 |
               ReverseByteTable[(i >> 16) & 0xFF] << 8 |
               ReverseByteTable[(i >> 24) & 0xFF];

        /// <summary>
        /// Reverses the bits of a <see cref="uint"/>.
        /// </summary>
        /// <param name="i">A <see cref="uint"/> to reverse.</param>
        /// <returns>A reversed <see cref="uint"/>.</returns>
        public static uint ReverseUInt32(uint i)
            => (uint)ReverseByteTable[i & 0xFF] << 24 |
               (uint)ReverseByteTable[(i >> 8) & 0xFF] << 16 |
               (uint)ReverseByteTable[(i >> 16) & 0xFF] << 8 |
                     ReverseByteTable[(i >> 24) & 0xFF];

        /// <summary>
        /// Reverses the bits of a <see cref="long"/>.
        /// </summary>
        /// <param name="l">A <see cref="long"/> to reverse.</param>
        /// <returns>A reversed <see cref="long"/>.</returns>
        public static long ReverseInt64(long l)
            => (long)ReverseByteTable[l & 0xFF] << 56 |
               (long)ReverseByteTable[(l >> 8) & 0xFF] << 48 |
               (long)ReverseByteTable[(l >> 16) & 0xFF] << 40 |
               (long)ReverseByteTable[(l >> 24) & 0xFF] << 32 |
               (long)ReverseByteTable[(l >> 32) & 0xFF] << 24 |
               (long)ReverseByteTable[(l >> 40) & 0xFF] << 16 |
               (long)ReverseByteTable[(l >> 48) & 0xFF] << 8 |
                     ReverseByteTable[(l >> 56) & 0xFF];

        /// <summary>
        /// Reverses the bits of a <see cref="ulong"/>.
        /// </summary>
        /// <param name="l">A <see cref="ulong"/> to reverse.</param>
        /// <returns>A reversed <see cref="ulong"/>.</returns>
        public static ulong ReverseUInt64(ulong l)
            => (ulong)ReverseByteTable[l & 0xFF] << 56 |
               (ulong)ReverseByteTable[(l >> 8) & 0xFF] << 48 |
               (ulong)ReverseByteTable[(l >> 16) & 0xFF] << 40 |
               (ulong)ReverseByteTable[(l >> 24) & 0xFF] << 32 |
               (ulong)ReverseByteTable[(l >> 32) & 0xFF] << 24 |
               (ulong)ReverseByteTable[(l >> 40) & 0xFF] << 16 |
               (ulong)ReverseByteTable[(l >> 48) & 0xFF] << 8 |
                      ReverseByteTable[(l >> 56) & 0xFF];

        /// <summary>
        /// Reverses the bottom <paramref name="bitCount"/> bits of a given <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// Adapted from Ross Williams' <i>A Painless Guide to CRC Error Detection Algorithms</i> (1993). This method is loop-based rather than table-based, and is therefore slower than the methods in the <see cref="BitReverser"/> class with dedicated data types.
        /// </remarks>
        /// <param name="value">A value whose bottom-most bits are to be reversed.</param>
        /// <param name="bitCount">The number of bits to reverse.</param>
        /// <returns>A <see cref="ulong"/> with its bottom <paramref name="bitCount"/> bits reversed.</returns>
        public static ulong ReverseValue(ulong value, int bitCount)
        {
            ulong result = value;

            while (bitCount != 0)
            {
                if ((value & 1) == 1)
                {
                    result |= 1UL << (--bitCount);
                }
                else
                {
                    result &= ~(1UL << (--bitCount));
                }

                value >>= 1;
            }

            return result;
        }

        /// <summary>
        /// Reverses the bottom <paramref name="bitCount"/> bits of a given <paramref name="value"/>, using optimized table-based routines when applicable.
        /// </summary>
        /// <remarks>
        /// Adapted from Ross Williams' <i>A Painless Guide to CRC Error Detection Algorithms</i> (1993).
        /// </remarks>
        /// <param name="value">A value whose bottom-most bits are to be reversed.</param>
        /// <param name="bitCount">The number of bits to reverse.</param>
        /// <returns>A <see cref="ulong"/> with its bottom <paramref name="bitCount"/> bits reversed.</returns>
        public static ulong ReverseValueFast(ulong value, int bitCount)
        {
            // Optimize for cases that can be made table-based
            return bitCount switch
            {
                 8 => (value & 0xFFFFFFFFFFFFFF00) | ReverseByte((byte)(value & 0xFF)),
                16 => (value & 0xFFFFFFFFFFFF0000) | ReverseUInt16((ushort)(value & 0xFFFF)),
                32 => (value & 0xFFFFFFFF00000000) | ReverseUInt32((uint)(value & 0xFFFFFFFF)),
                64 => ReverseUInt64(value),
                 _ => ReverseValue(value, bitCount),
            };
        }

        /*
        private static byte[] GenerateReverseByteTable()
        {
            byte[] result = new byte[256];

            foreach (byte b in Enumerable.Range(0, 255).Select(v => (byte)v))
            {
                result[b] = (byte)((b * 0x0202020202UL & 0x010884422010UL) % 1023);
            }

            return result;
        }

        private static void PrintReverseByteTable()
        {
            byte[] bytes = GenerateReverseByteTable();
            Console.WriteLine("private static readonly byte[] ReverseByteTable =");
            Console.Write("{");

            for (int i = 0; i < bytes.Length; i++)
            {
                if (i % 16 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write($"0x{bytes[i]:X2}, ");
            }

            Console.WriteLine("\n};");
        }
        */
    }
}

/*
 * Useful Resources:
 * https://graphics.stanford.edu/~seander/bithacks.html#BitReverseObvious
 */
