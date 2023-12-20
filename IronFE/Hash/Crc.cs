using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using IronFE.Tool;

namespace IronFE.Hash
{
    /// <summary>
    /// Calculates a cyclic redundancy check over data.
    /// </summary>
    public class Crc
    {
        private static readonly FrozenDictionary<CrcType, CrcParameters> PredefinedCrcs =
            new Dictionary<CrcType, CrcParameters>
            {
                {
                    CrcType.Crc16Arc,
                    new("CRC-16/ARC", 16, 0x8005, 0UL, true, true, 0UL)
                },
                {
                    CrcType.Crc16Cdma2000,
                    new("CRC-16/CDMA2000", 16, 0xC867, 0xFFFF, false, false, 0UL)
                },
                {
                    CrcType.Crc16Cms,
                    new("CRC-16/CMS", 16, 0x8005, 0xFFFF, false, false, 0UL)
                },
                {
                    CrcType.Crc16Dds110,
                    new("CRC-16/DDS-110", 16, 0x8005, 0x800D, false, false, 0UL)
                },
                {
                    CrcType.Crc16DectR,
                    new("CRC-16/DECT-R", 16, 0x0589, 0UL, false, false, 0x0001)
                },
                {
                    CrcType.Crc16DectX,
                    new("CRC-16/DECT-X", 16, 0x0589, 0UL, false, false, 0UL)
                },
                {
                    CrcType.Crc16Dnp,
                    new("CRC-16/DNP", 16, 0x3D65, 0UL, true, true, 0xFFFF)
                },
                {
                    CrcType.Crc16En13757,
                    new("CRC-16/EN-13757", 16, 0x3D65, 0UL, false, false, 0xFFFF)
                },
                {
                    CrcType.Crc16Xmodem,
                    new("CRC-16/XMODEM", 16, 0x1021, 0UL, false, false, 0UL)
                },
            }.ToFrozenDictionary();

        private readonly CrcParameters parameters;
        private readonly ulong[] crcTable;
        private readonly bool useTable;
        private ulong crcRegister;

        private delegate void UpdateDelegate(byte b);
        private readonly UpdateDelegate updateDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a pre-defined CRC configuration, identified by its <see cref="CrcType"/>, using the table-based lookup method.
        /// </summary>
        /// <param name="type">A <see cref="CrcType"/> corresponding to a pre-defined CRC configuration.</param>
        public Crc(CrcType type)
            : this(type, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a pre-defined CRC configuration, identified by its <see cref="CrcType"/>, and the choice to use a table-based lookup or manual calculation for CRC updates.
        /// </summary>
        /// <remarks>Using a table-based lookup is better for scenarios processing upwards of 256 bytes; the initial generation of the table can be more costly than beneficial for smaller quantities of data, because it is 256 bytes itself.</remarks>
        /// <param name="type">A <see cref="CrcType"/> corresponding to a pre-defined CRC configuration.</param>
        /// <param name="useTable">Whether to use the default table-based lookup to calculate updates, or to use manual calculation.</param>
        public Crc(CrcType type, bool useTable)
            : this(PredefinedCrcs.TryGetValue(type, out CrcParameters parameters) ? parameters : throw new ArgumentException("The provided CrcType was not found to belong to a pre-defined CRC."), useTable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a user-defined instance of <see cref="CrcParameters"/> using the table-based lookup method.
        /// </summary>
        /// <param name="parameters">A user-defined <see cref="CrcParameters"/> instance containing a particular CRC configuration.</param>
        public Crc(CrcParameters parameters)
            : this(parameters, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a user-defined instance of <see cref="CrcParameters"/> and the choice to use a table-based lookup or manual calculation for CRC updates.
        /// </summary>
        /// <remarks>Using a table-based lookup is better for scenarios processing upwards of 256 bytes; the initial generation of the table can be more costly than beneficial for smaller quantities of data, because it is 256 bytes itself.</remarks>
        /// <param name="parameters">A user-defined <see cref="CrcParameters"/> instance containing a particular CRC configuration.</param>
        /// <param name="useTable">Whether to use the default table-based lookup to calculate updates, or to use manual calculation.</param>
        public Crc(CrcParameters parameters, bool useTable)
        {
            this.parameters = parameters;
            Reset();
            crcTable = GenerateTable();

            this.useTable = useTable;
            if (this.useTable)
            {
                crcTable = GenerateTable();
                updateDelegate = new UpdateDelegate(UpdateUsingTable);
            }
            else
            {
                crcTable = [];
                updateDelegate = new UpdateDelegate(UpdateManually);
            }
        }

        /// <summary>
        /// Gets the resultant CRC calculated from the input data.
        /// </summary>
        public ulong Result
        {
            get
            {
                // If we're using a table, only reverse when input & output flips differ; otherwise, when manually calculating, flip output when needed
                if ((useTable && (parameters.ReflectInput ^ parameters.ReflectOutput)) || (!useTable && parameters.ReflectOutput))
                {
                    return parameters.OutputXor ^ BitReverser.ReverseValue(crcRegister, parameters.Width);
                }
                else
                {
                    return parameters.OutputXor ^ crcRegister;
                }
            }
        }

        /// <summary>
        /// Updates the CRC with a <see cref="byte"/> of input data.
        /// </summary>
        /// <remarks>
        /// Adapted from Ross Williams' <i>A Painless Guide to CRC Error Detection Algorithms</i> (1993).
        /// </remarks>
        /// <param name="b">The next <see cref="byte"/> from the input stream.</param>
        public void Update(byte b) => updateDelegate(b);

        /// <summary>
        /// Updates the CRC with an array of input data.
        /// </summary>
        /// <param name="data">The next group of <see cref="byte"/>s from the input stream.</param>
        public void Update(byte[] data)
        {
            foreach (byte b in data)
            {
                Update(b);
            }
        }

        /// <summary>
        /// Sets the CRC register to the <see cref="CrcParameters"/>-defined initial value.
        /// </summary>
        public void Reset()
        {
            if (parameters.ReflectInput)
            {
                crcRegister = BitReverser.ReverseValue(parameters.InitialValue, parameters.Width);
            }
            else
            {
                crcRegister = parameters.InitialValue;
            }
        }

        /// <summary>
        /// Updates the CRC using the table-based lookup.
        /// </summary>
        /// <param name="b">The next <see cref="byte"/> from the input stream.</param>
        private void UpdateUsingTable(byte b)
        {
            if (parameters.ReflectInput)
            {
                crcRegister = crcTable[(crcRegister ^ b) & 0xFF] ^ (crcRegister >> 8);
            }
            else
            {
                crcRegister = crcTable[((crcRegister >> (parameters.Width - 8)) ^ b) & 0xFF] ^ (crcRegister << 8);
            }
        }

        /// <summary>
        /// Updates the CRC using manual calculation.
        /// </summary>
        /// <param name="b">The next <see cref="byte"/> from the input stream.</param>
        private void UpdateManually(byte b)
        {
            if (parameters.ReflectInput)
            {
                b = BitReverser.ReverseByte(b);
            }

            crcRegister ^= (ulong)b << (parameters.Width - 8);
            ulong msb = 1UL << (parameters.Width - 1);
            for (int i = 0; i < 8; i++)
            {
                bool xorPoly = (crcRegister & msb) != 0;
                crcRegister <<= 1;
                if (xorPoly)
                {
                    crcRegister ^= parameters.Polynomial;
                }

                crcRegister &= (msb << 1) - 1UL;
            }
        }

        /// <summary>
        /// Generates a table of CRC values to use at calculation time.
        /// </summary>
        /// <returns>A table of 256 CRC values.</returns>
        private ulong[] GenerateTable()
        {
            ulong[] table = new ulong[256];
            ulong msb = 1UL << (parameters.Width - 1);

            for (int b = 0; b < table.Length; b++)
            {
                byte input = (byte)b;
                if (parameters.ReflectInput)
                {
                    input = BitReverser.ReverseByte((byte)b);
                }

                ulong register = (ulong)input << (parameters.Width - 8);
                for (int i = 0; i < 8; i++)
                {
                    bool xorPoly = (register & msb) != 0;
                    register <<= 1;
                    if (xorPoly)
                    {
                        register ^= parameters.Polynomial;
                    }
                }

                if (parameters.ReflectInput)
                {
                    register = BitReverser.ReverseValue(register, parameters.Width);
                }

                table[b] = register & (msb << 1) - 1UL;
            }

            return table;
        }
    }
}

/*
 * Useful Resources:
 * http://www.ross.net/crc/crcpaper.html
 * https://reveng.sourceforge.io/crc-catalogue/
 * https://crccalc.com/
 * https://derekwill.com/2017/03/29/crc-algorithm-implementation-in-c/
 * http://fileformats.archiveteam.org/wiki/CRC-16
 */
