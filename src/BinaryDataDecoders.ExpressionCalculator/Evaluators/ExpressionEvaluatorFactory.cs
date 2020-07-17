using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
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

            throw new NotSupportedException($"Type \"{typeof(T)}\" is not supported");
    }
}
