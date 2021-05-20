using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimulationInsight.MathLibrary.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void ConvertFromUnixTimeAndBack()
        {
            // Arrange:
            var dateTime1 = new DateTime(2021, 05, 01, 10, 40, 00, DateTimeKind.Utc);

            dateTime1 = dateTime1.AddMilliseconds(123);

            // Act:
            var unixTime = DateTimeUtilities.ConvertDateTimeToUnixTime(dateTime1);

            var dateTime2 = DateTimeUtilities.ConvertUnixTimeToDateTime(unixTime);

            // Assert:
            Assert.AreEqual(dateTime1, dateTime2);
        }
    }
}