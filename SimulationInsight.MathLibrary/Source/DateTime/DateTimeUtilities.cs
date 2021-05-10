using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.MathLibrary
{
    public static class DateTimeUtilities
    {
        public static DateTime ConvertUnixTimeToDataTime(double unixEpochTime)
        {
            var unixEpochTimeSeconds = (int)unixEpochTime;
            var unixEpochTimeRemainder = Math.IEEERemainder(unixEpochTime, 1.0);
            var unixEpochTimeMilliseconds = (int)(unixEpochTimeRemainder * 1e6);

            var dateTime = new DateTime(1970, 1, 1).AddSeconds(unixEpochTimeSeconds);

            dateTime = dateTime.AddMilliseconds(unixEpochTimeMilliseconds);

            return dateTime;
        }
    }
}
