using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.XPath;

namespace BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser
{
    [TestClass]
    public class JsonPathFactoryTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        //[DataRow("$.options.quantity", ":/options/quantity")]
        //[DataRow("$.*.quantity", ":/*/quantity")]
        //[DataRow("$..quantity", ":////quantity")]
        //[DataRow("$.obj.*.quantity", ":/obj/*/quantity")]
        //[DataRow("$.options[0].quantity", ":/options[0]/quantity")]
        //[DataRow("$.store.book[*].author", ":/store/book[*]/author")]
        //[DataRow("$..author", ":////author")]
        //[DataRow("$.store.*", ":/store/*")]
        //[DataRow("$..book[2]", ":////book[2]")]
        //[DataRow("$..book[-2]", ":////book[-2]")]
        //[DataRow("$..*", ":////*")]
        //[DataRow("$..book[-2", typeof(ParseCanceledException))]
        [DataRow("$.options[?(@.code=='AB1')].quantity", "")]
        //[DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", "")]
        //[DataRow("$.store..price", "")]
        //[DataRow("$..book[0,1]", ":////book[0,1]")]
        //[DataRow("$..book[:2]", "")]
        //[DataRow("$..book[1:2]", "")]
        //[DataRow("$..book[-2:]", "")]
        //[DataRow("$..book[2:]", "")]
        //[DataRow("$..book[?(@.isbn)]", "")]
        //[DataRow("$.store.book[?(@.price < 10)]", "")]
        //[DataRow("$..book[?(@.price <= $['expensive'])]", "")]
        //[DataRow("$..book[?(@.author =~ /.*REES/i)]", "")]
        //[DataRow("$..book.length()", "")]
        public void ParserTest(string query, object expected)
        {
            try
            {
                var result = JsonPathFactory.Parse(query);
                this.TestContext.WriteLine($"\"{query}\" == \"{result}\"");

                Assert.AreEqual(expected, result.ToString());
            }
            catch (Exception ex)
            {
                if (expected is Type type && type.IsInstanceOfType(ex))
                {
                    //Expected!
                    Assert.IsTrue(true);
                }
                else
                {
                    throw;
                }
            }
        }

        //[DataRow("$.obj..quantity")]
        // [DataRow("$..book[-2",<!- this should be an exception
    }
}
//https://goessner.net/articles/JsonPath/