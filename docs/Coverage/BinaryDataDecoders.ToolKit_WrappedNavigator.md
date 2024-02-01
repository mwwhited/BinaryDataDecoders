# BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                            |
| Coveredlines    | `59`                                                    |
| Uncoveredlines  | `303`                                                   |
| Coverablelines  | `362`                                                   |
| Totallines      | `555`                                                   |
| Linecoverage    | `16.2`                                                  |
| Coveredbranches | `27`                                                    |
| Totalbranches   | `208`                                                   |
| Branchcoverage  | `12.9`                                                  |
| Coveredmethods  | `12`                                                    |
| Totalmethods    | `60`                                                    |
| Methodcoverage  | `20`                                                    |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 0     | 100      | `ctor`                     |
| 1          | 0     | 100      | `Clone`                    |
| 2          | 0     | 0        | `get_BaseURI`              |
| 2          | 0     | 0        | `get_IsEmptyElement`       |
| 4          | 0     | 0        | `get_LocalName`            |
| 4          | 0     | 0        | `get_Name`                 |
| 2          | 0     | 0        | `get_NamespaceURI`         |
| 2          | 0     | 0        | `get_NameTable`            |
| 8          | 0     | 0        | `get_NodeType`             |
| 2          | 0     | 0        | `get_Prefix`               |
| 4          | 0     | 0        | `get_Value`                |
| 2          | 0     | 0        | `LookupNamespace`          |
| 2          | 0     | 0        | `LookupPrefix`             |
| 4          | 0     | 0        | `get_HasAttributes`        |
| 2          | 0     | 0        | `get_HasChildren`          |
| 6          | 0     | 0        | `IsSamePosition`           |
| 4          | 0     | 0        | `MoveTo`                   |
| 4          | 0     | 0        | `MoveToFirstAttribute`     |
| 2          | 0     | 0        | `MoveToNextNamespace`      |
| 2          | 0     | 0        | `MoveToFirstNamespace`     |
| 2          | 0     | 0        | `MoveToId`                 |
| 2          | 0     | 0        | `MoveToNextAttribute`      |
| 2          | 0     | 0        | `MoveToFirstChild`         |
| 10         | 0     | 0        | `MoveToFirstChildInternal` |
| 2          | 0     | 0        | `MoveToNext`               |
| 8          | 0     | 0        | `MoveToNextInternal`       |
| 2          | 0     | 0        | `MoveToPrevious`           |
| 8          | 0     | 0        | `MoveToPreviousInternal`   |
| 10         | 0     | 0        | `MoveToParent`             |
| 1          | 0     | 100      | `MoveToRoot`               |
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
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
‼7:   internal class WrappedNavigator(IWrappedNode node) : XPathNavigator
〰8:   {
〰9:       private WrapperState _state;
‼10:      private IWrappedNode _node = node;
〰11:  
‼12:      public override XPathNavigator Clone() => new WrappedNavigator(_node) { _state = this._state };
〰13:  
‼14:      public override string BaseURI => _state switch
‼15:      {
‼16:          WrapperState.Child => _node.Current.BaseURI,
‼17:          _ => ""
‼18:      };
〰19:  
‼20:      public override bool IsEmptyElement => _state switch
‼21:      {
‼22:          WrapperState.Child => _node.Current.IsEmptyElement,
‼23:          _ => false,
‼24:      };
〰25:  
‼26:      public override string LocalName => _state switch
‼27:      {
‼28:          WrapperState.Child => _node.Current.LocalName,
‼29:          WrapperState.NodeAttribute => "Source",
‼30:          _ => _state.ToString()
‼31:      };
〰32:  
‼33:      public override string Name => _state switch
‼34:      {
‼35:          WrapperState.Child => _node.Current.Name,
‼36:          WrapperState.NodeAttribute => "Source",
‼37:          _ => _state.ToString()
‼38:      };
〰39:  
‼40:      public override string NamespaceURI => _state switch
‼41:      {
‼42:          WrapperState.Child => _node.Current.NamespaceURI,
‼43:          _ => ""
‼44:      };
〰45:  
‼46:      public override XmlNameTable NameTable => _state switch
‼47:      {
‼48:          WrapperState.Child => _node.Current.NameTable,
‼49:          _ => null
‼50:      };
〰51:  
‼52:      public override XPathNodeType NodeType => _state switch
‼53:      {
‼54:          WrapperState.Child => _node.Current.NodeType switch
‼55:          {
‼56:              XPathNodeType.Root => throw new NotSupportedException(), // XPathNodeType.Element, //Children can not be root elements
‼57:              _ => _node.Current.NodeType
‼58:          },
‼59:          WrapperState.Root => XPathNodeType.Root,
‼60:          WrapperState.NodeAttribute => XPathNodeType.Attribute,
‼61:          _ => XPathNodeType.Element,
‼62:      };
〰63:  
‼64:      public override string Prefix => _state switch
‼65:      {
‼66:          WrapperState.Child => _node.Current.Prefix,
‼67:          _ => ""
‼68:      };
〰69:  
‼70:      public override string Value => _state switch
‼71:      {
‼72:          WrapperState.Child => _node.Current.Value,
‼73:          WrapperState.NodeAttribute => _node.Source,
‼74:          _ => ""
‼75:      };
〰76:  
‼77:      public override string LookupNamespace(string prefix) => _state switch
‼78:      {
‼79:          WrapperState.Child => _node.Current.LookupNamespace(prefix),
‼80:          _ => ""
‼81:      };
‼82:      public override string LookupPrefix(string namespaceURI) => _state switch
‼83:      {
‼84:          WrapperState.Child => _node.Current.LookupPrefix(namespaceURI),
‼85:          _ => ""
‼86:      };
〰87:  
‼88:      public override bool HasAttributes => _state switch
‼89:      {
‼90:          WrapperState.Child => _node.Current.HasAttributes,
‼91:          WrapperState.Node => true,
‼92:          _ => false
‼93:      };
〰94:  
‼95:      public override bool HasChildren => _state switch
‼96:      {
‼97:          WrapperState.Child => _node.Current.HasAttributes,
‼98:          _ => true,
‼99:      };
〰100: 
‼101:     public override bool IsSamePosition(XPathNavigator other) => _state switch
‼102:     {
‼103:         WrapperState.Child => _node.Current.IsSamePosition(other),
‼104:         _ => other switch
‼105:         {
‼106:             WrappedNavigator wrapped => object.ReferenceEquals(wrapped._node, this._node) && wrapped._state == this._state,
‼107:             _ => false
‼108:         }
‼109:     };
〰110: 
〰111:     public override bool MoveTo(XPathNavigator other)
〰112:     {
‼113:         if (other is WrappedNavigator wrapped && wrapped._node != null)
〰114:         {
‼115:             _node = wrapped._node;
‼116:             _state = wrapped._state;
‼117:             return true;
〰118:         }
‼119:         return false;
〰120:     }
〰121: 
‼122:     public override bool MoveToFirstAttribute() => _state switch
‼123:     {
‼124:         WrapperState.Child => _node.Current.MoveToFirstAttribute(),
‼125:         WrapperState.Node => (_state = WrapperState.NodeAttribute) == WrapperState.NodeAttribute,
‼126:         _ => false
‼127:     };
〰128: 
‼129:     public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼130:     {
‼131:         WrapperState.Child => _node.Current.MoveToNextNamespace(namespaceScope),
‼132:         _ => false
‼133:     };
‼134:     public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼135:     {
‼136:         WrapperState.Child => _node.Current.MoveToFirstNamespace(namespaceScope),
‼137:         _ => false
‼138:     };
〰139: 
‼140:     public override bool MoveToId(string id) => _state switch
‼141:     {
‼142:         WrapperState.Child => _node.Current.MoveToId(id),
‼143:         _ => false
‼144:     };
〰145: 
‼146:     public override bool MoveToNextAttribute() => _state switch
‼147:     {
‼148:         WrapperState.Child => _node.Current.MoveToNextAttribute(),
‼149:         _ => false
‼150:     };
〰151: 
‼152:     public override bool MoveToFirstChild() => _state switch
‼153:     {
‼154:         WrapperState.Child => _node.Current.MoveToFirstChild(),
‼155:         _ => MoveToFirstChildInternal()
‼156:     };
〰157:     private bool MoveToFirstChildInternal()
〰158:     {
‼159:         switch (_state)
〰160:         {
〰161:             case WrapperState.Root:
‼162:                 _state = WrapperState.Top;
‼163:                 return true;
〰164: 
〰165:             case WrapperState.NodeAttribute:
〰166:             case WrapperState.Top:
‼167:                 _state = WrapperState.Node;
‼168:                 if (_node.First == null) return false;
‼169:                 _node = _node.First;
‼170:                 return true;
〰171: 
〰172:             case WrapperState.Node:
‼173:                 _node.Current.MoveToRoot();
‼174:                 var result = _node.Current.MoveToFirstChild();
‼175:                 if (result)
‼176:                     _state = WrapperState.Child;
‼177:                 return result;
〰178: 
〰179:             default:
〰180:             case WrapperState.Child:
‼181:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰182:         }
〰183:     }
〰184: 
‼185:     public override bool MoveToNext() => _state switch
‼186:     {
‼187:         WrapperState.Child => _node.Current.MoveToNext(),
‼188:         _ => MoveToNextInternal()
‼189:     };
〰190:     private bool MoveToNextInternal()
〰191:     {
‼192:         switch (_state)
〰193:         {
〰194:             case WrapperState.Root:
〰195:             case WrapperState.Top:
‼196:                 return false;
〰197: 
〰198:             case WrapperState.NodeAttribute:
〰199:             case WrapperState.Node:
‼200:                 if (_node.Next == null)
‼201:                     return false;
‼202:                 _node = _node.Next;
‼203:                 _node.Current.MoveToRoot();
‼204:                 var result = _node.Current.MoveToFirstChild();
‼205:                 return true;
〰206: 
〰207:             default:
〰208:             case WrapperState.Child:
‼209:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰210:         }
〰211:     }
〰212: 
‼213:     public override bool MoveToPrevious() => _state switch
‼214:     {
‼215:         WrapperState.Child => _node.Current.MoveToPrevious(),
‼216:         _ => MoveToPreviousInternal()
‼217:     };
〰218:     private bool MoveToPreviousInternal()
〰219:     {
‼220:         switch (_state)
〰221:         {
〰222:             case WrapperState.Root:
〰223:             case WrapperState.Top:
‼224:                 return false;
〰225: 
〰226:             case WrapperState.NodeAttribute:
〰227:             case WrapperState.Node:
‼228:                 if (_node.Previous == null)
‼229:                     return false;
‼230:                 _node = _node.Previous;
‼231:                 return true;
〰232: 
〰233:             default:
〰234:             case WrapperState.Child:
‼235:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰236:         }
〰237:     }
〰238: 
〰239:     public override bool MoveToParent()
〰240:     {
‼241:         switch (_state)
〰242:         {
〰243:             case WrapperState.Root:
‼244:                 return false;
〰245: 
〰246:             case WrapperState.Top:
‼247:                 _state = WrapperState.Root;
‼248:                 return true;
〰249: 
〰250:             case WrapperState.NodeAttribute:
‼251:                 _state = WrapperState.Node;
‼252:                 return true;
〰253:             case WrapperState.Node:
‼254:                 _state = WrapperState.Top;
‼255:                 return true;
〰256:             case WrapperState.Child:
‼257:                 if (!_node.Current.MoveToParent())
〰258:                 {
‼259:                     _state = WrapperState.Node;
〰260:                 }
‼261:                 if (_node.Current.NodeType == XPathNodeType.Root)
〰262:                 {
‼263:                     _state = WrapperState.Node;
‼264:                     var result = _node.Current.MoveToFirstChild();
‼265:                     return result;
〰266:                 }
‼267:                 return true;
〰268:             default:
‼269:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰270:         }
〰271:     }
〰272:     public override void MoveToRoot()
〰273:     {
‼274:         _node = _node.First;
‼275:         _state = WrapperState.Root;
‼276:     }
〰277: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/WrappedNavigator.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
✔7:   internal class WrappedNavigator(IWrappedNode node) : XPathNavigator
〰8:   {
〰9:       private WrapperState _state;
✔10:      private IWrappedNode _node = node;
〰11:  
✔12:      public override XPathNavigator Clone() => new WrappedNavigator(_node) { _state = this._state };
〰13:  
‼14:      public override string BaseURI => _state switch
‼15:      {
‼16:          WrapperState.Child => _node.Current.BaseURI,
‼17:          _ => ""
‼18:      };
〰19:  
‼20:      public override bool IsEmptyElement => _state switch
‼21:      {
‼22:          WrapperState.Child => _node.Current.IsEmptyElement,
‼23:          _ => false,
‼24:      };
〰25:  
⚠26:      public override string LocalName => _state switch
✔27:      {
✔28:          WrapperState.Child => _node.Current.LocalName,
‼29:          WrapperState.NodeAttribute => "Source",
✔30:          _ => _state.ToString()
✔31:      };
〰32:  
‼33:      public override string Name => _state switch
‼34:      {
‼35:          WrapperState.Child => _node.Current.Name,
‼36:          WrapperState.NodeAttribute => "Source",
‼37:          _ => _state.ToString()
‼38:      };
〰39:  
✔40:      public override string NamespaceURI => _state switch
✔41:      {
✔42:          WrapperState.Child => _node.Current.NamespaceURI,
✔43:          _ => ""
✔44:      };
〰45:  
‼46:      public override XmlNameTable NameTable => _state switch
‼47:      {
‼48:          WrapperState.Child => _node.Current.NameTable,
‼49:          _ => null
‼50:      };
〰51:  
⚠52:      public override XPathNodeType NodeType => _state switch
✔53:      {
✔54:          WrapperState.Child => _node.Current.NodeType switch
✔55:          {
‼56:              XPathNodeType.Root => throw new NotSupportedException(), // XPathNodeType.Element, //Children can not be root elements
✔57:              _ => _node.Current.NodeType
✔58:          },
‼59:          WrapperState.Root => XPathNodeType.Root,
‼60:          WrapperState.NodeAttribute => XPathNodeType.Attribute,
✔61:          _ => XPathNodeType.Element,
✔62:      };
〰63:  
‼64:      public override string Prefix => _state switch
‼65:      {
‼66:          WrapperState.Child => _node.Current.Prefix,
‼67:          _ => ""
‼68:      };
〰69:  
⚠70:      public override string Value => _state switch
✔71:      {
✔72:          WrapperState.Child => _node.Current.Value,
‼73:          WrapperState.NodeAttribute => _node.Source,
‼74:          _ => ""
✔75:      };
〰76:  
‼77:      public override string LookupNamespace(string prefix) => _state switch
‼78:      {
‼79:          WrapperState.Child => _node.Current.LookupNamespace(prefix),
‼80:          _ => ""
‼81:      };
‼82:      public override string LookupPrefix(string namespaceURI) => _state switch
‼83:      {
‼84:          WrapperState.Child => _node.Current.LookupPrefix(namespaceURI),
‼85:          _ => ""
‼86:      };
〰87:  
‼88:      public override bool HasAttributes => _state switch
‼89:      {
‼90:          WrapperState.Child => _node.Current.HasAttributes,
‼91:          WrapperState.Node => true,
‼92:          _ => false
‼93:      };
〰94:  
‼95:      public override bool HasChildren => _state switch
‼96:      {
‼97:          WrapperState.Child => _node.Current.HasAttributes,
‼98:          _ => true,
‼99:      };
〰100: 
‼101:     public override bool IsSamePosition(XPathNavigator other) => _state switch
‼102:     {
‼103:         WrapperState.Child => _node.Current.IsSamePosition(other),
‼104:         _ => other switch
‼105:         {
‼106:             WrappedNavigator wrapped => object.ReferenceEquals(wrapped._node, this._node) && wrapped._state == this._state,
‼107:             _ => false
‼108:         }
‼109:     };
〰110: 
〰111:     public override bool MoveTo(XPathNavigator other)
〰112:     {
⚠113:         if (other is WrappedNavigator wrapped && wrapped._node != null)
〰114:         {
✔115:             _node = wrapped._node;
✔116:             _state = wrapped._state;
✔117:             return true;
〰118:         }
‼119:         return false;
〰120:     }
〰121: 
‼122:     public override bool MoveToFirstAttribute() => _state switch
‼123:     {
‼124:         WrapperState.Child => _node.Current.MoveToFirstAttribute(),
‼125:         WrapperState.Node => (_state = WrapperState.NodeAttribute) == WrapperState.NodeAttribute,
‼126:         _ => false
‼127:     };
〰128: 
‼129:     public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼130:     {
‼131:         WrapperState.Child => _node.Current.MoveToNextNamespace(namespaceScope),
‼132:         _ => false
‼133:     };
‼134:     public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼135:     {
‼136:         WrapperState.Child => _node.Current.MoveToFirstNamespace(namespaceScope),
‼137:         _ => false
‼138:     };
〰139: 
‼140:     public override bool MoveToId(string id) => _state switch
‼141:     {
‼142:         WrapperState.Child => _node.Current.MoveToId(id),
‼143:         _ => false
‼144:     };
〰145: 
‼146:     public override bool MoveToNextAttribute() => _state switch
‼147:     {
‼148:         WrapperState.Child => _node.Current.MoveToNextAttribute(),
‼149:         _ => false
‼150:     };
〰151: 
⚠152:     public override bool MoveToFirstChild() => _state switch
✔153:     {
‼154:         WrapperState.Child => _node.Current.MoveToFirstChild(),
✔155:         _ => MoveToFirstChildInternal()
✔156:     };
〰157:     private bool MoveToFirstChildInternal()
〰158:     {
⚠159:         switch (_state)
〰160:         {
〰161:             case WrapperState.Root:
✔162:                 _state = WrapperState.Top;
✔163:                 return true;
〰164: 
〰165:             case WrapperState.NodeAttribute:
〰166:             case WrapperState.Top:
✔167:                 _state = WrapperState.Node;
⚠168:                 if (_node.First == null) return false;
✔169:                 _node = _node.First;
✔170:                 return true;
〰171: 
〰172:             case WrapperState.Node:
✔173:                 _node.Current.MoveToRoot();
✔174:                 var result = _node.Current.MoveToFirstChild();
✔175:                 if (result)
✔176:                     _state = WrapperState.Child;
✔177:                 return result;
〰178: 
〰179:             default:
〰180:             case WrapperState.Child:
‼181:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰182:         }
〰183:     }
〰184: 
✔185:     public override bool MoveToNext() => _state switch
✔186:     {
✔187:         WrapperState.Child => _node.Current.MoveToNext(),
✔188:         _ => MoveToNextInternal()
✔189:     };
〰190:     private bool MoveToNextInternal()
〰191:     {
⚠192:         switch (_state)
〰193:         {
〰194:             case WrapperState.Root:
〰195:             case WrapperState.Top:
‼196:                 return false;
〰197: 
〰198:             case WrapperState.NodeAttribute:
〰199:             case WrapperState.Node:
⚠200:                 if (_node.Next == null)
‼201:                     return false;
✔202:                 _node = _node.Next;
✔203:                 _node.Current.MoveToRoot();
✔204:                 var result = _node.Current.MoveToFirstChild();
✔205:                 return true;
〰206: 
〰207:             default:
〰208:             case WrapperState.Child:
‼209:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰210:         }
〰211:     }
〰212: 
‼213:     public override bool MoveToPrevious() => _state switch
‼214:     {
‼215:         WrapperState.Child => _node.Current.MoveToPrevious(),
‼216:         _ => MoveToPreviousInternal()
‼217:     };
〰218:     private bool MoveToPreviousInternal()
〰219:     {
‼220:         switch (_state)
〰221:         {
〰222:             case WrapperState.Root:
〰223:             case WrapperState.Top:
‼224:                 return false;
〰225: 
〰226:             case WrapperState.NodeAttribute:
〰227:             case WrapperState.Node:
‼228:                 if (_node.Previous == null)
‼229:                     return false;
‼230:                 _node = _node.Previous;
‼231:                 return true;
〰232: 
〰233:             default:
〰234:             case WrapperState.Child:
‼235:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰236:         }
〰237:     }
〰238: 
〰239:     public override bool MoveToParent()
〰240:     {
‼241:         switch (_state)
〰242:         {
〰243:             case WrapperState.Root:
‼244:                 return false;
〰245: 
〰246:             case WrapperState.Top:
‼247:                 _state = WrapperState.Root;
‼248:                 return true;
〰249: 
〰250:             case WrapperState.NodeAttribute:
‼251:                 _state = WrapperState.Node;
‼252:                 return true;
〰253:             case WrapperState.Node:
‼254:                 _state = WrapperState.Top;
‼255:                 return true;
〰256:             case WrapperState.Child:
‼257:                 if (!_node.Current.MoveToParent())
〰258:                 {
‼259:                     _state = WrapperState.Node;
〰260:                 }
‼261:                 if (_node.Current.NodeType == XPathNodeType.Root)
〰262:                 {
‼263:                     _state = WrapperState.Node;
‼264:                     var result = _node.Current.MoveToFirstChild();
‼265:                     return result;
〰266:                 }
‼267:                 return true;
〰268:             default:
‼269:                 throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰270:         }
〰271:     }
〰272:     public override void MoveToRoot()
〰273:     {
✔274:         _node = _node.First;
✔275:         _state = WrapperState.Root;
✔276:     }
〰277: }
〰278: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

