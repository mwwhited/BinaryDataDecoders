using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Visitors
{
    public class ExpressionTreeVisitor<T> : ExpressionTreeBaseVisitor<ExpressionBase<T>>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

        public override ExpressionBase<T> VisitStart([NotNull] ExpressionTreeParser.StartContext context)
        {
            var entryPoint = Visit(context.expression()) ??
                throw new NotSupportedException($"No expression parsed: \"{context.GetText()}\"");
            EnsureChildCount(context, expected: "Expected <EOF>");
            return entryPoint;
        }

        private TParserRuleContext EnsureChildCount<TParserRuleContext>(TParserRuleContext context, string? expected = null, int childCount = 2)
            where TParserRuleContext : ParserRuleContext
        {
            if (context.children.Count != childCount)
            {
                var extraChildren = context.children.Skip(1).Take(context.children.Count - childCount);
                var extras = string.Join(";", extraChildren.Select(c => c.GetText()));

                if (string.IsNullOrWhiteSpace(extras))
                {
                    throw new NotSupportedException($"Missing Expression");
                }
                else
                {
                    throw new NotSupportedException(string.Join(", ", new[] { expected, $"Found: {extras}" }.Where(s => !string.IsNullOrWhiteSpace(s))));
                }
            }
            return context;
        }

        public override ExpressionBase<T> VisitErrorNode(IErrorNode node) =>
            throw new NotSupportedException(node.ToString());

        public override ExpressionBase<T> VisitExpression([NotNull] ExpressionTreeParser.ExpressionContext context)
        {
            var op = context.@operator?.Text.AsBinaryOperators();
            if (op.HasValue && op.Value != BinaryOperators.Unknown)
            {
                return new BinaryOperatorExpression<T>(
                    Visit(context.left) ?? throw new NotSupportedException($"Missing Left Expression: {context.GetText()}"),
                    op.Value,
                    Visit(context.right) ?? throw new NotSupportedException($"Missing Right Expression: {context.GetText()}")
                    );
            }

            return base.VisitExpression(context);
        }

        public override ExpressionBase<T> VisitInnerExpression([NotNull] ExpressionTreeParser.InnerExpressionContext context) =>
            new InnerExpression<T>(Visit(context.inner));


        public override ExpressionBase<T> VisitValue([NotNull] ExpressionTreeParser.ValueContext context) =>
            VisitNumber(context.NUMBER()) ??
            VisitVariable(context.VARIABLE()) ??
                throw new NotSupportedException($"Unable to parse \"{context.GetText()}\"")
            ;

        private ExpressionBase<T>? VisitVariable(ITerminalNode node) =>
            node != null ? new VariableExpression<T>(node.GetText()) : null;

        private ExpressionBase<T>? VisitNumber(ITerminalNode node) =>
            node != null ? new NumberExpression<T>(
                _evaluator.TryParse(node.GetText()) ??
                throw new NotSupportedException($"Unable to parse \"{node.GetText()}\" to type \"{typeof(T)}\"")
                ) : null;

        public override ExpressionBase<T> VisitUnaryOperatorLeftExpression([NotNull] ExpressionTreeParser.UnaryOperatorLeftExpressionContext context)
        {
            var result = new UnaryOperatorExpression<T>(
                context.@operator.Text.AsUnaryOperator(),
                ChainVisit(context.value(), context.innerExpression(), context.unaryOperatorLeftExpression())
                );
            EnsureChildCount(context, expected: $"Expected {nameof(context.value)}|{nameof(context.innerExpression)}|{nameof(context.unaryOperatorLeftExpression)}");
            return result;
        }
        public override ExpressionBase<T> VisitUnaryOperatorRightExpression([NotNull] ExpressionTreeParser.UnaryOperatorRightExpressionContext context)
        {
            var result = new UnaryOperatorExpression<T>(
                   context.@operator.Text.AsUnaryOperator(),
                   ChainVisit(context.value(), context.innerExpression(), context.unaryOperatorRightExpression())
                   );
            EnsureChildCount(context, expected: $"Expected {nameof(context.value)}|{nameof(context.innerExpression)}|{nameof(context.unaryOperatorRightExpression)}");
            return result;
        }

        private ExpressionBase<T> ChainVisit(params IParseTree[] nodes) =>
            Visit(nodes.FirstOrDefault(n => n != null) ?? throw new NotSupportedException($"No non-null node provided"));
    }
}