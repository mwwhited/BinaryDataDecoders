using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Tests.Json
{
    [TestClass]
    public class JsonTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Test()
        {
            //    var jFile = @"C:\Repos\sample.json";
            //    using var fs = File.Open(jFile, FileMode.Open);
            var fs = @"{""r"":123,""o"":{""f"":""v""}}";
            string jFile = null;
            var json = JsonDocument.Parse(fs);

            var j = new ExtensibleElementNode(
                "root",
                json.RootElement,

                valueSelector: v => v switch
                {
                    JsonElement element => element.ValueKind switch
                    {
                        JsonValueKind.Array => null,
                        JsonValueKind.Object => null,

                        JsonValueKind.String => element.GetString(),
                        _ => element.GetRawText()
                    },

                    JsonProperty property => property.Value.ValueKind switch
                    {
                        JsonValueKind.Array => null,
                        JsonValueKind.Object => null,

                        JsonValueKind.String => property.Value.GetString(),
                        _ => property.Value.GetRawText()
                    },

                    _ => throw new NotSupportedException(),
                },

                 attributeSelector: a => a switch
                 {
                     JsonElement element => new[]
                     {
                        (XName.Get("kind", ""), element.ValueKind.ToString()),
                        //(XName.Get("value", ""), element.ValueKind switch
                        //{
                        //    JsonValueKind.Array => null,
                        //    JsonValueKind.Object => null,

                        //    JsonValueKind.String => element.GetString(),
                        //    _=> element.GetRawText(),
                        //}),
                     }.Where(a => a.Item2 != null).AsEnumerable(),

                     JsonProperty property => null,

                     _ => throw new NotSupportedException(),
                 },

                 childSelector: c => c switch
                 {
                     JsonElement element => element.ValueKind switch
                     {
                         JsonValueKind.Array => element.EnumerateArray().Select(i => (XName.Get("item", ""), (object)i)),
                         JsonValueKind.Object => element.EnumerateObject().Select(i => (XName.Get(i.Name, ""), (object)i.Value)),

                         _ => null
                     },

                     JsonProperty property => new[] { (XName.Get(property.Name, ""), (object)property.Value) }.AsEnumerable(),

                     _ => throw new NotSupportedException()
                 }
                );

            #region v2
            //var j = new XPathItemNode<object>(
            //    "root",
            //    json.RootElement,

            //    i => i switch
            //    {
            //        JsonElement element => element.ValueKind switch
            //        {
            //            JsonValueKind.Object => null,
            //            JsonValueKind.Array => null,
            //            JsonValueKind.Null => null,
            //            JsonValueKind.Undefined => null,

            //            _ => element.GetRawText(),
            //        },

            //        JsonProperty property => property.Value.GetRawText(),

            //        _ => throw new NotSupportedException(),
            //    },

            //     childSelector: c => c switch
            //     {
            //         JsonElement element => element.ValueKind switch
            //         {
            //             JsonValueKind.Array => element.EnumerateArray().Select(i => (XName.Get("item", ""), (object)i)),
            //             JsonValueKind.Object => element.EnumerateObject().Select(i => (XName.Get("item", ""), (object)i)),

            //             _ => null
            //         },

            //         JsonProperty property =>null, // new[] { (XName.Get("value", ""), (object)property) }.AsEnumerable(),

            //         _ => throw new NotSupportedException()
            //     }
            //    );
            #endregion v1

            #region v1
            //var n = new XPathItemNode<JsonElement>(
            //    "root",
            //    json.RootElement,

            //    v => v.ValueKind switch
            //    {
            //        JsonValueKind.Array => null,
            //        JsonValueKind.Object => null,
            //        JsonValueKind.Null => null,
            //        JsonValueKind.Undefined => null,
            //        _ => v.ToString(),
            //    },

            //     childSelector: v => v.ValueKind switch
            //    {
            //        JsonValueKind.Array => v.EnumerateArray().Select(a => ((XName)"item", a)),
            //        JsonValueKind.Object => v.EnumerateObject().Select(a => ((XName)a.Name, a.Value)),

            //        JsonValueKind.Null => null,
            //        JsonValueKind.Undefined => null,



            //        _ => new[] { ((XName)(v.ValueKind.ToString()), v) }
            //    }
            //    );
            #endregion v1

            var oNavigator = new ExtensibleNavigator(j, jFile);
            oNavigator.MoveToRoot();
            this.TestContext.WriteLine(oNavigator.OuterXml);
        }
    }
}
