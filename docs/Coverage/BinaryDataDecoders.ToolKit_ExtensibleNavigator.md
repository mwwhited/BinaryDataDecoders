# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `59`                                                       |
| Uncoveredlines  | `95`                                                       |
| Coverablelines  | `154`                                                      |
| Totallines      | `333`                                                      |
| Linecoverage    | `38.3`                                                     |
| Coveredbranches | `36`                                                       |
| Totalbranches   | `116`                                                      |
| Branchcoverage  | `31`                                                       |
| Coveredmethods  | `20`                                                       |
| Totalmethods    | `50`                                                       |
| Methodcoverage  | `40`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 6          | 0     | 0        | `ctor`                 |
| 1          | 0     | 100      | `get_Name`             |
| 1          | 0     | 100      | `get_LocalName`        |
| 2          | 0     | 0        | `get_NamespaceURI`     |
| 1          | 0     | 100      | `get_NodeType`         |
| 1          | 0     | 100      | `get_Prefix`           |
| 6          | 0     | 0        | `LookupPrefix`         |
| 4          | 0     | 0        | `LookupNamespace`      |
| 2          | 0     | 0        | `get_Value`            |
| 2          | 0     | 0        | `get_IsEmptyElement`   |
| 2          | 0     | 0        | `get_HasAttributes`    |
| 2          | 0     | 0        | `get_HasChildren`      |
| 1          | 0     | 100      | `Clone`                |
| 1          | 0     | 100      | `MoveToId`             |
| 2          | 0     | 0        | `IsSamePosition`       |
| 4          | 0     | 0        | `MoveTo`               |
| 4          | 0     | 0        | `MoveToFirstNamespace` |
| 4          | 0     | 0        | `MoveToNextNamespace`  |
| 4          | 0     | 0        | `MoveToFirstAttribute` |
| 4          | 0     | 0        | `MoveToNextAttribute`  |
| 2          | 0     | 0        | `MoveToParent`         |
| 4          | 0     | 0        | `MoveToFirstChild`     |
| 2          | 0     | 0        | `MoveToNext`           |
| 2          | 0     | 0        | `MoveToPrevious`       |
| 1          | 100   | 100      | `ctor`                 |
| 6          | 100   | 100      | `ctor`                 |
| 1          | 100   | 100      | `get_Name`             |
| 1          | 100   | 100      | `get_LocalName`        |
| 2          | 80.0  | 50.0     | `get_NamespaceURI`     |
| 1          | 100   | 100      | `get_NodeType`         |
| 1          | 100   | 100      | `get_Prefix`           |
| 6          | 87.50 | 83.33    | `LookupPrefix`         |
| 4          | 0     | 0        | `LookupNamespace`      |
| 2          | 100   | 100      | `get_Value`            |
| 2          | 100   | 50.0     | `get_IsEmptyElement`   |
| 2          | 0     | 0        | `get_HasAttributes`    |
| 2          | 100   | 50.0     | `get_HasChildren`      |
| 1          | 100   | 100      | `Clone`                |
| 1          | 0     | 100      | `MoveToId`             |
| 2          | 80.0  | 50.0     | `IsSamePosition`       |
| 4          | 75.00 | 50.0     | `MoveTo`               |
| 4          | 50.0  | 75.00    | `MoveToFirstNamespace` |
| 4          | 0     | 0        | `MoveToNextNamespace`  |
| 4          | 75.00 | 50.0     | `MoveToFirstAttribute` |
| 4          | 100   | 100      | `MoveToNextAttribute`  |
| 2          | 100   | 100      | `MoveToParent`         |
| 4          | 100   | 100      | `MoveToFirstChild`     |
| 2          | 100   | 100      | `MoveToNext`           |
| 2          | 0     | 0        | `MoveToPrevious`       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNavigator.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰7:   
〰8:   public sealed class ExtensibleNavigator : XPathNavigator
〰9:   {
〰10:      private INode _current;
〰11:      private readonly IDictionary<string, string> _namespacePrefixes;
〰12:      public ExtensibleNavigator(INode current, string? baseUri = null)
‼13:          : this(current, baseUri, null, null)
〰14:      {
‼15:      }
‼16:      private ExtensibleNavigator(
‼17:          INode current,
‼18:          string? baseUri,
‼19:          XmlNameTable? nameTable,
‼20:          IDictionary<string, string>? namespacePrefixes)
〰21:      {
‼22:          BaseURI = baseUri ?? "";
‼23:          _current = current;
‼24:          NameTable = nameTable ?? new ExtensibleNameTable();
‼25:          _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
‼26:      }
〰27:  
‼28:      public override string Name => LocalName;
‼29:      public override string LocalName => _current.Name.LocalName;
‼30:      public override string NamespaceURI => _current switch
‼31:      {
‼32:          IRootNode _ => "",
‼33:          _ => _current.Name.NamespaceName
‼34:      };
〰35:  
〰36:      public override XPathNodeType NodeType =>
‼37:          _current.NodeType;
〰38:  
‼39:      public override string Prefix => LookupPrefix(NamespaceURI);
〰40:  
〰41:      public override string LookupPrefix(string namespaceURI)
〰42:      {
‼43:          if (_namespacePrefixes == null)
‼44:              return "";
〰45:  
‼46:          if (string.IsNullOrWhiteSpace(namespaceURI))
‼47:              return "";
〰48:  
‼49:          var uri = namespaceURI.Trim();
‼50:          if (!_namespacePrefixes.ContainsKey(uri))
〰51:          {
‼52:              _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
〰53:          }
‼54:          return _namespacePrefixes[uri];
〰55:      }
〰56:  
〰57:      public override string LookupNamespace(string prefix) =>
‼58:          _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix) ?? "";
〰59:  
‼60:      public override string Value => _current.Value ?? "";
‼61:      public override bool IsEmptyElement => string.IsNullOrEmpty(Value) && !HasChildren;
〰62:  
‼63:      public override bool HasAttributes => _current is IElementNode node && node.FirstAttribute != null;
‼64:      public override bool HasChildren => _current is IElementNode node && node.FirstChild != null;
〰65:  
〰66:      public override string BaseURI { get; }
〰67:      public override XmlNameTable NameTable { get; }
‼68:      public override XPathNavigator Clone() => new ExtensibleNavigator(_current, BaseURI, NameTable, _namespacePrefixes);
〰69:  
‼70:      public override bool MoveToId(string id) => false;
〰71:  
〰72:      public override bool IsSamePosition(XPathNavigator other) =>
‼73:          other switch
‼74:          {
‼75:              ExtensibleNavigator openXPath => openXPath._current.Equals(this._current),
‼76:              _ => false
‼77:          };
〰78:  
〰79:      public override bool MoveTo(XPathNavigator other)
〰80:      {
‼81:          if (other is ExtensibleNavigator openXPath && openXPath._current != null)
〰82:          {
‼83:              _current = openXPath._current;
‼84:              return true;
〰85:          }
‼86:          return false;
〰87:      }
〰88:  
〰89:      public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
〰90:      {
‼91:          if (_current is IElementNode current && current.FirstNamespace != null)
〰92:          {
‼93:              _current = current.FirstNamespace;
‼94:              return true;
〰95:          }
‼96:          return false;
〰97:      }
〰98:  
〰99:      public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
〰100:     {
‼101:         if (_current is INamespaceNode current && current.Next != null)
〰102:         {
‼103:             _current = current.Next;
‼104:             return true;
〰105:         }
‼106:         return false;
〰107:     }
〰108: 
〰109:     public override bool MoveToFirstAttribute()
〰110:     {
‼111:         if (_current is IElementNode current && current.FirstAttribute != null)
〰112:         {
‼113:             _current = current.FirstAttribute;
‼114:             return true;
〰115:         }
‼116:         return false;
〰117:     }
〰118: 
〰119:     public override bool MoveToNextAttribute()
〰120:     {
‼121:         if (_current is IAttributeNode current && current.Next != null)
〰122:         {
‼123:             _current = current.Next;
‼124:             return true;
〰125:         }
‼126:         return false;
〰127:     }
〰128: 
〰129:     public override bool MoveToParent()
〰130:     {
‼131:         if (_current.Parent != null)//&& !(_current.Parent is IRootNode)
〰132:         {
‼133:             _current = _current.Parent;
‼134:             return true;
〰135:         }
‼136:         return false;
〰137:     }
〰138: 
〰139:     public override bool MoveToFirstChild()
〰140:     {
‼141:         if (_current is IElementNode current && current.FirstChild != null)
〰142:         {
‼143:             _current = current.FirstChild;
‼144:             return true;
〰145:         }
‼146:         return false;
〰147:     }
〰148:     public override bool MoveToNext()
〰149:     {
‼150:         if (_current.Next != null)
〰151:         {
‼152:             _current = _current.Next;
‼153:             return true;
〰154:         }
‼155:         return false;
〰156:     }
〰157:     public override bool MoveToPrevious()
〰158:     {
‼159:         if (_current.Previous != null)
〰160:         {
‼161:             _current = _current.Previous;
‼162:             return true;
〰163:         }
‼164:         return false;
〰165:     }
〰166: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNavigator.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰7:   
〰8:   public sealed class ExtensibleNavigator : XPathNavigator
〰9:   {
〰10:      private INode _current;
〰11:      private readonly IDictionary<string, string> _namespacePrefixes;
〰12:      public ExtensibleNavigator(INode current, string? baseUri = null)
✔13:          : this(current, baseUri, null, null)
〰14:      {
✔15:      }
✔16:      private ExtensibleNavigator(
✔17:          INode current,
✔18:          string? baseUri,
✔19:          XmlNameTable? nameTable,
✔20:          IDictionary<string, string>? namespacePrefixes)
〰21:      {
✔22:          BaseURI = baseUri ?? "";
✔23:          _current = current;
✔24:          NameTable = nameTable ?? new ExtensibleNameTable();
✔25:          _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
✔26:      }
〰27:  
✔28:      public override string Name => LocalName;
✔29:      public override string LocalName => _current.Name.LocalName;
⚠30:      public override string NamespaceURI => _current switch
✔31:      {
‼32:          IRootNode _ => "",
✔33:          _ => _current.Name.NamespaceName
✔34:      };
〰35:  
〰36:      public override XPathNodeType NodeType =>
✔37:          _current.NodeType;
〰38:  
✔39:      public override string Prefix => LookupPrefix(NamespaceURI);
〰40:  
〰41:      public override string LookupPrefix(string namespaceURI)
〰42:      {
⚠43:          if (_namespacePrefixes == null)
‼44:              return "";
〰45:  
✔46:          if (string.IsNullOrWhiteSpace(namespaceURI))
✔47:              return "";
〰48:  
✔49:          var uri = namespaceURI.Trim();
✔50:          if (!_namespacePrefixes.ContainsKey(uri))
〰51:          {
✔52:              _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
〰53:          }
✔54:          return _namespacePrefixes[uri];
〰55:      }
〰56:  
〰57:      public override string LookupNamespace(string prefix) =>
‼58:          _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix) ?? "";
〰59:  
✔60:      public override string Value => _current.Value ?? "";
⚠61:      public override bool IsEmptyElement => string.IsNullOrEmpty(Value) && !HasChildren;
〰62:  
‼63:      public override bool HasAttributes => _current is IElementNode node && node.FirstAttribute != null;
⚠64:      public override bool HasChildren => _current is IElementNode node && node.FirstChild != null;
〰65:  
〰66:      public override string BaseURI { get; }
〰67:      public override XmlNameTable NameTable { get; }
✔68:      public override XPathNavigator Clone() => new ExtensibleNavigator(_current, BaseURI, NameTable, _namespacePrefixes);
〰69:  
‼70:      public override bool MoveToId(string id) => false;
〰71:  
〰72:      public override bool IsSamePosition(XPathNavigator other) =>
⚠73:          other switch
✔74:          {
✔75:              ExtensibleNavigator openXPath => openXPath._current.Equals(this._current),
‼76:              _ => false
✔77:          };
〰78:  
〰79:      public override bool MoveTo(XPathNavigator other)
〰80:      {
⚠81:          if (other is ExtensibleNavigator openXPath && openXPath._current != null)
〰82:          {
✔83:              _current = openXPath._current;
✔84:              return true;
〰85:          }
‼86:          return false;
〰87:      }
〰88:  
〰89:      public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
〰90:      {
⚠91:          if (_current is IElementNode current && current.FirstNamespace != null)
〰92:          {
‼93:              _current = current.FirstNamespace;
‼94:              return true;
〰95:          }
✔96:          return false;
〰97:      }
〰98:  
〰99:      public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
〰100:     {
‼101:         if (_current is INamespaceNode current && current.Next != null)
〰102:         {
‼103:             _current = current.Next;
‼104:             return true;
〰105:         }
‼106:         return false;
〰107:     }
〰108: 
〰109:     public override bool MoveToFirstAttribute()
〰110:     {
⚠111:         if (_current is IElementNode current && current.FirstAttribute != null)
〰112:         {
✔113:             _current = current.FirstAttribute;
✔114:             return true;
〰115:         }
‼116:         return false;
〰117:     }
〰118: 
〰119:     public override bool MoveToNextAttribute()
〰120:     {
✔121:         if (_current is IAttributeNode current && current.Next != null)
〰122:         {
✔123:             _current = current.Next;
✔124:             return true;
〰125:         }
✔126:         return false;
〰127:     }
〰128: 
〰129:     public override bool MoveToParent()
〰130:     {
✔131:         if (_current.Parent != null)//&& !(_current.Parent is IRootNode)
〰132:         {
✔133:             _current = _current.Parent;
✔134:             return true;
〰135:         }
✔136:         return false;
〰137:     }
〰138: 
〰139:     public override bool MoveToFirstChild()
〰140:     {
✔141:         if (_current is IElementNode current && current.FirstChild != null)
〰142:         {
✔143:             _current = current.FirstChild;
✔144:             return true;
〰145:         }
✔146:         return false;
〰147:     }
〰148:     public override bool MoveToNext()
〰149:     {
✔150:         if (_current.Next != null)
〰151:         {
✔152:             _current = _current.Next;
✔153:             return true;
〰154:         }
✔155:         return false;
〰156:     }
〰157:     public override bool MoveToPrevious()
〰158:     {
‼159:         if (_current.Previous != null)
〰160:         {
‼161:             _current = _current.Previous;
‼162:             return true;
〰163:         }
‼164:         return false;
〰165:     }
〰166: }
〰167: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

