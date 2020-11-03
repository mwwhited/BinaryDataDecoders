using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    /// <summary>
    /// Extension methods for XsltArgumentList
    /// </summary>
    public static class XsltArgumentListExtensions
    {
        private static readonly XsltExtensionFactory _builder = new XsltExtensionFactory();

        /// <summary>
        /// simplify chaining XsltArgumentList and AddExtensionObject
        /// </summary>
        /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
        /// <param name="extensionObjects">set of objects to be assigned</param>
        /// <returns>instance of xsltArgumentList</returns>
        public static XsltArgumentList AddExtensions(this XsltArgumentList xsltArgumentList, params object[] extensionObjects)
        {
            foreach (var extensionObject in extensionObjects)
                xsltArgumentList.AddExtensionObject(extensionObject);
            return xsltArgumentList;
        }
        /// <summary>
        /// simplify chaining XsltArgumentList and AddExtensionObject
        /// </summary>
        /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
        /// <param name="extensionObject">instance of objects to be assigned</param>
        /// <returns>instance of xsltArgumentList</returns>
        public static XsltArgumentList AddExtensionObject(this XsltArgumentList xsltArgumentList, object extensionObject)
        {
            var ns = extensionObject.GetXmlNamespace();
            var extended = _builder.BuildXsltExtension(extensionObject);
            xsltArgumentList.AddExtensionObject(ns, extended);
            return xsltArgumentList;
        }
    }
}
