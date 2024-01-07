using System;

namespace BinaryDataDecoders.ToolKit.Graphics
{
    public static class LightCalculator
    {
        public static double LuxToEv(this double lux) =>
            Math.Round(Math.Log(lux / 2.5d, 2d), 6);

        public static double EvToLux(this double ev) =>
            Math.Round(Math.Pow(2, ev) * 2.5, 6);

        public static double GetLux(double iso, double fStop, double shutterSpeed) =>
            Math.Round((Math.Pow(fStop, 2) * 250) / (iso * shutterSpeed), 6);

        public static double GetEv(double iso, double fStop, double shutterSpeed) =>
            Math.Round(Math.Log((Math.Pow(fStop, 2) * 100) / (iso * shutterSpeed), 2), 6);

        public static double GetAsa(double fStop, double shutterSpeed, double lux) =>
            Math.Round((Math.Pow(fStop, 2) * 250) / (lux * shutterSpeed), 2);

        public static double GetFStop(double iso, double shutterSpeed, double lux) =>
            Math.Round(Math.Sqrt((lux * shutterSpeed * iso) / 250), 2);

        public static double GetShutterSpeed(double iso, double fStop, double lux) =>
            Math.Round((Math.Pow(fStop, 2) * 250) / (lux * iso), 6);

        public static double GetAsaE(double fStop, double shutterSpeed, double ev) =>
            Math.Round((Math.Pow(fStop, 2) * 100) / (Math.Pow(2, ev) * shutterSpeed), 2);

        public static double GetFStopE(double iso, double shutterSpeed, double ev) =>
            Math.Round(Math.Sqrt((Math.Pow(2, ev) * shutterSpeed * iso) / 100), 2);

        public static double GetShutterSpeedE(double iso, double fStop, double ev) =>
            Math.Round((Math.Pow(fStop, 2) * 100) / (Math.Pow(2, ev) * iso), 6);
    }
}
