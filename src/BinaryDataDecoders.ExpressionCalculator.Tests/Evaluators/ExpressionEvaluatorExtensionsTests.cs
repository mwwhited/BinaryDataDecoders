using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators
{
    [TestClass]
    public class ExpressionEvaluatorExtensionsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Sequence_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = string.Join(";", sequence);
            Assert.AreEqual("5;4;3;2;1", result);
        }

        [TestMethod]
        public void Product_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(4, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = evaluator.Product(sequence);
            Assert.AreEqual(24m, result);
        }

        [TestMethod]
        public void Sum_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = evaluator.Sum(sequence);
            Assert.AreEqual(15m, result);
        }

        [TestMethod]
        public void Factorial_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Factorial(5);
        }
    }
}
