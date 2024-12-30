namespace BinaryDataDecoders.ToolKit.Numerics;

public record ByteNumber : FormattableNumber
{
    public ByteNumber(object value) : base(new ByteNotationFormatter(), value)
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

    public static implicit operator ByteNumber(ScientificNumber number) => new(number.AsDouble());
    public static implicit operator ByteNumber(EngineeringNumber number) => new(number.AsDouble());

    public override string ToString() => base.ToString();
}
