using BinaryDataDecoders.ToolKit.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal abstract class SyntaxPointerBase<TItem> : ISyntaxPointer
    {
        protected SyntaxPointerBase(TItem item, ISyntaxPointer? owner)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Owner = owner;

            ChildrenEnumerator = this.Children.GetReversibleEnumerator();
            AttributesEnumerator = this.Attributes.GetReversibleEnumerator();
        }

        public ISyntaxPointer? Owner { get; }
        public TItem Item { get; }

        protected virtual IEnumerable<ISyntaxPointer> GetChildren() { yield break; }
        public IEnumerable<ISyntaxPointer> Children => GetChildren();

        protected virtual IEnumerable<(XName name, object value)> GetAttributes() { yield break; }
        public IEnumerable<ISyntaxPointer> Attributes
        {
            get
            {
                foreach (var attribute in GetAttributes())
                    yield return attribute.ToSyntaxPointer(this);
            }
        }

        public bool HasChildren => Children.Any();
        public bool HasAttributes => Attributes.Any();

        public string NamespaceUri => $"bdd://CodeAnalysis/v1/{this.GetType().Name}";
        public string Name => Item?.GetType().Name ?? "UNKNOWN";
        public virtual string Value => ToString();

        public IReversibleEnumerator<ISyntaxPointer> ChildrenEnumerator { get; }
        public IReversibleEnumerator<ISyntaxPointer> AttributesEnumerator { get; }


#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public override string ToString() => Item.ToString();

#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
