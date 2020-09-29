using System;
using System.IO;

namespace BinaryDataDecoders.ToolKit.Security
{
    /// <summary>
    /// File IO sandboxing operation
    /// </summary>
    public static class SandboxPath
    {
        /// <summary>
        /// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
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
