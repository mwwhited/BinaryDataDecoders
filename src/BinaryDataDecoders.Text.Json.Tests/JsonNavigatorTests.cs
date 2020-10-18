using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace BinaryDataDecoders.ToolKit.Tests.Json
{
    [TestClass]
    public class JsonNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(JsonNavigatorFactory), Member = nameof(JsonNavigatorFactory.ToNavigable))]
        public void JsonNavigatorTest()
        {
            var fs = @"{""r"":123,""o"":{""f"":""v""}}";
            var json = JsonDocument.Parse(fs);

            var oNavigator = json.ToNavigable().CreateNavigator();
            oNavigator.MoveToRoot();
            this.TestContext.WriteLine(oNavigator.OuterXml);

            var rootName = oNavigator.Select("/");
            Assert.IsTrue(rootName.MoveNext());
            Assert.AreEqual("Object", rootName.Current.Name);

            var r = oNavigator.Select("/Object/r");
            Assert.IsTrue(r.MoveNext());
            Assert.AreEqual(123, r.Current.ValueAsInt);

            var f = oNavigator.Select("/Object/o/f");
            Assert.IsTrue(f.MoveNext());
            Assert.AreEqual("v", f.Current.Value);

            var fa = oNavigator.Select("/Object/o/f/@kind");
            Assert.IsTrue(fa.MoveNext());
            Assert.AreEqual("String", fa.Current.Value);
            /*
            <Object kind="Object">
              <r kind="Number">123</r>
              <o kind="Object">
                <f kind="String">v</f>
              </o>
            </Object>
            */
        }
    }
}
