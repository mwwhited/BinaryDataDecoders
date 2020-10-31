
# BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_WrappedNavigator.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.WrappedNavigator        | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 59                                                           | 
| Uncoveredlines       | 115                                                          | 
| Coverablelines       | 174                                                          | 
| Totallines           | 271                                                          | 
| Linecoverage         | 33.9                                                         | 
| Coveredbranches      | 22                                                           | 
| Totalbranches        | 88                                                           | 
| Branchcoverage       | 25                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\WrappedNavigator.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | Clone | 
| 2          | 0     | 0        | get_BaseURI | 
| 2          | 0     | 0        | get_IsEmptyElement | 
| 2          | 100   | 100      | get_LocalName | 
| 2          | 0     | 0        | get_Name | 
| 2          | 100   | 100      | get_NamespaceURI | 
| 2          | 0     | 0        | get_NameTable | 
| 6          | 80.0  | 66.66    | get_NodeType | 
| 2          | 0     | 0        | get_Prefix | 
| 2          | 80.0  | 50.0     | get_Value | 
| 2          | 0     | 0        | LookupNamespace | 
| 2          | 0     | 0        | LookupPrefix | 
| 2          | 0     | 0        | get_HasAttributes | 
| 2          | 0     | 0        | get_HasChildren | 
| 6          | 0     | 0        | IsSamePosition | 
| 4          | 80.0  | 50.0     | MoveTo | 
| 2          | 0     | 0        | MoveToFirstAttribute | 
| 2          | 0     | 0        | MoveToNextNamespace | 
| 2          | 0     | 0        | MoveToFirstNamespace | 
| 2          | 0     | 0        | MoveToId | 
| 2          | 0     | 0        | MoveToNextAttribute | 
| 2          | 80.0  | 50.0     | MoveToFirstChild | 
| 9          | 84.61 | 66.66    | MoveToFirstChildInternal | 
| 2          | 100   | 100      | MoveToNext | 
| 7          | 66.66 | 28.57    | MoveToNextInternal | 
| 2          | 0     | 0        | MoveToPrevious | 
| 7          | 0     | 0        | MoveToPreviousInternal | 
| 9          | 0     | 0        | MoveToParent | 
| 1          | 100   | 100      | MoveToRoot | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\WrappedNavigator.cs

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
✔31:          public override string LocalName => _state switch
✔32:          {
✔33:              WrapperState.Child => _node.Current.LocalName,
✔34:              _ => _state.ToString()
✔35:          };
〰36:  
‼37:          public override string Name => _state switch
‼38:          {
‼39:              WrapperState.Child => _node.Current.Name,
‼40:              _ => _state.ToString()
‼41:          };
〰42:  
✔43:          public override string NamespaceURI => _state switch
✔44:          {
✔45:              WrapperState.Child => _node.Current.NamespaceURI,
✔46:              _ => ""
✔47:          };
〰48:  
‼49:          public override XmlNameTable? NameTable => _state switch
‼50:          {
‼51:              WrapperState.Child => _node.Current.NameTable,
‼52:              _ => null
‼53:          };
〰54:  
⚠55:          public override XPathNodeType NodeType => _state switch
✔56:          {
✔57:              WrapperState.Child => _node.Current.NodeType switch
✔58:              {
‼59:                  XPathNodeType.Root => throw new NotSupportedException(), // XPathNodeType.Element, //Children can not be root elements
✔60:                  _ => _node.Current.NodeType
✔61:              },
‼62:              WrapperState.Root => XPathNodeType.Root,
✔63:              _ => XPathNodeType.Element,
✔64:          };
〰65:  
‼66:          public override string Prefix => _state switch
‼67:          {
‼68:              WrapperState.Child => _node.Current.Prefix,
‼69:              _ => ""
‼70:          };
〰71:  
⚠72:          public override string Value => _state switch
✔73:          {
✔74:              WrapperState.Child => _node.Current.Value,
‼75:              _ => ""
✔76:          };
〰77:  
‼78:          public override string LookupNamespace(string prefix) => _state switch
‼79:          {
‼80:              WrapperState.Child => _node.Current.LookupNamespace(prefix),
‼81:              _ => ""
‼82:          };
‼83:          public override string LookupPrefix(string namespaceURI) => _state switch
‼84:          {
‼85:              WrapperState.Child => _node.Current.LookupPrefix(namespaceURI),
‼86:              _ => ""
‼87:          };
〰88:  
‼89:          public override bool HasAttributes => _state switch
‼90:          {
‼91:              WrapperState.Child => _node.Current.HasAttributes,
‼92:              _ => false
‼93:          };
〰94:  
‼95:          public override bool HasChildren => _state switch
‼96:          {
‼97:              WrapperState.Child => _node.Current.HasAttributes,
‼98:              _ => true,
‼99:          };
〰100: 
‼101:         public override bool IsSamePosition(XPathNavigator other) => _state switch
‼102:         {
‼103:             WrapperState.Child => _node.Current.IsSamePosition(other),
‼104:             _ => other switch
‼105:             {
‼106:                 WrappedNavigator wrapped => object.ReferenceEquals(wrapped._node, this._node) && wrapped._state == this._state,
‼107:                 _ => false
‼108:             }
‼109:         };
〰110: 
〰111:         public override bool MoveTo(XPathNavigator other)
〰112:         {
⚠113:             if (other is WrappedNavigator wrapped && wrapped._node != null)
〰114:             {
✔115:                 _node = wrapped._node;
✔116:                 _state = wrapped._state;
✔117:                 return true;
〰118:             }
‼119:             return false;
〰120:         }
〰121: 
‼122:         public override bool MoveToFirstAttribute() => _state switch
‼123:         {
‼124:             WrapperState.Child => _node.Current.MoveToFirstAttribute(),
‼125:             _ => false
‼126:         };
〰127: 
‼128:         public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼129:         {
‼130:             WrapperState.Child => _node.Current.MoveToNextNamespace(namespaceScope),
‼131:             _ => false
‼132:         };
‼133:         public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
‼134:         {
‼135:             WrapperState.Child => _node.Current.MoveToFirstNamespace(namespaceScope),
‼136:             _ => false
‼137:         };
〰138: 
‼139:         public override bool MoveToId(string id) => _state switch
‼140:         {
‼141:             WrapperState.Child => _node.Current.MoveToId(id),
‼142:             _ => false
‼143:         };
〰144: 
‼145:         public override bool MoveToNextAttribute() => _state switch
‼146:         {
‼147:             WrapperState.Child => _node.Current.MoveToNextAttribute(),
‼148:             _ => false
‼149:         };
〰150: 
⚠151:         public override bool MoveToFirstChild() => _state switch
✔152:         {
‼153:             WrapperState.Child => _node.Current.MoveToFirstChild(),
✔154:             _ => MoveToFirstChildInternal()
✔155:         };
〰156:         private bool MoveToFirstChildInternal()
〰157:         {
⚠158:             switch (_state)
〰159:             {
〰160:                 case WrapperState.Root:
✔161:                     _state = WrapperState.Top;
✔162:                     return true;
〰163: 
〰164:                 case WrapperState.Top:
✔165:                     _state = WrapperState.Node;
‼166:                     if (_node.First == null) return false;
✔167:                     _node = _node.First;
✔168:                     return true;
〰169: 
〰170:                 case WrapperState.Node:
✔171:                     _node.Current.MoveToRoot();
✔172:                     var result = _node.Current.MoveToFirstChild();
✔173:                     if (result)
✔174:                         _state = WrapperState.Child;
✔175:                     return result;
〰176: 
〰177:                 default:
〰178:                 case WrapperState.Child:
‼179:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰180:             }
〰181:         }
〰182: 
✔183:         public override bool MoveToNext() => _state switch
✔184:         {
✔185:             WrapperState.Child => _node.Current.MoveToNext(),
✔186:             _ => MoveToNextInternal()
✔187:         };
〰188:         private bool MoveToNextInternal()
〰189:         {
⚠190:             switch (_state)
〰191:             {
〰192:                 case WrapperState.Root:
〰193:                 case WrapperState.Top:
‼194:                     return false;
〰195: 
〰196:                 case WrapperState.Node:
⚠197:                     if (_node.Next == null)
‼198:                         return false;
✔199:                     _node = _node.Next;
✔200:                     _node.Current.MoveToRoot();
✔201:                     var result = _node.Current.MoveToFirstChild();
✔202:                     return true;
〰203: 
〰204:                 default:
〰205:                 case WrapperState.Child:
‼206:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰207:             }
〰208:         }
〰209: 
‼210:         public override bool MoveToPrevious() => _state switch
‼211:         {
‼212:             WrapperState.Child => _node.Current.MoveToPrevious(),
‼213:             _ => MoveToPreviousInternal()
‼214:         };
〰215:         private bool MoveToPreviousInternal()
〰216:         {
‼217:             switch (_state)
〰218:             {
〰219:                 case WrapperState.Root:
〰220:                 case WrapperState.Top:
‼221:                     return false;
〰222: 
〰223:                 case WrapperState.Node:
‼224:                     if (_node.Previous == null)
‼225:                         return false;
‼226:                     _node = _node.Previous;
‼227:                     return true;
〰228: 
〰229:                 default:
〰230:                 case WrapperState.Child:
‼231:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰232:             }
〰233:         }
〰234: 
〰235:         public override bool MoveToParent()
〰236:         {
‼237:             switch (_state)
〰238:             {
〰239:                 case WrapperState.Root:
‼240:                     return false;
〰241: 
〰242:                 case WrapperState.Top:
‼243:                     _state = WrapperState.Root;
‼244:                     return true;
〰245: 
〰246:                 case WrapperState.Node:
‼247:                     _state = WrapperState.Top;
‼248:                     return true;
〰249:                 case WrapperState.Child:
‼250:                     if (!_node.Current.MoveToParent())
〰251:                     {
‼252:                         _state = WrapperState.Node;
〰253:                     }
‼254:                     if (_node.Current.NodeType == XPathNodeType.Root)
〰255:                     {
‼256:                         _state = WrapperState.Node;
‼257:                         var result = _node.Current.MoveToFirstChild();
‼258:                         return result;
〰259:                     }
‼260:                     return true;
〰261:                 default:
‼262:                     throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
〰263:             }
〰264:         }
〰265:         public override void MoveToRoot()
〰266:         {
✔267:             _node = _node.First;
✔268:             _state = WrapperState.Root;
✔269:         }
〰270:     }
〰271: }

```
## Footer 
[Return to Summary](Summary.md)

