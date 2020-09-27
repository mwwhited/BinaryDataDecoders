using BinaryDataDecoders.ToolKit.Security;
using System.IO;
using System.Xml.XPath;
using BinaryDataDecoders.ToolKit.IO;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    public class FileExtensions
    {
        public FileExtensions(string basePath) => BasePath = basePath;
        public string BasePath { get; }

        public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
        {
            if (string.IsNullOrWhiteSpace(source.OuterXml)) return source;

            var realPath = Sandbox.EnsureSafePath(BasePath, filePath).CreateParentIfNotExists();

            File.WriteAllText(realPath, source.OuterXml);

            return source;
        }
    }
}
