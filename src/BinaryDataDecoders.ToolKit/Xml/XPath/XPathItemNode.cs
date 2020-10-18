using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("E:>{Name}")]
    public class XPathItemNode<T> : IXPathItemNode
    {
        private readonly T _item;

        private readonly Func<T, string>? _valueSelector;
        private readonly Func<T, IEnumerable<(XName name, string value)>>? _attributeSelector;
        private readonly Func<T, IEnumerable<(XName name, T child)>>? _childSelector;
        private readonly Func<T, IEnumerable<XName>>? _namespaceSelector;

        private readonly Lazy<string?> _value;
        private readonly Lazy<IXPathItemNode?> _children;
        private readonly Lazy<IXPathAttributeNode?> _attributes;
        private readonly Lazy<IXPathNamespaceNode?> _namespaces;

        public XPathItemNode(
            XName name,
            T item,
            Func<T, string>? valueSelector = null,
            Func<T, IEnumerable<(XName name, string value)>>? attributeSelector = null,
            Func<T, IEnumerable<(XName name, T child)>>? childSelector = null,
            Func<T, IEnumerable<XName>>? namespaceSelector = null
            )
            : this(null, name, item, valueSelector, attributeSelector, childSelector, namespaceSelector)
        {
            Parent = new XPathRootNode<T>(this);
        }

        private XPathItemNode(
            IXPathNode? parent,
             XName name,
             T item,
             Func<T, string>? valueSelector,
             Func<T, IEnumerable<(XName name, string value)>>? attributeSelector,
             Func<T, IEnumerable<(XName name, T child)>>? childSelector,
             Func<T, IEnumerable<XName>>? namespaceSelector
             )
        {
            Parent = parent ?? new XPathRootNode<T>(this);
            Name = name;
            _item = item;

            _valueSelector = valueSelector;
            _attributeSelector = attributeSelector;
            _childSelector = childSelector;
            _namespaceSelector = namespaceSelector;

            _value = new Lazy<string?>(() => _valueSelector?.Invoke(_item));

            _attributes = new Lazy<IXPathAttributeNode?>(() =>
            {
                var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string value)>()).GetEnumerator();
                IXPathAttributeNode? first = null;
                IXPathAttributeNode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new XPathAttributeNode<T>(
                        this,
                        query.Current.name,
                        _item,
                        query.Current.value
                        )
                    {
                        Previous = previous,
                    };
                    if (previous is XPathAttributeNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                return first;
            });

            _children = new Lazy<IXPathItemNode?>(() =>
            {
                var query = (_childSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, T child)>()).GetEnumerator();
                IXPathItemNode? first = null;
                IXPathItemNode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new XPathItemNode<T>(
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
                    if (previous is XPathItemNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                return first;
            });


            _namespaces = new Lazy<IXPathNamespaceNode?>(() =>
            {
                var query = (_namespaceSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
                IXPathNamespaceNode? first = null;
                IXPathNamespaceNode? previous = null;

                while (query.MoveNext())
                {
                    var newItem = new XPathNamespaceNode<T>(
                        this,
                        query.Current,
                        _item
                        )
                    {
                        Previous = previous,
                    };
                    if (previous is XPathNamespaceNode<T> node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                return first;
            });

        }

        public IXPathItemNode? FirstChild => _children.Value;
        public IXPathAttributeNode? FirstAttribute => _attributes.Value;
        public IXPathNamespaceNode? FirstNamespace => _namespaces.Value;

        public IXPathItemNode? Next { get; internal set; }
        public IXPathItemNode? Previous { get; internal set; }


        public IXPathNode? Parent { get; }
        public XName Name { get; }
        public string? Value => _value.Value;

        public XPathNodeType NodeType { get; } = XPathNodeType.Element;
        IXPathNode? IXPathNode.Next => Next;
        IXPathNode? IXPathNode.Previous => Previous;
    }
}
