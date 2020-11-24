# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `59`                                                       |
| Uncoveredlines  | `18`                                                       |
| Coverablelines  | `77`                                                       |
| Totallines      | `165`                                                      |
| Linecoverage    | `76.6`                                                     |
| Coveredbranches | `36`                                                       |
| Totalbranches   | `56`                                                       |
| Branchcoverage  | `64.2`                                                     |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 100   | 100      | `ctor`                 |
| 6          | 100   | 100      | `ctor`                 |
| 1          | 100   | 100      | `get_Name`             |
| 1          | 100   | 100      | `get_LocalName`        |
| 2          | 80.0  | 50.0     | `get_NamespaceURI`     |
| 1          | 100   | 100      | `get_NodeType`         |
| 1          | 100   | 100      | `get_Prefix`           |
| 6          | 83.33 | 83.33    | `LookupPrefix`         |
| 2          | 0     | 0        | `LookupNamespace`      |
| 2          | 100   | 100      | `get_Value`            |
| 2          | 100   | 50.0     | `get_IsEmptyElement`   |
| 2          | 0     | 0        | `get_HasAttributes`    |
| 2          | 100   | 50.0     | `get_HasChildren`      |
| 1          | 100   | 100      | `get_BaseURI`          |
| 1          | 100   | 100      | `get_NameTable`        |
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

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleNavigator.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰7:   {
〰8:       public sealed class ExtensibleNavigator : XPathNavigator
〰9:       {
〰10:          private INode _current;
〰11:          private readonly IDictionary<string, string> _namespacePrefixes;
〰12:          public ExtensibleNavigator(INode current, string? baseUri = null)
✔13:              : this(current, baseUri, null, null)
〰14:          {
✔15:          }
✔16:          private ExtensibleNavigator(
✔17:              INode current,
✔18:              string? baseUri,
✔19:              XmlNameTable? nameTable,
✔20:              IDictionary<string, string>? namespacePrefixes)
〰21:          {
✔22:              BaseURI = baseUri ?? "";
✔23:              _current = current;
✔24:              NameTable = nameTable ?? new ExtensibleNameTable();
✔25:              _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
✔26:          }
〰27:  
✔28:          public override string Name => LocalName;
✔29:          public override string LocalName => _current.Name.LocalName;
⚠30:          public override string NamespaceURI => _current switch
✔31:          {
‼32:              IRootNode _ => "",
✔33:              _ => _current.Name.NamespaceName
✔34:          };
〰35:  
〰36:          public override XPathNodeType NodeType =>
✔37:              _current.NodeType;
〰38:  
✔39:          public override string Prefix => LookupPrefix(NamespaceURI);
〰40:  
〰41:          public override string LookupPrefix(string namespaceURI)
〰42:          {
‼43:              if (_namespacePrefixes == null) return "";
〰44:  
✔45:              if (string.IsNullOrWhiteSpace(namespaceURI)) return "";
〰46:  
✔47:              var uri = namespaceURI.Trim();
✔48:              if (!_namespacePrefixes.ContainsKey(uri))
〰49:              {
✔50:                  _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
〰51:              }
✔52:              return _namespacePrefixes[uri];
〰53:          }
〰54:  
〰55:          public override string LookupNamespace(string prefix) =>
‼56:              _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix);
〰57:  
✔58:          public override string Value => _current.Value ?? "";
⚠59:          public override bool IsEmptyElement => string.IsNullOrEmpty(Value) && !HasChildren;
〰60:  
‼61:          public override bool HasAttributes => _current is IElementNode node && node.FirstAttribute != null;
⚠62:          public override bool HasChildren => _current is IElementNode node && node.FirstChild != null;
〰63:  
✔64:          public override string BaseURI { get; }
✔65:          public override XmlNameTable NameTable { get; }
✔66:          public override XPathNavigator Clone() => new ExtensibleNavigator(_current, BaseURI, NameTable, _namespacePrefixes);
〰67:  
‼68:          public override bool MoveToId(string id) => false;
〰69:  
〰70:          public override bool IsSamePosition(XPathNavigator other) =>
⚠71:              other switch
✔72:              {
✔73:                  ExtensibleNavigator openXPath => openXPath._current.Equals(this._current),
‼74:                  _ => false
✔75:              };
〰76:  
〰77:          public override bool MoveTo(XPathNavigator other)
〰78:          {
⚠79:              if (other is ExtensibleNavigator openXPath && openXPath._current != null)
〰80:              {
✔81:                  _current = openXPath._current;
✔82:                  return true;
〰83:              }
‼84:              return false;
〰85:          }
〰86:  
〰87:          public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
〰88:          {
⚠89:              if (_current is IElementNode current && current.FirstNamespace != null)
〰90:              {
‼91:                  _current = current.FirstNamespace;
‼92:                  return true;
〰93:              }
✔94:              return false;
〰95:          }
〰96:  
〰97:          public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
〰98:          {
‼99:              if (_current is INamespaceNode current && current.Next != null)
〰100:             {
‼101:                 _current = current.Next;
‼102:                 return true;
〰103:             }
‼104:             return false;
〰105:         }
〰106: 
〰107:         public override bool MoveToFirstAttribute()
〰108:         {
⚠109:             if (_current is IElementNode current && current.FirstAttribute != null)
〰110:             {
✔111:                 _current = current.FirstAttribute;
✔112:                 return true;
〰113:             }
‼114:             return false;
〰115:         }
〰116: 
〰117:         public override bool MoveToNextAttribute()
〰118:         {
✔119:             if (_current is IAttributeNode current && current.Next != null)
〰120:             {
✔121:                 _current = current.Next;
✔122:                 return true;
〰123:             }
✔124:             return false;
〰125:         }
〰126: 
〰127:         public override bool MoveToParent()
〰128:         {
✔129:             if (_current.Parent != null)//&& !(_current.Parent is IRootNode)
〰130:             {
✔131:                 _current = _current.Parent;
✔132:                 return true;
〰133:             }
✔134:             return false;
〰135:         }
〰136: 
〰137:         public override bool MoveToFirstChild()
〰138:         {
✔139:             if (_current is IElementNode current && current.FirstChild != null)
〰140:             {
✔141:                 _current = current.FirstChild;
✔142:                 return true;
〰143:             }
✔144:             return false;
〰145:         }
〰146:         public override bool MoveToNext()
〰147:         {
✔148:             if (_current.Next != null)
〰149:             {
✔150:                 _current = _current.Next;
✔151:                 return true;
〰152:             }
✔153:             return false;
〰154:         }
〰155:         public override bool MoveToPrevious()
〰156:         {
‼157:             if (_current.Previous != null)
〰158:             {
‼159:                 _current = _current.Previous;
‼160:                 return true;
〰161:             }
‼162:             return false;
〰163:         }
〰164:     }
〰165: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

