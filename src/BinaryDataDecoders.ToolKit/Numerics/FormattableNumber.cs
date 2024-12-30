using System;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Numerics;

public record FormattableNumber : INumeric
{
    private readonly IFormatProvider _provider;

    public FormattableNumber(IFormatProvider provider, object value)
    {
        if (value is double) ValueDouble = Convert.ToDouble(value);
        else if (value is float) ValueDouble = Convert.ToDouble(value);
        else if (value is decimal) ValueDouble = Convert.ToDouble(value);
        else if (value is short) ValueDouble = Convert.ToDouble(value);
        else if (value is int) ValueDouble = Convert.ToDouble(value);
        else if (value is long) ValueDouble = Convert.ToDouble(value);
        else throw new NotSupportedException($"type {value.GetType()} is not supported");

        _provider = provider;
    }

    protected double? ValueDouble { get; init; }
    protected float? ValueSingle { get; init; }
    protected decimal? ValueDecimal { get; init; }
    protected short? ValueInt16 { get; init; }
    protected int? ValueInt32 { get; init; }
    protected long? ValueInt64 { get; init; }

    public double AsDouble()
    {
        if (ValueDouble.HasValue) return ValueDouble.Value;
        else if (ValueSingle.HasValue) return (double)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return (double)ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return ValueInt32.Value;
        else if (ValueInt64.HasValue) return ValueInt64.Value;
        return default;
    }
    public float AsSingle()
    {
        if (ValueDouble.HasValue) return (float)ValueDouble.Value;
        else if (ValueSingle.HasValue) return (float)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return (float)ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return ValueInt32.Value;
        else if (ValueInt64.HasValue) return ValueInt64.Value;
        return default;
    }
    public decimal AsDecimal()
    {
        if (ValueDouble.HasValue) return (decimal)ValueDouble.Value;
        else if (ValueSingle.HasValue) return (decimal)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return ValueInt32.Value;
        else if (ValueInt64.HasValue) return ValueInt64.Value;
        return default;
    }
    public short AsInt16()
    {
        if (ValueDouble.HasValue) return (short)ValueDouble.Value;
        else if (ValueSingle.HasValue) return (short)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return (short)ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return (short)ValueInt32.Value;
        else if (ValueInt64.HasValue) return (short)ValueInt64.Value;
        return default;
    }
    public int AsInt32()
    {
        if (ValueDouble.HasValue) return (int)ValueDouble.Value;
        else if (ValueSingle.HasValue) return (int)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return (int)ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return ValueInt32.Value;
        else if (ValueInt64.HasValue) return (int)ValueInt64.Value;
        return default;
    }
    public long AsInt64()
    {
        if (ValueDouble.HasValue) return (long)ValueDouble.Value;
        else if (ValueSingle.HasValue) return (long)ValueSingle.Value;
        else if (ValueDecimal.HasValue) return (long)ValueDecimal.Value;
        else if (ValueInt16.HasValue) return ValueInt16.Value;
        else if (ValueInt32.HasValue) return ValueInt32.Value;
        else if (ValueInt64.HasValue) return ValueInt64.Value;
        return default;
    }

    public static INumeric? Parse(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return default;

        IFormatProvider? formatProvider = new ScienceNotationFormatter();

        var symbol = new string(input[^1], 1);
        if (symbol == "b")
        {
            formatProvider = new ByteNotationFormatter();
        }

        var power = Symbols.Notations.FirstOrDefault(i => i.Value == symbol).Key;

        var value = power switch
        {
            0 => double.Parse(input),
            _ => double.Parse(input[0..^1]) * Math.Pow(1000, power)
        };

        return new FormattableNumber(formatProvider, value);
    }

    public override string ToString() => ToString(null, _provider);
    public virtual string ToString(string? format) => ToString(format, _provider);
    public virtual string ToString(string? format, IFormatProvider? formatProvider) =>
        string.Format(formatProvider ?? _provider, format ?? "{0:0.###}", AsDouble());
}
