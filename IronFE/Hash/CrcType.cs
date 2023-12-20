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
