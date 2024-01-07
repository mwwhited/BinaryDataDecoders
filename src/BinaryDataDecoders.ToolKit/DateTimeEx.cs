using System;

namespace BinaryDataDecoders.ToolKit;

public static class DateTimeEx
{
    public static DateTime UnixTimeStampToLocalDateTime(this long unixTimeStamp)
    {
        // http://stackoverflow.com/questions/249760/how-to-convert-unix-timestamp-to-datetime-and-vice-versa 
        // Unix timestamp is seconds past epoch
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }

    public static long LocalDateTimeToUnixTimeStamp(this DateTime time)
    {
        var utc = time.ToUniversalTime();
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        var result = utc.Subtract(dtDateTime);
        return (long)result.TotalSeconds;
    }

    public static int MonthsDifferent(this DateTime ldate, DateTime rdate)
    {
        return (ldate.Month - rdate.Month) + 12 * (ldate.Year - rdate.Year);
    }
    public static int? MonthsDifferent(this DateTime? ldate, DateTime? rdate)
    {
        return (ldate?.Month - rdate?.Month) + 12 * (ldate?.Year - rdate?.Year);
    }

    public static int Days360(this DateTime startDate, DateTime endDate)
    {
        var startDay = startDate.Day;
        var startMonth = startDate.Month;
        var startYear = startDate.Year;
        var endDay = endDate.Day;
        var endMonth = endDate.Month;
        var endYear = endDate.Year;

        if (startDay == 31 || startDate.IsLastDayOfFebruary())
            startDay = 30;

        if (startDay == 30 && endDay == 31)
            endDay = 30;

        return ((endYear - startYear) * 360) + ((endMonth - startMonth) * 30) + (endDay - startDay);
    }

    public static bool IsLastDayOfFebruary(this DateTime date)
    {
        return date.Month == 2 && date.Day == DateTime.DaysInMonth(date.Year, date.Month);
    }
}
