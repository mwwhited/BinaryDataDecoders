using BinaryDataDecoders.ToolKit.Reflection;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using BinaryDataDecoders.TestUtilities;

namespace BinaryDataDecoders.ToolKit.Tests.Reflection
{
    [TestClass]
    public class ReflectionElementNodeTests
    {
        public TestContext TestContext { get; set; }

        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private ReflectionElementNodeBuilder CreateReflectionElementNode(object testData, bool excludeNamespace = false) =>
            new ReflectionElementNodeBuilder(testData, excludeNamespace);

        [TestMethod, TestCategory(TestCategories.DevLocal)]
        [TestCategory(TestCategories.Unit)]
        public void ReflectionElementNodeTest()
        {
            // Stage
            var testData = new
            {
                Hello = "World!",
                DateTime = DateTime.Now,
                DateTimeOffset = DateTimeOffset.Now,
                TimeOfDay = DateTimeOffset.Now.TimeOfDay,
                Integer = 123,
                Decimal = 123.456m,
                Bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
                Nested = new
                {
                    Other = "Property1",
                },
                Array = new[]
                {
                    "test",
                    "test2"
                },
                ArrayIntegers = new[] { 1, 2, 3, 4, 5, 6 }
            };

            // Mock

            // Test
            var reflectionElementNode = this.CreateReflectionElementNode(testData, true).Build();
            var nav = reflectionElementNode.ToNavigable().CreateNavigator();

            if (nav != null)
                this.TestContext.AddResult(nav);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(nav?.OuterXml));

            // Verify
            this.mockRepository.VerifyAll();
        }
    }
}
