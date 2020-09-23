using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators
{
    [TestClass]
    public class ExpressionEvaluatorExtensionsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Sequence_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = string.Join(";", sequence);
            Assert.AreEqual("5;4;3;2;1", result);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Product_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(4, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = evaluator.Product(sequence);
            Assert.AreEqual(24m, result);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Sum_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
            var result = evaluator.Sum(sequence);
            Assert.AreEqual(15m, result);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Factorial_Test()
        {
            var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
            var result = evaluator.Factorial(5);
            Assert.AreEqual(120m, result);
        }
    }
}
