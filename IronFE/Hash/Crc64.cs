namespace IronFE.Hash
{
    /// <summary>
    /// Stores pre-defined CRC-64 parameter configurations.
    /// </summary>
    public static class Crc64
    {
        /// <summary>
        /// Gets the CRC-64/ECMA-182 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-ecma-182">CRC-64/ECMA-182</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Ecma182
        {
            get
            {
                return new("CRC-64/ECMA-182", 64, 0x42F0E1EBA9EA3693, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-64/GO-ISO configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-go-iso">CRC-64/GO-ISO</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters GoIso
        {
            get
            {
                return new("CRC-64/GO-ISO", 64, 0x000000000000001B, 0xFFFFFFFFFFFFFFFF, true, true, 0xFFFFFFFFFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-64/MS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-ms">CRC-64/MS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Ms
        {
            get
            {
                return new("CRC-64/MS", 64, 0x259C84CBA6426349, 0xFFFFFFFFFFFFFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-64/REDIS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-redis">CRC-64/REDIS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Redis
        {
            get
            {
                return new("CRC-64/REDIS", 64, 0xAD93D23594C935A9, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-64/WE configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-we">CRC-64/WE</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters We
        {
            get
            {
                return new("CRC-64/WE", 64, 0x42F0E1EBA9EA3693, 0xFFFFFFFFFFFFFFFF, false, false, 0xFFFFFFFFFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-64/XZ configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-64-xz">CRC-64/XZ</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Xz
        {
            get
            {
                return new("CRC-64/XZ", 64, 0x42F0E1EBA9EA3693, 0xFFFFFFFFFFFFFFFF, true, true, 0xFFFFFFFFFFFFFFFF);
            }
        }
    }
}
