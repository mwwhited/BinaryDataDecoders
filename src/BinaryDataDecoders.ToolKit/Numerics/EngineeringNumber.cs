using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit.Numerics;

public record EngineeringNumber : FormattableNumber
{
    public EngineeringNumber(object value) : base(new EngineeringNotationFormatter(), value)
    {
    }

    public static implicit operator double(EngineeringNumber number) => number.AsDouble();
    public static implicit operator float(EngineeringNumber number) => number.AsSingle();
    public static implicit operator decimal(EngineeringNumber number) => number.AsDecimal();
    public static implicit operator short(EngineeringNumber number) => number.AsInt16();
    public static implicit operator int(EngineeringNumber number) => number.AsInt32();
    public static implicit operator long(EngineeringNumber number) => number.AsInt64();

    public static implicit operator EngineeringNumber(double number) => new(value:number);
    public static implicit operator EngineeringNumber(float number) => new(value: number);
    public static implicit operator EngineeringNumber(decimal number) => new(value: number);
    public static implicit operator EngineeringNumber(short number) => new(value: number);
    public static implicit operator EngineeringNumber(int number) => new(value: number);
    public static implicit operator EngineeringNumber(long number) => new(value: number);

    public static implicit operator EngineeringNumber(ScientificNumber number) => new(number.AsDouble());
    public static implicit operator EngineeringNumber(ByteNumber number) => new(number.AsDouble());

    public override string ToString() => base.ToString();
}
