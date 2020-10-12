using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxTriviaPointer : SyntaxPointerBase<SyntaxTrivia>
    {
        private readonly ISyntaxPointer _triviaValue;

        public SyntaxTriviaPointer(SyntaxTrivia trivia, ISyntaxPointer owner) : base(trivia, owner)
        {
            _triviaValue = this.Value.ToSyntaxValuePointer(this);
        }

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            yield return _triviaValue;
        }
    }
}
