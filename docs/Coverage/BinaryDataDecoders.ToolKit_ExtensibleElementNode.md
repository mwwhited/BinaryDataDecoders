# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleElementNode

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleElementNode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `1`                                                          |
| Uncoveredlines  | `1`                                                          |
| Coverablelines  | `2`                                                          |
| Totallines      | `383`                                                        |
| Linecoverage    | `50`                                                         |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |
| Coveredmethods  | `1`                                                          |
| Totalmethods    | `2`                                                          |
| Methodcoverage  | `50`                                                         |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleElementNode.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Diagnostics;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰9:   
〰10:  [DebuggerDisplay("E:>{Name}")]
〰11:  public class ExtensibleElementNode(
〰12:      XName name,
〰13:      object item,
〰14:      Func<object, string?>? valueSelector = null,
〰15:      Func<object, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰16:      Func<object, IEnumerable<(XName name, object child)>?>? childSelector = null,
〰17:      Func<object, IEnumerable<XName>?>? namespacesSelector = null,
〰18:      Predicate<object>? preserveWhitespace = null
‼19:          ) : ExtensibleElementNode<object>(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
〰20:  {
〰21:  }
〰22:  [DebuggerDisplay("E:>{Name}")]
〰23:  public class ExtensibleElementNode<T> : IElementNode, ISimpleNode
〰24:  {
〰25:      private readonly T _item;
〰26:  
〰27:      private readonly Func<T, string?>? _valueSelector;
〰28:      private readonly Predicate<T>? _preserveWhitespace;
〰29:      private readonly Func<T, IEnumerable<(XName name, string? value)>?>? _attributeSelector;
〰30:      private readonly Func<T, IEnumerable<(XName name, T child)>?>? _childSelector;
〰31:      private readonly Func<T, IEnumerable<XName>?>? _namespacesSelector;
〰32:  
〰33:      private readonly Lazy<INode?> _value;
〰34:      private readonly Lazy<INode?> _children;
〰35:      private readonly Lazy<IAttributeNode?> _attributes;
〰36:      private readonly Lazy<INamespaceNode?> _namespaces;
〰37:  
〰38:      public ExtensibleElementNode(
〰39:          XName name,
〰40:          T item,
〰41:          Func<T, string?>? valueSelector = null,
〰42:          Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰43:          Func<T, IEnumerable<(XName name, T child)>?>? childSelector = null,
〰44:          Func<T, IEnumerable<XName>?>? namespacesSelector = null,
〰45:          Predicate<T>? preserveWhitespace = null
〰46:          )
〰47:          : this(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
〰48:      {
〰49:      }
〰50:  
〰51:      protected ExtensibleElementNode(
〰52:          INode? parent,
〰53:          XName name,
〰54:          T item,
〰55:          Func<T, string?>? valueSelector,
〰56:          Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector,
〰57:          Func<T, IEnumerable<(XName name, T child)>?>? childSelector,
〰58:          Func<T, IEnumerable<XName>?>? namespacesSelector,
〰59:          Predicate<T>? preserveWhitespace = null
〰60:          )
〰61:      {
〰62:          Parent = parent ?? new ExtensibleRootNode<T>(this);
〰63:          Name = name;
〰64:          _item = item;
〰65:  
〰66:          _valueSelector = valueSelector;
〰67:          _attributeSelector = attributeSelector;
〰68:          _childSelector = childSelector;
〰69:          _namespacesSelector = namespacesSelector;
〰70:          _preserveWhitespace = preserveWhitespace;
〰71:  
〰72:          _value = new Lazy<INode?>(() =>
〰73:              _valueSelector?.Invoke(_item) switch
〰74:              {
〰75:                  null => (INode?)null,
〰76:                  string value => string.IsNullOrWhiteSpace(value) switch
〰77:                  {
〰78:                      true => new ExtensibleWhitespaceNode<T>(this, Name, _item, value),
〰79:                      false => (_preserveWhitespace?.Invoke(_item) ?? false) switch
〰80:                      {
〰81:                          true => new ExtensibleSignificantWhitespaceNode<T>(this, Name, _item, value),
〰82:                          false => new ExtensibleTextNode<T>(this, Name, _item, value)
〰83:                      }
〰84:                  },
〰85:              });
〰86:  
〰87:          _attributes = new Lazy<IAttributeNode?>(() =>
〰88:          {
〰89:              var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string? value)>()).GetEnumerator();
〰90:              IAttributeNode? first = null;
〰91:              IAttributeNode? previous = null;
〰92:  
〰93:              while (query.MoveNext())
〰94:              {
〰95:                  if (query.Current.value == null) continue;
〰96:  
〰97:                  var newItem = new ExtensibleAttributeNode<T>(
〰98:                      this,
〰99:                      query.Current.name,
〰100:                     _item,
〰101:                     query.Current.value
〰102:                     )
〰103:                 {
〰104:                     Previous = previous,
〰105:                 };
〰106:                 if (previous is ExtensibleAttributeNode<T> node) node.Next = newItem;
〰107:                 first ??= newItem;
〰108:                 previous = newItem;
〰109:             }
〰110: 
〰111:             return first;
〰112:         });
〰113: 
〰114:         _children = new Lazy<INode?>(() =>
〰115:         {
〰116:             var query = (_childSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, T child)>()).GetEnumerator();
〰117:             INode? first = null;
〰118:             INode? previous = null;
〰119: 
〰120:             while (query.MoveNext())
〰121:             {
〰122:                 if (query.Current.child == null) continue;
〰123:                 var newItem = new ExtensibleElementNode<T>(
〰124:                     this,
〰125:                     query.Current.name,
〰126:                     query.Current.child,
〰127:                     _valueSelector,
〰128:                     _attributeSelector,
〰129:                     _childSelector,
〰130:                     _namespacesSelector
〰131:                     )
〰132:                 {
〰133:                     Previous = previous,
〰134:                 };
〰135:                 // Console.WriteLine($"\t\t==={newItem.Name} +++ {newItem.NodeType}");
〰136:                 if (previous is ISimpleNode node) node.Next = newItem;
〰137:                 first ??= newItem;
〰138:                 previous = newItem;
〰139:             }
〰140: 
〰141:             if (_value.Value is ISimpleNode next && previous is ISimpleNode last)
〰142:             {
〰143:                 last.Next = next;
〰144:                 next.Previous = last;
〰145:             }
〰146: 
〰147:             return first ?? _value.Value;
〰148:         });
〰149: 
〰150: 
〰151:         _namespaces = new Lazy<INamespaceNode?>(() =>
〰152:         {
〰153:             var query = (_namespacesSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
〰154:             INamespaceNode? first = null;
〰155:             INamespaceNode? previous = null;
〰156: 
〰157:             while (query.MoveNext())
〰158:             {
〰159:                 var newItem = new ExtensibleNamespaceNode<T>(
〰160:                     this,
〰161:                     query.Current,
〰162:                     _item
〰163:                     )
〰164:                 {
〰165:                     Previous = previous,
〰166:                 };
〰167:                 if (previous is ExtensibleNamespaceNode<T> node) node.Next = newItem;
〰168:                 first ??= newItem;
〰169:                 previous = newItem;
〰170:             }
〰171: 
〰172:             return first;
〰173:         });
〰174:     }
〰175: 
〰176:     public INode? FirstChild => _children.Value;
〰177:     public IAttributeNode? FirstAttribute => _attributes.Value;
〰178:     public INamespaceNode? FirstNamespace => _namespaces.Value;
〰179: 
〰180:     public INode? Next { get; private set; }
〰181:     public INode? Previous { get; private set; }
〰182: 
〰183:     public INode? Parent { get; }
〰184:     public XName Name { get; }
〰185:     public string? Value => _value.Value?.Value;
〰186: 
〰187:     public XPathNodeType NodeType { get; } = XPathNodeType.Element;
〰188: 
〰189:     INode? ISimpleNode.Next { set => Next = value; }
〰190:     INode? ISimpleNode.Previous { set => Previous = value; }
〰191: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleElementNode.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Diagnostics;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰9:   
〰10:  [DebuggerDisplay("E:>{Name}")]
〰11:  public class ExtensibleElementNode(
〰12:      XName name,
〰13:      object item,
〰14:      Func<object, string?>? valueSelector = null,
〰15:      Func<object, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰16:      Func<object, IEnumerable<(XName name, object child)>?>? childSelector = null,
〰17:      Func<object, IEnumerable<XName>?>? namespacesSelector = null,
〰18:      Predicate<object>? preserveWhitespace = null
✔19:          ) : ExtensibleElementNode<object>(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
〰20:  {
〰21:  }
〰22:  [DebuggerDisplay("E:>{Name}")]
〰23:  public class ExtensibleElementNode<T> : IElementNode, ISimpleNode
〰24:  {
〰25:      private readonly T _item;
〰26:  
〰27:      private readonly Func<T, string?>? _valueSelector;
〰28:      private readonly Predicate<T>? _preserveWhitespace;
〰29:      private readonly Func<T, IEnumerable<(XName name, string? value)>?>? _attributeSelector;
〰30:      private readonly Func<T, IEnumerable<(XName name, T child)>?>? _childSelector;
〰31:      private readonly Func<T, IEnumerable<XName>?>? _namespacesSelector;
〰32:  
〰33:      private readonly Lazy<INode?> _value;
〰34:      private readonly Lazy<INode?> _children;
〰35:      private readonly Lazy<IAttributeNode?> _attributes;
〰36:      private readonly Lazy<INamespaceNode?> _namespaces;
〰37:  
〰38:      public ExtensibleElementNode(
〰39:          XName name,
〰40:          T item,
〰41:          Func<T, string?>? valueSelector = null,
〰42:          Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰43:          Func<T, IEnumerable<(XName name, T child)>?>? childSelector = null,
〰44:          Func<T, IEnumerable<XName>?>? namespacesSelector = null,
〰45:          Predicate<T>? preserveWhitespace = null
〰46:          )
〰47:          : this(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
〰48:      {
〰49:      }
〰50:  
〰51:      protected ExtensibleElementNode(
〰52:          INode? parent,
〰53:          XName name,
〰54:          T item,
〰55:          Func<T, string?>? valueSelector,
〰56:          Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector,
〰57:          Func<T, IEnumerable<(XName name, T child)>?>? childSelector,
〰58:          Func<T, IEnumerable<XName>?>? namespacesSelector,
〰59:          Predicate<T>? preserveWhitespace = null
〰60:          )
〰61:      {
〰62:          Parent = parent ?? new ExtensibleRootNode<T>(this);
〰63:          Name = name;
〰64:          _item = item;
〰65:  
〰66:          _valueSelector = valueSelector;
〰67:          _attributeSelector = attributeSelector;
〰68:          _childSelector = childSelector;
〰69:          _namespacesSelector = namespacesSelector;
〰70:          _preserveWhitespace = preserveWhitespace;
〰71:  
〰72:          _value = new Lazy<INode?>(() =>
〰73:              _valueSelector?.Invoke(_item) switch
〰74:              {
〰75:                  null => (INode?)null,
〰76:                  string value => string.IsNullOrWhiteSpace(value) switch
〰77:                  {
〰78:                      true => new ExtensibleWhitespaceNode<T>(this, Name, _item, value),
〰79:                      false => (_preserveWhitespace?.Invoke(_item) ?? false) switch
〰80:                      {
〰81:                          true => new ExtensibleSignificantWhitespaceNode<T>(this, Name, _item, value),
〰82:                          false => new ExtensibleTextNode<T>(this, Name, _item, value)
〰83:                      }
〰84:                  },
〰85:              });
〰86:  
〰87:          _attributes = new Lazy<IAttributeNode?>(() =>
〰88:          {
〰89:              var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string? value)>()).GetEnumerator();
〰90:              IAttributeNode? first = null;
〰91:              IAttributeNode? previous = null;
〰92:  
〰93:              while (query.MoveNext())
〰94:              {
〰95:                  if (query.Current.value == null) continue;
〰96:  
〰97:                  var newItem = new ExtensibleAttributeNode<T>(
〰98:                      this,
〰99:                      query.Current.name,
〰100:                     _item,
〰101:                     query.Current.value
〰102:                     )
〰103:                 {
〰104:                     Previous = previous,
〰105:                 };
〰106:                 if (previous is ExtensibleAttributeNode<T> node) node.Next = newItem;
〰107:                 first ??= newItem;
〰108:                 previous = newItem;
〰109:             }
〰110: 
〰111:             return first;
〰112:         });
〰113: 
〰114:         _children = new Lazy<INode?>(() =>
〰115:         {
〰116:             var query = (_childSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, T child)>()).GetEnumerator();
〰117:             INode? first = null;
〰118:             INode? previous = null;
〰119: 
〰120:             while (query.MoveNext())
〰121:             {
〰122:                 if (query.Current.child == null) continue;
〰123:                 var newItem = new ExtensibleElementNode<T>(
〰124:                     this,
〰125:                     query.Current.name,
〰126:                     query.Current.child,
〰127:                     _valueSelector,
〰128:                     _attributeSelector,
〰129:                     _childSelector,
〰130:                     _namespacesSelector
〰131:                     )
〰132:                 {
〰133:                     Previous = previous,
〰134:                 };
〰135:                 // Console.WriteLine($"\t\t==={newItem.Name} +++ {newItem.NodeType}");
〰136:                 if (previous is ISimpleNode node) node.Next = newItem;
〰137:                 first ??= newItem;
〰138:                 previous = newItem;
〰139:             }
〰140: 
〰141:             if (_value.Value is ISimpleNode next && previous is ISimpleNode last)
〰142:             {
〰143:                 last.Next = next;
〰144:                 next.Previous = last;
〰145:             }
〰146: 
〰147:             return first ?? _value.Value;
〰148:         });
〰149: 
〰150: 
〰151:         _namespaces = new Lazy<INamespaceNode?>(() =>
〰152:         {
〰153:             var query = (_namespacesSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
〰154:             INamespaceNode? first = null;
〰155:             INamespaceNode? previous = null;
〰156: 
〰157:             while (query.MoveNext())
〰158:             {
〰159:                 var newItem = new ExtensibleNamespaceNode<T>(
〰160:                     this,
〰161:                     query.Current,
〰162:                     _item
〰163:                     )
〰164:                 {
〰165:                     Previous = previous,
〰166:                 };
〰167:                 if (previous is ExtensibleNamespaceNode<T> node) node.Next = newItem;
〰168:                 first ??= newItem;
〰169:                 previous = newItem;
〰170:             }
〰171: 
〰172:             return first;
〰173:         });
〰174:     }
〰175: 
〰176:     public INode? FirstChild => _children.Value;
〰177:     public IAttributeNode? FirstAttribute => _attributes.Value;
〰178:     public INamespaceNode? FirstNamespace => _namespaces.Value;
〰179: 
〰180:     public INode? Next { get; private set; }
〰181:     public INode? Previous { get; private set; }
〰182: 
〰183:     public INode? Parent { get; }
〰184:     public XName Name { get; }
〰185:     public string? Value => _value.Value?.Value;
〰186: 
〰187:     public XPathNodeType NodeType { get; } = XPathNodeType.Element;
〰188: 
〰189:     INode? ISimpleNode.Next { set => Next = value; }
〰190:     INode? ISimpleNode.Previous { set => Previous = value; }
〰191: }
〰192: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

