# BinaryDataDecoders.ToolKit.Xml.Linq.ObjectXmlExtensions

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.ObjectXmlExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                              |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `102`                                                     |
| Coverablelines  | `102`                                                     |
| Totallines      | `221`                                                     |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `84`                                                      |
| Branchcoverage  | `0`                                                       |
| Coveredmethods  | `0`                                                       |
| Totalmethods    | `6`                                                       |
| Methodcoverage  | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 6          | 0     | 0        | `AsXElement`         |
| 10         | 0     | 0        | `ReflectPropertyXml` |
| 26         | 0     | 0        | `ReflectObjectXml`   |
| 6          | 0     | 0        | `AsXElement`         |
| 10         | 0     | 0        | `ReflectPropertyXml` |
| 26         | 0     | 0        | `ReflectObjectXml`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/ObjectXmlExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   using System.Reflection;
〰7:   using System.Xml;
〰8:   using System.Xml.Linq;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰11:  
〰12:  public static class ObjectXmlExtensions
〰13:  {
〰14:      public static XElement? AsXElement(this object input) =>
‼15:          input switch
‼16:          {
‼17:              null => null,
‼18:              XElement element => element,
‼19:              XDocument document => XElement.Load(document.CreateReader()),
‼20:              _ => ReflectObjectXml(input)
‼21:          };
〰22:  
〰23:      private static XObject? ReflectPropertyXml(PropertyInfo prop, object? input, XName parentName)
〰24:      {
‼25:          var name = XmlConvert.EncodeName(prop.Name);
‼26:          var val = prop.GetValue(input, null);
‼27:          if (val == null || val == DBNull.Value)
‼28:              return null;
〰29:  
‼30:          if (prop.PropertyType.IsSimpleType())
〰31:          {
‼32:              return new XAttribute(name, val);
〰33:          }
〰34:  
‼35:          return ReflectObjectXml(val, XName.Get(name, parentName?.NamespaceName ?? ""));
〰36:      }
〰37:  
〰38:      private static XElement? ReflectObjectXml(object input, XName? elementName = null)
〰39:      {
‼40:          if (input == null)
‼41:              return null;
〰42:  
‼43:          if (elementName == null) elementName = input.GetXmlElementName();
〰44:  
‼45:          var type = input.GetType();
〰46:  
〰47:  
‼48:          var ret = new XElement(elementName);
‼49:          if (type.IsSimpleType())
〰50:          {
‼51:              ret.Add(input);
〰52:          }
〰53:          else
〰54:          {
‼55:              if (input is MemoryStream ms)
〰56:              {
‼57:                  input = ms.ToArray();
〰58:              }
‼59:              if (input is Stream stream)
〰60:              {
‼61:                  using var newMs = new MemoryStream();
‼62:                  stream.CopyTo(newMs);
‼63:                  input = newMs.ToArray();
〰64:              }
〰65:  
‼66:              var enumerable = input as IEnumerable;
〰67:  
‼68:              if (enumerable != null)
〰69:              {
‼70:                  if (input is IEnumerable<char> || input is char[])
〰71:                  {
‼72:                      input = new string(enumerable.Cast<char>().ToArray());
〰73:                  }
‼74:                  else if (input is IEnumerable<byte> || input is byte[])
〰75:                  {
‼76:                      input = Convert.ToBase64String(enumerable.Cast<byte>().ToArray());
〰77:                  }
〰78:              }
‼79:              if (input is string) // ensure strings are written as text
〰80:              {
‼81:                  ret.Add(input);
〰82:              }
‼83:              else if (enumerable != null)
〰84:              {
‼85:                  var itemName = enumerable.GetXmlItemName(elementName);
〰86:  
‼87:                  var elements = from item in enumerable.Cast<object>()
‼88:                                 where item != null
‼89:                                 let itemType = item.GetType()
‼90:                                 select ReflectObjectXml(item, itemName);
〰91:  
‼92:                  ret.Add(elements);
‼93:                  if (!ret.HasElements)
‼94:                      return null;
〰95:              }
〰96:              else
〰97:              {
‼98:                  var props = type.GetProperties();
‼99:                  var elements = from prop in props
‼100:                                let value = ReflectPropertyXml(prop, input, elementName)
‼101:                                where value != null
‼102:                                select value;
〰103: 
‼104:                 ret.Add(elements);
〰105:             }
〰106:         }
〰107: 
‼108:         return ret;
〰109:     }
〰110: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Linq/ObjectXmlExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   using System.Reflection;
〰7:   using System.Xml;
〰8:   using System.Xml.Linq;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰11:  
〰12:  public static class ObjectXmlExtensions
〰13:  {
〰14:      public static XElement? AsXElement(this object input) =>
‼15:          input switch
‼16:          {
‼17:              null => null,
‼18:              XElement element => element,
‼19:              XDocument document => XElement.Load(document.CreateReader()),
‼20:              _ => ReflectObjectXml(input)
‼21:          };
〰22:  
〰23:      private static XObject? ReflectPropertyXml(PropertyInfo prop, object? input, XName parentName)
〰24:      {
‼25:          var name = XmlConvert.EncodeName(prop.Name);
‼26:          var val = prop.GetValue(input, null);
‼27:          if (val == null || val == DBNull.Value)
‼28:              return null;
〰29:  
‼30:          if (prop.PropertyType.IsSimpleType())
〰31:          {
‼32:              return new XAttribute(name, val);
〰33:          }
〰34:  
‼35:          return ReflectObjectXml(val, XName.Get(name, parentName?.NamespaceName ?? ""));
〰36:      }
〰37:  
〰38:      private static XElement? ReflectObjectXml(object input, XName? elementName = null)
〰39:      {
‼40:          if (input == null)
‼41:              return null;
〰42:  
‼43:          if (elementName == null) elementName = input.GetXmlElementName();
〰44:  
‼45:          var type = input.GetType();
〰46:  
〰47:  
‼48:          var ret = new XElement(elementName);
‼49:          if (type.IsSimpleType())
〰50:          {
‼51:              ret.Add(input);
〰52:          }
〰53:          else
〰54:          {
‼55:              if (input is MemoryStream ms)
〰56:              {
‼57:                  input = ms.ToArray();
〰58:              }
‼59:              if (input is Stream stream)
〰60:              {
‼61:                  using var newMs = new MemoryStream();
‼62:                  stream.CopyTo(newMs);
‼63:                  input = newMs.ToArray();
〰64:              }
〰65:  
‼66:              var enumerable = input as IEnumerable;
〰67:  
‼68:              if (enumerable != null)
〰69:              {
‼70:                  if (input is IEnumerable<char> || input is char[])
〰71:                  {
‼72:                      input = new string(enumerable.Cast<char>().ToArray());
〰73:                  }
‼74:                  else if (input is IEnumerable<byte> || input is byte[])
〰75:                  {
‼76:                      input = Convert.ToBase64String(enumerable.Cast<byte>().ToArray());
〰77:                  }
〰78:              }
‼79:              if (input is string) // ensure strings are written as text
〰80:              {
‼81:                  ret.Add(input);
〰82:              }
‼83:              else if (enumerable != null)
〰84:              {
‼85:                  var itemName = enumerable.GetXmlItemName(elementName);
〰86:  
‼87:                  var elements = from item in enumerable.Cast<object>()
‼88:                                 where item != null
‼89:                                 let itemType = item.GetType()
‼90:                                 select ReflectObjectXml(item, itemName);
〰91:  
‼92:                  ret.Add(elements);
‼93:                  if (!ret.HasElements)
‼94:                      return null;
〰95:              }
〰96:              else
〰97:              {
‼98:                  var props = type.GetProperties();
‼99:                  var elements = from prop in props
‼100:                                let value = ReflectPropertyXml(prop, input, elementName)
‼101:                                where value != null
‼102:                                select value;
〰103: 
‼104:                 ret.Add(elements);
〰105:             }
〰106:         }
〰107: 
‼108:         return ret;
〰109:     }
〰110: }
〰111: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

