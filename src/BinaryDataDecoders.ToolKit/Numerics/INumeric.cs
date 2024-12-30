using System;

namespace BinaryDataDecoders.ToolKit.Numerics;

public interface INumeric : IFormattable
{
    double AsDouble();
    float AsSingle();
    decimal AsDecimal();
    short AsInt16();
    int AsInt32();
    long AsInt64();
}
