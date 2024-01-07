﻿using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using System;
using System.Collections.Generic;
using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions;

public sealed class UnaryOperatorExpression<T>(
    UnaryOperators @operator,
    ExpressionBase<T> operand
        ) : ExpressionBase<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

    public UnaryOperators Operator { get; } = @operator;
    public ExpressionBase<T> Operand { get; } = operand;

    public override ExpressionBase<T> Clone() => new UnaryOperatorExpression<T>(Operator, Operand.Clone());

    public override T Evaluate(IDictionary<string, T> variables) =>
        Operator switch
        {
            Negate => _evaluator.Negate(Operand.Evaluate(variables)),
            Factorial => _evaluator.Factorial(Operand.Evaluate(variables)),

            _ => throw new NotSupportedException($"Operator {Operator} not supported")
        };

    private string OperandString =>
            Operand switch
            {
                BinaryOperatorExpression<T> _ => $"({Operand})",
                _ => $"{Operand}",
            };

    private string OperatorString => Operator.AsString();

    public override string ToString() =>
        Operator.IsRight() ?
            $"{OperandString}{OperatorString}" :
            $"{OperatorString}{OperandString}";
}
