# BinaryDataDecoders.ToolKit.IO.PathEx

## Summary

| Key             | Value                                  |
| :-------------- | :------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.PathEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`           |
| Coveredlines    | `0`                                    |
| Uncoveredlines  | `75`                                   |
| Coverablelines  | `75`                                   |
| Totallines      | `147`                                  |
| Linecoverage    | `0`                                    |
| Coveredbranches | `0`                                    |
| Totalbranches   | `48`                                   |
| Branchcoverage  | `0`                                    |
| Coveredmethods  | `0`                                    |
| Totalmethods    | `7`                                    |
| Methodcoverage  | `0`                                    |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 2          | 0     | 0        | `CreateParentIfNotExists`  |
| 2          | 0     | 0        | `EndsInDirectorySeparator` |
| 2          | 0     | 0        | `FixUpPath`                |
| 6          | 0     | 0        | `GetBasePath`              |
| 10         | 0     | 0        | `EnumerateFiles`           |
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
‼22:              if (!Directory.Exists(realDir))
‼23:                  Directory.CreateDirectory(realDir);
‼24:              return path;
〰25:          }
〰26:  
〰27:          public static bool EndsInDirectorySeparator(string path) =>
‼28:              path.EndsWith(Path.DirectorySeparatorChar) ||
‼29:              path.EndsWith(Path.AltDirectorySeparatorChar);
〰30:  
〰31:          public static string? FixUpPath(string path) =>
‼32:             string.IsNullOrWhiteSpace(path) ? null : string.Join(Path.DirectorySeparatorChar, path.Split('/', '\\'));
〰33:  
〰34:          public static string? GetBasePath(string path)
〰35:          {
‼36:              if (string.IsNullOrWhiteSpace(path))
‼37:                  return null;
‼38:              path = Path.GetFullPath(path);
‼39:              if (EndsInDirectorySeparator(path))
‼40:                  path += "*.*";
‼41:              var wildCards = new[] { '*', '?' };
‼42:              var pathSegments = path.Split('/', '\\');
‼43:              var segmentsQuery = from ps in pathSegments
‼44:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
‼45:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰46:  
‼47:              if (path == basePath)
〰48:              {
‼49:                  return Path.GetDirectoryName(basePath);
〰50:              }
〰51:  
‼52:              return basePath;
〰53:          }
〰54:  
〰55:          public static IEnumerable<string> EnumerateFiles(string? wildcardPath)
〰56:          {
‼57:              if (string.IsNullOrWhiteSpace(wildcardPath))
‼58:                  yield break;
〰59:  
‼60:              wildcardPath = Path.GetFullPath(wildcardPath);
〰61:  
‼62:              if (File.Exists(wildcardPath))
〰63:              {
‼64:                  yield return wildcardPath;
‼65:                  yield break;
〰66:              }
〰67:  
‼68:              if (EndsInDirectorySeparator(wildcardPath))
‼69:                  wildcardPath += "*.*";
‼70:              var wildCards = new[] { '*', '?' };
‼71:              var pathSegments = wildcardPath.Split('/', '\\');
‼72:              var segmentsQuery = from ps in pathSegments
‼73:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
‼74:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰75:              // var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard).ToArray();
〰76:              //var searchPaths = searchPathSegments[..^1];
〰77:              //var searchFilePattern = searchPathSegments[^1].segment;
‼78:              var searchPathSegments = string.Join(Path.DirectorySeparatorChar, segmentsQuery.SkipWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
‼79:              var searchPaths = Path.GetDirectoryName(searchPathSegments);
‼80:              var searchFilePattern = Path.GetFileName(searchPathSegments);
〰81:  
‼82:              foreach (var directory in EnumerateDirectories(basePath, searchPaths))
‼83:                  foreach (var file in Directory.EnumerateFiles(directory, searchFilePattern))
‼84:                      yield return file;
‼85:          }
〰86:  
〰87:          public static IEnumerable<string> EnumerateDirectories(string path, string wildcardPath)
〰88:          {
‼89:              if (string.IsNullOrWhiteSpace(wildcardPath))
〰90:              {
‼91:                  if (Directory.Exists(path))
〰92:                  {
‼93:                      yield return path;
〰94:                  }
‼95:                  yield break;
〰96:              }
‼97:              path = Path.GetFullPath(path);
‼98:              var wildCards = new[] { '*', '?' };
‼99:              var pathSegments = wildcardPath.Split('/', '\\');
‼100:             var segmentsQuery = from ps in pathSegments
‼101:                                 select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
〰102: 
‼103:             var basePath = Path.Combine(path, string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment)));
‼104:             var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard);
‼105:             var enumerator = searchPathSegments.Select(s => s.segment).GetEnumerator();
〰106: 
‼107:             var directories = EnumerateDirectories(path, enumerator);
‼108:             foreach (var directory in directories)
‼109:                 yield return directory;
‼110:         }
〰111: 
〰112:         internal static IEnumerable<string> EnumerateDirectories(string path, IEnumerator<string> enumerator)
〰113:         {
‼114:             IEnumerable<string> directories = null;
‼115:             var recursive = false;
‼116:             while (enumerator.MoveNext())
〰117:             {
‼118:                 var current = enumerator.Current;
‼119:                 if (enumerator.Current == "**")
〰120:                 {
‼121:                     recursive = true;
‼122:                     while (enumerator.MoveNext() && enumerator.Current == "**")
〰123:                         ;
〰124:                 }
‼125:                 var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
〰126: 
‼127:                 if (directories == null)
〰128:                 {
‼129:                     var matches = Directory.EnumerateDirectories(path, enumerator.Current ?? "*.*", searchOption);
‼130:                     directories = matches;
〰131:                 }
〰132:                 else
〰133:                 {
‼134:                     var searchPath = enumerator.Current ?? "*.*";
‼135:                     directories = from dir in directories
‼136:                                   from child in Directory.EnumerateDirectories(dir, searchPath, searchOption)
‼137:                                   select child;
〰138:                 }
〰139: 
‼140:                 recursive = false;
〰141:             }
〰142: 
‼143:             foreach (var dir in directories ?? Enumerable.Empty<string>())
‼144:                 yield return dir;
‼145:         }
〰146:     }
〰147: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

