using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl;

public static class XslCompiledTransformEx
{
    public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params XElement[] arguments) =>
        Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
    public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<XElement> arguments)
    {
        var query = arguments.Select(x => new KeyValuePair<XName, XElement>(x.Name, x));
        return Transform(xmlStylesheet, xmlDocument, query);
    }
    public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params KeyValuePair<XName, XElement>[] arguments) =>
        Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
    public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<KeyValuePair<XName, XElement>> arguments)
    {
        var xsltArgumentList = new XsltArgumentList();

        foreach (var argument in arguments)
        {
            var navigator = argument.Value.CreateNavigator();
            xsltArgumentList.AddParam(argument.Key.LocalName, argument.Key.NamespaceName, navigator);
        }

        var transform = new XslCompiledTransform(false);

        using var stylesheetReader = xmlStylesheet.CreateReader();
        using var xmlDocumentReader = xmlDocument.CreateReader();
        transform.Load(stylesheetReader);

        using var outStream = new MemoryStream();
        using var writer = new StreamWriter(outStream);
        transform.Transform(xmlDocumentReader, xsltArgumentList, writer);
        var result = Encoding.UTF8.GetString(outStream.ToArray());
        return result;
    }

    public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params XElement[] arguments) =>
        Transform(xmlStylesheetPath, xmlDocumentPath, arguments.OfType<object>());
    public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params object[] arguments) =>
        Transform(xmlStylesheetPath, xmlDocumentPath, arguments.AsEnumerable());
    public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, IEnumerable<object> arguments)
    {
        var xsltArgumentList = new XsltArgumentList();

        foreach (var argument in arguments.Where(a => a != null))
        {
            var element = (argument is XDocument) ? (argument as XDocument)?.Root : (argument as XElement);
            if (element != null)
            {
                var navigator = element.CreateNavigator();
                xsltArgumentList.AddParam(element.Name.LocalName, element.Name.NamespaceName, navigator);
            }
            else if (argument is XPathNavigator navigator)
            {
                xsltArgumentList.AddParam(navigator.Name, navigator.NamespaceURI, navigator);
            }
            else if (argument is KeyValuePair<string, object> kvp)
            {
                xsltArgumentList.AddExtensionObject(kvp.Key, kvp.Value);
            }
            else
            {
                xsltArgumentList.AddExtensionObject(argument.GetXmlNamespace(), argument);
            }
        }

        var transform = new XslCompiledTransform(true);
        transform.Load(xmlStylesheetPath);

        using var outStream = new MemoryStream();
        using var writer = new StreamWriter(outStream);
        transform.Transform(xmlDocumentPath, xsltArgumentList, writer);
        var result = Encoding.UTF8.GetString(outStream.ToArray());
        return result;
    }
}
