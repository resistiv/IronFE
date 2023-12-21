namespace IronFE.Hash
{
    /// <summary>
    /// Stores pre-defined CRC-32 parameter configurations.
    /// </summary>
    public static class Crc32
    {
        /// <summary>
        /// Gets the CRC-32/AIXM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-aixm">CRC-32/AIXM</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Aixm
        {
            get
            {
                return new("CRC-32/AIXM", 32, 0x814141AB, 0UL, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-32/AUTOSAR configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-autosar">CRC-32/AUTOSAR</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Autosar
        {
            get
            {
                return new("CRC-32/AUTOSAR", 32, 0xF4ACFB13, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/BASE91-D configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-base91-d">CRC-32/BASE91-D</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Base91D
        {
            get
            {
                return new("CRC-32/BASE91-D", 32, 0xA833982B, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/BZIP2 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-bzip2">CRC-32/BZIP2</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Bzip2
        {
            get
            {
                return new("CRC-32/BZIP2", 32, 0x04C11DB7, 0xFFFFFFFF, false, false, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/CD-ROM-EDC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-cd-rom-edc">CRC-32/CD-ROM-EDC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters CdRomEdc
        {
            get
            {
                return new("CRC-32/CD-ROM-EDC", 32, 0x8001801B, 0UL, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-32/CKSUM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-cksum">CRC-32/CKSUM</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Cksum
        {
            get
            {
                return new("CRC-32/CKSUM", 32, 0x04C11DB7, 0UL, false, false, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/ISCSI configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-iscsi">CRC-32/ISCSI</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Iscsi
        {
            get
            {
                return new("CRC-32/ISCSI", 32, 0x1EDC6F41, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/ISO-HDLC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-iso-hdlc">CRC-32/ISO-HDLC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters IsoHdlc
        {
            get
            {
                return new("CRC-32/ISO-HDLC", 32, 0x04C11DB7, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
            }
        }

        /// <summary>
        /// Gets the CRC-32/JAMCRC configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-jamcrc">CRC-32/JAMCRC</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters JamCrc
        {
            get
            {
                return new("CRC-32/JAMCRC", 32, 0x04C11DB7, 0xFFFFFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-32/MEF configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-mef">CRC-32/MEF</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Mef
        {
            get
            {
                return new("CRC-32/MEF", 32, 0x741B8CD7, 0xFFFFFFFF, true, true, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-32/MPEG-2 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-mpeg-2">CRC-32/MPEG-2</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Mpeg2
        {
            get
            {
                return new("CRC-32/MPEG-2", 32, 0x04C11DB7, 0xFFFFFFFF, false, false, 0UL);
            }
        }

        /// <summary>
        /// Gets the CRC-32/XFER configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/17plus.htm#crc.cat.crc-32-xfer">CRC-32/XFER</see> in the RevEng catalogue.
        /// </remarks>
        public static CrcParameters Xfer
        {
            get
            {
                return new("CRC-32/XFER", 32, 0x000000AF, 0UL, false, false, 0UL);
            }
        }
    }
}
