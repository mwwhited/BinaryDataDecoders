using System.IO;

namespace BinaryDataDecoders.ToolKit.IO
{
    /// <summary>
    /// Extensions for path strings
    /// </summary>
    public static class PathEx
    {
        /// <summary>
        /// Create parent directory is does not exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns>return input path to support chaining</returns>
        public static string CreateParentIfNotExists(this string path)
        {
            var realDir = Path.GetDirectoryName(path);
            if (!Directory.Exists(realDir)) Directory.CreateDirectory(realDir);
            return path;
        }
    }
}
