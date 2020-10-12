using Microsoft.CodeAnalysis;
using System.Collections.Generic;
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
            yield return _tokenValue;
        }
        protected override IEnumerable<(XName name, object value)> GetAttributes()
        {
            XNamespace loc = this.NamespaceUri + "#Location";
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
