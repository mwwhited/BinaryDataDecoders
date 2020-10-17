using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static bool EndsInDirectorySeparator(string path) =>
            path.EndsWith(Path.DirectorySeparatorChar) ||
            path.EndsWith(Path.AltDirectorySeparatorChar);

        public static string GetBasePath(string path)
        {
            path = Path.GetFullPath(path);
            if (EndsInDirectorySeparator(path)) path += "*.*";
            var wildCards = new[] { '*', '?' };
            var pathSegments = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var segmentsQuery = from ps in pathSegments
                                select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
            var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));

            if (path == basePath)
            {
                return Path.GetDirectoryName(basePath);
            }

            return basePath;
        }

        public static IEnumerable<string> EnumerateFiles(string wildcardPath)
        {
            wildcardPath = Path.GetFullPath(wildcardPath);

            if (File.Exists(wildcardPath))
            {
                yield return wildcardPath;
                yield break;
            }

            if (EndsInDirectorySeparator(wildcardPath)) wildcardPath += "*.*";
            var wildCards = new[] { '*', '?' };
            var pathSegments = wildcardPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var segmentsQuery = from ps in pathSegments
                                select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
            var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
            // var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard).ToArray();
            //var searchPaths = searchPathSegments[..^1];
            //var searchFilePattern = searchPathSegments[^1].segment;
            var searchPathSegments = string.Join(Path.DirectorySeparatorChar, segmentsQuery.SkipWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
            var searchPaths = Path.GetDirectoryName(searchPathSegments);
            var searchFilePattern = Path.GetFileName(searchPathSegments);

            foreach (var directory in EnumerateDirectories(basePath, searchPaths))
                foreach (var file in Directory.EnumerateFiles(directory, searchFilePattern))
                    yield return file;
        }

        public static IEnumerable<string> EnumerateDirectories(string path, string wildcardPath)
        {
            if (string.IsNullOrWhiteSpace(wildcardPath))
            {
                if (Directory.Exists(path))
                {
                    yield return path;
                }
                yield break;
            }
            path = Path.GetFullPath(path);
            var wildCards = new[] { '*', '?' };
            var pathSegments = wildcardPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var segmentsQuery = from ps in pathSegments
                                select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));

            var basePath = Path.Combine(path, string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment)));
            var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard);
            var enumerator = searchPathSegments.Select(s => s.segment).GetEnumerator();

            var directories = EnumerateDirectories(path, enumerator);
            foreach (var directory in directories)
                yield return directory;
        }

        internal static IEnumerable<string> EnumerateDirectories(string path, IEnumerator<string> enumerator)
        {
            IEnumerable<string> directories = null;
            var recursive = false;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (enumerator.Current == "**")
                {
                    recursive = true;
                    while (enumerator.MoveNext() && enumerator.Current == "**") ;
                }
                var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                if (directories == null)
                {
                    var matches = Directory.EnumerateDirectories(path, enumerator.Current ?? "*.*", searchOption);
                    directories = matches;
                }
                else
                {
                    var searchPath = enumerator.Current ?? "*.*";
                    directories = from dir in directories
                                  from child in Directory.EnumerateDirectories(dir, searchPath, searchOption)
                                  select child;
                }

                recursive = false;
            }

            foreach (var dir in directories ?? Enumerable.Empty<string>())
                yield return dir;
        }
    }
}
