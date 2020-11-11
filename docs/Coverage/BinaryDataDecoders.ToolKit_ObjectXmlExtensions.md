# BinaryDataDecoders.ToolKit.Xml.Linq.ObjectXmlExtensions

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.ObjectXmlExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                              |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `66`                                                      |
| Coverablelines  | `66`                                                      |
| Totallines      | `147`                                                     |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `52`                                                      |
| Branchcoverage  | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `cctor`        |
| 2          | 0     | 0        | `IsSimpleType` |
| 6          | 0     | 0        | `ToXml`        |
| 6          | 0     | 0        | `ToXml`        |
| 38         | 0     | 0        | `ToXml`        |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Linq\ObjectXmlExtensions.cs

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
〰10:  namespace BinaryDataDecoders.ToolKit.Xml.Linq
〰11:  {
〰12:      public static class ObjectXmlExtensions
〰13:      {
〰14:          // https://stackoverflow.com/a/2404984/89586
〰15:  
‼16:          private static readonly Type[] WriteTypes = new[] {
‼17:              typeof(DateTime), typeof(decimal), typeof(Guid), typeof(bool),
‼18:              typeof(DateTime?), typeof(decimal?), typeof(Guid?), typeof(bool?),
‼19:          };
‼20:          public static bool IsSimpleType(this Type type) => type.IsPrimitive || WriteTypes.Contains(type);
〰21:  
〰22:          private static XObject? ToXml(this PropertyInfo prop, object? input)
〰23:          {
‼24:              var name = XmlConvert.EncodeName(prop.Name);
‼25:              var val = prop.GetValue(input, null);
‼26:              if (val == null || val == DBNull.Value)
‼27:                  return null;
〰28:  
‼29:              if (prop.PropertyType.IsSimpleType())
〰30:              {
‼31:                  return new XAttribute(name, val);
〰32:              }
〰33:  
‼34:              return val.ToXml(name);
〰35:          }
〰36:  
〰37:          public static XElement? ToXml(this object input)
〰38:          {
‼39:              if (input == null) return null;
〰40:  
‼41:              var element = input as XElement;
‼42:              if (element != null)
‼43:                  return element;
〰44:  
‼45:              var document = input as XDocument;
‼46:              if (document != null)
〰47:              {
‼48:                  return XElement.Load(document.CreateReader());
〰49:              }
〰50:  
‼51:              return input.ToXml(null);
〰52:          }
〰53:          public static XElement? ToXml(this object input, string? element)
〰54:          {
‼55:              if (input == null)
‼56:                  return null;
〰57:  
‼58:              if (string.IsNullOrEmpty(element))
‼59:                  element = "object";
‼60:              element = XmlConvert.EncodeName(element);
〰61:  
‼62:              var type = input.GetType();
〰63:  
〰64:  
‼65:              var ret = new XElement(element);
‼66:              if (type.IsSimpleType())
〰67:              {
‼68:                  ret.Add(input);
〰69:              }
〰70:              else
〰71:              {
‼72:                  var ms = input as MemoryStream;
‼73:                  if (ms != null)
〰74:                  {
‼75:                      input = ms.ToArray();
〰76:                  }
‼77:                  if (input is Stream)
〰78:                  {
‼79:                      throw new NotSupportedException();
〰80:                  }
〰81:  
‼82:                  var enumerable = input as IEnumerable;
〰83:  
‼84:                  if (enumerable != null)
〰85:                  {
‼86:                      if (input is IEnumerable<char> || input is char[])
〰87:                      {
‼88:                          input = new string(enumerable.Cast<char>().ToArray());
〰89:                      }
‼90:                      else if (input is IEnumerable<byte> || input is byte[])
〰91:                      {
‼92:                          input = Convert.ToBase64String(enumerable.Cast<byte>().ToArray());
〰93:                      }
〰94:                  }
‼95:                  if (input is string) // ensure strings are written as text
〰96:                  {
‼97:                      ret.Add(input);
〰98:                  }
‼99:                  else if (enumerable != null)
〰100:                 {
‼101:                     var itemName = enumerable.GetType().GetElementType()?.Name ?? "<>f__AnonymousType1`";
〰102: 
‼103:                     if (itemName.StartsWith("<>f__AnonymousType1`"))
〰104:                     {
‼105:                         if (element.EndsWith("s"))
〰106:                         {
‼107:                             itemName = element.Substring(0, element.Length - 1);
〰108:                         }
‼109:                         else if (element.EndsWith("es"))
〰110:                         {
‼111:                             itemName = element.Substring(0, element.Length - 2);
〰112:                         }
‼113:                         else if (element == "object")
〰114:                         {
‼115:                             itemName = "item";
〰116:                         }
〰117:                         else
〰118:                         {
‼119:                             itemName = element;
〰120:                         }
〰121:                     }
〰122: 
‼123:                     var elements = from item in enumerable.Cast<object>()
‼124:                                    where item != null
‼125:                                    let itemType = item.GetType()
‼126:                                    select item.ToXml(itemName);
〰127: 
‼128:                     ret.Add(elements);
‼129:                     if (!ret.HasElements)
‼130:                         return null;
〰131:                 }
〰132:                 else
〰133:                 {
‼134:                     var props = type.GetProperties();
‼135:                     var elements = from prop in props
‼136:                                    let value = prop.ToXml(input)
‼137:                                    where value != null
‼138:                                    select value;
〰139: 
‼140:                     ret.Add(elements);
〰141:                 }
〰142:             }
〰143: 
‼144:             return ret;
〰145:         }
〰146:     }
〰147: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

