
# BinaryDataDecoders.ToolKit.Security.SandboxPath
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_SandboxPath.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Security.SandboxPath              | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 9                                                            | 
| Coverablelines       | 9                                                            | 
| Totallines           | 48                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Security\SandboxPath.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 4          | 0     | 0        | EnsureSafePath | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Security\SandboxPath.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Security
〰5:   {
〰6:       /// <summary>
〰7:       /// File IO sandboxing operation
〰8:       /// </summary>
〰9:       public static class SandboxPath
〰10:      {
〰11:          /// <summary>
〰12:          /// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰13:          /// </summary>
〰14:          /// <param name="basePath"></param>
〰15:          /// <param name="filePath"></param>
〰16:          /// <returns></returns>
〰17:          /// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰18:          public static string EnsureSafePath(string basePath, string filePath)
〰19:          {
‼20:              var sandbox = Path.GetFullPath(basePath);
‼21:              var currentDirectory = Path.GetFullPath(Environment.CurrentDirectory);
〰22:  
‼23:              var composedPath = Path.GetFullPath(
‼24:                  currentDirectory.StartsWith(sandbox) ?
‼25:                      filePath :
‼26:                      Path.Combine(basePath, filePath)
‼27:                  );
〰28:  
‼29:              if (!composedPath.StartsWith(sandbox)) throw new ApplicationException($"invalid path requested: {filePath}");
‼30:              return composedPath;
〰31:          }
〰32:  
〰33:          ///// <summary>
〰34:          ///// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰35:          ///// </summary>
〰36:          ///// <param name="basePath"></param>
〰37:          ///// <param name="filePath"></param>
〰38:          ///// <returns></returns>
〰39:          ///// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰40:          //public static bool IsSafePath(string basePath, string filePath)
〰41:          //{
〰42:          //    var sandbox = Path.GetFullPath(basePath);
〰43:          //    var composedPath = Path.Combine(basePath, filePath);
〰44:          //    var fullPath = Path.GetFullPath(composedPath);
〰45:          //    return fullPath.StartsWith(sandbox);
〰46:          //}
〰47:      }
〰48:  }

```
## Footer 
[Return to Summary](Summary.md)

