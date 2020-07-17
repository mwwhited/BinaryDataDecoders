using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public static class OperatorExtensions
    {
        public static string AsString(this UnaryOperators @operator) =>
            @operator switch
            {
                Negate => "-",

                _ => throw new NotSupportedException($"Operator {@operator} not supported")
            };

        public static UnaryOperators AsUnaryOperator(this string input) =>
            input switch
            {
                "-" => Negate,

                _ => UnaryOperators.Unknown
            };

        public static string AsString(this BinaryOperators @operator) =>
            @operator switch
            {
                Power => "^",

                Multiply => "*",
                Divide => "/",
                Modulo =>"%",

                Add => "+",
                Subtract => "-",

                _ => $"?{@operator}?"
            };

        public static BinaryOperators AsBinaryOperators(this string input) =>
            input switch
            {
                "^" => Power,

                "*" => Multiply,
                "/" => Divide,
                "%" => Modulo,

                "+" => Add,
                "-" => Subtract,

                _ => BinaryOperators.Unknown
            };

        public static int GetPriority(this BinaryOperators @operator) =>
            @operator switch
            {
                Power => 3,

                Multiply => 2,
                Divide => 2,
                Modulo => 2,

                Add => 1,
                Subtract => 1,

                _ => int.MaxValue,
            };
    }
}
