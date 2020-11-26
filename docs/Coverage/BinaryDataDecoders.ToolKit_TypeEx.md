# BinaryDataDecoders.ToolKit.TypeEx

## Summary

| Key             | Value                               |
| :-------------- | :---------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.TypeEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`        |
| Coveredlines    | `16`                                |
| Uncoveredlines  | `14`                                |
| Coverablelines  | `30`                                |
| Totallines      | `104`                               |
| Linecoverage    | `53.3`                              |
| Coveredbranches | `6`                                 |
| Totalbranches   | `26`                                |
| Branchcoverage  | `23`                                |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 2          | 80.0  | 50.0     | `GetResourceStream`        |
| 2          | 0     | 0        | `GetResourceAsStringAsync` |
| 6          | 0     | 0        | `GetXmlNamespace`          |
| 2          | 0     | 0        | `GetXmlNamespaceForOutput` |
| 1          | 100   | 100      | `cctor`                    |
| 2          | 100   | 100      | `IsSimpleType`             |
| 8          | 0     | 0        | `IsAnonymousType`          |
| 4          | 100   | 75.00    | `GetXmlElementName`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/TypeEx.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Linq;
〰4:   using System.Reflection;
〰5:   using System.Threading.Tasks;
〰6:   using System.Xml;
〰7:   using System.Xml.Linq;
〰8:   using System.Xml.Serialization;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit
〰11:  {
〰12:      /// <summary>
〰13:      /// Extension methods for System.Object
〰14:      /// </summary>
〰15:      public static class TypeEx
〰16:      {
〰17:          /// <summary>
〰18:          /// Access stream for resource found in the same name space as the referenced object
〰19:          /// </summary>
〰20:          /// <param name="classType">object to use as locater</param>
〰21:          /// <param name="filename">name of resource</param>
〰22:          /// <returns>resource stream</returns>
〰23:          public static Stream GetResourceStream(this Type classType, string filename) =>
⚠24:               classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}") ??
✔25:               classType.Assembly.GetManifestResourceStream(
✔26:                   classType.Assembly.GetManifestResourceNames()
‼27:                                     .FirstOrDefault(f => f.EndsWith($".{filename}"))
✔28:                   );
〰29:  
〰30:          /// <summary>
〰31:          /// Access stream for resource found in the same name space as the referenced object
〰32:          /// </summary>
〰33:          /// <param name="context">object to use as locater</param>
〰34:          /// <param name="filename">name of resource</param>
〰35:          /// <returns>string content of resource</returns>
〰36:          public static async Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
‼37:              (await context.GetResourceStream(filename).ReadAsStringAsync()) ?? "";
〰38:  
〰39:          /// <summary>
〰40:          /// Resolve XML Name space for referenced object.
〰41:          /// </summary>
〰42:          /// <remarks>
〰43:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰44:          ///
〰45:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰46:          /// </remarks>
〰47:          /// <param name="type"></param>
〰48:          /// <returns></returns>
〰49:          public static string GetXmlNamespace(this Type type)
〰50:          {
‼51:              var ns = type.GetCustomAttribute<XmlRootAttribute>(true)?.Namespace;
‼52:              if (string.IsNullOrWhiteSpace(ns))
〰53:              {
‼54:                  if (type.IsAnonymousType()) return "";
‼55:                  return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
〰56:              }
‼57:              return ns;
〰58:          }
〰59:  
〰60:          /// <summary>
〰61:          /// Resolve XML Namespace for referenced object.
〰62:          /// </summary>
〰63:          /// <remarks>
〰64:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰65:          ///
〰66:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰67:          /// </remarks>
〰68:          /// <param name="type"></param>
〰69:          /// <returns></returns>
〰70:          public static string GetXmlNamespaceForOutput(this Type type) =>
‼71:              type?.GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰72:  
✔73:          private static readonly Type[] _simpleTypes = new[] {
✔74:              typeof(decimal), typeof(decimal?),
✔75:              typeof(Guid),typeof(Guid?),
✔76:              typeof(bool), typeof(bool?),
✔77:              typeof(DateTime), typeof(DateTime?),
✔78:              typeof(DateTimeOffset),typeof(DateTimeOffset?),
✔79:              typeof(TimeSpan),typeof(TimeSpan?),
✔80:          };
〰81:          /// <summary>
〰82:          /// check if type is "simple" .. primitive or [decimal, datetime, bool]
〰83:          /// </summary>
〰84:          /// <param name="type"></param>
〰85:          /// <returns></returns>
✔86:          public static bool IsSimpleType(this Type type) => type.IsPrimitive || _simpleTypes.Contains(type);
〰87:  
〰88:          public static bool IsAnonymousType(this Type type) =>
‼89:              type?.Name switch
‼90:              {
‼91:                  null => false,
‼92:                  string name when name.StartsWith("<>f__AnonymousType") || name.StartsWith("VB$AnonymousType_") => true,
‼93:                  _ => false
‼94:              };
〰95:  
〰96:          public static XName GetXmlElementName(this Type type, bool excludeNamespace = false)
〰97:          {
✔98:              var objectName = type.Name;
✔99:              if (objectName.StartsWith("<>f__AnonymousType")) objectName = "object";
〰100: 
⚠101:             return XName.Get(XmlConvert.EncodeName(objectName), excludeNamespace ? "" : type.GetXmlNamespace());
〰102:         }
〰103:     }
〰104: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

