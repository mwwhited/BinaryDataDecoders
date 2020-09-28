using BinaryDataDecoders.ToolKit.Security;
using System.IO;
using System.Xml.XPath;
using BinaryDataDecoders.ToolKit.IO;
using System.Xml;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.FileExtensions, BinaryDataDecoders.ToolKit
    /// </summary>
    public class FileExtensions
    {
        public FileExtensions(string sandbox) => _sandbox = sandbox;
        private readonly string _sandbox;

        public XPathNavigator WriteToFile(XPathNavigator source, string filePath)
        {
            if (string.IsNullOrWhiteSpace(source.OuterXml)) return source;
            var realPath = Sandbox.EnsureSafePath(_sandbox, filePath).CreateParentIfNotExists();
            File.WriteAllText(realPath, source.OuterXml);
            return source;
        }

        public XPathNavigator ReadXml(string filePath) =>
            XDocument.Load(Sandbox.EnsureSafePath(_sandbox, filePath)).CreateNavigator();
    }
}
