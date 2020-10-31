# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleElementNode

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleElementNode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `2`                                                          |
| Uncoveredlines  | `0`                                                          |
| Coverablelines  | `2`                                                          |
| Totallines      | `196`                                                        |
| Linecoverage    | `100`                                                        |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleElementNode.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Diagnostics;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰9:   {
〰10:      [DebuggerDisplay("E:>{Name}")]
〰11:      public class ExtensibleElementNode : ExtensibleElementNode<object>
〰12:      {
〰13:          public ExtensibleElementNode(
〰14:              XName name,
〰15:              object item,
〰16:              Func<object, string?>? valueSelector = null,
〰17:              Func<object, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰18:              Func<object, IEnumerable<(XName name, object child)>?>? childSelector = null,
〰19:              Func<object, IEnumerable<XName>?>? namespacesSelector = null,
〰20:              Predicate<object>? preserveWhitespace = null
〰21:              )
✔22:              : base(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector)
〰23:          {
✔24:          }
〰25:      }
〰26:      [DebuggerDisplay("E:>{Name}")]
〰27:      public class ExtensibleElementNode<T> : IElementNode, ISimpleNode
〰28:      {
〰29:          private readonly T _item;
〰30:  
〰31:          private readonly Func<T, string?>? _valueSelector;
〰32:          private readonly Predicate<T>? _preserveWhitespace;
〰33:          private readonly Func<T, IEnumerable<(XName name, string? value)>?>? _attributeSelector;
〰34:          private readonly Func<T, IEnumerable<(XName name, T child)>?>? _childSelector;
〰35:          private readonly Func<T, IEnumerable<XName>?>? _namespacesSelector;
〰36:  
〰37:          private readonly Lazy<INode?> _value;
〰38:          private readonly Lazy<INode?> _children;
〰39:          private readonly Lazy<IAttributeNode?> _attributes;
〰40:          private readonly Lazy<INamespaceNode?> _namespaces;
〰41:  
〰42:          public ExtensibleElementNode(
〰43:              XName name,
〰44:              T item,
〰45:              Func<T, string?>? valueSelector = null,
〰46:              Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
〰47:              Func<T, IEnumerable<(XName name, T child)>?>? childSelector = null,
〰48:              Func<T, IEnumerable<XName>?>? namespacesSelector = null,
〰49:              Predicate<T>? preserveWhitespace = null
〰50:              )
〰51:              : this(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
〰52:          {
〰53:          }
〰54:  
〰55:          protected ExtensibleElementNode(
〰56:              INode? parent,
〰57:              XName name,
〰58:              T item,
〰59:              Func<T, string?>? valueSelector,
〰60:              Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector,
〰61:              Func<T, IEnumerable<(XName name, T child)>?>? childSelector,
〰62:              Func<T, IEnumerable<XName>?>? namespacesSelector,
〰63:              Predicate<T>? preserveWhitespace = null
〰64:              )
〰65:          {
〰66:              Parent = parent ?? new ExtensibleRootNode<T>(this);
〰67:              Name = name;
〰68:              _item = item;
〰69:  
〰70:              _valueSelector = valueSelector;
〰71:              _attributeSelector = attributeSelector;
〰72:              _childSelector = childSelector;
〰73:              _namespacesSelector = namespacesSelector;
〰74:              _preserveWhitespace = preserveWhitespace;
〰75:  
〰76:              _value = new Lazy<INode?>(() =>
〰77:                  _valueSelector?.Invoke(_item) switch
〰78:                  {
〰79:                      null => (INode?)null,
〰80:                      string value => string.IsNullOrWhiteSpace(value) switch
〰81:                      {
〰82:                          true => new ExtensibleWhitespaceNode<T>(this, Name, _item, value),
〰83:                          false => (_preserveWhitespace?.Invoke(_item) ?? false) switch
〰84:                          {
〰85:                              true => new ExtensibleSignificantWhitespaceNode<T>(this, Name, _item, value),
〰86:                              false => new ExtensibleTextNode<T>(this, Name, _item, value)
〰87:                          }
〰88:                      },
〰89:                  });
〰90:  
〰91:              _attributes = new Lazy<IAttributeNode?>(() =>
〰92:              {
〰93:                  var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string? value)>()).GetEnumerator();
〰94:                  IAttributeNode? first = null;
〰95:                  IAttributeNode? previous = null;
〰96:  
〰97:                  while (query.MoveNext())
〰98:                  {
〰99:                      if (query.Current.value == null) continue;
〰100: 
〰101:                     var newItem = new ExtensibleAttributeNode<T>(
〰102:                         this,
〰103:                         query.Current.name,
〰104:                         _item,
〰105:                         query.Current.value
〰106:                         )
〰107:                     {
〰108:                         Previous = previous,
〰109:                     };
〰110:                     if (previous is ExtensibleAttributeNode<T> node) node.Next = newItem;
〰111:                     if (first == null) first = newItem;
〰112:                     previous = newItem;
〰113:                 }
〰114: 
〰115:                 return first;
〰116:             });
〰117: 
〰118:             _children = new Lazy<INode?>(() =>
〰119:             {
〰120:                 var query = (_childSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, T child)>()).GetEnumerator();
〰121:                 INode? first = null;
〰122:                 INode? previous = null;
〰123: 
〰124:                 while (query.MoveNext())
〰125:                 {
〰126:                     if (query.Current.child == null) continue;
〰127:                     var newItem = new ExtensibleElementNode<T>(
〰128:                         this,
〰129:                         query.Current.name,
〰130:                         query.Current.child,
〰131:                         _valueSelector,
〰132:                         _attributeSelector,
〰133:                         _childSelector,
〰134:                         _namespacesSelector
〰135:                         )
〰136:                     {
〰137:                         Previous = previous,
〰138:                     };
〰139:                     // Console.WriteLine($"\t\t==={newItem.Name} +++ {newItem.NodeType}");
〰140:                     if (previous is ISimpleNode node) node.Next = newItem;
〰141:                     if (first == null) first = newItem;
〰142:                     previous = newItem;
〰143:                 }
〰144: 
〰145:                 if (_value.Value is ISimpleNode next && previous is ISimpleNode last)
〰146:                 {
〰147:                     last.Next = next;
〰148:                     next.Previous = last;
〰149:                 }
〰150: 
〰151:                 return first ?? _value.Value;
〰152:             });
〰153: 
〰154: 
〰155:             _namespaces = new Lazy<INamespaceNode?>(() =>
〰156:             {
〰157:                 var query = (_namespacesSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
〰158:                 INamespaceNode? first = null;
〰159:                 INamespaceNode? previous = null;
〰160: 
〰161:                 while (query.MoveNext())
〰162:                 {
〰163:                     var newItem = new ExtensibleNamespaceNode<T>(
〰164:                         this,
〰165:                         query.Current,
〰166:                         _item
〰167:                         )
〰168:                     {
〰169:                         Previous = previous,
〰170:                     };
〰171:                     if (previous is ExtensibleNamespaceNode<T> node) node.Next = newItem;
〰172:                     if (first == null) first = newItem;
〰173:                     previous = newItem;
〰174:                 }
〰175: 
〰176:                 return first;
〰177:             });
〰178:         }
〰179: 
〰180:         public INode? FirstChild => _children.Value;
〰181:         public IAttributeNode? FirstAttribute => _attributes.Value;
〰182:         public INamespaceNode? FirstNamespace => _namespaces.Value;
〰183: 
〰184:         public INode? Next { get; private set; }
〰185:         public INode? Previous { get; private set; }
〰186: 
〰187:         public INode? Parent { get; }
〰188:         public XName Name { get; }
〰189:         public string? Value => _value.Value?.Value;
〰190: 
〰191:         public XPathNodeType NodeType { get; } = XPathNodeType.Element;
〰192: 
〰193:         INode? ISimpleNode.Next { set => Next = value; }
〰194:         INode? ISimpleNode.Previous { set => Previous = value; }
〰195:     }
〰196: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

