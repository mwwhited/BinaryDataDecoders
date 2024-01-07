# BinaryDataDecoders.ToolKit.Graphics.LightCalculator

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Graphics.LightCalculator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `10`                                                  |
| Coverablelines  | `10`                                                  |
| Totallines      | `37`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `10`                                                  |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `LuxToEv`          |
| 1          | 0     | 100      | `EvToLux`          |
| 1          | 0     | 100      | `GetLux`           |
| 1          | 0     | 100      | `GetEv`            |
| 1          | 0     | 100      | `GetAsa`           |
| 1          | 0     | 100      | `GetFStop`         |
| 1          | 0     | 100      | `GetShutterSpeed`  |
| 1          | 0     | 100      | `GetAsaE`          |
| 1          | 0     | 100      | `GetFStopE`        |
| 1          | 0     | 100      | `GetShutterSpeedE` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Graphics/LightCalculator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Graphics
〰4:   {
〰5:       public static class LightCalculator
〰6:       {
〰7:           public static double LuxToEv(this double lux) =>
‼8:               Math.Round(Math.Log(lux / 2.5d, 2d), 6);
〰9:   
〰10:          public static double EvToLux(this double ev) =>
‼11:              Math.Round(Math.Pow(2, ev) * 2.5, 6);
〰12:  
〰13:          public static double GetLux(double iso, double fStop, double shutterSpeed) =>
‼14:              Math.Round((Math.Pow(fStop, 2) * 250) / (iso * shutterSpeed), 6);
〰15:  
〰16:          public static double GetEv(double iso, double fStop, double shutterSpeed) =>
‼17:              Math.Round(Math.Log((Math.Pow(fStop, 2) * 100) / (iso * shutterSpeed), 2), 6);
〰18:  
〰19:          public static double GetAsa(double fStop, double shutterSpeed, double lux) =>
‼20:              Math.Round((Math.Pow(fStop, 2) * 250) / (lux * shutterSpeed), 2);
〰21:  
〰22:          public static double GetFStop(double iso, double shutterSpeed, double lux) =>
‼23:              Math.Round(Math.Sqrt((lux * shutterSpeed * iso) / 250), 2);
〰24:  
〰25:          public static double GetShutterSpeed(double iso, double fStop, double lux) =>
‼26:              Math.Round((Math.Pow(fStop, 2) * 250) / (lux * iso), 6);
〰27:  
〰28:          public static double GetAsaE(double fStop, double shutterSpeed, double ev) =>
‼29:              Math.Round((Math.Pow(fStop, 2) * 100) / (Math.Pow(2, ev) * shutterSpeed), 2);
〰30:  
〰31:          public static double GetFStopE(double iso, double shutterSpeed, double ev) =>
‼32:              Math.Round(Math.Sqrt((Math.Pow(2, ev) * shutterSpeed * iso) / 100), 2);
〰33:  
〰34:          public static double GetShutterSpeedE(double iso, double fStop, double ev) =>
‼35:              Math.Round((Math.Pow(fStop, 2) * 100) / (Math.Pow(2, ev) * iso), 6);
〰36:      }
〰37:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

