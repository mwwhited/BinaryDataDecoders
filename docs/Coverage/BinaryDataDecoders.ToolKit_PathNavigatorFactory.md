# BinaryDataDecoders.ToolKit.IO.PathNavigatorFactory

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.PathNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `65`                                                 |
| Coverablelines  | `65`                                                 |
| Totallines      | `86`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `16`                                                 |
| Branchcoverage  | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `2`                                                  |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 16         | 0     | 0        | `AsNode`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/IO/PathNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.IO;
〰4:   using System.Linq;
〰5:   using System.Xml;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.IO
〰10:  {
〰11:      public static class PathNavigatorFactory
〰12:      {
〰13:          public static IXPathNavigable ToNavigable(this DirectoryInfo dir, XName? rootName = null, string? baseUri = null) =>
‼14:              new ExtensibleNavigator(dir.AsNode(rootName, baseUri));
〰15:  
〰16:          public static INode AsNode(this DirectoryInfo dir, XName? rootName = null, string? baseUri = null)
〰17:          {
‼18:              if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
‼19:                  rootName = "Directory";
〰20:  
‼21:              var trimLen = dir.FullName.Length;
〰22:  
‼23:              return new ExtensibleElementNode(
‼24:                  rootName,
‼25:                  dir,
‼26:  
‼27:                    //valueSelector: v => v switch
‼28:                    //{
‼29:                    //    FileInfo file => file.Name,
‼30:                    //    DirectoryInfo directory => directory.Name,
‼31:                    //    _ => throw new NotSupportedException(),
‼32:                    //},
‼33:  
‼34:                    attributeSelector: a => a switch
‼35:                    {
‼36:                        DirectoryInfo directory => new[]
‼37:                        {
‼38:                            (XName.Get(nameof(directory.Attributes), rootName.NamespaceName), directory.Attributes.ToString()),
‼39:                            (XName.Get(nameof(directory.CreationTime), rootName.NamespaceName), directory.CreationTime.ToString()),
‼40:                            (XName.Get(nameof(directory.CreationTimeUtc), rootName.NamespaceName), directory.CreationTimeUtc.ToString()),
‼41:                            (XName.Get(nameof(directory.Extension), rootName.NamespaceName), directory.Extension),
‼42:                            (XName.Get(nameof(directory.FullName), rootName.NamespaceName), directory.FullName),
‼43:                            (XName.Get("RelativeName", rootName.NamespaceName), directory.FullName[trimLen..]),
‼44:                            (XName.Get(nameof(directory.LastAccessTime), rootName.NamespaceName), directory.LastAccessTime.ToString()),
‼45:                            (XName.Get(nameof(directory.LastAccessTimeUtc), rootName.NamespaceName), directory.LastAccessTimeUtc.ToString()),
‼46:                            (XName.Get(nameof(directory.LastWriteTime), rootName.NamespaceName), directory.LastWriteTime.ToString()),
‼47:                            (XName.Get(nameof(directory.LastWriteTimeUtc), rootName.NamespaceName), directory.LastWriteTimeUtc.ToString()),
‼48:                            (XName.Get(nameof(directory.Name), rootName.NamespaceName), directory.Name),
‼49:                            (XName.Get("WithoutExtension", rootName.NamespaceName), Path.GetFileNameWithoutExtension( directory.Name)),
‼50:                        }.Select(i => (i.Item1, (string?)i.Item2)),
‼51:  
‼52:                        FileInfo file => new[]
‼53:                        {
‼54:                            (XName.Get(nameof(file.Attributes), rootName.NamespaceName), file.Attributes.ToString()),
‼55:                            (XName.Get(nameof(file.CreationTime), rootName.NamespaceName), file.CreationTime.ToString()),
‼56:                            (XName.Get(nameof(file.CreationTimeUtc), rootName.NamespaceName), file.CreationTimeUtc.ToString()),
‼57:                            (XName.Get(nameof(file.Extension), rootName.NamespaceName), file.Extension),
‼58:                            (XName.Get(nameof(file.FullName), rootName.NamespaceName), file.FullName),
‼59:                            (XName.Get("RelativeName", rootName.NamespaceName), file.FullName[trimLen..]),
‼60:                            (XName.Get(nameof(file.IsReadOnly), rootName.NamespaceName), file.IsReadOnly.ToString()),
‼61:                            (XName.Get(nameof(file.LastAccessTime), rootName.NamespaceName), file.LastAccessTime.ToString()),
‼62:                            (XName.Get(nameof(file.LastAccessTimeUtc), rootName.NamespaceName), file.LastAccessTimeUtc.ToString()),
‼63:                            (XName.Get(nameof(file.LastWriteTime), rootName.NamespaceName), file.LastWriteTime.ToString()),
‼64:                            (XName.Get(nameof(file.LastWriteTimeUtc), rootName.NamespaceName), file.LastWriteTimeUtc.ToString()),
‼65:                            (XName.Get(nameof(file.Length), rootName.NamespaceName), file.Length.ToString()),
‼66:                            (XName.Get(nameof(file.Name), rootName.NamespaceName), file.Name),
‼67:                            (XName.Get("WithoutExtension", rootName.NamespaceName), Path.GetFileNameWithoutExtension( file.Name)),
‼68:                        }.Select(i => (i.Item1, (string?)i.Item2)),
‼69:  
‼70:                        _ => throw new NotSupportedException(),
‼71:                    },
‼72:  
‼73:  
‼74:                   childSelector: c => c switch
‼75:                   {
‼76:                       DirectoryInfo directory => directory.GetDirectories().Select(fsi => (XName.Get("Directory", rootName.NamespaceName), (object)fsi))
‼77:                                          .Concat(directory.GetFiles().Select(fsi => (XName.Get("File", rootName.NamespaceName), (object)fsi))),
‼78:  
‼79:                       FileInfo file => null,
‼80:  
‼81:                       _ => throw new NotSupportedException()
‼82:                   }
‼83:              );
〰84:          }
〰85:      }
〰86:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

