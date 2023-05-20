# BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                            |
| Coveredlines    | `60`                                                    |
| Uncoveredlines  | `122`                                                   |
| Coverablelines  | `182`                                                   |
| Totallines      | `283`                                                   |
| Linecoverage    | `32.9`                                                  |
| Coveredbranches | `27`                                                    |
| Totalbranches   | `104`                                                   |
| Branchcoverage  | `25.9`                                                  |
| Coveredmethods  | `12`                                                    |
| Totalmethods    | `30`                                                    |
| Methodcoverage  | `40`                                                    |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 100   | 100      | `ctor`                     |
| 1          | 100   | 100      | `Clone`                    |
| 2          | 0     | 0        | `get_BaseURI`              |
| 2          | 0     | 0        | `get_IsEmptyElement`       |
| 4          | 83.33 | 75.00    | `get_LocalName`            |
| 4          | 0     | 0        | `get_Name`                 |
| 2          | 100   | 100      | `get_NamespaceURI`         |
| 2          | 0     | 0        | `get_NameTable`            |
| 8          | 72.72 | 62.50    | `get_NodeType`             |
| 2          | 0     | 0        | `get_Prefix`               |
| 4          | 66.66 | 50.0     | `get_Value`                |
| 2          | 0     | 0        | `LookupNamespace`          |
| 2          | 0     | 0        | `LookupPrefix`             |
| 4          | 0     | 0        | `get_HasAttributes`        |
| 2          | 0     | 0        | `get_HasChildren`          |
| 6          | 0     | 0        | `IsSamePosition`           |
| 4          | 80.0  | 50.0     | `MoveTo`                   |
| 4          | 0     | 0        | `MoveToFirstAttribute`     |
| 2          | 0     | 0        | `MoveToNextNamespace`      |
| 2          | 0     | 0        | `MoveToFirstNamespace`     |
| 2          | 0     | 0        | `MoveToId`                 |
| 2          | 0     | 0        | `MoveToNextAttribute`      |
| 2          | 80.0  | 50.0     | `MoveToFirstChild`         |
| 10         | 92.30 | 70.0     | `MoveToFirstChildInternal` |
| 2          | 100   | 100      | `MoveToNext`               |
| 8          | 66.66 | 37.50    | `MoveToNextInternal`       |
| 2          | 0     | 0        | `MoveToPrevious`           |
| 8          | 0     | 0        | `MoveToPreviousInternal`   |
| 10         | 0     | 0        | `MoveToParent`             |
| 1          | 100   | 100      | `MoveToRoot`               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/WrappedNavigator.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       internal class WrappedNavigator : XPathNavigator
〰8:       {
〰9:           private WrapperState _state;
〰10:          private IWrappedNode _node;
〰11:  
✔12:          public WrappedNavigator(IWrappedNode node)
〰13:          {
✔14:              _node = node;
✔15:          }
〰16:  
✔17:          public override XPathNavigator Clone() => new WrappedNavigator(_node) { _state = this._state };
〰18:  
‼19:          public override string BaseURI => _state switch
‼20:          {
‼21:              WrapperState.Child => _node.Current.BaseURI,
‼22:              _ => ""
‼23:          };
〰24:  
‼25:          public override bool IsEmptyElement => _state switch
‼26:          {
‼27:              WrapperState.Child => _node.Current.IsEmptyElement,
‼28:              _ => false,
‼29:          };
〰30:  
⚠31:          public override string LocalName => _state switch
✔32:          {
✔33:              WrapperState.Child => _node.Current.LocalName,
‼34:              WrapperState.NodeAttribute => "Source",
✔35:              _ => _state.ToString()
✔36:          };
〰37:  
‼38:          public override string Name => _state switch
‼39:          {
‼40:              WrapperState.Child => _node.Current.Name,
‼41:              WrapperState.NodeAttribute => "Source",
‼42:              _ => _state.ToString()
‼43:          };
〰44:  
✔45:          public override string NamespaceURI => _state switch
✔46:          {
✔47:              WrapperState.Child => _node.Current.NamespaceURI,
✔48:              _ => ""
✔49:          };
〰50:  
‼51:          public override XmlNameTable? NameTable => _state switch
‼52:          {
‼53:              WrapperState.Child => _node.Current.NameTable,
‼54:              _ => null
‼55:          };
〰56:  
⚠57:          public override XPathNodeType NodeType => _state switch
✔58:          {
✔59:              WrapperState.Child => _node.Current.NodeType switch
✔60:              {
‼61:                  XPathNodeType.Root => throw new NotSupportedException(), // XPathNodeType.Element, //Children can not be root elements
✔62:                  _ => _node.Current.NodeType
✔63:              },
‼64:              WrapperState.Root => XPathNodeType.Root,
‼65:              WrapperState.NodeAttribute => XPathNodeType.Attribute,
✔66:              _ => XPathNodeType.Element,
✔67:          };
〰68:  
‼69:          public override string Prefix => _state switch
‼70:          {
‼71:              WrapperState.Child => _node.Current.Prefix,
‼72:              _ => ""
‼73:          };
〰74:  
⚠75:          public override string Value => _state switch
✔76:          {
✔77:              WrapperState.Child => _node.Current.Value,
‼78:              WrapperState.NodeAttribute => _node.Source,
‼79:              _ => ""
✔80:          };
〰81:  
‼82:          public override string LookupNamespace(string prefix) => _state switch
‼83:          {
‼84:              WrapperState.Child => _node.Current.LookupNamespace(prefix),
‼85:              _ => ""
‼86:          };
‼87:          public override string LookupPrefix(string namespaceURI) => _state switch
‼88:          {
‼89:              WrapperState.Child => _node.Current.LookupPrefix(namespaceURI),
‼90:              _ => ""
‼91:          };
〰92:  
‼93:          public override bool HasAttributes => _state switch
‼94:          {
‼95:              WrapperState.Child => _node.Current.HasAttributes,
‼96:              WrapperState.Node => true,
‼97:              _ => false
‼98:          };
〰99:  
‼100:         public override bool HasChildren => _state switch
‼101:         {
‼102:             WrapperState.Child => _node.Current.HasAttributes,
‼103:             _ => true,
‼104:         };
〰105: 
‼106:         public override bool IsSamePosition(XPathNavigator other) => _state switch
‼107:         {
‼108:             WrapperState.Child => _node.Current.IsSamePosition(other),
‼109:             _ => other switch
‼110:             {
‼111:                 WrappedNavigator wrapped => object.ReferenceEquals(wrapped._node, this._node) && wrapped._state == this._state,
‼112:                 _ => false
‼113:             }
‼114:         };
〰115: 
〰116:         public override bool MoveTo(XPathNavigator other)
〰117:         {
⚠118:             if (other is WrappedNavigator wrapped && wrapped._node != null)
〰119:             {
✔120:                 _node = wrapped._node;
✔121:                 _state = wrapped._state;
✔122:                 return true;
〰123:             }
‼124:             return false;
〰125:         }
〰126: 
‼127:         public override bool MoveToFirstAttribute() => _state switch
‼128:         {
‼129:             WrapperState.Child => _node.Current.MoveToFirstAttribute(),
‼130:             WrapperState.Node => (_state = WrapperState.NodeAttribute) == WrapperState.NodeAttribute,
‼131:             _ => false
‼132:         };
〰133: 
‼134:         public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼135:         {
‼136:             WrapperState.Child => _node.Current.MoveToNextNamespace(namespaceScope),
‼137:             _ => false
‼138:         };
‼139:         public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼140:         {
‼141:             WrapperState.Child => _node.Current.MoveToFirstNamespace(namespaceScope),
‼142:             _ => false
‼143:         };
〰144: 
‼145:         public override bool MoveToId(string id) => _state switch
‼146:         {
‼147:             WrapperState.Child => _node.Current.MoveToId(id),
‼148:             _ => false
‼149:         };
〰150: 
‼151:         public override bool MoveToNextAttribute() => _state switch
‼152:         {
‼153:             WrapperState.Child => _node.Current.MoveToNextAttribute(),
‼154:             _ => false
‼155:         };
〰156: 
⚠157:         public override bool MoveToFirstChild() => _state switch
✔158:         {
‼159:             WrapperState.Child => _node.Current.MoveToFirstChild(),
✔160:             _ => MoveToFirstChildInternal()
✔161:         };
〰162:         private bool MoveToFirstChildInternal()
〰163:         {
⚠164:             switch (_state)
〰165:             {
〰166:                 case WrapperState.Root:
✔167:                     _state = WrapperState.Top;
✔168:                     return true;
〰169: 
〰170:                 case WrapperState.NodeAttribute:
〰171:                 case WrapperState.Top:
✔172:                     _state = WrapperState.Node;
⚠173:                     if (_node.First == null) return false;
✔174:                     _node = _node.First;
✔175:                     return true;
〰176: 
〰177:                 case WrapperState.Node:
✔178:                     _node.Current.MoveToRoot();
✔179:                     var result = _node.Current.MoveToFirstChild();
✔180:                     if (result)
✔181:                         _state = WrapperState.Child;
✔182:                     return result;
〰183: 
〰184:                 default:
〰185:                 case WrapperState.Child:
‼186:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰187:             }
〰188:         }
〰189: 
✔190:         public override bool MoveToNext() => _state switch
✔191:         {
✔192:             WrapperState.Child => _node.Current.MoveToNext(),
✔193:             _ => MoveToNextInternal()
✔194:         };
〰195:         private bool MoveToNextInternal()
〰196:         {
⚠197:             switch (_state)
〰198:             {
〰199:                 case WrapperState.Root:
〰200:                 case WrapperState.Top:
‼201:                     return false;
〰202: 
〰203:                 case WrapperState.NodeAttribute:
〰204:                 case WrapperState.Node:
⚠205:                     if (_node.Next == null)
‼206:                         return false;
✔207:                     _node = _node.Next;
✔208:                     _node.Current.MoveToRoot();
✔209:                     var result = _node.Current.MoveToFirstChild();
✔210:                     return true;
〰211: 
〰212:                 default:
〰213:                 case WrapperState.Child:
‼214:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰215:             }
〰216:         }
〰217: 
‼218:         public override bool MoveToPrevious() => _state switch
‼219:         {
‼220:             WrapperState.Child => _node.Current.MoveToPrevious(),
‼221:             _ => MoveToPreviousInternal()
‼222:         };
〰223:         private bool MoveToPreviousInternal()
〰224:         {
‼225:             switch (_state)
〰226:             {
〰227:                 case WrapperState.Root:
〰228:                 case WrapperState.Top:
‼229:                     return false;
〰230: 
〰231:                 case WrapperState.NodeAttribute:
〰232:                 case WrapperState.Node:
‼233:                     if (_node.Previous == null)
‼234:                         return false;
‼235:                     _node = _node.Previous;
‼236:                     return true;
〰237: 
〰238:                 default:
〰239:                 case WrapperState.Child:
‼240:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰241:             }
〰242:         }
〰243: 
〰244:         public override bool MoveToParent()
〰245:         {
‼246:             switch (_state)
〰247:             {
〰248:                 case WrapperState.Root:
‼249:                     return false;
〰250: 
〰251:                 case WrapperState.Top:
‼252:                     _state = WrapperState.Root;
‼253:                     return true;
〰254: 
〰255:                 case WrapperState.NodeAttribute:
‼256:                     _state = WrapperState.Node;
‼257:                     return true;
〰258:                 case WrapperState.Node:
‼259:                     _state = WrapperState.Top;
‼260:                     return true;
〰261:                 case WrapperState.Child:
‼262:                     if (!_node.Current.MoveToParent())
〰263:                     {
‼264:                         _state = WrapperState.Node;
〰265:                     }
‼266:                     if (_node.Current.NodeType == XPathNodeType.Root)
〰267:                     {
‼268:                         _state = WrapperState.Node;
‼269:                         var result = _node.Current.MoveToFirstChild();
‼270:                         return result;
〰271:                     }
‼272:                     return true;
〰273:                 default:
‼274:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰275:             }
〰276:         }
〰277:         public override void MoveToRoot()
〰278:         {
✔279:             _node = _node.First;
✔280:             _state = WrapperState.Root;
✔281:         }
〰282:     }
〰283: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

