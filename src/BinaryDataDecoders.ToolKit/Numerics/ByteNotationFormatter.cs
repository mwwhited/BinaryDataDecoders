using System;

namespace BinaryDataDecoders.ToolKit.Numerics;

public sealed class ByteNotationFormatter : IFormatProvider, ICustomFormatter
{
    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        var value = Convert.ToDouble(arg);

        var exponent = Math.Floor(Math.Log(Math.Abs(value), 1024));

        var symbol = Symbols.Notations.TryGetValue(exponent, out var l) ? $"{l}" : $"e{exponent * 3}";

        return (value * Math.Pow(1024, -(int)exponent)).ToString(format ?? "0.###") + symbol + 'b';
    }

    public object? GetFormat(Type? formatType) =>
        formatType == typeof(ICustomFormatter) ? this : (object?)null;
}
