
using BinaryDataDecoders.ToolKit.Security;
using System;
using System.Diagnostics;
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
        /// Changes the extension of a path string.
        /// </summary>
        /// <param name="file">The path information to modify. The path cannot contain any of the characters
        /// defined in System.IO.Path.GetInvalidPathChars.</param>
        /// <param name="extension">The new extension (with or without a leading period). Specify null to remove
        /// an existing extension from path.</param>
        /// <returns>The modified path information. On Windows-based desktop platforms, if path is
        /// null or an empty string (""), the path information is returned unmodified. If
        /// extension is null, the returned string contains the specified path with its extension
        /// removed. If path has no extension, and extension is not null, the returned path
        /// string contains extension appended to the end of path.</returns>
        public string ChangeExtension(string file, string extension) => Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search
        /// pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not
        /// case-sensitive.</param>
        /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
        /// that match the specified search pattern, or an empty array if no files are found.</returns>
        public XPathNavigator ListFiles(string path) =>
            new XElement(_ns + "files",
                from f in Directory.GetFiles(SandboxPath.EnsureSafePath(_sandbox, path))
                select new XElement(_ns + "file", f)
            ).ToXPathNavigable().CreateNavigator();

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search
        /// pattern in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not
        /// case-sensitive.</param>
        /// <param name="pattern">The search string to match against the names of files in path. This parameter
        /// can contain a combination of valid literal path and wildcard (* and ?) characters,
        /// but it doesn't support regular expressions.</param>
        /// <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
        /// that match the specified search pattern, or an empty array if no files are found.</returns>
        public XPathNavigator ListFilesFiltered(string path, string pattern)
        {
            var cleanedPath = SandboxPath.EnsureSafePath(_sandbox, path);
#if DEBUG
            Console.WriteLine($"==> Path: {path}");
            Console.WriteLine($"==> Pattern: {pattern}");
            Console.WriteLine($"==> Cleaned: {cleanedPath}");
#endif
            var files = Directory.Exists(cleanedPath) ? Directory.GetFiles(cleanedPath, pattern) : Enumerable.Empty<string>(); ;
            var xml = new XElement(_ns + "files",
                  from f in files
                  select new XElement(_ns + "file", new XText(f))
              );
            return xml.ToXPathNavigable().CreateNavigator();
        }
    }
}
