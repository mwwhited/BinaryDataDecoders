using System;
using System.Xml;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal class WrappedNavigator : XPathNavigator
    {
        private const string ROOT = "ROOT";

        private WrapperState _state;
        private IWrappedNode _current;

        public WrappedNavigator(IWrappedNode seed)
        {
            _current = seed;
        }

        public override XPathNavigator Clone() => new WrappedNavigator(_current) { _state = this._state };


        public override string BaseURI => _state switch
        {
            WrapperState.Child => _current.Current.BaseURI,
            _ => ""
        };

        public override bool IsEmptyElement => _state switch
        {
            WrapperState.Child => _current.Current.IsEmptyElement,
            _ => false,
        };

        public override string LocalName => _state switch
        {
            WrapperState.Child => _current.Current.LocalName,
            _ => ROOT
        };

        public override string Name => _state switch
        {
            WrapperState.Child => _current.Current.Name,
            _ => ROOT
        };

        public override string NamespaceURI => _state switch
        {
            WrapperState.Child => _current.Current.NamespaceURI,
            _ => ""
        };

        public override XmlNameTable? NameTable => _state switch
        {
            WrapperState.Child => _current.Current.NameTable,
            _ => null
        };

        public override XPathNodeType NodeType => _state switch
        {
            WrapperState.Child => _current.Current.NodeType switch
            {
                XPathNodeType.Root => XPathNodeType.Element, //Children can not be root elements
                _ => _current.Current.NodeType
            },
            WrapperState.Element => XPathNodeType.Element,
            WrapperState.Root => XPathNodeType.Root,
            _ => XPathNodeType.Comment,
        };

        public override string Prefix => _state switch
        {
            WrapperState.Child => _current.Current.Prefix,
            _ => ""
        };

        public override string Value => _state switch
        {
            WrapperState.Child => _current.Current.Value,
            _ => ""
        };

        public override bool IsSamePosition(XPathNavigator other) => _state switch
        {
            WrapperState.Child => _current.Current.IsSamePosition(other),
            _ => other switch
            {
                WrappedNavigator wrapped => object.ReferenceEquals(wrapped._current, this._current) && wrapped._state == this._state,
                _ => false
            }
        };

        public override bool MoveTo(XPathNavigator other)
        {
            if (other is WrappedNavigator wrapped)
            {
                _current = wrapped._current;
                _state = wrapped._state;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstAttribute() => _state switch
        {
            WrapperState.Child => _current.Current.MoveToFirstAttribute(),
            _ => false
        };

        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => _state switch
        {
            WrapperState.Child => _current.Current.MoveToNextNamespace(namespaceScope),
            _ => false
        };
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => _state switch
        {
            WrapperState.Child => _current.Current.MoveToFirstNamespace(namespaceScope),
            _ => false
        };

        public override bool MoveToId(string id) => _state switch
        {
            WrapperState.Child => _current.Current.MoveToId(id),
            _ => false
        };

        public override bool MoveToNextAttribute() => _state switch
        {
            WrapperState.Child => _current.Current.MoveToNextAttribute(),
            _ => false
        };

        public override bool MoveToFirstChild() => _state switch
        {
            WrapperState.Child => _current.Current.MoveToFirstChild(),
            _ => MoveToFirstChildInternal()
        };

        private bool MoveToFirstChildInternal()
        {
            switch (_state)
            {
                case WrapperState.Root:
                    _state = WrapperState.Element;
                    break;
                case WrapperState.Element:
                    _state = WrapperState.Child;
                    break;

                default:
                case WrapperState.Child:
                    throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
            }

            _current = _current.First;
            return true;
        }

        public override bool MoveToNext() => _state switch
        {
            WrapperState.Child => _current.Current.MoveToNext(),
            _ => MoveToNextInternal()
        };
        public override bool MoveToPrevious() => _state switch
        {
            WrapperState.Child => _current.Current.MoveToPrevious(),
            _ => MoveToPreviousInternal()
        };

        private bool MoveToNextInternal()
        {
            switch (_state)
            {
                case WrapperState.Root:
                    return false;

                case WrapperState.Element:
                    if (_current.Next == null) return false;
                    _current = _current.Next;
                    return true;

                default:
                case WrapperState.Child:
                    throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
            }
        }

        private bool MoveToPreviousInternal()
        {
            switch (_state)
            {
                case WrapperState.Root:
                    return false;

                case WrapperState.Element:
                    if (_current.Previous == null) return false;
                    _current = _current.Previous;
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

                case WrapperState.Element:
                    _state = WrapperState.Root;
                    return true;
                case WrapperState.Child:
                    if (!_current.Current.MoveToParent())
                    {
                        if (_current.Current.NodeType == XPathNodeType.Root)
                        {
                            _current.Current.MoveToFirst();
                        }
                        _state = WrapperState.Element;
                    }
                    return true;
                default:
                    throw new InvalidOperationException($"Invalid operation while in \"{_state}\" state");
            }
        }

    }
}
