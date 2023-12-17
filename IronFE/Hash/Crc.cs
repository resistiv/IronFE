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
                    CrcType.Crc16Xmodem,
                    new("CRC-16/XMODEM", 16, 0x1021, 0UL, false, false, 0UL)
                },
            }.ToFrozenDictionary();

        private readonly CrcParameters parameters;
        private ulong crcRegister;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a pre-defined CRC configuration, identified by its <see cref="CrcType"/>.
        /// </summary>
        /// <param name="type">A <see cref="CrcType"/> corresponding to a pre-defined CRC configuration.</param>
        public Crc(CrcType type)
        {
            if (PredefinedCrcs.TryGetValue(type, out CrcParameters param))
            {
                parameters = param;
                crcRegister = parameters.InitialValue;
            }
            else
            {
                throw new ArgumentException("The provided CrcType was not found to belong to a pre-defined CRC.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a user-defined instance of <see cref="CrcParameters"/>.
        /// </summary>
        /// <param name="parameters">A user-defined <see cref="CrcParameters"/> instance containing a particular CRC configuration.</param>
        public Crc(CrcParameters parameters)
        {
            this.parameters = parameters;
            crcRegister = this.parameters.InitialValue;
        }

        /// <summary>
        /// Gets the resultant CRC calculated from the input data.
        /// </summary>
        public ulong Result
        {
            get
            {
                if (parameters.ReflectOutput)
                {
                    // Optimize common cases with table-based reverses to improve runtime
                    var result = parameters.Width switch
                    {
                         8 => BitReverser.ReverseByte((byte)(crcRegister & 0xFF)),
                        16 => BitReverser.ReverseUInt16((ushort)(crcRegister & 0xFFFF)),
                        32 => BitReverser.ReverseUInt32((uint)(crcRegister & 0xFFFFFFFF)),
                        64 => BitReverser.ReverseUInt64(crcRegister),
                         _ => BitReverser.ReverseValue(crcRegister, parameters.Width),
                    };
                    return parameters.OutputXor ^ result;
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
        /// <param name="b">The next <see cref="byte"/> in the input stream.</param>
        public void UpdateCrc(byte b)
        {
            if (parameters.ReflectInput)
            {
                b = BitReverser.ReverseByte(b);
            }

            crcRegister ^= (ulong)b << (parameters.Width - 8);
            ulong msb = 1UL << (parameters.Width - 1);
            for (int i = 0; i < 8; i++)
            {
                crcRegister <<= 1;
                if ((crcRegister & msb) != 0)
                {
                    crcRegister ^= parameters.Polynomial;
                }

                // crcRegister &= (1UL << parameters.Width) - 1UL;
                crcRegister &= (msb << 1) - 1UL;
            }
        }
    }
}

/*
 * Useful Resources:
 * http://www.ross.net/crc/crcpaper.html
 * https://reveng.sourceforge.io/crc-catalogue/
 */
