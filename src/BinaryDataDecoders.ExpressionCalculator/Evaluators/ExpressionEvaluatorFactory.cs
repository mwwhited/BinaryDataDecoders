using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public static class ExpressionEvaluatorFactory
{
    public static IExpressionEvaluator<T> Create<T>()
        where T : struct, IComparable<T>, IEquatable<T> =>
            typeof(T) == typeof(decimal) ? (IExpressionEvaluator<T>)(object)new DecimalExpressionEvaluator() :

            typeof(T) == typeof(double) ? (IExpressionEvaluator<T>)(object)new DoubleExpressionEvaluator() :
            typeof(T) == typeof(float) ? (IExpressionEvaluator<T>)(object)new FloatExpressionEvaluator() :

            typeof(T) == typeof(int) ? (IExpressionEvaluator<T>)(object)new Int32ExpressionEvaluator() :
            typeof(T) == typeof(short) ? (IExpressionEvaluator<T>)(object)new Int16ExpressionEvaluator() :
            typeof(T) == typeof(long) ? (IExpressionEvaluator<T>)(object)new Int64ExpressionEvaluator() :
            typeof(T) == typeof(sbyte) ? (IExpressionEvaluator<T>)(object)new Int8ExpressionEvaluator() :

            typeof(T) == typeof(byte) ? (IExpressionEvaluator<T>)(object)new UInt8ExpressionEvaluator() :
            typeof(T) == typeof(uint) ? (IExpressionEvaluator<T>)(object)new UInt32ExpressionEvaluator() :
            typeof(T) == typeof(ushort) ? (IExpressionEvaluator<T>)(object)new UInt16ExpressionEvaluator() :
            typeof(T) == typeof(ulong) ? (IExpressionEvaluator<T>)(object)new UInt64ExpressionEvaluator() :

        throw new NotSupportedException($"Type \"{typeof(T)}\" is not supported");
}
