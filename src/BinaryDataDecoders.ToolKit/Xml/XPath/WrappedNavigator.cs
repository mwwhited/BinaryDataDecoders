using System;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;

internal class WrappedNavigator(IWrappedNode node) : XPathNavigator
{
    private WrapperState _state;
    private IWrappedNode _node = node;

    public override XPathNavigator Clone() => new WrappedNavigator(_node) { _state = this._state };

    public override string BaseURI => _state switch
    {
        WrapperState.Child => _node.Current.BaseURI,
        _ => ""
    };

    public override bool IsEmptyElement => _state switch
    {
        WrapperState.Child => _node.Current.IsEmptyElement,
        _ => false,
    };

    public override string LocalName => _state switch
    {
        WrapperState.Child => _node.Current.LocalName,
        WrapperState.NodeAttribute => "Source",
        _ => _state.ToString()
    };

    public override string Name => _state switch
    {
        WrapperState.Child => _node.Current.Name,
        WrapperState.NodeAttribute => "Source",
        _ => _state.ToString()
    };

    public override string NamespaceURI => _state switch
    {
        WrapperState.Child => _node.Current.NamespaceURI,
        _ => ""
    };

    public override XmlNameTable NameTable => _state switch
    {
        WrapperState.Child => _node.Current.NameTable,
        _ => null
    };

    public override XPathNodeType NodeType => _state switch
    {
        WrapperState.Child => _node.Current.NodeType switch
        {
            XPathNodeType.Root => throw new NotSupportedException(), // XPathNodeType.Element, //Children can not be root elements
            _ => _node.Current.NodeType
        },
        WrapperState.Root => XPathNodeType.Root,
        WrapperState.NodeAttribute => XPathNodeType.Attribute,
        _ => XPathNodeType.Element,
    };

    public override string Prefix => _state switch
    {
        WrapperState.Child => _node.Current.Prefix,
        _ => ""
    };

    public override string Value => _state switch
    {
        WrapperState.Child => _node.Current.Value,
        WrapperState.NodeAttribute => _node.Source,
        _ => ""
    };

    public override string LookupNamespace(string prefix) => _state switch
    {
        WrapperState.Child => _node.Current.LookupNamespace(prefix),
        _ => ""
    } ?? "";
    public override string LookupPrefix(string namespaceURI) => _state switch
    {
        WrapperState.Child => _node.Current.LookupPrefix(namespaceURI),
        _ => ""
    } ?? "";

    public override bool HasAttributes => _state switch
    {
        WrapperState.Child => _node.Current.HasAttributes,
        WrapperState.Node => true,
        _ => false
    };

    public override bool HasChildren => _state switch
    {
        WrapperState.Child => _node.Current.HasAttributes,
        _ => true,
    };

    public override bool IsSamePosition(XPathNavigator other) => _state switch
    {
        WrapperState.Child => _node.Current.IsSamePosition(other),
        _ => other switch
        {
            WrappedNavigator wrapped => object.ReferenceEquals(wrapped._node, this._node) && wrapped._state == this._state,
            _ => false
        }
    };

    public override bool MoveTo(XPathNavigator other)
    {
        if (other is WrappedNavigator wrapped && wrapped._node != null)
        {
            _node = wrapped._node;
            _state = wrapped._state;
            return true;
        }
        return false;
    }

    public override bool MoveToFirstAttribute() => _state switch
    {
        WrapperState.Child => _node.Current.MoveToFirstAttribute(),
        WrapperState.Node => (_state = WrapperState.NodeAttribute) == WrapperState.NodeAttribute,
        _ => false
    };

    public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
    {
        WrapperState.Child => _node.Current.MoveToNextNamespace(namespaceScope),
        _ => false
    };
    public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
    {
        WrapperState.Child => _node.Current.MoveToFirstNamespace(namespaceScope),
        _ => false
    };

    public override bool MoveToId(string id) => _state switch
    {
        WrapperState.Child => _node.Current.MoveToId(id),
        _ => false
    };

    public override bool MoveToNextAttribute() => _state switch
    {
        WrapperState.Child => _node.Current.MoveToNextAttribute(),
        _ => false
    };

    public override bool MoveToFirstChild() => _state switch
    {
        WrapperState.Child => _node.Current.MoveToFirstChild(),
        _ => MoveToFirstChildInternal()
    };
    private bool MoveToFirstChildInternal()
    {
        switch (_state)
        {
            case WrapperState.Root:
                _state = WrapperState.Top;
                return true;

            case WrapperState.NodeAttribute:
            case WrapperState.Top:
                _state = WrapperState.Node;
                if (_node.First == null) return false;
                _node = _node.First;
                return true;

            case WrapperState.Node:
                _node.Current.MoveToRoot();
                var result = _node.Current.MoveToFirstChild();
                if (result)
                    _state = WrapperState.Child;
                return result;

            default:
            case WrapperState.Child:
                throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
        }
    }

    public override bool MoveToNext() => _state switch
    {
        WrapperState.Child => _node.Current.MoveToNext(),
        _ => MoveToNextInternal()
    };
    private bool MoveToNextInternal()
    {
        switch (_state)
        {
            case WrapperState.Root:
            case WrapperState.Top:
                return false;

            case WrapperState.NodeAttribute:
            case WrapperState.Node:
                if (_node.Next == null)
                    return false;
                _node = _node.Next;
                _node.Current.MoveToRoot();
                var result = _node.Current.MoveToFirstChild();
                return true;

            default:
            case WrapperState.Child:
                throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
        }
    }

    public override bool MoveToPrevious() => _state switch
    {
        WrapperState.Child => _node.Current.MoveToPrevious(),
        _ => MoveToPreviousInternal()
    };
    private bool MoveToPreviousInternal()
    {
        switch (_state)
        {
            case WrapperState.Root:
            case WrapperState.Top:
                return false;

            case WrapperState.NodeAttribute:
            case WrapperState.Node:
                if (_node.Previous == null)
                    return false;
                _node = _node.Previous;
                return true;

            default:
            case WrapperState.Child:
                throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
        }
    }

    public override bool MoveToParent()
    {
        switch (_state)
        {
            case WrapperState.Root:
                return false;

            case WrapperState.Top:
                _state = WrapperState.Root;
                return true;

            case WrapperState.NodeAttribute:
                _state = WrapperState.Node;
                return true;
            case WrapperState.Node:
                _state = WrapperState.Top;
                return true;
            case WrapperState.Child:
                if (!_node.Current.MoveToParent())
                {
                    _state = WrapperState.Node;
                }
                if (_node.Current.NodeType == XPathNodeType.Root)
                {
                    _state = WrapperState.Node;
                    var result = _node.Current.MoveToFirstChild();
                    return result;
                }
                return true;
            default:
                throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
        }
    }
    public override void MoveToRoot()
    {
        _node = _node.First;
        _state = WrapperState.Root;
    }
}
