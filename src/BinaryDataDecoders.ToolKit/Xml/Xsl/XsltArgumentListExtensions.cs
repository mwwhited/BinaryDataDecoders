using System.Linq;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    public static class XsltArgumentListExtensions
    {
        public static XsltArgumentList AddExtensions(this XsltArgumentList xsltArgumentList, params object[] extensionObjects)
        {
            foreach (var extensionObject in extensionObjects)
                xsltArgumentList.AddExtensionObject(extensionObject);
            return xsltArgumentList;
        }
        public static XsltArgumentList AddExtensionObject(this XsltArgumentList xsltArgumentList, object extensionObject)
        {
            var ns = $"clr:{string.Join(',', extensionObject.GetType().AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
            xsltArgumentList.AddExtensionObject(ns, extensionObject);
            return xsltArgumentList;
        }
    }
}
