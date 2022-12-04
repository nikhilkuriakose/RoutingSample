using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TimeConverter : ITimeConverter
    {
        public Time ConvertTime(Time fromTime, string timeZone)
        {
            try
            {
                DateTime timeToConvert = DateTime.Parse(fromTime.LocalTime);
                return new Time
                {
                    LocalTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(timeToConvert, fromTime.TimeZone, timeZone).ToString(),
                    TimeZone = timeZone
                };
            }
            catch
            {
                return new Time
                {
                    LocalTime = "Error",
                    TimeZone = "Error"
                };
            }
        }
    }
}
