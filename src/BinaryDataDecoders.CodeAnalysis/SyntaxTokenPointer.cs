using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxTokenPointer : SyntaxPointerBase<SyntaxToken>
    {
        private readonly ISyntaxPointer _tokenValue;

        public SyntaxTokenPointer(SyntaxToken token, ISyntaxPointer owner) : base(token, owner)
        {
            _tokenValue = this.Value.ToSyntaxValuePointer(this);
        }

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            if (Item.HasStructuredTrivia)
            {
                foreach (var t in Item.LeadingTrivia)
                    yield return t.ToSyntaxPointer(this);
            }

            yield return _tokenValue;

            var comments = Item.GetAllTrivia().Where(i => i.Kind().ToString().Contains("Comment"));
            foreach (var t in comments)
            {
                Debug.WriteLine(t);
                yield return new SyntaxCommentPointer<SyntaxTrivia>(t, this);
            }

            if (Item.HasStructuredTrivia)
            {
                foreach (var t in Item.TrailingTrivia)
                    yield return t.ToSyntaxPointer(this);
            }
        }
        protected override IEnumerable<(XName name, object value)> GetAttributes()
        {
            XNamespace loc = this.NamespaceUri + "?Location";
            var location = Item.GetLocation();
            yield return (loc + "Kind", location.Kind);
            if (location.IsInSource)
            {
                yield return (loc + "Start", location.SourceSpan.Start);
                yield return (loc + "End", location.SourceSpan.End);
            }
        }
    }
}
