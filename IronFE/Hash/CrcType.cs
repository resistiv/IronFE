namespace IronFE.Hash
{
    /// <summary>
    /// Gets particular pre-defined CRC parameter configurations.
    /// </summary>
    public static class CrcType
    {
        /// <summary>
        /// Gets the CRC-16/ARC configuration, also known as CRC-16-IBM.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-arc">CRC-16/ARC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Arc
        {
            get
            {
                return new("CRC-16/ARC", 16, 0x8005, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/CDMA2000 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-cdma2000">CRC-16/CDMA2000</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Cdma2000
        {
            get
            {
                return new("CRC-16/CDMA2000", 16, 0xC867, 0xFFFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/CMS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-cms">CRC-16/CMS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Cms
        {
            get
            {
                return new("CRC-16/CMS", 16, 0x8005, 0xFFFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/DDS-110 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dds-110">CRC-16/DDS-110</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Dds110
        {
            get
            {
                return new("CRC-16/DDS-110", 16, 0x8005, 0x800D, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/DECT-R configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dect-r">CRC-16/DECT-R</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16DectR
        {
            get
            {
                return new("CRC-16/DECT-R", 16, 0x0589, 0UL, false, false, 0x0001);
            }
        }

        /// <summary>
        /// Gets the CRC-16/DECT-X configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dect-x">CRC-16/DECT-X</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16DectX
        {
            get
            {
                return new("CRC-16/DECT-X", 16, 0x0589, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/DNP configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dnp">CRC-16/DNP</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Dnp
        {
            get
            {
                return new("CRC-16/DNP", 16, 0x3D65, 0UL, true, true, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/EN-13757 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-en-13757">CRC-16/EN-13757</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16En13757
        {
            get
            {
                return new("CRC-16/EN-13757", 16, 0x3D65, 0UL, false, false, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/GENIBUS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-genibus">CRC-16/GENIBUS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Genibus
        {
            get
            {
                return new("CRC-16/GENIBUS", 16, 0x1021, 0xFFFF, false, false, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/GSM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-gsm">CRC-16/GSM</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Gsm
        {
            get
            {
                return new("CRC-16/GSM", 16, 0x1021, 0UL, false, false, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/IBM-3740 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-ibm-3740">CRC-16/IBM-3740</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Ibm3740
        {
            get
            {
                return new("CRC-16/IBM-3740", 16, 0x1021, 0xFFFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/IBM-SDLC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-ibm-sdlc">CRC-16/IBM-SDLC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16IbmSdlc
        {
            get
            {
                return new("CRC-16/IBM-SDLC", 16, 0x1021, 0xFFFF, true, true, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/ISO-IEC-14443-3-A configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-iso-iec-14443-3-a">CRC-16/ISO-IEC-14443-3-A</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16IsoIec144433A
        {
            get
            {
                return new("CRC-16/ISO-IEC-14443-3-A", 16, 0x1021, 0xC6C6, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/KERMIT configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-kermit">CRC-16/KERMIT</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Kermit
        {
            get
            {
                return new("CRC-16/KERMIT", 16, 0x1021, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/LJ1200 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-lj1200">CRC-16/LJ1200</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Lj1200
        {
            get
            {
                return new("CRC-16/LJ1200", 16, 0x6F63, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/M17 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-m17">CRC-16/M17</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16M17
        {
            get
            {
                return new("CRC-16/M17", 16, 0x5935, 0xFFFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/MAXIM-DOW configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-maxim-dow">CRC-16/MAXIM-DOW</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16MaximDow
        {
            get
            {
                return new("CRC-16/MAXIM-DOW", 16, 0x8005, 0UL, true, true, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/MCRF4XX configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-mcrf4xx">CRC-16/MCRF4XX</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Mcrf4xx
        {
            get
            {
                return new("CRC-16/MCRF4XX", 16, 0x1021, 0xFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/MODBUS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-modbus">CRC-16/MODBUS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Modbus
        {
            get
            {
                return new("CRC-16/MODBUS", 16, 0x8005, 0xFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/NRSC-5 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-nrsc-5">CRC-16/NRSC-5</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Nrsc5
        {
            get
            {
                return new("CRC-16/NRSC-5", 16, 0x080B, 0xFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/OPENSAFETY-A configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-opensafety-a">CRC-16/OPENSAFETY-A</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16OpenSafetyA
        {
            get
            {
                return new("CRC-16/OPENSAFETY-A", 16, 0x5935, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/OPENSAFETY-B configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-opensafety-b">CRC-16/OPENSAFETY-A</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16OpenSafetyB
        {
            get
            {
                return new("CRC-16/OPENSAFETY-B", 16, 0x755B, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/PROFIBUS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-profibus">CRC-16/PROFIBUS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Profibus
        {
            get
            {
                return new("CRC-16/PROFIBUS", 16, 0x1DCF, 0xFFFF, false, false, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/RIELLO configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-riello">CRC-16/RIELLO</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Riello
        {
            get
            {
                return new("CRC-16/RIELLO", 16, 0x1021, 0xB2AA, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/SPI-FUJITSU configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-spi-fujitsu">CRC-16/SPI-FUJITSU</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16SpiFujitsu
        {
            get
            {
                return new("CRC-16/SPI-FUJITSU", 16, 0x1021, 0x1D0F, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/T10-DIF configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-t10-dif">CRC-16/T10-DIF</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16T10Dif
        {
            get
            {
                return new("CRC-16/T10-DIF", 16, 0x8BB7, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/TELEDISK configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-teledisk">CRC-16/TELEDISK</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Teledisk
        {
            get
            {
                return new("CRC-16/TELEDISK", 16, 0xA097, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/TMS37157 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-tms37157">CRC-16/TMS37157</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Tms37157
        {
            get
            {
                return new("CRC-16/TMS37157", 16, 0x1021, 0x89EC, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/UMTS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-umts">CRC-16/UMTS</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Umts
        {
            get
            {
                return new("CRC-16/UMTS", 16, 0x8005, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-16/USB configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-usb">CRC-16/USB</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Usb
        {
            get
            {
                return new("CRC-16/USB", 16, 0x8005, 0xFFFF, true, true, 0xFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-16/XMODEM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-xmodem">CRC-16/XMODEM</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Crc16Xmodem
        {
            get
            {
                return new("CRC-16/XMODEM", 16, 0x1021, 0UL, false, false, 0UL);
            }
        }
    }
}
