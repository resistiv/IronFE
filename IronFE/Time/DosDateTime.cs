using System;

namespace IronFE.Time
{
    /// <summary>
    /// Handles DOS date/time conversions.
    /// </summary>
    public static class DosDateTime
    {
        private static readonly DateTime MinDateTime = new(1980, 1, 1, 0, 0, 0);
        private static readonly DateTime MaxDateTime = new(2107, 12, 31, 23, 59, 58);

        /// <summary>
        /// Converts the date component of the current <see cref="DateTime"/> object to a DOS packed date.
        /// </summary>
        /// <param name="dateTime">A <see cref="DateTime"/>.</param>
        /// <returns>A 16-bit unsigned integer that encodes the <see cref="DateTime.Year"/>, <see cref="DateTime.Month"/>, and <see cref="DateTime.Day"/> properties.</returns>
        public static ushort ToDosDate(this DateTime dateTime)
        {
            // Outside of supported DOS date range
            if (dateTime.Date < MinDateTime.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), "Cannot convert a date earlier than 1980/01/01 to DOS format.");
            }
            else if (dateTime.Date > MaxDateTime.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), "Cannot convert a date later than 2107/12/31 to DOS format.");
            }

            ushort outDate = 0;

            outDate |= (ushort)(((dateTime.Year - MinDateTime.Year) & 0x7F) << 9);
            outDate |= (ushort)((dateTime.Month & 0xF) << 5);
            outDate |= (ushort)(dateTime.Day & 0x1F);

            return outDate;
        }

        /// <summary>
        /// Converts the time component of the current <see cref="DateTime"/> object to a DOS packed time.
        /// </summary>
        /// <remarks>
        /// This method will result in a lossy conversion of seconds because the DOS format stores seconds in increments of 2 rather than 1.
        /// </remarks>
        /// <param name="dateTime">A <see cref="DateTime"/>.</param>
        /// <returns>A 16-bit unsigned integer that encodes the <see cref="DateTime.Hour"/>, <see cref="DateTime.Minute"/>, and <see cref="DateTime.Second"/> properties.</returns>
        public static ushort ToDosTime(this DateTime dateTime)
        {
            ushort outTime = 0;

            outTime |= (ushort)((dateTime.Hour & 0x1F) << 11);
            outTime |= (ushort)((dateTime.Minute & 0x3F) << 5);
            outTime |= (ushort)((dateTime.Second / 2) & 0x1F);

            return outTime;
        }

        /// <summary>
        /// Converts the current <see cref="DateTime"/> object to a DOS packed date and time.
        /// </summary>
        /// <remarks>
        /// This method will result in a lossy conversion of seconds because the DOS format stores seconds in increments of 2 rather than 1.
        /// </remarks>
        /// <param name="dateTime">A <see cref="DateTime"/>.</param>
        /// <param name="order">The order in which the date and time are stored within the encoded DOS date time.</param>
        /// <returns>A 32-bit unsigned integer that encodes the <see cref="DateTime.Year"/>, <see cref="DateTime.Month"/>, <see cref="DateTime.Day"/>, <see cref="DateTime.Hour"/>, <see cref="DateTime.Minute"/>, and <see cref="DateTime.Second"/> properties.</returns>
        public static uint ToDosDateTime(this DateTime dateTime, DosDateTimeOrder order)
        {
            ushort date = dateTime.ToDosDate();
            ushort time = dateTime.ToDosTime();

            return order switch
            {
                DosDateTimeOrder.DateTime => ((uint)date << 16) | time,
                DosDateTimeOrder.TimeDate => ((uint)time << 16) | date,
                _ => throw new ArgumentException("Invalid DosDateTimeOrder."),
            };
        }

        /// <summary>
        /// Converts a DOS packed date component into a standard <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dosDate">A DOS packed date component.</param>
        /// <returns>A <see cref="DateTime"/> representing the DOS date.</returns>
        public static DateTime DateToDateTime(ushort dosDate)
        {
            int year = ((dosDate >> 9) & 0x7F) + 1980;
            int month = (dosDate >> 5) & 0x0F;
            int day = dosDate & 0x1F;

            // Some formats incorrectly utilize a blank month and date, so set to 1 for compatibility.
            if (month == 0)
            {
                month = 1;
            }

            if (day == 0)
            {
                day = 1;
            }

            // Bounds checking is left to the DateTime constructor
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Converts a DOS packed time component into a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="dosTime">A DOS packed time component.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the DOS time.</returns>
        public static TimeSpan TimeToTimeSpan(ushort dosTime)
        {
            int hour = (dosTime >> 11) & 0x1F;
            int minute = (dosTime >> 5) & 0x3F;
            int second = (dosTime & 0x1F) * 2;

            // Bounds checking is left to the TimeSpan constructor
            return new TimeSpan(hour, minute, second);
        }

        /// <summary>
        /// Converts a DOS packed date and time into a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dosDate">A DOS packed date component.</param>
        /// <param name="dosTime">A DOS packed time component.</param>
        /// <returns>A <see cref="DateTime"/> representing the DOS date and time.</returns>
        public static DateTime ToDateTime(ushort dosDate, ushort dosTime)
            => DateToDateTime(dosDate) + TimeToTimeSpan(dosTime);

        /// <summary>
        /// Converts a DOS packed date and time into a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dosDateTime">A DOS packed date and time.</param>
        /// <param name="order">The order in which the date and time are stored within <paramref name="dosDateTime"/>.</param>
        /// <returns>A <see cref="DateTime"/> representing the DOS date and time.</returns>
        public static DateTime ToDateTime(uint dosDateTime, DosDateTimeOrder order)
            => DateToDateTime((ushort)(((order == DosDateTimeOrder.DateTime) ? (dosDateTime >> 16) : dosDateTime) & 0xFFFF)) +
               TimeToTimeSpan((ushort)(((order == DosDateTimeOrder.DateTime) ? dosDateTime : (dosDateTime >> 16)) & 0xFFFF));
    }
}

/*
 * Useful Resources:
 * https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-filetimetodosdatetime
 * http://fileformats.archiveteam.org/wiki/MS-DOS_date/time
 */

/*
 *         Year offset from 1980              Month                  Day
 *     ┌────────────────────────────┐     ┌─────────────┐     ┌──────────────────┐
 * ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐
 * │ 15 │ 14 │ 13 │ 12 │ 11 │ 10 │  9 │  8 │  7 │  6 │  5 │  4 │  3 │  2 │  1 │  0 │
 * └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘
 *         Hour (24 HR)                   Minute                  Seconds (/2)
 *     ┌──────────────────┐     ┌───────────────────────┐     ┌──────────────────┐
 * ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐
 * │ 15 │ 14 │ 13 │ 12 │ 11 │ 10 │  9 │  8 │  7 │  6 │  5 │  4 │  3 │  2 │  1 │  0 │
 * └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘
 */
