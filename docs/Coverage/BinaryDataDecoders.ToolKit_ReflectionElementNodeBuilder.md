# BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNodeBuilder

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNodeBuilder` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                         |
| Coveredlines    | `64`                                                                 |
| Uncoveredlines  | `20`                                                                 |
| Coverablelines  | `84`                                                                 |
| Totallines      | `131`                                                                |
| Linecoverage    | `76.1`                                                               |
| Coveredbranches | `46`                                                                 |
| Totalbranches   | `74`                                                                 |
| Branchcoverage  | `62.1`                                                               |
| Coveredmethods  | `9`                                                                  |
| Totalmethods    | `10`                                                                 |
| Methodcoverage  | `90`                                                                 |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 100   | 100      | `ctor`               |
| 1          | 88.88 | 100      | `Build`              |
| 1          | 0     | 100      | `PreserveWhitespace` |
| 1          | 100   | 100      | `NamespacesSelector` |
| 12         | 90.0  | 66.66    | `ChildSelector`      |
| 8          | 80.0  | 62.50    | `AllowNavigate`      |
| 1          | 50.0  | 100      | `SafeRead`           |
| 20         | 90.0  | 50.0     | `AttributeSelector`  |
| 20         | 58.82 | 65.00    | `ValueSelector`      |
| 14         | 63.63 | 71.42    | `IsValue`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Reflection/ReflectionElementNodeBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Collections;
〰4:   using System.Collections.Generic;
〰5:   using System.Diagnostics;
〰6:   using System.IO;
〰7:   using System.Linq;
〰8:   using System.Reflection;
〰9:   using System.Xml.Linq;
〰10:  
〰11:  namespace BinaryDataDecoders.ToolKit.Reflection
〰12:  {
〰13:      public class ReflectionElementNodeBuilder
〰14:      {
〰15:          protected bool ExcludeNamespace { get; }
〰16:          protected bool ExcludeTypeDetails { get; }
〰17:          protected object Seed { get; }
〰18:  
〰19:          public ReflectionElementNodeBuilder(object seed, bool excludeNamespace = false, bool excludeTypeDetails = false)
〰20:          {
〰21:              Seed = seed;
〰22:              ExcludeNamespace = excludeNamespace;
〰23:              ExcludeTypeDetails = excludeTypeDetails;
✔24:          }
〰25:  
〰26:          public INode Build() =>
✔27:              new ExtensibleElementNode(
✔28:                   Seed.GetXmlElementName(ExcludeNamespace),
✔29:                   Seed,
✔30:                   o => ValueSelector(o),
✔31:                   o => AttributeSelector(o),
✔32:                   o => ChildSelector(o),
✔33:                   o => NamespacesSelector(o),
‼34:                   o => PreserveWhitespace(o)
✔35:                   );
〰36:  
‼37:          protected virtual bool PreserveWhitespace(object obj) => true;
✔38:          protected virtual IEnumerable<XName>? NamespacesSelector(object model) => Enumerable.Empty<XName>();
〰39:  
〰40:          protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
⚠41:               IsValue(model) ? null : model switch
✔42:               {
‼43:                   null => null,
✔44:                   IEnumerable enumerable => from item in enumerable.Cast<object>()
✔45:                                             where item != null
✔46:                                             select (item.GetXmlElementName(ExcludeNamespace), item),
⚠47:                   _ => from property in model.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>()
⚠48:                        where property.CanRead && AllowNavigate(model, property)
⚠49:                        select (XName.Get(property.Name, ExcludeNamespace ? "" : model.GetXmlNamespace()), SafeRead(model, property))
✔50:               };
〰51:  
〰52:          protected virtual bool AllowNavigate(object model, PropertyInfo property) =>
⚠53:              model switch
✔54:              {
‼55:                  null => false,
‼56:                  Type _ => false,
✔57:                  _ => property.GetIndexParameters() switch
✔58:                  {
⚠59:                      ParameterInfo[] indexes when indexes.Length > 0 => false,
✔60:                      _ => true,
✔61:                  }
✔62:              };
〰63:  
〰64:          protected virtual object? SafeRead(object model, PropertyInfo property)
〰65:          {
〰66:              try
〰67:              {
✔68:                  return property.GetValue(model);
〰69:              }
‼70:              catch (Exception ex)
〰71:              {
〰72:                  Debug.WriteLine($"Failed to read {property.Name}: {ex.Message}");
‼73:                  return null;
〰74:              }
✔75:          }
〰76:  
〰77:          protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
⚠78:              ExcludeTypeDetails switch
✔79:              {
‼80:                  true => null,
✔81:                  false => model switch
✔82:                  {
‼83:                      null => null,
✔84:                      // Type type => new (XName name, string? value)[] {
✔85:                      //    (XName.Get("AssemblyQualifiedName"), type.AssemblyQualifiedName),
✔86:                      //    (XName.Get("Name"), type.Name),
✔87:                      //    (XName.Get("FullName"),type.FullName),
✔88:                      //    (XName.Get("Namespace"), type.Namespace),
✔89:                      //},
⚠90:                      _ => new (XName name, string? value)[] {
✔91:                         (XName.Get("AssemblyQualifiedName"), model?.GetType()?.AssemblyQualifiedName),
✔92:                         (XName.Get("Name"), model?.GetType()?.Name),
✔93:                         (XName.Get("FullName"), model?.GetType()?.FullName),
✔94:                         (XName.Get("Namespace"), model?.GetType()?.Namespace),
✔95:                     }
✔96:                  }
✔97:              };
〰98:  
〰99:          protected virtual string? ValueSelector(object model) =>
⚠100:             IsValue(model) ? model switch
✔101:             {
‼102:                 null => null,
✔103: 
‼104:                 Type type => type.AssemblyQualifiedName,
✔105: 
✔106:                 byte[] bytes => Convert.ToBase64String(bytes),
‼107:                 IEnumerable<byte> bytes => Convert.ToBase64String(bytes.ToArray()),
‼108:                 MemoryStream ms => Convert.ToBase64String(ms.ToArray()),
‼109:                 Stream stream => Convert.ToBase64String(stream.AsBytes()),
✔110: 
✔111:                 string @string => @string,
‼112:                 char[] chars => new string(chars),
‼113:                 IEnumerable<char> chars => new string(chars.ToArray()),
✔114: 
✔115:                 _ => null // model.ToString()
✔116:             } : null;
〰117: 
〰118:         protected virtual bool IsValue(object input) =>
⚠119:             input switch
✔120:             {
‼121:                 null => false,
✔122:                 _ when input.GetType().IsSimpleType() => true,
✔123:                 byte[] _ => true,
‼124:                 IEnumerable<byte> _ => true,
‼125:                 char[] _ => true,
✔126:                 IEnumerable<char> _ => true,
‼127:                 Stream _ => true,
✔128:                 _ => false
✔129:             };
〰130:     }
〰131: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

