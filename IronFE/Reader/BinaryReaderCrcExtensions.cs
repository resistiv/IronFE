using System;
using System.IO;
using IronFE.Hash;

namespace IronFE.Reader
{
    /// <summary>
    /// Reads primitive data types as binary values and calculates the CRC of the read data.
    /// </summary>
    public static class BinaryReaderCrcExtensions
    {
        /// <summary>
        /// Reads a <see cref="byte"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>The next <see cref="byte"/> read from the current stream.</returns>
        public static byte ReadByteWithCrc(this BinaryReader reader, Crc crc)
        {
            byte b = reader.ReadByte();
            crc.Update(b);
            return b;
        }

        /// <summary>
        /// Reads an <see cref="sbyte"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>An <see cref="sbyte"/> read from the current stream.</returns>
        public static sbyte ReadSByteWithCrc(this BinaryReader reader, Crc crc)
            => (sbyte)reader.ReadByteWithCrc(crc);

        /// <summary>
        /// Reads a <see cref="bool"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns><c>true</c> if the byte is nonzero; otherwise, <c>false</c>.</returns>
        public static bool ReadBooleanWithCrc(this BinaryReader reader, Crc crc)
            => reader.ReadByteWithCrc(crc) != 0;

        /// <summary>
        /// Reads the specified number of <see cref="byte"/>s from the current <see cref="Stream"/> into a byte array and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="count">The number of <see cref="byte"/>s to read from the <see cref="Stream"/>.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="T:byte[]"/> read from the current stream.</returns>
        public static byte[] ReadBytesWithCrc(this BinaryReader reader, int count, Crc crc)
        {
            byte[] bytes = reader.ReadBytes(count);

            foreach (byte b in bytes)
            {
                crc.Update(b);
            }

            return bytes;
        }

        /// <summary>
        /// Reads a <see cref="short"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="short"/> read from the current stream.</returns>
        public static short ReadInt16WithCrc(this BinaryReader reader, Crc crc)
        {
            short s = reader.ReadInt16();

            foreach (byte b in BitConverter.GetBytes(s))
            {
                crc.Update(b);
            }

            return s;
        }

        /// <summary>
        /// Reads a <see cref="ushort"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="ushort"/> read from the current stream.</returns>
        public static ushort ReadUInt16WithCrc(this BinaryReader reader, Crc crc)
        {
            ushort s = reader.ReadUInt16();

            foreach (byte b in BitConverter.GetBytes(s))
            {
                crc.Update(b);
            }

            return s;
        }

        /// <summary>
        /// Reads an <see cref="int"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>An <see cref="int"/> read from the current stream.</returns>
        public static int ReadInt32WithCrc(this BinaryReader reader, Crc crc)
        {
            int i = reader.ReadInt32();

            foreach (byte b in BitConverter.GetBytes(i))
            {
                crc.Update(b);
            }

            return i;
        }

        /// <summary>
        /// Reads a <see cref="uint"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="uint"/> read from the current stream.</returns>
        public static uint ReadUInt32WithCrc(this BinaryReader reader, Crc crc)
        {
            uint i = reader.ReadUInt32();

            foreach (byte b in BitConverter.GetBytes(i))
            {
                crc.Update(b);
            }

            return i;
        }

        /// <summary>
        /// Reads a <see cref="long"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="long"/> read from the current stream.</returns>
        public static long ReadInt64WithCrc(this BinaryReader reader, Crc crc)
        {
            long l = reader.ReadInt64();

            foreach (byte b in BitConverter.GetBytes(l))
            {
                crc.Update(b);
            }

            return l;
        }

        /// <summary>
        /// Reads a <see cref="ulong"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="ulong"/> read from the current stream.</returns>
        public static ulong ReadUInt64WithCrc(this BinaryReader reader, Crc crc)
        {
            ulong l = reader.ReadUInt64();

            foreach (byte b in BitConverter.GetBytes(l))
            {
                crc.Update(b);
            }

            return l;
        }

        /// <summary>
        /// Reads a <see cref="Half"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="Half"/> read from the current stream.</returns>
        public static Half ReadHalfWithCrc(this BinaryReader reader, Crc crc)
        {
            Half h = reader.ReadHalf();

            foreach (byte b in BitConverter.GetBytes(h))
            {
                crc.Update(b);
            }

            return h;
        }

        /// <summary>
        /// Reads a <see cref="float"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="float"/> read from the current stream.</returns>
        public static float ReadSingleWithCrc(this BinaryReader reader, Crc crc)
        {
            float f = reader.ReadSingle();

            foreach (byte b in BitConverter.GetBytes(f))
            {
                crc.Update(b);
            }

            return f;
        }

        /// <summary>
        /// Reads a <see cref="double"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="double"/> read from the current stream.</returns>
        public static double ReadDoubleWithCrc(this BinaryReader reader, Crc crc)
        {
            double d = reader.ReadDouble();

            foreach (byte b in BitConverter.GetBytes(d))
            {
                crc.Update(b);
            }

            return d;
        }

        /// <summary>
        /// Reads a <see cref="decimal"/> from the current <see cref="Stream"/> and calculates it into the specified <see cref="Crc"/>.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader"/> instance to read data from.</param>
        /// <param name="crc">The <see cref="Crc"/> instance to calculate the read data into.</param>
        /// <returns>A <see cref="decimal"/> read from the current stream.</returns>
        public static decimal ReadDecimalWithCrc(this BinaryReader reader, Crc crc)
        {
            decimal d = reader.ReadDecimal();

            foreach (int i in decimal.GetBits(d))
            {
                foreach (byte b in BitConverter.GetBytes(i))
                {
                    crc.Update(b);
                }
            }

            return d;
        }
    }
}
