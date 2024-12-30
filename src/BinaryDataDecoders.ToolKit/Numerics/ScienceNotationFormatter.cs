using System;

namespace BinaryDataDecoders.ToolKit.Numerics;

public sealed class ScienceNotationFormatter : IFormatProvider, ICustomFormatter
{
    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        var value = Convert.ToDouble(arg);
        var exponent = Math.Floor(Math.Log10(Math.Abs(value)));
        var suffix = exponent == 0 ? "" : $"e{exponent}";

        return (value * Math.Pow(10, -(int)exponent)).ToString(format ?? "0.###") + suffix;
    }

    public object? GetFormat(Type? formatType) =>
        formatType == typeof(ICustomFormatter) ? this : (object?)null;
}
