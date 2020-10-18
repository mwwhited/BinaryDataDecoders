using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("E:>{Name}")]
    public class ExtensibleElementNode : ExtensibleElementNode<object>
    {
        public ExtensibleElementNode(
            XName name,
            object item,
            Func<object, string>? valueSelector = null,
            Func<object, IEnumerable<(XName name, string value)>>? attributeSelector = null,
            Func<object, IEnumerable<(XName name, object child)>>? childSelector = null,
            Func<object, IEnumerable<XName>>? namespaceSelector = null
            )
            : base(null, name, item, valueSelector, attributeSelector, childSelector, namespaceSelector)
        {
        }
    }
    [DebuggerDisplay("E:>{Name}")]
    public class ExtensibleElementNode<T> : IElementNode
    {
        private readonly T _item;

        private readonly Func<T, string>? _valueSelector;
        private readonly Func<T, IEnumerable<(XName name, string value)>>? _attributeSelector;
        private readonly Func<T, IEnumerable<(XName name, T child)>>? _childSelector;
        private readonly Func<T, IEnumerable<XName>>? _namespaceSelector;

        private readonly Lazy<INode?> _value;
        private readonly Lazy<INode?> _children;
        private readonly Lazy<IAttributeNode?> _attributes;
        private readonly Lazy<INamespaceNode?> _namespaces;

        public ExtensibleElementNode(
            XName name,
            T item,
            Func<T, string>? valueSelector = null,
            Func<T, IEnumerable<(XName name, string value)>>? attributeSelector = null,
            Func<T, IEnumerable<(XName name, T child)>>? childSelector = null,
            Func<T, IEnumerable<XName>>? namespaceSelector = null
            )
            : this(null, name, item, valueSelector, attributeSelector, childSelector, namespaceSelector)
        {
        }

        protected ExtensibleElementNode(
            INode? parent,
             XName name,
             T item,
             Func<T, string>? valueSelector,
             Func<T, IEnumerable<(XName name, string value)>>? attributeSelector,
             Func<T, IEnumerable<(XName name, T child)>>? childSelector,
             Func<T, IEnumerable<XName>>? namespaceSelector
             )
        {
            Parent = parent ?? new ExtensibleRootNode<T>(this);
            Name = name;
            _item = item;

            _valueSelector = valueSelector;
            _attributeSelector = attributeSelector;
            _childSelector = childSelector;
            _namespaceSelector = namespaceSelector;

            _value = new Lazy<INode?>(() =>
                _valueSelector?.Invoke(_item) switch
                {
                    null => (INode?)null,
                    string value when !string.IsNullOrWhiteSpace(value) => new XPathTextNode<T>(this, Name, _item, value),
                    string value when string.IsNullOrWhiteSpace(value) => new XPathWhitespaceNode<T>(this, Name, _item, value),

                    _ => throw new NotSupportedException(),
                });

            _attributes = new Lazy<IAttributeNode?>(() =>
            {
                var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string value)>()).GetEnumerator();
                IAttributeNode? first = null;
                IAttributeNode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new ExtensibleAttributeNode<T>(
                        this,
                        query.Current.name,
                        _item,
                        query.Current.value
                        )
                    {
                        Previous = previous,
                    };
                    if (previous is ExtensibleAttributeNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                return first;
            });

            _children = new Lazy<INode?>(() =>
            {
                var query = (_childSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, T child)>()).GetEnumerator();
                INode? first = null;
                INode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new ExtensibleElementNode<T>(
                        this,
                        query.Current.name,
                        query.Current.child,
                        _valueSelector,
                        _attributeSelector,
                        _childSelector,
                        _namespaceSelector
                        )
                    {
                        Previous = previous,
                    };
                    if (previous is ExtensibleElementNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }
                if (_value.Value != null)
                {
                    if (_value.Value is XPathTextNode<T> next && previous is ExtensibleElementNode<T> last)
                    {
                        last.Next = next;
                        next.Previous = last;
                    }
                }
                return first ?? _value.Value;
            });


            _namespaces = new Lazy<INamespaceNode?>(() =>
            {
                var query = (_namespaceSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
                INamespaceNode? first = null;
                INamespaceNode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new ExtensibleNamespaceNode<T>(
                        this,
                        query.Current,
                        _item
                        )
                    {
                        Previous = previous,
                    };
                    if (previous is ExtensibleNamespaceNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                return first;
            });
        }

        public INode? FirstChild => _children.Value;
        public IAttributeNode? FirstAttribute => _attributes.Value;
        public INamespaceNode? FirstNamespace => _namespaces.Value;

        public INode? Next { get; internal set; }
        public INode? Previous { get; internal set; }


        public INode? Parent { get; }
        public XName Name { get; }
        public string? Value => _value.Value?.Value;

        public XPathNodeType NodeType { get; } = XPathNodeType.Element;
    }
}
