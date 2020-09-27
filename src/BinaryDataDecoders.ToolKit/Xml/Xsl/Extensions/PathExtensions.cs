using _Path = System.IO.Path;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    public class PathExtensions
    {
        public string GetFileName(string file) => _Path.GetFileName(file);
        public string GetFileNameWithoutExtension(string file) => _Path.GetFileNameWithoutExtension(file);
        public string GetExtension(string file) => _Path.GetExtension(file);
        public string ChangeExtension(string file, string extension) => _Path.ChangeExtension(file, string.IsNullOrWhiteSpace(extension) ? null : extension);
    }
}
