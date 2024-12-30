using System.Linq;

namespace BinaryDataDecoders.ToolKit.Numerics;

public record ByteNumber : FormattableNumber
{
    public ByteNumber(object value) : base(value, new ByteNotationFormatter())
    {
    }

    public static implicit operator double(ByteNumber number) => number.AsDouble();
    public static implicit operator float(ByteNumber number) => number.AsSingle();
    public static implicit operator decimal(ByteNumber number) => number.AsDecimal();
    public static implicit operator short(ByteNumber number) => number.AsInt16();
    public static implicit operator int(ByteNumber number) => number.AsInt32();
    public static implicit operator long(ByteNumber number) => number.AsInt64();

    public static implicit operator ByteNumber(double number) => new(value: number);
    public static implicit operator ByteNumber(float number) => new(value: number);
    public static implicit operator ByteNumber(decimal number) => new(value: number);
    public static implicit operator ByteNumber(short number) => new(value: number);
    public static implicit operator ByteNumber(int number) => new(value: number);
    public static implicit operator ByteNumber(long number) => new(value: number);

    public static implicit operator ByteNumber(ScientificNumber number) => new(number.AsDecimal());
    public static implicit operator ByteNumber(EngineeringNumber number) => new(number.AsDecimal());

    public override string ToString() => base.ToString();

    public static bool TryParse(string? input, out ByteNumber? value)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length < 2 || input[^1] != 'b')
        {
            value = default;
            return false;
        }

        var symbol = new string(input[^2], 1);
        var power = Symbols.Notations.FirstOrDefault(i => i.Value == symbol).Key;

        if (power != 0)
        {
            if (decimal.TryParse(input[0..^2], out var valueOut))
            {
                if (power > 0)
                    for (var p = 0; p < power; p++)
                        valueOut *= 1024;
                else if (power < 0)
                    for (var p = 0; p > power; p--)
                        valueOut /= 1024;
                value = valueOut;
                return true;
            }
        }
        else
        {
            if (double.TryParse(input[0..^1], out var valueOut))
            {
                value = valueOut;
                return true;
            }
        }

        value = default;
        return false;
    }
}
