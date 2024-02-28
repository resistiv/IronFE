using System;

namespace IronFE.Time
{
    /// <summary>
    /// Handles HFS+ date/time conversions.
    /// </summary>
    public static class HfsPlusDateTime
    {
        private static readonly DateTime MinDateTime = new(1904, 1, 1, 0, 0, 0);
        private static readonly DateTime MaxDateTime = new(2040, 2, 6, 6, 28, 15);

        /// <summary>
        /// Converts the current <see cref="DateTime"/> object to an HFS+ date and time.
        /// </summary>
        /// <param name="dateTime">A <see cref="DateTime"/>.</param>
        /// <returns>A 32-bit unsigned integer representing the converted <see cref="DateTime"/> as the number of seconds since 1904/01/01 00:00:00.</returns>
        public static uint ToHfsPlusDateTime(this DateTime dateTime)
        {
            if (dateTime < MinDateTime)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), string.Format(Properties.Strings.HfsPlusDateTimeOutOfRangeMin, MinDateTime));
            }
            else if (dateTime > MaxDateTime)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), string.Format(Properties.Strings.HfsPlusDateTimeOutOfRangeMax, MaxDateTime));
            }

            return (uint)dateTime.Subtract(MinDateTime).TotalSeconds;
        }

        /// <summary>
        /// Converts an HFS+ date and time into a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="hfsPlusDateTime">A 32-bit unsigned integer representing the number of seconds since 1904/01/01 00:00:00.</param>
        /// <returns>A <see cref="DateTime"/> representing the HFS+ date and time.</returns>
        public static DateTime ToDateTime(uint hfsPlusDateTime)
            => MinDateTime.Add(TimeSpan.FromSeconds(hfsPlusDateTime));
    }
}
