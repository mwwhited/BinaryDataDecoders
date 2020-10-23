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
            Func<object, string?>? valueSelector = null,
            Func<object, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
            Func<object, IEnumerable<(XName name, object child)>?>? childSelector = null,
            Func<object, IEnumerable<XName>?>? namespacesSelector = null,
            Predicate<object>? preserveWhitespace = null
            )
            : base(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector)
        {
        }
    }
    [DebuggerDisplay("E:>{Name}")]
    public class ExtensibleElementNode<T> : IElementNode, ISimpleNode
    {
        private readonly T _item;

        private readonly Func<T, string?>? _valueSelector;
        private readonly Predicate<T>? _preserveWhitespace;
        private readonly Func<T, IEnumerable<(XName name, string? value)>?>? _attributeSelector;
        private readonly Func<T, IEnumerable<(XName name, T child)>?>? _childSelector;
        private readonly Func<T, IEnumerable<XName>?>? _namespacesSelector;

        private readonly Lazy<INode?> _value;
        private readonly Lazy<INode?> _children;
        private readonly Lazy<IAttributeNode?> _attributes;
        private readonly Lazy<INamespaceNode?> _namespaces;

        public ExtensibleElementNode(
            XName name,
            T item,
            Func<T, string?>? valueSelector = null,
            Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector = null,
            Func<T, IEnumerable<(XName name, T child)>?>? childSelector = null,
            Func<T, IEnumerable<XName>?>? namespacesSelector = null,
            Predicate<T>? preserveWhitespace = null
            )
            : this(null, name, item, valueSelector, attributeSelector, childSelector, namespacesSelector, preserveWhitespace)
        {
        }

        protected ExtensibleElementNode(
            INode? parent,
            XName name,
            T item,
            Func<T, string?>? valueSelector,
            Func<T, IEnumerable<(XName name, string? value)>?>? attributeSelector,
            Func<T, IEnumerable<(XName name, T child)>?>? childSelector,
            Func<T, IEnumerable<XName>?>? namespacesSelector,
            Predicate<T>? preserveWhitespace = null
            )
        {
            Parent = parent ?? new ExtensibleRootNode<T>(this);
            Name = name;
            _item = item;

            _valueSelector = valueSelector;
            _attributeSelector = attributeSelector;
            _childSelector = childSelector;
            _namespacesSelector = namespacesSelector;
            _preserveWhitespace = preserveWhitespace;

            _value = new Lazy<INode?>(() =>
                _valueSelector?.Invoke(_item) switch
                {
                    null => (INode?)null,
                    string value => string.IsNullOrWhiteSpace(value) switch
                    {
                        true => new ExtensibleWhitespaceNode<T>(this, Name, _item, value),
                        false => (_preserveWhitespace?.Invoke(_item) ?? false) switch
                        {
                            true => new ExtensibleSignificantWhitespaceNode<T>(this, Name, _item, value),
                            false => new ExtensibleTextNode<T>(this, Name, _item, value)
                        }
                    },
                });

            _attributes = new Lazy<IAttributeNode?>(() =>
            {
                var query = (_attributeSelector?.Invoke(_item) ?? Enumerable.Empty<(XName name, string? value)>()).GetEnumerator();
                IAttributeNode? first = null;
                IAttributeNode? previous = null;

                while (query.MoveNext())
                {
                    if (query.Current.value == null) continue;

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
                    if (query.Current.child == null) continue;
                    var newItem = new ExtensibleElementNode<T>(
                        this,
                        query.Current.name,
                        query.Current.child,
                        _valueSelector,
                        _attributeSelector,
                        _childSelector,
                        _namespacesSelector
                        )
                    {
                        Previous = previous,
                    };
                    // Console.WriteLine($"\t\t==={newItem.Name} +++ {newItem.NodeType}");
                    if (previous is ISimpleNode node) node.Next = newItem;
                    if (first == null) first = newItem;
                    previous = newItem;
                }

                if (_value.Value is ISimpleNode next && previous is ISimpleNode last)
                {
                    last.Next = next;
                    next.Previous = last;
                }

                return first ?? _value.Value;
            });


            _namespaces = new Lazy<INamespaceNode?>(() =>
            {
                var query = (_namespacesSelector?.Invoke(_item) ?? Enumerable.Empty<XName>()).GetEnumerator();
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

        public INode? Next { get; private set; }
        public INode? Previous { get; private set; }

        public INode? Parent { get; }
        public XName Name { get; }
        public string? Value => _value.Value?.Value;

        public XPathNodeType NodeType { get; } = XPathNodeType.Element;

        INode? ISimpleNode.Next { set => Next = value; }
        INode? ISimpleNode.Previous { set => Previous = value; }
    }
}
