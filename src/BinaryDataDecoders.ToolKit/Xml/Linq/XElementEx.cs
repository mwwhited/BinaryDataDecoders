using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq;

public static class XElementEx
{
    public static XmlNode ToXmlNode(this XElement element)
    {
        using var xmlReader = element.CreateReader();
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlReader);
        return xmlDoc.FirstChild;
    }
    public static string? GetDescendantAsString(this XElement element, XName name) =>
        (string?)element.Descendants(name).FirstOrDefault();

    public static long? GetDescendantAsLong(this XElement element, XName name) =>
        (long?)element?.Descendants(name).FirstOrDefault();

    public static string? GetTargetValue(this IEnumerable<XElement> elements, string name) =>
        elements?.Where(e => string.Equals((string?)e.Attribute("name"), name, StringComparison.InvariantCultureIgnoreCase))
                       .Select(e => (string?)e.Attribute("value"))
                       .FirstOrDefault();
}
