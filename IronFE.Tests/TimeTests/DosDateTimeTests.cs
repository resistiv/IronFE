using System;
using IronFE.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronFE.Tests.TimeTests
{
    /// <summary>
    /// Tests functionality of the <see cref="Time.DosDateTime"/> class.
    /// </summary>
    [TestClass]
    public class DosDateTimeTests
    {
        // Date and time taken from first entry of this ZOO file: http://cd.textfiles.com/geminiatari/ZIP/PROGRAM/ARP68PIX.ZOO
        private const uint DosTimeDate = 0x3D150B74;
        private const uint DosDateTime = 0x0B743D15;
        private const ushort DosDate = 0x0B74;
        private const ushort DosTime = 0x3D15;

        // Converted using HxD's implementation
        private static readonly DateTime ConvertedDateTime = new(1985, 11, 20, 7, 40, 42);

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDosDate(DateTime)"/> extension method.
        /// </summary>
        [TestMethod]
        public void ToDosDate()
        {
            ushort date = ConvertedDateTime.ToDosDate();
            Assert.AreEqual(DosDate, date);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDosDate(DateTime)"/> extension method when given a date below the minimum DOS date.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDosDateBelowMin()
        {
            new DateTime(1979, 12, 31).ToDosDate();
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDosDate(DateTime)"/> extension method when given a date above the maximum DOS date.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDosDateAboveMax()
        {
            new DateTime(2108, 1, 1).ToDosDate();
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDosTime(DateTime)"/> extension method.
        /// </summary>
        [TestMethod]
        public void ToDosTime()
        {
            ushort time = ConvertedDateTime.ToDosTime();
            Assert.AreEqual(DosTime, time);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDosDateTime(DateTime, DosDateTimeOrder)"/> extension method.
        /// </summary>
        [TestMethod]
        public void ToDosDateTime()
        {
            uint dateTime = ConvertedDateTime.ToDosDateTime(DosDateTimeOrder.DateTime);
            uint timeDate = ConvertedDateTime.ToDosDateTime(DosDateTimeOrder.TimeDate);
            Assert.AreEqual(DosDateTime, dateTime);
            Assert.AreEqual(DosTimeDate, timeDate);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.DateToDateTime(ushort)"/> method.
        /// </summary>
        [TestMethod]
        public void DateToDateTime()
        {
            DateTime date = Time.DosDateTime.DateToDateTime(DosDate);
            Assert.AreEqual(ConvertedDateTime.Date, date);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.TimeToTimeSpan(ushort)"/> method.
        /// </summary>
        [TestMethod]
        public void TimeToTimeSpan()
        {
            TimeSpan time = Time.DosDateTime.TimeToTimeSpan(DosTime);
            Assert.AreEqual(ConvertedDateTime.TimeOfDay, time);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDateTime(ushort, ushort)"/> method.
        /// </summary>
        [TestMethod]
        public void ToDateTime()
        {
            DateTime dateTime = Time.DosDateTime.ToDateTime(DosDate, DosTime);
            Assert.AreEqual(ConvertedDateTime, dateTime);
        }

        /// <summary>
        /// Tests functionality of the <see cref="DosDateTime.ToDateTime(uint, DosDateTimeOrder)"/> method.
        /// </summary>
        [TestMethod]
        public void ToDateTimeWithOrder()
        {
            DateTime dateTime = Time.DosDateTime.ToDateTime(DosDateTime, DosDateTimeOrder.DateTime);
            DateTime timeDate = Time.DosDateTime.ToDateTime(DosTimeDate, DosDateTimeOrder.TimeDate);
            Assert.AreEqual(ConvertedDateTime, dateTime);
            Assert.AreEqual(ConvertedDateTime, timeDate);
        }
    }
}
