using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Linq;

public static class XmlNodeEx
{
    public static XElement? ToXElement(this XmlNode node)
    {
        var xDoc = new XDocument();
        using (var xmlWriter = xDoc.CreateWriter())
            node.WriteTo(xmlWriter);
        return xDoc.Root;
    }
}
