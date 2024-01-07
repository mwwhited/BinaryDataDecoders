# BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNodeBuilder

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNodeBuilder` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                         |
| Coveredlines    | `63`                                                                 |
| Uncoveredlines  | `103`                                                                |
| Coverablelines  | `166`                                                                |
| Totallines      | `247`                                                                |
| Linecoverage    | `37.9`                                                               |
| Coveredbranches | `46`                                                                 |
| Totalbranches   | `148`                                                                |
| Branchcoverage  | `31`                                                                 |
| Coveredmethods  | `8`                                                                  |
| Totalmethods    | `18`                                                                 |
| Methodcoverage  | `44.4`                                                               |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `Build`              |
| 1          | 0     | 100      | `PreserveWhitespace` |
| 1          | 0     | 100      | `NamespacesSelector` |
| 12         | 0     | 0        | `ChildSelector`      |
| 8          | 0     | 0        | `AllowNavigate`      |
| 1          | 0     | 100      | `SafeRead`           |
| 20         | 0     | 0        | `AttributeSelector`  |
| 20         | 0     | 0        | `ValueSelector`      |
| 14         | 0     | 0        | `IsValue`            |
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
〰11:  namespace BinaryDataDecoders.ToolKit.Reflection;
〰12:  
〰13:  public class ReflectionElementNodeBuilder(object seed, bool excludeNamespace = false, bool excludeTypeDetails = false)
〰14:  {
〰15:      protected bool ExcludeNamespace { get; } = excludeNamespace;
〰16:      protected bool ExcludeTypeDetails { get; } = excludeTypeDetails;
〰17:      protected object Seed { get; } = seed;
〰18:  
〰19:      public INode Build() =>
‼20:          new ExtensibleElementNode(
‼21:               Seed.GetXmlElementName(ExcludeNamespace),
‼22:               Seed,
‼23:               o => ValueSelector(o),
‼24:               o => AttributeSelector(o),
‼25:               o => ChildSelector(o),
‼26:               o => NamespacesSelector(o),
‼27:               o => PreserveWhitespace(o)
‼28:               );
〰29:  
‼30:      protected virtual bool PreserveWhitespace(object obj) => true;
‼31:      protected virtual IEnumerable<XName>? NamespacesSelector(object model) => Enumerable.Empty<XName>();
〰32:  
〰33:      protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
‼34:           IsValue(model) ? null : model switch
‼35:           {
‼36:               null => null,
‼37:               IEnumerable enumerable => from item in enumerable.Cast<object>()
‼38:                                         where item != null
‼39:                                         select (item.GetXmlElementName(ExcludeNamespace), item),
‼40:               _ => from property in model.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>()
‼41:                    where property.CanRead && AllowNavigate(model, property)
‼42:                    select (XName.Get(property.Name, ExcludeNamespace ? "" : model.GetXmlNamespace()), SafeRead(model, property))
‼43:           };
〰44:  
〰45:      protected virtual bool AllowNavigate(object model, PropertyInfo property) =>
‼46:          model switch
‼47:          {
‼48:              null => false,
‼49:              Type _ => false,
‼50:              _ => property.GetIndexParameters() switch
‼51:              {
‼52:                  ParameterInfo[] indexes when indexes.Length > 0 => false,
‼53:                  _ => true,
‼54:              }
‼55:          };
〰56:  
〰57:      protected virtual object? SafeRead(object model, PropertyInfo property)
〰58:      {
〰59:          try
〰60:          {
‼61:              return property.GetValue(model);
〰62:          }
‼63:          catch (Exception ex)
〰64:          {
〰65:              Debug.WriteLine($"Failed to read {property.Name}: {ex.Message}");
‼66:              return null;
〰67:          }
‼68:      }
〰69:  
〰70:      protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
‼71:          ExcludeTypeDetails switch
‼72:          {
‼73:              true => null,
‼74:              false => model switch
‼75:              {
‼76:                  null => null,
‼77:                  // Type type => new (XName name, string? value)[] {
‼78:                  //    (XName.Get("AssemblyQualifiedName"), type.AssemblyQualifiedName),
‼79:                  //    (XName.Get("Name"), type.Name),
‼80:                  //    (XName.Get("FullName"),type.FullName),
‼81:                  //    (XName.Get("Namespace"), type.Namespace),
‼82:                  //},
‼83:                  _ => new (XName name, string? value)[] {
‼84:                     (XName.Get("AssemblyQualifiedName"), model?.GetType()?.AssemblyQualifiedName),
‼85:                     (XName.Get("Name"), model?.GetType()?.Name),
‼86:                     (XName.Get("FullName"), model?.GetType()?.FullName),
‼87:                     (XName.Get("Namespace"), model?.GetType()?.Namespace),
‼88:                 }
‼89:              }
‼90:          };
〰91:  
〰92:      protected virtual string? ValueSelector(object model) =>
‼93:          IsValue(model) ? model switch
‼94:          {
‼95:              null => null,
‼96:  
‼97:              Type type => type.AssemblyQualifiedName,
‼98:  
‼99:              byte[] bytes => Convert.ToBase64String(bytes),
‼100:             IEnumerable<byte> bytes => Convert.ToBase64String(bytes.ToArray()),
‼101:             MemoryStream ms => Convert.ToBase64String(ms.ToArray()),
‼102:             Stream stream => Convert.ToBase64String(stream.AsBytes()),
‼103: 
‼104:             string @string => @string,
‼105:             char[] chars => new string(chars),
‼106:             IEnumerable<char> chars => new string(chars.ToArray()),
‼107: 
‼108:             _ => null // model.ToString()
‼109:         } : null;
〰110: 
〰111:     protected virtual bool IsValue(object input) =>
‼112:         input switch
‼113:         {
‼114:             null => false,
‼115:             _ when input.GetType().IsSimpleType() => true,
‼116:             byte[] _ => true,
‼117:             IEnumerable<byte> _ => true,
‼118:             char[] _ => true,
‼119:             IEnumerable<char> _ => true,
‼120:             Stream _ => true,
‼121:             _ => false
‼122:         };
〰123: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Reflection/ReflectionElementNodeBuilder.cs

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
〰11:  namespace BinaryDataDecoders.ToolKit.Reflection;
〰12:  
〰13:  public class ReflectionElementNodeBuilder(object seed, bool excludeNamespace = false, bool excludeTypeDetails = false)
〰14:  {
〰15:      protected bool ExcludeNamespace { get; } = excludeNamespace;
〰16:      protected bool ExcludeTypeDetails { get; } = excludeTypeDetails;
〰17:      protected object Seed { get; } = seed;
〰18:  
〰19:      public INode Build() =>
✔20:          new ExtensibleElementNode(
✔21:               Seed.GetXmlElementName(ExcludeNamespace),
✔22:               Seed,
✔23:               o => ValueSelector(o),
✔24:               o => AttributeSelector(o),
✔25:               o => ChildSelector(o),
✔26:               o => NamespacesSelector(o),
‼27:               o => PreserveWhitespace(o)
✔28:               );
〰29:  
‼30:      protected virtual bool PreserveWhitespace(object obj) => true;
✔31:      protected virtual IEnumerable<XName>? NamespacesSelector(object model) => Enumerable.Empty<XName>();
〰32:  
〰33:      protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
⚠34:           IsValue(model) ? null : model switch
✔35:           {
‼36:               null => null,
✔37:               IEnumerable enumerable => from item in enumerable.Cast<object>()
✔38:                                         where item != null
✔39:                                         select (item.GetXmlElementName(ExcludeNamespace), item),
⚠40:               _ => from property in model.GetType().GetProperties() ?? Enumerable.Empty<PropertyInfo>()
⚠41:                    where property.CanRead && AllowNavigate(model, property)
⚠42:                    select (XName.Get(property.Name, ExcludeNamespace ? "" : model.GetXmlNamespace()), SafeRead(model, property))
✔43:           };
〰44:  
〰45:      protected virtual bool AllowNavigate(object model, PropertyInfo property) =>
⚠46:          model switch
✔47:          {
‼48:              null => false,
‼49:              Type _ => false,
✔50:              _ => property.GetIndexParameters() switch
✔51:              {
⚠52:                  ParameterInfo[] indexes when indexes.Length > 0 => false,
✔53:                  _ => true,
✔54:              }
✔55:          };
〰56:  
〰57:      protected virtual object? SafeRead(object model, PropertyInfo property)
〰58:      {
〰59:          try
〰60:          {
✔61:              return property.GetValue(model);
〰62:          }
‼63:          catch (Exception ex)
〰64:          {
〰65:              Debug.WriteLine($"Failed to read {property.Name}: {ex.Message}");
‼66:              return null;
〰67:          }
✔68:      }
〰69:  
〰70:      protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
⚠71:          ExcludeTypeDetails switch
✔72:          {
‼73:              true => null,
✔74:              false => model switch
✔75:              {
‼76:                  null => null,
✔77:                  // Type type => new (XName name, string? value)[] {
✔78:                  //    (XName.Get("AssemblyQualifiedName"), type.AssemblyQualifiedName),
✔79:                  //    (XName.Get("Name"), type.Name),
✔80:                  //    (XName.Get("FullName"),type.FullName),
✔81:                  //    (XName.Get("Namespace"), type.Namespace),
✔82:                  //},
⚠83:                  _ => new (XName name, string? value)[] {
✔84:                     (XName.Get("AssemblyQualifiedName"), model?.GetType()?.AssemblyQualifiedName),
✔85:                     (XName.Get("Name"), model?.GetType()?.Name),
✔86:                     (XName.Get("FullName"), model?.GetType()?.FullName),
✔87:                     (XName.Get("Namespace"), model?.GetType()?.Namespace),
✔88:                 }
✔89:              }
✔90:          };
〰91:  
〰92:      protected virtual string? ValueSelector(object model) =>
⚠93:          IsValue(model) ? model switch
✔94:          {
‼95:              null => null,
✔96:  
‼97:              Type type => type.AssemblyQualifiedName,
✔98:  
✔99:              byte[] bytes => Convert.ToBase64String(bytes),
‼100:             IEnumerable<byte> bytes => Convert.ToBase64String(bytes.ToArray()),
‼101:             MemoryStream ms => Convert.ToBase64String(ms.ToArray()),
‼102:             Stream stream => Convert.ToBase64String(stream.AsBytes()),
✔103: 
✔104:             string @string => @string,
‼105:             char[] chars => new string(chars),
‼106:             IEnumerable<char> chars => new string(chars.ToArray()),
✔107: 
✔108:             _ => null // model.ToString()
✔109:         } : null;
〰110: 
〰111:     protected virtual bool IsValue(object input) =>
⚠112:         input switch
✔113:         {
‼114:             null => false,
✔115:             _ when input.GetType().IsSimpleType() => true,
✔116:             byte[] _ => true,
‼117:             IEnumerable<byte> _ => true,
‼118:             char[] _ => true,
✔119:             IEnumerable<char> _ => true,
‼120:             Stream _ => true,
✔121:             _ => false
✔122:         };
〰123: }
〰124: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

