
# BinaryDataDecoders.ToolKit.IO.PathEx
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_PathEx.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.IO.PathEx                         | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 15                                                           | 
| Coverablelines       | 15                                                           | 
| Totallines           | 135                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 8                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\IO\PathEx.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 2          | 0     | 0        | CreateParentIfNotExists | 
| 2          | 0     | 0        | EndsInDirectorySeparator | 
| 4          | 0     | 0        | GetBasePath | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\IO\PathEx.cs

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
〰30:          public static string GetBasePath(string path)
〰31:          {
‼32:              path = Path.GetFullPath(path);
‼33:              if (EndsInDirectorySeparator(path)) path += "*.*";
‼34:              var wildCards = new[] { '*', '?' };
‼35:              var pathSegments = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
‼36:              var segmentsQuery = from ps in pathSegments
‼37:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
‼38:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰39:  
‼40:              if (path == basePath)
〰41:              {
‼42:                  return Path.GetDirectoryName(basePath);
〰43:              }
〰44:  
‼45:              return basePath;
〰46:          }
〰47:  
〰48:          public static IEnumerable<string> EnumerateFiles(string wildcardPath)
〰49:          {
〰50:              wildcardPath = Path.GetFullPath(wildcardPath);
〰51:  
〰52:              if (File.Exists(wildcardPath))
〰53:              {
〰54:                  yield return wildcardPath;
〰55:                  yield break;
〰56:              }
〰57:  
〰58:              if (EndsInDirectorySeparator(wildcardPath)) wildcardPath += "*.*";
〰59:              var wildCards = new[] { '*', '?' };
〰60:              var pathSegments = wildcardPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
〰61:              var segmentsQuery = from ps in pathSegments
〰62:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
〰63:              var basePath = string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰64:              // var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard).ToArray();
〰65:              //var searchPaths = searchPathSegments[..^1];
〰66:              //var searchFilePattern = searchPathSegments[^1].segment;
〰67:              var searchPathSegments = string.Join(Path.DirectorySeparatorChar, segmentsQuery.SkipWhile(ps => !ps.hasWildcard).Select(ps => ps.segment));
〰68:              var searchPaths = Path.GetDirectoryName(searchPathSegments);
〰69:              var searchFilePattern = Path.GetFileName(searchPathSegments);
〰70:  
〰71:              foreach (var directory in EnumerateDirectories(basePath, searchPaths))
〰72:                  foreach (var file in Directory.EnumerateFiles(directory, searchFilePattern))
〰73:                      yield return file;
〰74:          }
〰75:  
〰76:          public static IEnumerable<string> EnumerateDirectories(string path, string wildcardPath)
〰77:          {
〰78:              if (string.IsNullOrWhiteSpace(wildcardPath))
〰79:              {
〰80:                  if (Directory.Exists(path))
〰81:                  {
〰82:                      yield return path;
〰83:                  }
〰84:                  yield break;
〰85:              }
〰86:              path = Path.GetFullPath(path);
〰87:              var wildCards = new[] { '*', '?' };
〰88:              var pathSegments = wildcardPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
〰89:              var segmentsQuery = from ps in pathSegments
〰90:                                  select (segment: ps, hasWildcard: wildCards.Any(c => ps.Contains(c)));
〰91:  
〰92:              var basePath = Path.Combine(path, string.Join(Path.DirectorySeparatorChar, segmentsQuery.TakeWhile(ps => !ps.hasWildcard).Select(ps => ps.segment)));
〰93:              var searchPathSegments = segmentsQuery.SkipWhile(ps => !ps.hasWildcard);
〰94:              var enumerator = searchPathSegments.Select(s => s.segment).GetEnumerator();
〰95:  
〰96:              var directories = EnumerateDirectories(path, enumerator);
〰97:              foreach (var directory in directories)
〰98:                  yield return directory;
〰99:          }
〰100: 
〰101:         internal static IEnumerable<string> EnumerateDirectories(string path, IEnumerator<string> enumerator)
〰102:         {
〰103:             IEnumerable<string> directories = null;
〰104:             var recursive = false;
〰105:             while (enumerator.MoveNext())
〰106:             {
〰107:                 var current = enumerator.Current;
〰108:                 if (enumerator.Current == "**")
〰109:                 {
〰110:                     recursive = true;
〰111:                     while (enumerator.MoveNext() && enumerator.Current == "**") ;
〰112:                 }
〰113:                 var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
〰114: 
〰115:                 if (directories == null)
〰116:                 {
〰117:                     var matches = Directory.EnumerateDirectories(path, enumerator.Current ?? "*.*", searchOption);
〰118:                     directories = matches;
〰119:                 }
〰120:                 else
〰121:                 {
〰122:                     var searchPath = enumerator.Current ?? "*.*";
〰123:                     directories = from dir in directories
〰124:                                   from child in Directory.EnumerateDirectories(dir, searchPath, searchOption)
〰125:                                   select child;
〰126:                 }
〰127: 
〰128:                 recursive = false;
〰129:             }
〰130: 
〰131:             foreach (var dir in directories ?? Enumerable.Empty<string>())
〰132:                 yield return dir;
〰133:         }
〰134:     }
〰135: }

```
## Footer 
[Return to Summary](Summary.md)

