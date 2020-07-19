﻿using BinaryDataDecoders.ExpressionCalculator.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions
{
    [TestClass]
    public class VariableExpressionTests
    {
        [TestMethod, TestCategory("Unit")]
        public void Equals_SameReference_Tests()
        {
            var exp = new VariableExpression<double>("Test");
            Assert.IsTrue(exp.Equals(exp));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_SameValue_Tests()
        {
            var var1 = new VariableExpression<double>("Test1");
            var var2 = new VariableExpression<double>("Test1");
            Assert.IsTrue(var1.Equals(var2));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_DifferentValue_Tests()
        {
            var var1 = new VariableExpression<double>("Test1");
            var var2 = new VariableExpression<double>("Test2");
            Assert.IsFalse(var1.Equals(var2));
        }

        [TestMethod, TestCategory("Unit")]
        public void Equals_SameString_Tests()
        {
            var var1 = new VariableExpression<double>("Test1");
            var var2 = "Test1";
            Assert.IsTrue(var1.Equals(var2));
        }
        [TestMethod, TestCategory("Unit")]
        public void Equals_DifferentString_Tests()
        {
            var var1 = new VariableExpression<double>("Test1");
            var var2 = "Test2";
            Assert.IsFalse(var1.Equals(var2));
        }
    }
}
