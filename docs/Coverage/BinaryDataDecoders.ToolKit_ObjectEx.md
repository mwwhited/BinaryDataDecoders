# BinaryDataDecoders.ToolKit.ObjectEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.ObjectEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `1`                                   |
| Uncoveredlines  | `16`                                  |
| Coverablelines  | `17`                                  |
| Totallines      | `83`                                  |
| Linecoverage    | `5.8`                                 |
| Coveredbranches | `0`                                   |
| Totalbranches   | `28`                                  |
| Branchcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 100   | 100      | `GetResourceStream`        |
| 1          | 0     | 100      | `GetResourceAsStringAsync` |
| 1          | 0     | 100      | `GetXmlNamespace`          |
| 1          | 0     | 100      | `GetXmlNamespaceForOutput` |
| 1          | 0     | 100      | `GetXmlElementName`        |
| 1          | 0     | 100      | `GetXmlItemName`           |
| 28         | 0     | 0        | `GetXmlItemName`           |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ObjectEx.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.IO;
〰3:   using System.Threading.Tasks;
〰4:   using System.Xml;
〰5:   using System.Xml.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit
〰8:   {
〰9:       /// <summary>
〰10:      /// Extension methods for System.Object
〰11:      /// </summary>
〰12:      public static class ObjectEx
〰13:      {
〰14:          /// <summary>
〰15:          /// Access stream for resource found in the same name space as the referenced object
〰16:          /// </summary>
〰17:          /// <param name="context">object to use as locater</param>
〰18:          /// <param name="filename">name of resource</param>
〰19:          /// <returns>resource stream</returns>
〰20:          public static Stream? GetResourceStream(this object context, string filename) =>
✔21:              context.GetType().GetResourceStream(filename);
〰22:  
〰23:          /// <summary>
〰24:          /// Access stream for resource found in the same name space as the referenced object
〰25:          /// </summary>
〰26:          /// <param name="context">object to use as locater</param>
〰27:          /// <param name="filename">name of resource</param>
〰28:          /// <returns>string content of resource</returns>
〰29:          public static Task<string?> GetResourceAsStringAsync(this object context, string filename) =>
‼30:              context.GetResourceStream(filename).ReadAsStringAsync();
〰31:  
〰32:          /// <summary>
〰33:          /// Resolve XML Name space for referenced object.
〰34:          /// </summary>
〰35:          /// <remarks>
〰36:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰37:          ///
〰38:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰39:          /// </remarks>
〰40:          /// <param name="obj"></param>
〰41:          /// <returns></returns>
〰42:          public static string GetXmlNamespace(this object obj) =>
‼43:              obj.GetType().GetXmlNamespace();
〰44:  
〰45:          /// <summary>
〰46:          /// Resolve XML Namespace for referenced object.
〰47:          /// </summary>
〰48:          /// <remarks>
〰49:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰50:          ///
〰51:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰52:          /// </remarks>
〰53:          /// <param name="obj"></param>
〰54:          /// <returns></returns>
〰55:          public static string GetXmlNamespaceForOutput(this object obj) =>
‼56:              obj.GetType().GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰57:  
〰58:  
〰59:          public static XName GetXmlElementName(this object @object, bool excludeNamespace = false) =>
‼60:              @object.GetType().GetXmlElementName(excludeNamespace);
〰61:  
〰62:          public static XName GetXmlItemName(this IEnumerable enumerable, bool excludeNamespace) =>
‼63:              enumerable.GetXmlItemName(enumerable.GetXmlElementName(excludeNamespace));
〰64:  
〰65:          public static XName GetXmlItemName(this IEnumerable enumerable, XName? elementName = null)
〰66:          {
‼67:              var elementType = enumerable.GetType().GetElementType();
‼68:              var itemName = elementType?.Name;
〰69:              return XName.Get(itemName switch
〰70:              {
‼71:                  _ when elementType?.IsAnonymousType() ?? false =>
‼72:                      elementName switch
‼73:                      {
‼74:                          _ when elementName?.LocalName.EndsWith("es") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 2),
‼75:                          _ when elementName?.LocalName.EndsWith("s") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 1),
‼76:                          _ when string.Equals(elementName?.LocalName, "object", System.StringComparison.InvariantCultureIgnoreCase) => null,
‼77:                          _ => null,
‼78:                      },
‼79:                  _ => itemName
〰80:              } ?? "item", elementName?.NamespaceName ?? elementType?.GetXmlNamespace() ?? "");
〰81:          }
〰82:      }
〰83:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

