using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            //if (Item.ContainsDirectives)
            //{
            //    //foreach (var t in Item.GetLeadingTrivia())
            //    //    yield return t.ToSyntaxPointer(this);
            //}

            //if (Item.HasStructuredTrivia)
            //{
            //    foreach (var t in Item.GetLeadingTrivia())
            //        yield return t.ToSyntaxPointer(this);
            //}
            foreach (var t in Item.ChildNodesAndTokens())
                yield return t.ToSyntaxPointer(this);
            //if (Item.HasStructuredTrivia)
            //{
            //    foreach (var t in Item.GetTrailingTrivia())
            //        yield return t.ToSyntaxPointer(this);
            //}
        }

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
