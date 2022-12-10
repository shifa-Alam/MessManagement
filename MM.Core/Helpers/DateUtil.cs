namespace MessManagement.Core.Helpers
{
   
    public static class DateUtil
    {
        public static DateTime StartOfTheDay(this DateTime d) => new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
        public static DateTime EndOfTheDay(this DateTime d) => new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
    }
}
