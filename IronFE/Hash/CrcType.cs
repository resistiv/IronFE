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
        /// Represents the CRC-16/XMODEM configuration.
        /// </summary>
        /// <remarks>
        /// See <see href="https://reveng.sourceforge.io/crc-catalogue/16.htm#crc.cat.crc-16-xmodem">CRC-16/XMODEM</see> in the RevEng catalogue.
        /// </remarks>
        Crc16Xmodem,
    }
}
