﻿using System;

namespace BinaryDataDecoders.ToolKit;

/// <summary>
/// Extension methods to support BinaryCode Decimal (BCD)
/// </summary>
public static class BcdEx
{
    //TODO: extend to support ReadOnlySpan

    /// <summary>
    /// convert Binary Code Decimal (BCD) byte to integer
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static int AsBCD(this byte input)
    {
        var low = input & 0x0f;
        var high = (input & 0xf0) >> 4;

        if (low > 9)
            throw new IndexOutOfRangeException("low");
        if (high > 9)
            throw new IndexOutOfRangeException("high");

        return low + (high * 10);
    }
    /// <summary>
    /// convert decimal value to Binary code Decimal (BCD)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static byte ToBCD(this int input)
    {
        if (input > 99 || input < 0)
            throw new ArgumentOutOfRangeException(nameof(input));

        var high = input / 10;
        var low = input - (high * 10);

        if (low > 9)
            throw new IndexOutOfRangeException("low");
        if (high > 9)
            throw new IndexOutOfRangeException("high");

        return (byte)((high << 4) | low);
    }
}
