
using BinaryDataDecoders.ToolKit.Security;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions, BinaryDataDecoders.ToolKit
    /// </summary>
    public class PathExtensions
    {
        public PathExtensions(string sandbox)
        {
            _sandbox = sandbox;
            _ns = this.GetXmlNamespace() + ":out";
        }
        private readonly string _sandbox;
        private readonly XNamespace _ns;

        public string GetFileName(string file) => Path.GetFileName(file);
        public string GetFileNameWithoutExtension(string file) => Path.GetFileNameWithoutExtension(file);
        public string GetExtension(string file) => Path.GetExtension(file);
        public string ChangeExtension(string file, string extension) => Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);

        public XPathNavigator ListFiles(string path) =>
            new XElement(_ns + "files",
                from f in Directory.GetFiles(Sandbox.EnsureSafePath(_sandbox, path))
                select new XElement(_ns + "file", f)
            ).ToXPathNavigable().CreateNavigator();

        public XPathNavigator ListFilesFiltered(string path, string pattern)
        {
            var files = Directory.GetFiles(Sandbox.EnsureSafePath(_sandbox, path), pattern);
            var xml = new XElement(_ns + "files",
                  from f in files
                  select new XElement(_ns + "file", new XText(f))
              );
            return xml.ToXPathNavigable().CreateNavigator();
        }
    }
}
