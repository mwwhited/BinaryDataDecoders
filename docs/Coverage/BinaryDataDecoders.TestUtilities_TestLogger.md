# BinaryDataDecoders.TestUtilities.Logging.TestLogger

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.Logging.TestLogger` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                    |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `25`                                                  |
| Coverablelines  | `25`                                                  |
| Totallines      | `75`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `10`                                                  |
| Branchcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 2          | 0     | 0        | `ctor`       |
| 2          | 0     | 0        | `ctor`       |
| 1          | 0     | 100      | `BeginScope` |
| 1          | 0     | 100      | `IsEnabled`  |
| 4          | 0     | 0        | `Log`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Logging/TestLogger.cs

```CSharp
〰1:   using Microsoft.Extensions.Logging;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Diagnostics;
〰5:   
〰6:   namespace BinaryDataDecoders.TestUtilities.Logging
〰7:   {
〰8:       public class TestLogger : ILogger
〰9:       {
〰10:          protected readonly TestContext _context;
〰11:          protected readonly string? _category;
〰12:  
‼13:          public TestLogger(
‼14:              TestContext testContext,
‼15:              string category = null
‼16:              )
〰17:          {
‼18:              _context = testContext;
‼19:              _category = string.IsNullOrWhiteSpace(category) ? null : category;
‼20:          }
〰21:  
‼22:          public TestLogger(
‼23:              ITestContextWrapper contextWrapper,
‼24:              string category = null
‼25:              )
〰26:          {
‼27:              _context = contextWrapper.Context;
‼28:              _category = string.IsNullOrWhiteSpace(category) ? null : category;
‼29:          }
〰30:  
‼31:          public virtual IDisposable BeginScope<TState>(TState state) => new LoggerScope<TState>(state);
‼32:          public virtual bool IsEnabled(LogLevel logLevel) =>true;
〰33:          public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
〰34:          {
〰35:              void WriteMessage(string message)
〰36:              {
‼37:                  if (_context == null)
〰38:                  {
〰39:                      Debug.WriteLine(message);
〰40:                  }
〰41:                  else
〰42:                  {
‼43:                      _context.WriteLine(message);
〰44:                  }
‼45:              }
〰46:  
‼47:              if (formatter != null)
〰48:              {
‼49:                  WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {formatter(state, exception)}");
〰50:              }
〰51:              else
〰52:              {
‼53:                  WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {state}");
‼54:                  if (exception != null)
〰55:                  {
‼56:                      WriteMessage($@"{_category}-ERROR>{logLevel}({eventId}): {exception}");
〰57:                  }
〰58:              }
‼59:          }
〰60:      }
〰61:  
〰62:      public class TestLogger<T> : TestLogger, ILogger<T>
〰63:      {
〰64:          public TestLogger(
〰65:              TestContext testContext
〰66:              ) : base(testContext, typeof(T).FullName)
〰67:          {
〰68:          }
〰69:          public TestLogger(
〰70:              ITestContextWrapper contextWrapper
〰71:              ) : base(contextWrapper, typeof(T).FullName)
〰72:          {
〰73:          }
〰74:      }
〰75:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

