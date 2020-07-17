using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Visitors
{
    public class ExpressionTreeVisitor<T> : ExpressionTreeBaseVisitor<ExpressionBase<T>>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

        public override ExpressionBase<T> VisitStart([NotNull] ExpressionTreeParser.StartContext context) =>
            Visit(context.expression());

        public override ExpressionBase<T> VisitExpression([NotNull] ExpressionTreeParser.ExpressionContext context)
        {
            var op = context.@operator?.Text.AsBinaryOperators();
            if (op.HasValue && op.Value != BinaryOperators.Unknown)
            {
                return new BinaryOperatorExpression<T>(
                    Visit(context.left),
                    op.Value,
                    Visit(context.right)
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

        public override ExpressionBase<T> VisitUnaryOperatorExpression([NotNull] ExpressionTreeParser.UnaryOperatorExpressionContext context) =>
            new UnaryOperatorExpression<T>(
                context.@operator.Text.AsUnaryOperator(),
                Visit(context.value()) ?? Visit(context.innerExpression())
                );
    }
}