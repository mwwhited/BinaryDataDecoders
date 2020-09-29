
using BinaryDataDecoders.ToolKit.Security;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using static BinaryDataDecoders.ToolKit.ToolkitConstants;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions, BinaryDataDecoders.ToolKit
    /// 
    /// 
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.Base + nameof(PathExtensions))]
    //clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.PathExtensions, BinaryDataDecoders.ToolKit
    public class PathExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sandbox">base path used to sand-box requests</param>
        public PathExtensions(string sandbox)
        {
            _sandbox = sandbox;
            _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
        }
        private readonly string _sandbox;
        private readonly XNamespace _ns;

        /// <summary>
        /// Returns the file name and extension of the specified path string.
        /// </summary>
        /// <param name="file">The path string from which to obtain the file name and extension.</param>
        /// <returns>
        /// The characters after the last directory separator character in path. If the last
        /// character of path is a directory or volume separator character, this method returns
        /// System.String.Empty. If path is null, this method returns null.
        /// </returns>
        public string GetFileName(string file) => Path.GetFileName(file);
        /// <summary>
        /// Returns the file name of the specified path string without the extension.
        /// </summary>
        /// <param name="file">The path of the file.</param>
        /// <returns>
        /// The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
        /// minus the last period (.) and all characters following it.
        /// </returns>
        public string GetFileNameWithoutExtension(string file) => Path.GetFileNameWithoutExtension(file);
        /// <summary>
        /// Returns the extension (including the period ".") of the specified path string.
        /// </summary>
        /// <param name="file">The path string from which to get the extension.</param>
        /// <returns></returns>
        public string GetExtension(string file) => Path.GetExtension(file);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public string ChangeExtension(string file, string extension) => Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);

        public XPathNavigator ListFiles(string path) =>
            new XElement(_ns + "files",
                from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
                select new XElement(_ns + "file", f)
            ).ToXPathNavigable().CreateNavigator();

        public XPathNavigator ListFilesFiltered(string path, string pattern)
        {
            var files = Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path), pattern);
            var xml = new XElement(_ns + "files",
                  from f in files
                  select new XElement(_ns + "file", new XText(f))
              );
            return xml.ToXPathNavigable().CreateNavigator();
        }
    }
}
