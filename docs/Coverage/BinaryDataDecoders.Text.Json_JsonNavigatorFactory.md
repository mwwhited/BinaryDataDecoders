# BinaryDataDecoders.Text.Json.JsonNavigatorFactory

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Json.JsonNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.Text.Json`                      |
| Coveredlines    | `44`                                                |
| Uncoveredlines  | `17`                                                |
| Coverablelines  | `61`                                                |
| Totallines      | `87`                                                |
| Linecoverage    | `72.1`                                              |
| Coveredbranches | `16`                                                |
| Totalbranches   | `34`                                                |
| Branchcoverage  | `47`                                                |
| Coveredmethods  | `3`                                                 |
| Totalmethods    | `5`                                                 |
| Methodcoverage  | `60`                                                |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `ParseAsJsonPath` |
| 1          | 100   | 100      | `ToNavigable`     |
| 1          | 100   | 100      | `ToNavigable`     |
| 1          | 0     | 100      | `AsNode`          |
| 34         | 73.68 | 47.05    | `AsNode`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Json/JsonNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.Text.Json.JsonPath.Parser;
〰2:   using BinaryDataDecoders.ToolKit.PathSegments;
〰3:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   using System;
〰5:   using System.Linq;
〰6:   using System.Text.Json;
〰7:   using System.Xml.Linq;
〰8:   using System.Xml.XPath;
〰9:   
〰10:  namespace BinaryDataDecoders.Text.Json
〰11:  {
〰12:      public static class JsonNavigatorFactory
〰13:      {
‼14:          public static IPathSegment ParseAsJsonPath(this string jsonPath) => JsonPathFactory.Parse(jsonPath);
〰15:  
〰16:          public static IXPathNavigable ToNavigable(this JsonDocument json, XName? rootName = null, string? baseUri = null) =>
✔17:              json.RootElement.ToNavigable(rootName, baseUri);
〰18:  
〰19:          public static IXPathNavigable ToNavigable(this JsonElement json, XName? rootName = null, string? baseUri = null) =>
✔20:              new ExtensibleNavigator(json.AsNode(rootName, baseUri));
〰21:  
〰22:          public static INode AsNode(this JsonDocument json, XName? rootName = null, string? baseUri = null) =>
‼23:              json.RootElement.AsNode(rootName, baseUri);
〰24:  
〰25:          public static INode AsNode(this JsonElement json, XName? rootName = null, string? baseUri = null)
〰26:          {
⚠27:              if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
✔28:                  rootName = XName.Get(json.ValueKind.ToString(), baseUri ?? "");
〰29:  
✔30:              return new ExtensibleElementNode(
✔31:                  rootName,
✔32:                  json.Clone(),
✔33:  
⚠34:                  valueSelector: v => v switch
✔35:                  {
⚠36:                      JsonElement element => element.ValueKind switch
✔37:                      {
‼38:                          JsonValueKind.Array => null,
✔39:                          JsonValueKind.Object => null,
✔40:  
✔41:                          JsonValueKind.String => element.GetString(),
✔42:                          _ => element.GetRawText()
✔43:                      },
✔44:  
‼45:                      JsonProperty property => property.Value.ValueKind switch
‼46:                      {
‼47:                          JsonValueKind.Array => null,
‼48:                          JsonValueKind.Object => null,
‼49:  
‼50:                          JsonValueKind.String => property.Value.GetString(),
‼51:                          _ => property.Value.GetRawText()
‼52:                      },
✔53:  
‼54:                      _ => throw new NotSupportedException(),
✔55:                  },
✔56:  
⚠57:                   attributeSelector: a => a switch
✔58:                   {
✔59:                       JsonElement element => new (XName, string?)[]
✔60:                       {
✔61:                          (XName.Get("kind", ""), element.ValueKind.ToString()),
✔62:  
✔63:                       }.Where(a => a.Item2 != null).AsEnumerable(),
✔64:  
‼65:                       JsonProperty property => null,
✔66:  
‼67:                       _ => throw new NotSupportedException(),
✔68:                   },
✔69:  
⚠70:                   childSelector: c => c switch
✔71:                   {
✔72:                       JsonElement element => element.ValueKind switch
✔73:                       {
‼74:                           JsonValueKind.Array => element.EnumerateArray().Select(i => (XName.Get("item", rootName.NamespaceName), (object)i)),
✔75:                           JsonValueKind.Object => element.EnumerateObject().Select(i => (XName.Get(i.Name, rootName.NamespaceName), (object)i.Value)),
✔76:  
✔77:                           _ => null
✔78:                       },
✔79:  
‼80:                       JsonProperty property => new[] { (XName.Get(property.Name, rootName.NamespaceName), (object)property.Value) }.AsEnumerable(),
✔81:  
‼82:                       _ => throw new NotSupportedException()
✔83:                   }
✔84:              );
〰85:          }
〰86:      }
〰87:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

