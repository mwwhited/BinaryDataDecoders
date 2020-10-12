using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxNodePointer : SyntaxPointerBase<SyntaxNode>
    {
        public SyntaxNodePointer(SyntaxNode node, ISyntaxPointer owner) : base(node, owner)
        {
        }

        protected override IEnumerable<ISyntaxPointer> GetChildren() =>
            Item.GetLeadingTrivia().Select(i => i.ToSyntaxPointer(this))
            .Concat(
            Item.ChildNodesAndTokens().Select(i => i.ToSyntaxPointer(this))
            )
            .Concat(
            Item.GetTrailingTrivia().Select(i => i.ToSyntaxPointer(this))
            )
            ;

        protected override IEnumerable<(XName name, object value)> GetAttributes()
        {
            if (Owner == null || Owner is SyntaxRootPointer)
            {
                yield return (nameof(Item.Language), Item.Language);
            }
            foreach (var common in base.GetAttributes())
            {
                yield return common;
            }
        }
    }
}
