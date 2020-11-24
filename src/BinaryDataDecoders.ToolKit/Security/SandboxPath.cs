using BinaryDataDecoders.ToolKit.IO;
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
            var currentDirectory = Path.GetFullPath(Environment.CurrentDirectory);

            var composedPath = Path.GetFullPath(
                currentDirectory.StartsWith(sandbox) ?
                    filePath :
                    Path.Combine(basePath, filePath)
                );

            if (!composedPath.StartsWith(sandbox)) throw new ApplicationException($"invalid path requested: {filePath}");
            return PathEx.FixUpPath(composedPath);
        }

        ///// <summary>
        ///// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
        ///// </summary>
        ///// <param name="basePath"></param>
        ///// <param name="filePath"></param>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
        //public static bool IsSafePath(string basePath, string filePath)
        //{
        //    var sandbox = Path.GetFullPath(basePath);
        //    var composedPath = Path.Combine(basePath, filePath);
        //    var fullPath = Path.GetFullPath(composedPath);
        //    return fullPath.StartsWith(sandbox);
        //}
    }
}
