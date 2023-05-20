using BinaryDataDecoders.ToolKit.Linq;
using System;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Graphics
{
    public class ColorConversion
    {
        public static (double hue, double saturation, double lightness) Rgb2Hsl((byte red, byte green, byte blue) color) => Rgb2Hsl(color.red, color.green, color.blue);
        public static (double hue, double saturation, double lightness) Rgb2Hsl(byte red, byte green, byte blue) => Rgb2Hsl((red, green, blue), 255.0);
        public static (double hue, double saturation, double lightness) Rgb2Hsl((double red, double green, double blue) color, double factor = 1.0)
        {
            var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
            var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
            var diff = c.max - c.min;
            var lightness = (c.max + c.min) / 2.0;

            return (
                hue: diff switch
                {
                    0.0 => 0.0,
                    _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
                    _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
                    _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
                    _ => 0.0
                } * 60 % 360,
                saturation: diff switch
                {
                    0.0 => 0.0,
                    _ => diff / (1.0 - Math.Abs(2 * lightness - 1))
                },
                lightness: lightness
                );
        }


        public static (double hue, double saturation, double value) Rgb2Hsv((byte red, byte green, byte blue) color) => Rgb2Hsv(color.red, color.green, color.blue);
        public static (double hue, double saturation, double value) Rgb2Hsv(byte red, byte green, byte blue) => Rgb2Hsv((red, green, blue), 255.0);
        public static (double hue, double saturation, double value) Rgb2Hsv((double red, double green, double blue) color, double factor = 1.0)
        {
            var primes = (red: color.red / factor, green: color.green / factor, blue: color.blue / factor);
            var c = (max: primes.ToArray<double>().Max(), min: primes.ToArray<double>().Min());
            var diff = c.max - c.min;

            return (
                hue: diff switch
                {
                    0.0 => 0.0,
                    _ when c.max == primes.red => ((primes.green - primes.blue) / diff) % 6,
                    _ when c.max == primes.green => ((primes.blue - primes.red) / diff) + 2,
                    _ when c.max == primes.blue => ((primes.red - primes.green) / diff) + 4,
                    _ => 0.0
                } * 60 % 360,
                saturation: c.max switch
                {
                    0.0 => 0.0,
                    _ => diff / c.max
                },
                value: c.max
                );
        }

        public static (double red, double green, double blue) Hsv2Rgb((double hue, double saturation, double value) color, double factor = 1.0)
        {
            var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);

            var c = adjusted.value * adjusted.saturation;
            var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
            var m = adjusted.value - c;

            (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
            {
                0 => (c, x, 0),
                1 => (x, c, 0),
                2 => (0, c, x),
                3 => (0, x, c),
                4 => (x, 0, c),
                _ => (c, 0, x)
            };

            return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
        }
        public static (double red, double green, double blue) Hsl2Rgb((double hue, double saturation, double lightness) color, double factor = 1.0)
        {
            var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);

            var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
            ;
            var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
            var m = adjusted.lightness - c / 2.0;

            (double red, double green, double blue) rgb = (((int)(adjusted.hue / 60)) % 6) switch
            {
                0 => (c, x, 0),
                1 => (x, c, 0),
                2 => (0, c, x),
                3 => (0, x, c),
                4 => (x, 0, c),
                _ => (c, 0, x)
            };

            return ((rgb.red + m) * factor, (rgb.green + m) * factor, (rgb.blue + m) * factor);
        }

        public static (double hue, double saturation, double value) Hsl2Hsv((double hue, double saturation, double lightness) color)
        {
            var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, lightness: color.lightness);

            var c = (1 - Math.Abs(2.0 * adjusted.lightness - 1.0)) * adjusted.saturation;
            var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
            var m = adjusted.lightness - c / 2.0;

            var terms = new[] { c + m, x + m, m };

            var c2 = (max: terms.Max(), min: terms.Min());
            var diff = c2.max - c2.min;

            return (
                hue: adjusted.hue,
                saturation: c2.max == 0.0 ? 0.0 : diff / c2.max,
                value: c2.max
                );
        }

        public static (double hue, double saturation, double lightness) Hsv2Hsl((double hue, double saturation, double value) color)
        {
            var adjusted = (hue: color.hue % 360.0, saturation: color.saturation, value: color.value);

            var c = adjusted.value * adjusted.saturation;
            var x = c * (1 - Math.Abs(adjusted.hue / 60 % 2 - 1));
            var m = adjusted.value - c;

            var rgbP = new[] { c + m, x + m, m };
            var c2 = (max: rgbP.Max(), min: rgbP.Min());
            var diff = c2.max - c2.min;
            var lightness = (c2.max + c2.min) / 2.0;

            return (
                hue: adjusted.hue,
                saturation: diff == 0.0 ? 0.0 : diff / (1.0 - Math.Abs(2 * lightness - 1)),
                lightness: lightness
                );
        }
    }
}