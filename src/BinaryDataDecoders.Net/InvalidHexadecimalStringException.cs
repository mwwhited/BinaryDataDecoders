using System;
using System.Diagnostics;

namespace BinaryDataDecoders.Net;

public class InvalidHexadecimalStringException(string hexString) : Exception(string.Format("\"{0}\" is not a valid Hexadecimal Number", hexString))
{
    public string Hexadecimal { get; } = hexString;

    [DebuggerNonUserCode]
    public static void Check(string hexString)
    {
        if (!ConvertEx.IsHexString(hexString))
            throw new InvalidHexadecimalStringException(hexString);
    }
}
