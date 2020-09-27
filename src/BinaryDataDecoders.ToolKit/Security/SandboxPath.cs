using System;
using System.IO;

namespace BinaryDataDecoders.ToolKit.Security
{
    public static class Sandbox
    {
        public static string EnsureSafePath(string basePath, string filePath)
        {
            var sandbox = Path.GetFullPath(basePath);
            var composedPath = Path.Combine(basePath, filePath);
            var fullPath = Path.GetFullPath(composedPath);
            if (!fullPath.StartsWith(sandbox)) throw new ApplicationException($"invalid path requested: {filePath}");
            return fullPath;
        }
    }
}
