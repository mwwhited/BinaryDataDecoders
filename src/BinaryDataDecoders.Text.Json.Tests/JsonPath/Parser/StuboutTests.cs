using Antlr4.Runtime;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.XPath;

namespace BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser
{
    [TestClass]
    public class StuboutTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow("$.options[0].quantity")]
        [DataRow("$.options[?(@.code=='AB1')].quantity")]
        [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity")]
        public void ParserTest(string query)
        {
            //var parser = new JsonPathParser(
            //    new CommonTokenStream(
            //        new JsonPathLexer(
            //            new AntlrInputStream(query)
            //            )
            //        )
            //    );

            var result = JsonPathFactory.Parse(query);
            this.TestContext.AddResult(result);
        }
    }
}
