using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BinaryDataDecoders.ToolKit.Tests.Json
{
    [TestClass]
    public class JsonTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Test()
        {
            var json = JsonDocument.Parse(@"{""hello"":""world""}");
        }
    }
}
