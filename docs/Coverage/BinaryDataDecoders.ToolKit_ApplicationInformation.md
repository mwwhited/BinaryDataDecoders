# BinaryDataDecoders.ToolKit.Reflection.ApplicationInformation

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Reflection.ApplicationInformation` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                   |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `9`                                                            |
| Coverablelines  | `9`                                                            |
| Totallines      | `60`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `6`                                                            |
| Branchcoverage  | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `4`                                                            |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name                           |
| :--------- | :---- | :------- | :----------------------------- |
| 2          | 0     | 0        | `get_ExecutingAssembly`        |
| 2          | 0     | 0        | `get_ExecutingAssemblyVersion` |
| 2          | 0     | 0        | `get_CompileDate`              |
| 1          | 0     | 100      | `RetrieveLinkerTimestamp`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Reflection/ApplicationInformation.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Reflection;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Reflection
〰6:   {
〰7:       // http://blog.codinghorror.com/determining-build-date-the-hard-way/
〰8:       // http://stackoverflow.com/questions/2050396/getting-the-date-of-a-net-assembly
〰9:       public  class ApplicationInformation
〰10:      {
〰11:          /// <summary>
〰12:          /// Gets the executing assembly.
〰13:          /// </summary>
〰14:          /// <value>The executing assembly.</value>
〰15:          public  Assembly ExecutingAssembly
〰16:          {
‼17:              get { return executingAssembly ?? (executingAssembly = Assembly.GetExecutingAssembly()); }
〰18:          }
〰19:          private  Assembly executingAssembly;
〰20:  
〰21:          /// <summary>
〰22:          /// Gets the executing assembly version.
〰23:          /// </summary>
〰24:          /// <value>The executing assembly version.</value>
〰25:          public  Version ExecutingAssemblyVersion
〰26:          {
‼27:              get { return executingAssemblyVersion ?? (executingAssemblyVersion = ExecutingAssembly.GetName().Version); }
〰28:          }
〰29:          private  Version executingAssemblyVersion;
〰30:  
〰31:          /// <summary>
〰32:          /// Gets the compile date of the currently executing assembly.
〰33:          /// </summary>
〰34:          /// <value>The compile date.</value>
〰35:          public  DateTime CompileDate
〰36:          {
‼37:              get { return (compileDate ?? (compileDate = RetrieveLinkerTimestamp(ExecutingAssembly.Location))).Value; }
〰38:          }
〰39:          private  DateTime? compileDate;
〰40:  
〰41:          /// <summary>
〰42:          /// Retrieves the linker timestamp.
〰43:          /// </summary>
〰44:          /// <param name="filePath">The file path.</param>
〰45:          /// <returns></returns>
〰46:          /// <remarks>http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html</remarks>
〰47:          private  DateTime RetrieveLinkerTimestamp(string filePath)
〰48:          {
〰49:              const int peHeaderOffset = 60;
〰50:              const int linkerTimestampOffset = 8;
‼51:              var b = new byte[2048];
‼52:              using (var s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
〰53:              {
‼54:                  s.Read(b, 0, 2048);
‼55:              }
‼56:              var dt = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(BitConverter.ToInt32(b, BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset));
‼57:              return dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
〰58:          }
〰59:      }
〰60:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

