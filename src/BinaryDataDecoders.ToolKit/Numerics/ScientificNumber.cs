namespace BinaryDataDecoders.ToolKit.Numerics;

public record ScientificNumber : FormattableNumber
{
    public ScientificNumber(object value) : base(new ScienceNotationFormatter(), value)
    {
    }

    public static implicit operator double(ScientificNumber number) => number.AsDouble();
    public static implicit operator float(ScientificNumber number) => number.AsSingle();
    public static implicit operator decimal(ScientificNumber number) => number.AsDecimal();
    public static implicit operator short(ScientificNumber number) => number.AsInt16();
    public static implicit operator int(ScientificNumber number) => number.AsInt32();
    public static implicit operator long(ScientificNumber number) => number.AsInt64();

    public static implicit operator ScientificNumber(double number) => new(value: number);
    public static implicit operator ScientificNumber(float number) => new(value: number);
    public static implicit operator ScientificNumber(decimal number) => new(value: number);
    public static implicit operator ScientificNumber(short number) => new(value: number);
    public static implicit operator ScientificNumber(int number) => new(value: number);
    public static implicit operator ScientificNumber(long number) => new(value: number);

    public static implicit operator ScientificNumber(ByteNumber number) => new(number.AsDouble());
    public static implicit operator ScientificNumber(EngineeringNumber number) => new(number.AsDouble());

    public override string ToString() => base.ToString();
}