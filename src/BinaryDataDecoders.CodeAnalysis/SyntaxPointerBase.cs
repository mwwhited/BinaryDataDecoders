using BinaryDataDecoders.ToolKit.Collections;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using CS = Microsoft.CodeAnalysis.CSharp.CSharpExtensions;
using VB = Microsoft.CodeAnalysis.VisualBasic.VisualBasicExtensions;

namespace BinaryDataDecoders.CodeAnalysis
{
    [DebuggerDisplay("{GetType().Name}::{Name}")]
    internal abstract class SyntaxPointerBase<TItem> : ISyntaxPointer
    {
        public const string CsLang = "C#";
        public const string VbLang = "Visual Basic";

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

        protected virtual IEnumerable<(XName name, object value)> GetAttributes()
        {
            // yield return ("RawType", Item.GetType().AssemblyQualifiedName);
            if (Item is SyntaxNode node)
            {
                yield return ("RawKind", node.RawKind);
                yield return ("Type", nameof(SyntaxNode)[6..]);
            }
            else if (Item is SyntaxToken token)
            {
                yield return ("RawKind", token.RawKind);
                yield return ("Type", nameof(SyntaxToken)[6..]);
            }
            else if (Item is SyntaxNodeOrToken nodeOrToken)
            {
                yield return ("RawKind", nodeOrToken.RawKind);
                yield return ("Type", nameof(SyntaxNodeOrToken)[6..]);
            }
            else if (Item is SyntaxTrivia trivia)
            {
                yield return ("RawKind", trivia.RawKind);
                yield return ("Type", nameof(SyntaxTrivia)[6..]);
            }

            //yield return ("Raw", Item.ToString());
            yield break;
        }
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

        public string NamespaceUri => $"bdd:CodeAnalysis/{this.GetType().Name[6..^7]}";
        public string Name =>
           $@"{Item switch
           {
               SyntaxNode node when node.Language == CsLang => CS.Kind(node),
               SyntaxToken token when token.Language == CsLang => CS.Kind(token),
               SyntaxNodeOrToken nodeOrToken when nodeOrToken.Language == CsLang => CS.Kind(nodeOrToken),
               SyntaxTrivia trivia when trivia.Language == CsLang => CS.Kind(trivia),

               SyntaxNode node when node.Language == VbLang => VB.Kind(node),
               SyntaxToken token when token.Language == VbLang => VB.Kind(token),
               SyntaxNodeOrToken nodeOrToken when nodeOrToken.Language == VbLang => VB.Kind(nodeOrToken),
               SyntaxTrivia trivia when trivia.Language == VbLang => VB.Kind(trivia),

               _ => Item?.GetType().Name ?? "UNKNOWN"
           }}";
        public virtual string Value => ToString();

        public IReversibleEnumerator<ISyntaxPointer> ChildrenEnumerator { get; }
        public IReversibleEnumerator<ISyntaxPointer> AttributesEnumerator { get; }


#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public override string ToString() => Item.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.


        public override bool Equals(object obj) => obj is SyntaxPointerBase<TItem> pointer && Equals(pointer.Item);

        protected virtual bool Equals(TItem obj) =>
            Item switch
            {
                SyntaxToken token when obj is SyntaxToken oToken => token.IsEquivalentTo(oToken),
                SyntaxTrivia trivia when obj is SyntaxTrivia oTrivia => trivia.IsEquivalentTo(oTrivia),
                SyntaxTree tree when obj is SyntaxTree oTree => tree.IsEquivalentTo(oTree),
                SyntaxNode node when obj is SyntaxNode oNode => node.IsEquivalentTo(oNode),
                SyntaxNodeOrToken nodeOrToken when obj is SyntaxNodeOrToken oNodeOrToken => nodeOrToken.IsEquivalentTo(oNodeOrToken),
                _ => false
            };
    }
}
