using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public sealed class VariableExpression<T> : ExpressionBase<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public string Name { get; }

        public VariableExpression(string name) => Name = name;

        public override ExpressionBase<T> Clone() => new VariableExpression<T>(Name);
        public override T Evaluate(IDictionary<string, T> variables) => variables[Name];
        public override string ToString() => Name;

        public override bool Equals(object obj) =>
            this == obj ||
            obj is VariableExpression<T> vari && Name.Equals(vari.Name);
    }
}
