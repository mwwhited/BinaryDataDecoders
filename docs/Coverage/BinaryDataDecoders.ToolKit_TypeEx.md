# BinaryDataDecoders.ToolKit.TypeEx

## Summary

| Key             | Value                               |
| :-------------- | :---------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.TypeEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`        |
| Coveredlines    | `1`                                 |
| Uncoveredlines  | `25`                                |
| Coverablelines  | `26`                                |
| Totallines      | `100`                               |
| Linecoverage    | `3.8`                               |
| Coveredbranches | `0`                                 |
| Totalbranches   | `24`                                |
| Branchcoverage  | `0`                                 |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 100   | 100      | `GetResourceStream`        |
| 2          | 0     | 0        | `GetResourceAsStringAsync` |
| 6          | 0     | 0        | `GetXmlNamespace`          |
| 2          | 0     | 0        | `GetXmlNamespaceForOutput` |
| 1          | 0     | 100      | `cctor`                    |
| 2          | 0     | 0        | `IsSimpleType`             |
| 8          | 0     | 0        | `IsAnonymousType`          |
| 4          | 0     | 0        | `GetXmlElementName`        |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\TypeEx.cs

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
✔24:               classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");
〰25:  
〰26:          /// <summary>
〰27:          /// Access stream for resource found in the same name space as the referenced object
〰28:          /// </summary>
〰29:          /// <param name="context">object to use as locater</param>
〰30:          /// <param name="filename">name of resource</param>
〰31:          /// <returns>string content of resource</returns>
〰32:          public static async Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
‼33:              (await context.GetResourceStream(filename).ReadAsStringAsync()) ?? "";
〰34:  
〰35:          /// <summary>
〰36:          /// Resolve XML Name space for referenced object.
〰37:          /// </summary>
〰38:          /// <remarks>
〰39:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰40:          ///
〰41:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰42:          /// </remarks>
〰43:          /// <param name="type"></param>
〰44:          /// <returns></returns>
〰45:          public static string GetXmlNamespace(this Type type)
〰46:          {
‼47:              var ns = type.GetCustomAttribute<XmlRootAttribute>(true)?.Namespace;
‼48:              if (string.IsNullOrWhiteSpace(ns))
〰49:              {
‼50:                  if (type.IsAnonymousType()) return "";
‼51:                  return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
〰52:              }
‼53:              return ns;
〰54:          }
〰55:  
〰56:          /// <summary>
〰57:          /// Resolve XML Namespace for referenced object.
〰58:          /// </summary>
〰59:          /// <remarks>
〰60:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰61:          ///
〰62:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰63:          /// </remarks>
〰64:          /// <param name="type"></param>
〰65:          /// <returns></returns>
〰66:          public static string GetXmlNamespaceForOutput(this Type type) =>
‼67:              type?.GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰68:  
‼69:          private static readonly Type[] _simpleTypes = new[] {
‼70:              typeof(decimal), typeof(decimal?),
‼71:              typeof(Guid),typeof(Guid?),
‼72:              typeof(bool), typeof(bool?),
‼73:              typeof(DateTime), typeof(DateTime?),
‼74:              typeof(DateTimeOffset),typeof(DateTimeOffset?),
‼75:              typeof(TimeSpan),typeof(TimeSpan?),
‼76:          };
〰77:          /// <summary>
〰78:          /// check if type is "simple" .. primitive or [decimal, datetime, bool]
〰79:          /// </summary>
〰80:          /// <param name="type"></param>
〰81:          /// <returns></returns>
‼82:          public static bool IsSimpleType(this Type type) => type.IsPrimitive || _simpleTypes.Contains(type);
〰83:  
〰84:          public static bool IsAnonymousType(this Type type) =>
‼85:              type?.Name switch
‼86:              {
‼87:                  null => false,
‼88:                  string name when name.StartsWith("<>f__AnonymousType") || name.StartsWith("VB$AnonymousType_") => true,
‼89:                  _ => false
‼90:              };
〰91:  
〰92:          public static XName GetXmlElementName(this Type type, bool excludeNamespace = false)
〰93:          {
‼94:              var objectName = type.Name;
‼95:              if (objectName.StartsWith("<>f__AnonymousType")) objectName = "object";
〰96:  
‼97:              return XName.Get(XmlConvert.EncodeName(objectName), excludeNamespace ? "" : type.GetXmlNamespace());
〰98:          }
〰99:      }
〰100: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

