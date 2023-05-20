# BinaryDataDecoders.TestUtilities.Logging.TestLoggerRegistrar

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.Logging.TestLoggerRegistrar` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                             |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `5`                                                            |
| Coverablelines  | `5`                                                            |
| Totallines      | `17`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `2`                                                            |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `1`                                                            |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name                     |
| :--------- | :---- | :------- | :----------------------- |
| 2          | 0     | 0        | `AddTestLoggingServices` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Logging/TestLoggerRegistrar.cs

```CSharp
〰1:   using Microsoft.Extensions.DependencyInjection;
〰2:   using Microsoft.Extensions.Logging;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.TestUtilities.Logging
〰6:   {
〰7:       public static class TestLoggerRegistrar
〰8:       {
〰9:           public static IServiceCollection AddTestLoggingServices(this IServiceCollection services, TestContext context) =>
‼10:              services
‼11:                  .AddTransient<ITestContextWrapper>(sp => new TestContextWrapper(context))
‼12:                  .AddSingleton(sp => LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug).AddDebug()))
‼13:                  .AddSingleton<ILogger, TestLogger>()
‼14:                  .AddSingleton(typeof(ILogger<>), typeof(TestLogger<>))
〰15:              ;
〰16:      }
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

