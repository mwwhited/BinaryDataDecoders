using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Numerics;

public sealed class Symbols
{
    internal static readonly Dictionary<double, string> Notations = new()
    {
        {double.NegativeInfinity, "-"},
        {-8, "y"},
        {-7, "z"},
        {-6, "a"},
        {-5, "f"},
        {-4, "p"},
        {-3, "n"},
        {-2, "μ"},
        {-1, "m"},
        {0, ""},
        {1, "k"},
        {2, "M"},
        {3, "G"},
        {4, "T"},
        {5, "P"},
        {6, "E"},
        {7, "Z"},
        {8, "Y"},
    };

}

public sealed class EngineeringNotationFormatter : IFormatProvider, ICustomFormatter
{
    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        var value = Convert.ToDouble(arg);

        var exponent = Math.Floor(Math.Log10(Math.Abs(value))/3);

        var symbol = Symbols.Notations.TryGetValue(exponent, out var l) ? $"{l}" : $"e{exponent * 3}";

        return (value * Math.Pow(1000, -(int)exponent)).ToString(format ?? "0.###") + symbol;
    }

    public object? GetFormat(Type? formatType) =>
        formatType == typeof(ICustomFormatter) ? this : (object?)null;
}
