# BinaryDataDecoders.ToolKit.Calculators.LightCalculator

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Calculators.LightCalculator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                             |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `6`                                                      |
| Coverablelines  | `6`                                                      |
| Totallines      | `15`                                                     |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `Lux`      |
| 1          | 0     | 100      | `Iso`      |
| 1          | 0     | 100      | `Aperture` |
| 1          | 0     | 100      | `Shutter`  |
| 1          | 0     | 100      | `Ev`       |
| 1          | 0     | 100      | `A`        |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Calculators\LightCalculator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Calculators
〰4:   {
〰5:       public class LightCalculator
〰6:       {
‼7:           public double Lux(double aperture, double iso, double shutter) => (System.Math.Pow(aperture, 2d) * 250d) / (iso * shutter);
‼8:           public double Iso(double aperture, double lux, double shutter) => (Math.Pow(aperture, 2d) * 250d) / (lux * shutter);
‼9:           public double Aperture(double iso, double lux, double shutter) => Math.Sqrt(lux * shutter / 2.5d * (iso) / 100);
‼10:          public double Shutter(double iso, double lux, double aperture) => Math.Pow(aperture, 2d) * 2.5 / lux * 100 / iso;
〰11:  
‼12:          public double Ev(double lux) => Math.Log(lux / 2.5d, 2d);
‼13:          public double A(double aperture, double shutter) => Math.Log(Math.Pow(aperture, 2d) / shutter, 2d);
〰14:      }
〰15:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

