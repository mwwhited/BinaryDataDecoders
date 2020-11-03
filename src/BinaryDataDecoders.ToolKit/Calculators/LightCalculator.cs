using System;

namespace BinaryDataDecoders.ToolKit.Calculators
{
    public class LightCalculator
    {
        public double Lux(double aperture, double iso, double shutter) => (System.Math.Pow(aperture, 2d) * 250d) / (iso * shutter);
        public double Iso(double aperture, double lux, double shutter) => (Math.Pow(aperture, 2d) * 250d) / (lux * shutter);
        public double Aperture(double iso, double lux, double shutter) => Math.Sqrt(lux * shutter / 2.5d * (iso) / 100);
        public double Shutter(double iso, double lux, double aperture) => Math.Pow(aperture, 2d) * 2.5 / lux * 100 / iso;

        public double Ev(double lux) => Math.Log(lux / 2.5d, 2d);
        public double A(double aperture, double shutter) => Math.Log(Math.Pow(aperture, 2d) / shutter, 2d);
    }
}
