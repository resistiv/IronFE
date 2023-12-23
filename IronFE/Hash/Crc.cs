using System.Collections.Generic;
using IronFE.Tool;

namespace IronFE.Hash
{
    /// <summary>
    /// Calculates a cyclic redundancy check over data.
    /// </summary>
    public class Crc
    {
        private static readonly Dictionary<CrcParameters, ulong[]> TableDictionary = new();

        private readonly CrcParameters parameters;
        private readonly ulong[] crcTable;
        private ulong crcRegister;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a <see cref="CrcParameters"/> struct.
        /// </summary>
        /// <param name="parameters">A <see cref="CrcParameters"/> struct containing a particular CRC configuration.</param>
        public Crc(CrcParameters parameters)
        {
            this.parameters = parameters;
            Reset();

            // Re-use previously generated tables to reduce construction time
            if (TableDictionary.TryGetValue(parameters, out ulong[]? value))
            {
                crcTable = value;
            }
            else
            {
                crcTable = GenerateTable();
                TableDictionary.Add(parameters, crcTable);
            }
        }

        /// <summary>
        /// Gets the resultant CRC calculated from the input data.
        /// </summary>
        public ulong Result
        {
            get
            {
                if (parameters.ReflectInput ^ parameters.ReflectOutput)
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
        public void Update(byte b)
        {
            if (parameters.ReflectInput)
            {
                crcRegister = crcTable[(crcRegister ^ b) & 0xFF] ^ (crcRegister >> 8);
            }
            else
            {
                crcRegister = crcTable[((crcRegister >> (parameters.Width - 8)) ^ b) & 0xFF] ^ (crcRegister << 8);
            }

            crcRegister &= (((1UL << (parameters.Width - 1)) - 1UL) << 1) | 1;
        }

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
            crcRegister = parameters.InitialValue;

            if (parameters.ReflectInput)
            {
                crcRegister = BitReverser.ReverseValueFast(crcRegister, parameters.Width);
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
            ulong mask = ((msb - 1UL) << 1) | 1;

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
                    if ((register & msb) != 0)
                    {
                        register = (register << 1) ^ parameters.Polynomial;
                    }
                    else
                    {
                        register <<= 1;
                    }
                }

                if (parameters.ReflectInput)
                {
                    register = BitReverser.ReverseValueFast(register, parameters.Width);
                }

                table[b] = register & mask;
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
