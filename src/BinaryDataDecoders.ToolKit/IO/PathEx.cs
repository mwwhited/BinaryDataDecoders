using System.IO;

namespace BinaryDataDecoders.ToolKit.IO
{
    public static class PathEx
    {
        public static string CreateParentIfNotExists(this string path)
        {
            var realDir = Path.GetDirectoryName(path);
            if (!Directory.Exists(realDir)) Directory.CreateDirectory(realDir);
            return path;
        }
    }
}
