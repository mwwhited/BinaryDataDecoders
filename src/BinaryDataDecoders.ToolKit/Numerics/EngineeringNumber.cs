using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit.Numerics;

public record EngineeringNumber : FormattableNumber
{
    public EngineeringNumber(object value) : base(value, new EngineeringNotationFormatter())
    {
    }

    public static implicit operator double(EngineeringNumber number) => number.AsDouble();
    public static implicit operator float(EngineeringNumber number) => number.AsSingle();
    public static implicit operator decimal(EngineeringNumber number) => number.AsDecimal();
    public static implicit operator short(EngineeringNumber number) => number.AsInt16();
    public static implicit operator int(EngineeringNumber number) => number.AsInt32();
    public static implicit operator long(EngineeringNumber number) => number.AsInt64();

    public static implicit operator EngineeringNumber(double number) => new(value: number);
    public static implicit operator EngineeringNumber(float number) => new(value: number);
    public static implicit operator EngineeringNumber(decimal number) => new(value: number);
    public static implicit operator EngineeringNumber(short number) => new(value: number);
    public static implicit operator EngineeringNumber(int number) => new(value: number);
    public static implicit operator EngineeringNumber(long number) => new(value: number);

    public static implicit operator EngineeringNumber(ScientificNumber number) => new(number.AsDecimal());
    public static implicit operator EngineeringNumber(ByteNumber number) => new(number.AsDecimal());

    public override string ToString() => base.ToString();

    public static bool TryParse(string? input, out EngineeringNumber? value)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            value = default;
            return false;
        }

        var symbol = new string(input[^1], 1);
        var power = Symbols.Notations.FirstOrDefault(i => i.Value == symbol).Key;

        if (power != 0)
        {
            if (decimal.TryParse(input[0..^1], out var valueOut))
            {
                if (power > 0)
                    for (var p = 0; p < power; p++)
                        valueOut *= 1000;
                else if (power < 0)
                    for (var p = 0; p > power; p--)
                        valueOut /= 1000;
                value = valueOut;
                return true;
            }
        }
        else
        {
            if (double.TryParse(input, out var valueOut))
            {
                value = valueOut;
                return true;
            }
        }

        value = default;
        return false;
    }
}
