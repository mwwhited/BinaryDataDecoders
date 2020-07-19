using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class UInt8ExpressionEvaluator : IExpressionEvaluator<byte>
    {
        public byte Add(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
           (byte)(left.Evaluate(variables) + right.Evaluate(variables));
        public byte Divide(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
           (byte)(left.Evaluate(variables) / right.Evaluate(variables));

        public byte Modulo(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
            (byte)(left.Evaluate(variables) % right.Evaluate(variables));
        public byte Multiple(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
           (byte)(left.Evaluate(variables) * right.Evaluate(variables));
        public byte Negate(ExpressionBase<byte> operand, IDictionary<string, byte> variables) => throw new NotSupportedException(nameof(Negate));
        public byte Power(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
            (byte)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public byte Subtract(ExpressionBase<byte> left, ExpressionBase<byte> right, IDictionary<string, byte> variables) =>
            (byte)(left.Evaluate(variables) - right.Evaluate(variables));

        public byte? TryParse(string input) => byte.TryParse(input, out var ret) ? (byte?)ret : null;
        public byte GetValue(int value) => (byte)value;
        public byte GetValue(double value) => (byte)value;
    }
}
