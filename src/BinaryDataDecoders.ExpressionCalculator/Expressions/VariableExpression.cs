using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions;

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
public sealed class VariableExpression<T> : ExpressionBase<T>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    where T : struct, IComparable<T>, IEquatable<T>
{
    public string Name { get; }

    public VariableExpression(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Variable name not assigned");
        Name = name;
    }

    public override ExpressionBase<T> Clone() => new VariableExpression<T>(Name);
    public override T Evaluate(IDictionary<string, T> variables) => variables[Name];
    public override string ToString() => Name;

    public override bool Equals(object? obj) =>
        this == obj ||
        obj is VariableExpression<T> vari && Name.Equals(vari.Name) ||
        obj is string && Name.Equals(obj);
}
