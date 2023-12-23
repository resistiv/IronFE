namespace IronFE.Time
{
    /// <summary>
    /// Represents the order in which a DOS packed date and time are stored in a 32-bit unsigned integer.
    /// </summary>
    public enum DosDateTimeOrder
    {
        /// <summary>
        /// Represents a value where the DOS date is stored within the upper 16 bits and the DOS time is stored within the lower 16 bits.
        /// </summary>
        DateTime,

        /// <summary>
        /// Represents a value where the DOS time is stored within the upper 16 bits and the DOS date is stored within the lower 16 bits.
        /// </summary>
        TimeDate,
    }
}
