# BinaryDataDecoders.ToolKit.ObjectEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.ObjectEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `2`                                   |
| Uncoveredlines  | `15`                                  |
| Coverablelines  | `17`                                  |
| Totallines      | `82`                                  |
| Linecoverage    | `11.7`                                |
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
| 1          | 100   | 100      | `GetXmlElementName`        |
| 1          | 0     | 100      | `GetXmlItemName`           |
| 28         | 0     | 0        | `GetXmlItemName`           |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ObjectEx.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.IO;
〰3:   using System.Threading.Tasks;
〰4:   using System.Xml.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit
〰7:   {
〰8:       /// <summary>
〰9:       /// Extension methods for System.Object
〰10:      /// </summary>
〰11:      public static class ObjectEx
〰12:      {
〰13:          /// <summary>
〰14:          /// Access stream for resource found in the same name space as the referenced object
〰15:          /// </summary>
〰16:          /// <param name="context">object to use as locater</param>
〰17:          /// <param name="filename">name of resource</param>
〰18:          /// <returns>resource stream</returns>
〰19:          public static Stream? GetResourceStream(this object context, string filename) =>
✔20:              context.GetType().GetResourceStream(filename);
〰21:  
〰22:          /// <summary>
〰23:          /// Access stream for resource found in the same name space as the referenced object
〰24:          /// </summary>
〰25:          /// <param name="context">object to use as locater</param>
〰26:          /// <param name="filename">name of resource</param>
〰27:          /// <returns>string content of resource</returns>
〰28:          public static Task<string?> GetResourceAsStringAsync(this object context, string filename) =>
‼29:              context.GetResourceStream(filename).ReadAsStringAsync();
〰30:  
〰31:          /// <summary>
〰32:          /// Resolve XML Name space for referenced object.
〰33:          /// </summary>
〰34:          /// <remarks>
〰35:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰36:          ///
〰37:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰38:          /// </remarks>
〰39:          /// <param name="obj"></param>
〰40:          /// <returns></returns>
〰41:          public static string GetXmlNamespace(this object obj) =>
‼42:              obj.GetType().GetXmlNamespace();
〰43:  
〰44:          /// <summary>
〰45:          /// Resolve XML Namespace for referenced object.
〰46:          /// </summary>
〰47:          /// <remarks>
〰48:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰49:          ///
〰50:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰51:          /// </remarks>
〰52:          /// <param name="obj"></param>
〰53:          /// <returns></returns>
〰54:          public static string GetXmlNamespaceForOutput(this object obj) =>
‼55:              obj.GetType().GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰56:  
〰57:  
〰58:          public static XName GetXmlElementName(this object @object, bool excludeNamespace = false) =>
✔59:              @object.GetType().GetXmlElementName(excludeNamespace);
〰60:  
〰61:          public static XName GetXmlItemName(this IEnumerable enumerable, bool excludeNamespace) =>
‼62:              enumerable.GetXmlItemName(enumerable.GetXmlElementName(excludeNamespace));
〰63:  
〰64:          public static XName GetXmlItemName(this IEnumerable enumerable, XName? elementName = null)
〰65:          {
‼66:              var elementType = enumerable.GetType().GetElementType();
‼67:              var itemName = elementType?.Name;
〰68:              return XName.Get(itemName switch
〰69:              {
‼70:                  _ when elementType?.IsAnonymousType() ?? false =>
‼71:                      elementName switch
‼72:                      {
‼73:                          _ when elementName?.LocalName.EndsWith("es") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 2),
‼74:                          _ when elementName?.LocalName.EndsWith("s") ?? false => elementName.LocalName.Substring(0, elementName.LocalName.Length - 1),
‼75:                          _ when string.Equals(elementName?.LocalName, "object", System.StringComparison.InvariantCultureIgnoreCase) => null,
‼76:                          _ => null,
‼77:                      },
‼78:                  _ => itemName
〰79:              } ?? "item", elementName?.NamespaceName ?? elementType?.GetXmlNamespace() ?? "");
〰80:          }
〰81:      }
〰82:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

