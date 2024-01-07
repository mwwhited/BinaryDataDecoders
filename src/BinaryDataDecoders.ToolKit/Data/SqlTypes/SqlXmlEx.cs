using BinaryDataDecoders.ToolKit.Xml.Linq;
using System.Data.SqlTypes;

namespace BinaryDataDecoders.ToolKit.Data.SqlTypes;

public static class SqlXmlEx
{
    public static XFragment ToXFragment(this SqlXml sqlxml)
    {
        using var xmlReader = sqlxml.CreateReader();
        return XFragment.Parse(xmlReader);
    }

    public static SqlXml ToSqlXml(this XFragment xFragment) => new SqlXml(xFragment.CreateReader());
}
