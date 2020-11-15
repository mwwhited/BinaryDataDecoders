using BinaryDataDecoders.ToolKit.Xml.Linq;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.Linq
{
    [TestClass]
    public class ObjectXmlExtensionsTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void AsXElementTest()
        {
            var testData = new
            {
                hello = "world",
                nested = new
                {
                    another = 1,
                    other = DateTimeOffset.Now,
                    DeeperStill = new[]
                    {
                        new {obj1=1 },
                        new {obj1=2 },
                        new {obj1=3 },
                        new {obj1=4 },
                        new {obj1=5 },
                    },
                },
            };

            var result = ObjectXmlExtensions.AsXElement(testData);

            this.TestContext.AddResult(result);
        }
    }
}
