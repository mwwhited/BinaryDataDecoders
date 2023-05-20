# BinaryDataDecoders.ToolKit.DateTimeEx

## Summary

| Key             | Value                                   |
| :-------------- | :-------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.DateTimeEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`            |
| Coveredlines    | `7`                                     |
| Uncoveredlines  | `14`                                    |
| Coverablelines  | `21`                                    |
| Totallines      | `57`                                    |
| Linecoverage    | `33.3`                                  |
| Coveredbranches | `0`                                     |
| Totalbranches   | `26`                                    |
| Branchcoverage  | `0`                                     |
| Coveredmethods  | `2`                                     |
| Totalmethods    | `6`                                     |
| Methodcoverage  | `33.3`                                  |

## Metrics

| Complexity | Lines | Branches | Name                           |
| :--------- | :---- | :------- | :----------------------------- |
| 1          | 100   | 100      | `UnixTimeStampToLocalDateTime` |
| 1          | 100   | 100      | `LocalDateTimeToUnixTimeStamp` |
| 1          | 0     | 100      | `MonthsDifferent`              |
| 16         | 0     | 0        | `MonthsDifferent`              |
| 8          | 0     | 0        | `Days360`                      |
| 2          | 0     | 0        | `IsLastDayOfFebruary`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/DateTimeEx.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit
〰4:   {
〰5:       public static class DateTimeEx
〰6:       {
〰7:           public static DateTime UnixTimeStampToLocalDateTime(this long unixTimeStamp)
〰8:           {
〰9:               // http://stackoverflow.com/questions/249760/how-to-convert-unix-timestamp-to-datetime-and-vice-versa
〰10:              // Unix timestamp is seconds past epoch
✔11:              var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
✔12:              dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
✔13:              return dtDateTime;
〰14:          }
〰15:  
〰16:          public static long LocalDateTimeToUnixTimeStamp(this DateTime time)
〰17:          {
✔18:              var utc = time.ToUniversalTime();
✔19:              var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
〰20:  
✔21:              var result = utc.Subtract(dtDateTime);
✔22:              return (long)result.TotalSeconds;
〰23:          }
〰24:  
〰25:          public static int MonthsDifferent(this DateTime ldate, DateTime rdate)
〰26:          {
‼27:              return (ldate.Month - rdate.Month) + 12 * (ldate.Year - rdate.Year);
〰28:          }
〰29:          public static int? MonthsDifferent(this DateTime? ldate, DateTime? rdate)
〰30:          {
‼31:              return (ldate?.Month - rdate?.Month) + 12 * (ldate?.Year - rdate?.Year);
〰32:          }
〰33:  
〰34:          public static int Days360(this DateTime startDate, DateTime endDate)
〰35:          {
‼36:              var startDay = startDate.Day;
‼37:              var startMonth = startDate.Month;
‼38:              var startYear = startDate.Year;
‼39:              var endDay = endDate.Day;
‼40:              var endMonth = endDate.Month;
‼41:              var endYear = endDate.Year;
〰42:  
‼43:              if (startDay == 31 || startDate.IsLastDayOfFebruary())
‼44:                  startDay = 30;
〰45:  
‼46:              if (startDay == 30 && endDay == 31)
‼47:                  endDay = 30;
〰48:  
‼49:              return ((endYear - startYear) * 360) + ((endMonth - startMonth) * 30) + (endDay - startDay);
〰50:          }
〰51:  
〰52:          public static bool IsLastDayOfFebruary(this DateTime date)
〰53:          {
‼54:              return date.Month == 2 && date.Day == DateTime.DaysInMonth(date.Year, date.Month);
〰55:          }
〰56:      }
〰57:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

