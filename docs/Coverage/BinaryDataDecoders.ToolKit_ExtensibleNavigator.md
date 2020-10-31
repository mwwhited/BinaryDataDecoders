# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `57`                                                       |
| Uncoveredlines  | `18`                                                       |
| Coverablelines  | `75`                                                       |
| Totallines      | `166`                                                      |
| Linecoverage    | `76`                                                       |
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
〰3:   using System.Runtime.CompilerServices;
〰4:   using System.Xml;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰8:   {
〰9:       public sealed class ExtensibleNavigator : XPathNavigator
〰10:      {
〰11:          private INode _current;
〰12:          private readonly IDictionary<string, string> _namespacePrefixes;
〰13:          public ExtensibleNavigator(INode current, string? baseUri = null)
✔14:              : this(current, baseUri, null, null)
〰15:          {
✔16:          }
✔17:          private ExtensibleNavigator(
✔18:              INode current,
✔19:              string? baseUri,
✔20:              XmlNameTable? nameTable,
✔21:              IDictionary<string, string>? namespacePrefixes)
〰22:          {
✔23:              BaseURI = baseUri ?? "";
✔24:              _current = current;
✔25:              NameTable = nameTable ?? new ExtensibleNameTable();
✔26:              _namespacePrefixes = namespacePrefixes ?? new Dictionary<string, string>();
✔27:          }
〰28:  
✔29:          public override string Name => LocalName;
✔30:          public override string LocalName => _current.Name.LocalName;
⚠31:          public override string NamespaceURI => _current switch
✔32:          {
‼33:              IRootNode _ => "",
✔34:              _ => _current.Name.NamespaceName
✔35:          };
〰36:  
〰37:          public override XPathNodeType NodeType =>
✔38:              _current.NodeType;
〰39:  
✔40:          public override string Prefix => LookupPrefix(NamespaceURI);
〰41:  
〰42:          public override string LookupPrefix(string namespaceURI)
〰43:          {
‼44:              if (_namespacePrefixes == null) return "";
〰45:  
✔46:              if (string.IsNullOrWhiteSpace(namespaceURI)) return "";
〰47:  
✔48:              var uri = namespaceURI.Trim();
✔49:              if (!_namespacePrefixes.ContainsKey(uri))
〰50:              {
✔51:                  _namespacePrefixes.Add(uri, $"n{_namespacePrefixes.Count + 1}");
〰52:              }
✔53:              return _namespacePrefixes[uri];
〰54:          }
〰55:  
〰56:          public override string LookupNamespace(string prefix) =>
‼57:              _namespacePrefixes.FirstOrDefault(v => v.Value == prefix).Key ?? base.LookupNamespace(prefix);
〰58:  
✔59:          public override string Value => _current.Value ?? "";
⚠60:          public override bool IsEmptyElement => string.IsNullOrEmpty(Value) && !HasChildren;
〰61:  
‼62:          public override bool HasAttributes => _current is IElementNode node && node.FirstAttribute != null;
⚠63:          public override bool HasChildren => _current is IElementNode node && node.FirstChild != null;
〰64:  
〰65:          public override string BaseURI { get; }
〰66:          public override XmlNameTable NameTable { get; }
✔67:          public override XPathNavigator Clone() => new ExtensibleNavigator(_current, BaseURI, NameTable, _namespacePrefixes);
〰68:  
‼69:          public override bool MoveToId(string id) => false;
〰70:  
〰71:          public override bool IsSamePosition(XPathNavigator other) =>
⚠72:              other switch
✔73:              {
✔74:                  ExtensibleNavigator openXPath => openXPath._current.Equals(this._current),
‼75:                  _ => false
✔76:              };
〰77:  
〰78:          public override bool MoveTo(XPathNavigator other)
〰79:          {
⚠80:              if (other is ExtensibleNavigator openXPath && openXPath._current != null)
〰81:              {
✔82:                  _current = openXPath._current;
✔83:                  return true;
〰84:              }
‼85:              return false;
〰86:          }
〰87:  
〰88:          public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
〰89:          {
⚠90:              if (_current is IElementNode current && current.FirstNamespace != null)
〰91:              {
‼92:                  _current = current.FirstNamespace;
‼93:                  return true;
〰94:              }
✔95:              return false;
〰96:          }
〰97:  
〰98:          public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
〰99:          {
‼100:             if (_current is INamespaceNode current && current.Next != null)
〰101:             {
‼102:                 _current = current.Next;
‼103:                 return true;
〰104:             }
‼105:             return false;
〰106:         }
〰107: 
〰108:         public override bool MoveToFirstAttribute()
〰109:         {
⚠110:             if (_current is IElementNode current && current.FirstAttribute != null)
〰111:             {
✔112:                 _current = current.FirstAttribute;
✔113:                 return true;
〰114:             }
‼115:             return false;
〰116:         }
〰117: 
〰118:         public override bool MoveToNextAttribute()
〰119:         {
✔120:             if (_current is IAttributeNode current && current.Next != null)
〰121:             {
✔122:                 _current = current.Next;
✔123:                 return true;
〰124:             }
✔125:             return false;
〰126:         }
〰127: 
〰128:         public override bool MoveToParent()
〰129:         {
✔130:             if (_current.Parent != null)//&& !(_current.Parent is IRootNode)
〰131:             {
✔132:                 _current = _current.Parent;
✔133:                 return true;
〰134:             }
✔135:             return false;
〰136:         }
〰137: 
〰138:         public override bool MoveToFirstChild()
〰139:         {
✔140:             if (_current is IElementNode current && current.FirstChild != null)
〰141:             {
✔142:                 _current = current.FirstChild;
✔143:                 return true;
〰144:             }
✔145:             return false;
〰146:         }
〰147:         public override bool MoveToNext()
〰148:         {
✔149:             if (_current.Next != null)
〰150:             {
✔151:                 _current = _current.Next;
✔152:                 return true;
〰153:             }
✔154:             return false;
〰155:         }
〰156:         public override bool MoveToPrevious()
〰157:         {
‼158:             if (_current.Previous != null)
〰159:             {
‼160:                 _current = _current.Previous;
‼161:                 return true;
〰162:             }
‼163:             return false;
〰164:         }
〰165:     }
〰166: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

