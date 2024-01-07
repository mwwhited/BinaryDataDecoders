using System;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq;

public static class XAttributeEx
{
    public static TEnum AsEnum<TEnum>(this XAttribute xAttribute)
        where TEnum : struct
    {
        if (xAttribute != null && Enum.TryParse<TEnum>((string)xAttribute, out  var value))
            return value;
        return default;
    }
}
