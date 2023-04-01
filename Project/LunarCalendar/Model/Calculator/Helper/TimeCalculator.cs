using Calculator.SwissEphemeris;

namespace Calculator
{
    internal class TimeCalculator
    {
        public static double GetJulDay(DateTime utcDate)
        {
            return SwEph.swe_julday(utcDate.Year, utcDate.Month, utcDate.Day, HMS2Hours(utcDate.Hour, utcDate.Minute, utcDate.Second), 1);
        }

        public static DateTime FromJulDay(double julDay)
        {

            SwEph.swe_revjul(julDay, 1, out int year, out int mon, out int day, out double jut);

            var t = jut;
            int hour = (int)t;
            t = (t - hour) * 60;
            int minute = (int)t;
            t = (t - minute) * 60;
            int second = (int)t;

            return new DateTime(year, mon, day, hour, minute, second, DateTimeKind.Unspecified);
        }

        private static double HMS2Hours(int hour, int minute, int second)
        {
            return hour + minute / 60.0 + second / 3600.0;
        }
    }
}
