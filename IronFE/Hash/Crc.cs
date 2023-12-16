using System;
using System.Collections.Frozen;
using System.Collections.Generic;

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
                    new("CRC-16-ARC", 16, 0x8005, 0UL, true, true, 0UL)
                },
                {
                    CrcType.Crc16Ccitt,
                    new("CRC-16-CCITT", 16, 0x1021, 0xFFFF, false, false, 0UL)
                },
            }.ToFrozenDictionary();

        private readonly CrcParameters parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crc"/> class with a pre-defined CRC configuration, identified by its <see cref="CrcType"/>.
        /// </summary>
        /// <param name="type">A <see cref="CrcType"/> corresponding to a pre-defined CRC configuration.</param>
        public Crc(CrcType type)
        {
            if (PredefinedCrcs.TryGetValue(type, out CrcParameters param))
            {
                parameters = param;
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
        }
    }
}

/*
 * Useful Resources:
 * http://www.ross.net/crc/crcpaper.html
 */
