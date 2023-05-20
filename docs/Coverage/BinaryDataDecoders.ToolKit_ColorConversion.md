# BinaryDataDecoders.ToolKit.Graphics.ColorConversion

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Graphics.ColorConversion` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `96`                                                  |
| Coverablelines  | `96`                                                  |
| Totallines      | `145`                                                 |
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
〰7:       public class ColorConversion
〰8:       {
‼9:           public static (double hue, double saturation, double lightness) Rgb2Hsl((byte red, byte green, byte blue) color) => Rgb2Hsl(color.red, color.green, color.blue);
‼10:          public static (double hue, double saturation, double lightness) Rgb2Hsl(byte red, byte green, byte blue) => Rgb2Hsl((red, green, blue), 255.0);
〰11:          public static (double hue, double saturation, double lightness) Rgb2Hsl((double red, double green, double blue) color, double factor = 1.0)
〰12:          {
‼13:              var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
‼14:              var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
‼15:              var diff = c.max - c.min;
‼16:              var lightness = (c.max + c.min) / 2.0;
〰17:  
‼18:              return (
‼19:                  hue: diff switch
‼20:                  {
‼21:                      0.0 => 0.0,
‼22:                      _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
‼23:                      _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
‼24:                      _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
‼25:                      _ => 0.0
‼26:                  } * 60 % 360,
‼27:                  saturation: diff switch
‼28:                  {
‼29:                      0.0 => 0.0,
‼30:                      _ => diff / (1.0 - Math.Abs(2 * lightness - 1))
‼31:                  },
‼32:                  lightness: lightness
‼33:                  );
〰34:          }
〰35:  
〰36:  
‼37:          public static (double hue, double saturation, double value) Rgb2Hsv((byte red, byte green, byte blue) color) => Rgb2Hsv(color.red, color.green, color.blue);
‼38:          public static (double hue, double saturation, double value) Rgb2Hsv(byte red, byte green, byte blue) => Rgb2Hsv((red, green, blue), 255.0);
〰39:          public static (double hue, double saturation, double value) Rgb2Hsv((double red, double green, double blue) color, double factor = 1.0)
〰40:          {
‼41:              var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
‼42:              var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
‼43:              var diff = c.max - c.min;
〰44:  
‼45:              return (
‼46:                  hue: diff switch
‼47:                  {
‼48:                      0.0 => 0.0,
‼49:                      _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
‼50:                      _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
‼51:                      _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
‼52:                      _ => 0.0
‼53:                  } * 60 % 360,
‼54:                  saturation: c.max switch
‼55:                  {
‼56:                      0.0 => 0.0,
‼57:                      _ => diff / c.max
‼58:                  },
‼59:                  value: c.max
‼60:                  );
〰61:          }
〰62:  
〰63:          public static (double red, double green, double blue) Hsv2Rgb((double hue, double saturation, double value) color, double factor = 1.0)
〰64:          {
‼65:              var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);
〰66:  
‼67:              var c = adjusted.value * adjusted.saturation;
‼68:              var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼69:              var m = adjusted.value - c;
〰70:  
‼71:              (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
‼72:              {
‼73:                  0 => (c, x, 0),
‼74:                  1 => (x, c, 0),
‼75:                  2 => (0, c, x),
‼76:                  3 => (0, x, c),
‼77:                  4 => (x, 0, c),
‼78:                  _ => (c, 0, x)
‼79:              };
〰80:  
‼81:              return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
〰82:          }
〰83:          public static (double red, double green, double blue) Hsl2Rgb((double hue, double saturation, double lightness) color, double factor = 1.0)
〰84:          {
‼85:              var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);
〰86:  
‼87:              var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
〰88:              ;
‼89:              var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼90:              var m = adjusted.lightness - c / 2.0;
〰91:  
‼92:              (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
‼93:              {
‼94:                  0 => (c, x, 0),
‼95:                  1 => (x, c, 0),
‼96:                  2 => (0, c, x),
‼97:                  3 => (0, x, c),
‼98:                  4 => (x, 0, c),
‼99:                  _ => (c, 0, x)
‼100:             };
〰101: 
‼102:             return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
〰103:         }
〰104: 
〰105:         public static (double hue, double saturation, double value) Hsl2Hsv((double hue, double saturation, double lightness) color)
〰106:         {
‼107:             var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);
〰108: 
‼109:             var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
‼110:             var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼111:             var m = adjusted.lightness - c / 2.0;
〰112: 
‼113:             var terms = new[] { c + m, x + m, m };
〰114: 
‼115:             var c2 = (max: terms.Max(), min: terms.Min());
‼116:             var diff = c2.max - c2.min;
〰117: 
‼118:             return (
‼119:                 hue: adjusted.hue,
‼120:                 saturation: c2.max == 0.0 ? 0.0 : diff / c2.max,
‼121:                 value: c2.max
‼122:                 );
〰123:         }
〰124: 
〰125:         public static (double hue, double saturation, double lightness) Hsv2Hsl((double hue, double saturation, double value) color)
〰126:         {
‼127:             var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);
〰128: 
‼129:             var c = adjusted.value * adjusted.saturation;
‼130:             var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
‼131:             var m = adjusted.value - c;
〰132: 
‼133:             var rgbP = new[] { c + m, x + m, m };
‼134:             var c2 = (max: rgbP.Max(), min: rgbP.Min());
‼135:             var diff = c2.max - c2.min;
‼136:             var lightness = (c2.max + c2.min) / 2.0;
〰137: 
‼138:             return (
‼139:                 hue: adjusted.hue,
‼140:                 saturation: diff == 0.0 ? 0.0 : diff / (1.0 - Math.Abs(2 * lightness - 1)),
‼141:                 lightness: lightness
‼142:                 );
〰143:         }
〰144:     }
〰145: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

