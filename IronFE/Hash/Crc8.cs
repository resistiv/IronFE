namespace IronFE.Hash
{
    /// <summary>
    /// Stores pre-defined CRC-8 parameter configurations.
    /// </summary>
    /// <remarks>
    /// Adapted from Greg Cook's <see href="https://reveng.sourceforge.io/crc-catalogue/">Catalogue of parametrised CRC algorithms</see>.
    /// </remarks>
    public static class Crc8
    {
        /// <summary>
        /// Gets the CRC-8/AUTOSAR configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-autosar">CRC-8/AUTOSAR</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Autosar
        {
            get
            {
                return new("CRC-8/AUTOSAR", 8, 0x2F, 0xFF, false, false, 0xFF);
            }
        }

        /// <summary>
        /// Gets the CRC-8/BLUETOOTH configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-bluetooth">CRC-8/BLUETOOTH</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Bluetooth
        {
            get
            {
                return new("CRC-8/BLUETOOTH", 8, 0xA7, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/CDMA2000 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-cdma2000">CRC-8/CDMA2000</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Cdma2000
        {
            get
            {
                return new("CRC-8/CDMA2000", 8, 0x9B, 0xFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/DARC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-darc">CRC-8/DARC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Darc
        {
            get
            {
                return new("CRC-8/DARC", 8, 0x39, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/DVB-S2 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-dvb-s2">CRC-8/DVB-S2</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters DvbS2
        {
            get
            {
                return new("CRC-8/DVB-S2", 8, 0xD5, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/GSM-A configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-gsm-a">CRC-8/GSM-A</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters GsmA
        {
            get
            {
                return new("CRC-8/GSM-A", 8, 0x1D, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/GSM-B configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-gsm-b">CRC-8/GSM-B</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters GsmB
        {
            get
            {
                return new("CRC-8/GSM-B", 8, 0x49, 0UL, false, false, 0xFF);
            }
        }

        /// <summary>
        /// Gets the CRC-8/HITAG configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-hitag">CRC-8/HITAG</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Hitag
        {
            get
            {
                return new("CRC-8/HITAG", 8, 0x1D, 0xFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/I-432-1 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-i-432-1">CRC-8/I-432-1</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters I4321
        {
            get
            {
                return new("CRC-8/I-432-1", 8, 0x07, 0UL, false, false, 0x55);
            }
        }

        /// <summary>
        /// Gets the CRC-8/I-CODE configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-i-code">CRC-8/I-CODE</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters ICode
        {
            get
            {
                return new("CRC-8/I-CODE", 8, 0x1D, 0xFD, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/LTE configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-lte">CRC-8/LTE</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Lte
        {
            get
            {
                return new("CRC-8/LTE", 8, 0x9B, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/MAXIM-DOW configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-maxim-dow">CRC-8/MAXIM-DOW</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters MaximDow
        {
            get
            {
                return new("CRC-8/MAXIM-DOW", 8, 0x31, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/MIFARE-MAD configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-mifare-mad">CRC-8/MIFARE-MAD</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters MifareMad
        {
            get
            {
                return new("CRC-8/MIFARE-MAD", 8, 0x1D, 0xC7, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/NRSC-5 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-nrsc-5">CRC-8/NRSC-5</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Nrsc5
        {
            get
            {
                return new("CRC-8/NRSC-5", 8, 0x31, 0xFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/OPENSAFETY configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-opensafety">CRC-8/OPENSAFETY</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters OpenSafety
        {
            get
            {
                return new("CRC-8/OPENSAFETY", 8, 0x2F, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/ROHC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-rohc">CRC-8/ROHC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Rohc
        {
            get
            {
                return new("CRC-8/OPENSAFETY", 8, 0x07, 0xFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/SAE-J1850 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-sae-j1850">CRC-8/SAE-J1850</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters SaeJ1850
        {
            get
            {
                return new("CRC-8/SAE-J1850", 8, 0x1D, 0xFF, false, false, 0xFF);
            }
        }

        /// <summary>
        /// Gets the CRC-8/SMBUS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-smbus">CRC-8/SMBUS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters SmBus
        {
            get
            {
                return new("CRC-8/SMBUS", 8, 0x07, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/TECH-3250 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-tech-3250">CRC-8/TECH-3250</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Tech3250
        {
            get
            {
                return new("CRC-8/TECH-3250", 8, 0x1D, 0xFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-8/WCDMA configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/1-15.htm#crc.cat.crc-8-wcdma">CRC-8/WCDMA</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Wcdma
        {
            get
            {
                return new("CRC-8/WCDMA", 8, 0x9B, 0UL, true, true, 0UL);
            }
        }
    }
}
