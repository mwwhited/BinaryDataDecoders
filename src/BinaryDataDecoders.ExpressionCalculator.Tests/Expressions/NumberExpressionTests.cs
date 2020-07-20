using BinaryDataDecoders.ExpressionCalculator.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions
{
    [TestClass]
    public class NumberExpressionTests
    {
        [TestMethod, TestCategory("Unit")]
        public void Equals_SameReference_Test()
        {
            var exp = new NumberExpression<double>(1.1);
            Assert.IsTrue(exp.Equals(exp));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_SameValue_Test()
        {
            var num1 = new NumberExpression<double>(1.1);
            var num2 = new NumberExpression<double>(1.1);
            Assert.IsTrue(num1.Equals(num2));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_DifferentValue_Test()
        {
            var num1 = new NumberExpression<double>(1.1);
            var num2 = new NumberExpression<double>(1.2);
            Assert.IsFalse(num1.Equals(num2));
        }

        [TestMethod, TestCategory("Unit")]
        public void Equals_SameNumber_Test()
        {
            var num1 = new NumberExpression<double>(1.1);
            var num2 = 1.1;
            Assert.IsTrue(num1.Equals(num2));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_DifferentNumber_Test()
        {
            var num1 = new NumberExpression<double>(1.1);
            var num2 = 1.2;
            Assert.IsFalse(num1.Equals(num2));
        }
    }
}
