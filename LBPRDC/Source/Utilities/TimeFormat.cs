namespace LBPRDC.Source.Utilities
{
    internal class TimeFormat
    {
        public static TimeSpan ToTimeSpan(string units, int rawTime)
        {
            if (units == "day(s)")
            {
                return TimeSpan.FromHours(rawTime * 8);
            }
            else if (units == "minute(s)")
            {
                return TimeSpan.FromMinutes(rawTime);
            }
            return TimeSpan.Zero;
        }

        public static TimeSpan ParseTimeString(string timeString)
        {
            bool isNegative = timeString[0] == '-';
            string[] parts = timeString.Substring(1).Split(':');

            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);

            int totalMinutes = (isNegative ? -1 : 1) * (Math.Abs(hours) * 60 + minutes);

            return TimeSpan.FromMinutes(totalMinutes);
        }
    }
}
