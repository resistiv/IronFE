namespace IronFE.Hash
{
    /// <summary>
    /// Represents particular pre-defined CRC parameter configurations.
    /// </summary>
    public enum CrcType
    {
        /// <summary>
        /// Represents the CRC-16/ARC configuration, also known as CRC-16-IBM.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-arc">CRC-16/ARC</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Arc,

        /// <summary>
        /// Represents the CRC-16/CDMA2000 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-cdma2000">CRC-16/CDMA2000</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Cdma2000,

        /// <summary>
        /// Represents the CRC-16/CMS configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-cms">CRC-16/CMS</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Cms,

        /// <summary>
        /// Represents the CRC-16/DDS-110 configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dds-110">CRC-16/DDS-110</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Dds110,

        /// <summary>
        /// Represents the CRC-16/DECT-R configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-dect-r">CRC-16/DECT-R</see> in the RevEng catalogue.
        /// </remarks>
        Crc16DectR,

        /// <summary>
        /// Represents the CRC-16/XMODEM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-xmodem">CRC-16/XMODEM</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Xmodem,
    }
}
