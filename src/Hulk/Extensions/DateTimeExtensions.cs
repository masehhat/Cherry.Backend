using System;

namespace Hulk.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTime(this DateTime dateTime)
        {
            return Convert.ToInt32(dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }

        public static DateTime UnixTimeToDateTime(this int unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
        }
    }
}