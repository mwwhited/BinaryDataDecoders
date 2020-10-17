using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxTriviaPointer : SyntaxPointerBase<SyntaxTrivia>
    {
        private readonly ISyntaxPointer _triviaValue;

        public SyntaxTriviaPointer(SyntaxTrivia trivia, ISyntaxPointer owner) : base(trivia, owner)
        {
            _triviaValue = new SyntaxPreserveWhitespacePointer<SyntaxTrivia>(trivia, this);
        }

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            var node = Item.GetStructure();
            if (node != null)
            {
                yield return node.ToSyntaxPointer(this);
            }
            else
            {
                yield return _triviaValue;
            }
        }

        protected override IEnumerable<(XName name, object value)> GetAttributes()
        {
            yield return ("Value", Item.ToString());

            foreach (var a in base.GetAttributes())
                yield return a;
        }
    }
}
