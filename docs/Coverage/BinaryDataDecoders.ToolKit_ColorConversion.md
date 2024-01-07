# BinaryDataDecoders.ToolKit.Graphics.ColorConversion

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Graphics.ColorConversion` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `96`                                                  |
| Coverablelines  | `96`                                                  |
| Totallines      | `146`                                                 |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `36`                                                  |
| Branchcoverage  | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `10`                                                  |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `Rgb2Hsl` |
| 1          | 0     | 100      | `Rgb2Hsl` |
| 10         | 0     | 0        | `Rgb2Hsl` |
| 1          | 0     | 100      | `Rgb2Hsv` |
| 1          | 0     | 100      | `Rgb2Hsv` |
| 10         | 0     | 0        | `Rgb2Hsv` |
| 6          | 0     | 0        | `Hsv2Rgb` |
| 6          | 0     | 0        | `Hsl2Rgb` |
| 2          | 0     | 0        | `Hsl2Hsv` |
| 2          | 0     | 0        | `Hsv2Hsl` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Graphics/ColorConversion.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Linq;
〰2:   using System;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Graphics
〰6:   {
〰7:   
〰8:       public static class ColorConversion
〰9:       {
‼10:          public static (double hue, double saturation, double lightness) Rgb2Hsl((byte red, byte green, byte blue) color) => Rgb2Hsl(color.red, color.green, color.blue);
‼11:          public static (double hue, double saturation, double lightness) Rgb2Hsl(byte red, byte green, byte blue) => Rgb2Hsl((red, green, blue), 255.0);
〰12:          public static (double hue, double saturation, double lightness) Rgb2Hsl((double red, double green, double blue) color, double factor = 1.0)
〰13:          {
‼14:              var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
‼15:              var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
‼16:              var diff = c.max - c.min;
‼17:              var lightness = (c.max + c.min) / 2.0;
〰18:  
‼19:              return (
‼20:                  hue: diff switch
‼21:                  {
‼22:                      0.0 => 0.0,
‼23:                      _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
‼24:                      _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
‼25:                      _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
‼26:                      _ => 0.0
‼27:                  } * 60 % 360,
‼28:                  saturation: diff switch
‼29:                  {
‼30:                      0.0 => 0.0,
‼31:                      _ => diff / (1.0 - Math.Abs(2 * lightness - 1))
‼32:                  },
‼33:                  lightness: lightness
‼34:                  );
〰35:          }
〰36:  
〰37:  
‼38:          public static (double hue, double saturation, double value) Rgb2Hsv((byte red, byte green, byte blue) color) => Rgb2Hsv(color.red, color.green, color.blue);
‼39:          public static (double hue, double saturation, double value) Rgb2Hsv(byte red, byte green, byte blue) => Rgb2Hsv((red, green, blue), 255.0);
〰40:          public static (double hue, double saturation, double value) Rgb2Hsv((double red, double green, double blue) color, double factor = 1.0)
〰41:          {
‼42:              var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
‼43:              var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
‼44:              var diff = c.max - c.min;
〰45:  
‼46:              return (
‼47:                  hue: diff switch
‼48:                  {
‼49:                      0.0 => 0.0,
‼50:                      _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
‼51:                      _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
‼52:                      _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
‼53:                      _ => 0.0
‼54:                  } * 60 % 360,
‼55:                  saturation: c.max switch
‼56:                  {
‼57:                      0.0 => 0.0,
‼58:                      _ => diff / c.max
‼59:                  },
‼60:                  value: c.max
‼61:                  );
〰62:          }
〰63:  
〰64:          public static (double red, double green, double blue) Hsv2Rgb((double hue, double saturation, double value) color, double factor = 1.0)
〰65:          {
‼66:              var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);
〰67:  
‼68:              var c = adjusted.value * adjusted.saturation;
‼69:              var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼70:              var m = adjusted.value - c;
〰71:  
‼72:              (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
‼73:              {
‼74:                  0 => (c, x, 0),
‼75:                  1 => (x, c, 0),
‼76:                  2 => (0, c, x),
‼77:                  3 => (0, x, c),
‼78:                  4 => (x, 0, c),
‼79:                  _ => (c, 0, x)
‼80:              };
〰81:  
‼82:              return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
〰83:          }
〰84:          public static (double red, double green, double blue) Hsl2Rgb((double hue, double saturation, double lightness) color, double factor = 1.0)
〰85:          {
‼86:              var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);
〰87:  
‼88:              var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
〰89:              ;
‼90:              var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼91:              var m = adjusted.lightness - c / 2.0;
〰92:  
‼93:              (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
‼94:              {
‼95:                  0 => (c, x, 0),
‼96:                  1 => (x, c, 0),
‼97:                  2 => (0, c, x),
‼98:                  3 => (0, x, c),
‼99:                  4 => (x, 0, c),
‼100:                 _ => (c, 0, x)
‼101:             };
〰102: 
‼103:             return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
〰104:         }
〰105: 
〰106:         public static (double hue, double saturation, double value) Hsl2Hsv((double hue, double saturation, double lightness) color)
〰107:         {
‼108:             var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);
〰109: 
‼110:             var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
‼111:             var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼112:             var m = adjusted.lightness - c / 2.0;
〰113: 
‼114:             var terms = new[] { c + m, x + m, m };
〰115: 
‼116:             var c2 = (max: terms.Max(), min: terms.Min());
‼117:             var diff = c2.max - c2.min;
〰118: 
‼119:             return (
‼120:                 hue: adjusted.hue,
‼121:                 saturation: c2.max == 0.0 ? 0.0 : diff / c2.max,
‼122:                 value: c2.max
‼123:                 );
〰124:         }
〰125: 
〰126:         public static (double hue, double saturation, double lightness) Hsv2Hsl((double hue, double saturation, double value) color)
〰127:         {
‼128:             var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);
〰129: 
‼130:             var c = adjusted.value * adjusted.saturation;
‼131:             var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼132:             var m = adjusted.value - c;
〰133: 
‼134:             var rgbP = new[] { c + m, x + m, m };
‼135:             var c2 = (max: rgbP.Max(), min: rgbP.Min());
‼136:             var diff = c2.max - c2.min;
‼137:             var lightness = (c2.max + c2.min) / 2.0;
〰138: 
‼139:             return (
‼140:                 hue: adjusted.hue,
‼141:                 saturation: diff == 0.0 ? 0.0 : diff / (1.0 - Math.Abs(2 * lightness - 1)),
‼142:                 lightness: lightness
‼143:                 );
〰144:         }
〰145:     }
〰146: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

