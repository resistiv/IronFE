using System;
using IronFE.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.TimeTests
{
    /// <summary>
    /// Tests functionality of the <see cref="Time.HfsPlusDateTime"/> class.
    /// </summary>
    [TestClass]
    public class HfsPlusDateTimeTests
    {
        // Timestamp taken from the MacBinary file on this page: https://www.macintoshrepository.org/479-binhex-4-0
        private const uint HfsPlusDateTime = 0x9898231B;

        // Converted using https://www.epochconverter.com/mac
        private static readonly DateTime ConvertedDateTime = new(1985, 2, 14, 20, 54, 51);

        /// <summary>
        /// Tests functionality of the <see cref="HfsPlusDateTime.ToHfsPlusDateTime(DateTime)"/> extension method.
        /// </summary>
        [TestMethod]
        public void ToHfsPlusDateTime()
        {
            uint dateTime = ConvertedDateTime.ToHfsPlusDateTime();
            Assert.AreEqual(HfsPlusDateTime, dateTime);
        }

        /// <summary>
        /// Tests functionality of the <see cref="HfsPlusDateTime.ToHfsPlusDateTime(DateTime)"/> extension method when given a date and time below the minimum HFS+ date and time.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToHfsPlusDateTimeBelowMin()
        {
            new DateTime(1903, 12, 31, 23, 59, 59).ToHfsPlusDateTime();
        }

        /// <summary>
        /// Tests functionality of the <see cref="HfsPlusDateTime.ToHfsPlusDateTime(DateTime)"/> extension method when given a date and time above the maximum HFS+ date and time.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToHfsPlusDateTimeAboveMax()
        {
            new DateTime(2040, 2, 6, 6, 28, 16).ToHfsPlusDateTime();
        }

        /// <summary>
        /// Tests functionality of the <see cref="HfsPlusDateTime.ToDateTime(uint)"/> method.
        /// </summary>
        [TestMethod]
        public void ToDateTime()
        {
            DateTime dateTime = Time.HfsPlusDateTime.ToDateTime(HfsPlusDateTime);
            Assert.AreEqual(ConvertedDateTime, dateTime);
        }
    }
}
