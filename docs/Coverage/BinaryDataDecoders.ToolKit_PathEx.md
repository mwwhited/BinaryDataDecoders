# BinaryDataDecoders.ToolKit.IO.PathEx

## Summary

| Key             | Value                                  |
| :-------------- | :------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.PathEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`           |
| Coveredlines    | `0`                                    |
| Uncoveredlines  | `68`                                   |
| Coverablelines  | `68`                                   |
| Totallines      | `138`                                  |
| Linecoverage    | `0`                                    |
| Coveredbranches | `0`                                    |
| Totalbranches   | `42`                                   |
| Branchcoverage  | `0`                                    |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 2          | 0     | 0        | `CreateParentIfNotExists`  |
| 2          | 0     | 0        | `EndsInDirectorySeparator` |
| 1          | 0     | 100      | `FixUpPath`                |
| 4          | 0     | 0        | `GetBasePath`              |
| 8          | 0     | 0        | `EnumerateFiles`           |
| 6          | 0     | 0        | `EnumerateDirectories`     |
| 20         | 0     | 0        | `EnumerateDirectories`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/IO/PathEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.IO
〰8:   {
〰9:       /// <summary>
〰10:      /// Extensions for path strings
〰11:      /// </summary>
〰12:      public static class PathEx
〰13:      {
〰14:          /// <summary>
〰15:          /// Create parent directory is does not exist
〰16:          /// </summary>
〰17:          /// <param name="path"></param>
〰18:          /// <returns>return input path to support chaining</returns>
〰19:          public static string CreateParentIfNotExists(this string path)
〰20:          {
‼21:              var realDir = Path.GetDirectoryName(path);
‼22:              if (!Directory.Exists(realDir)) Directory.CreateDirectory(realDir);
‼23:              return path;
〰24:          }
〰25:  
〰26:          public static bool EndsInDirectorySeparator(string path) =>
‼27:              path.EndsWith(Path.DirectorySeparatorChar) ||
‼28:              path.EndsWith(Path.AltDirectorySeparatorChar);
〰29:  
〰30:          public static string FixUpPath(string path) =>
‼31:             string.Join(Path.DirectorySeparatorChar, path.Split('/', '\\'));
〰32:  
〰33:          public static string GetBasePath(string path)
〰34:          {
‼35:              path = Path.GetFullPath(path);
‼36:              if (EndsInDirectorySeparator(path)) path += "*.*";
‼37:              var wildCards = new[] { '*', '?' };
‼38:              var pathSegments = path.Split('/', '\\');
‼39:              var segmentsQuery = from ps in pathSegments
‼40:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
‼41:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰42:  
‼43:              if (path == basePath)
〰44:              {
‼45:                  return Path.GetDirectoryName(basePath);
〰46:              }
〰47:  
‼48:              return basePath;
〰49:          }
〰50:  
〰51:          public static IEnumerable<string> EnumerateFiles(string wildcardPath)
〰52:          {
‼53:              wildcardPath = Path.GetFullPath(wildcardPath);
〰54:  
‼55:              if (File.Exists(wildcardPath))
〰56:              {
‼57:                  yield return wildcardPath;
‼58:                  yield break;
〰59:              }
〰60:  
‼61:              if (EndsInDirectorySeparator(wildcardPath)) wildcardPath += "*.*";
‼62:              var wildCards = new[] { '*', '?' };
‼63:              var pathSegments = wildcardPath.Split('/', '\\');
‼64:              var segmentsQuery = from ps in pathSegments
‼65:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
‼66:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰67:              // var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard).ToArray();
〰68:              //var searchPaths = searchPathSegments[..^1];
〰69:              //var searchFilePattern = searchPathSegments[^1].segment;
‼70:              var searchPathSegments = string.Join(Path.DirectorySeparatorChar, segmentsQuery.SkipWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
‼71:              var searchPaths = Path.GetDirectoryName(searchPathSegments);
‼72:              var searchFilePattern = Path.GetFileName(searchPathSegments);
〰73:  
‼74:              foreach (var directory in EnumerateDirectories(basePath, searchPaths))
‼75:                  foreach (var file in Directory.EnumerateFiles(directory, searchFilePattern))
‼76:                      yield return file;
‼77:          }
〰78:  
〰79:          public static IEnumerable<string> EnumerateDirectories(string path, string wildcardPath)
〰80:          {
‼81:              if (string.IsNullOrWhiteSpace(wildcardPath))
〰82:              {
‼83:                  if (Directory.Exists(path))
〰84:                  {
‼85:                      yield return path;
〰86:                  }
‼87:                  yield break;
〰88:              }
‼89:              path = Path.GetFullPath(path);
‼90:              var wildCards = new[] { '*', '?' };
‼91:              var pathSegments = wildcardPath.Split('/', '\\');
‼92:              var segmentsQuery = from ps in pathSegments
‼93:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
〰94:  
‼95:              var basePath = Path.Combine(path, string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment)));
‼96:              var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard);
‼97:              var enumerator = searchPathSegments.Select(s => s.segment).GetEnumerator();
〰98:  
‼99:              var directories = EnumerateDirectories(path, enumerator);
‼100:             foreach (var directory in directories)
‼101:                 yield return directory;
‼102:         }
〰103: 
〰104:         internal static IEnumerable<string> EnumerateDirectories(string path, IEnumerator<string> enumerator)
〰105:         {
‼106:             IEnumerable<string> directories = null;
‼107:             var recursive = false;
‼108:             while (enumerator.MoveNext())
〰109:             {
‼110:                 var current = enumerator.Current;
‼111:                 if (enumerator.Current == "**")
〰112:                 {
‼113:                     recursive = true;
‼114:                     while (enumerator.MoveNext() && enumerator.Current == "**") ;
〰115:                 }
‼116:                 var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
〰117: 
‼118:                 if (directories == null)
〰119:                 {
‼120:                     var matches = Directory.EnumerateDirectories(path, enumerator.Current ?? "*.*", searchOption);
‼121:                     directories = matches;
〰122:                 }
〰123:                 else
〰124:                 {
‼125:                     var searchPath = enumerator.Current ?? "*.*";
‼126:                     directories = from dir in directories
‼127:                                   from child in Directory.EnumerateDirectories(dir, searchPath, searchOption)
‼128:                                   select child;
〰129:                 }
〰130: 
‼131:                 recursive = false;
〰132:             }
〰133: 
‼134:             foreach (var dir in directories ?? Enumerable.Empty<string>())
‼135:                 yield return dir;
‼136:         }
〰137:     }
〰138: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

