using Antlr4.Runtime;
using BinaryDataDecoders.ExpressionCalculator.Expressions;
using BinaryDataDecoders.ExpressionCalculator.Visitors;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Parser
{
    public class ExpressionParser<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Parse(string input) =>
            new ExpressionTreeVisitor<T>().Visit(
                new ExpressionTreeParser(
                        new CommonTokenStream(
                            new ExpressionTreeLexer(
                                new AntlrInputStream(input)
                                )
                            )
                        )
                    {
                        ErrorHandler = new BailErrorStrategy(),
                    }.start()
                );
    }
}
