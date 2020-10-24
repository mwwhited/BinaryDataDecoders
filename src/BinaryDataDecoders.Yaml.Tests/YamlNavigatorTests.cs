using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryDataDecoders.Yaml;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using System.Threading.Tasks;
using System.IO;

namespace BinaryDataDecoders.Yaml.Tests
{
    [TestClass]
    public class YamlNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow("Example.yml")]
        [DataRow("dotnet-core.yml")]
        [DataRow("codeql-analysis.yml")]
        public void ToNavigableTest(string resourceName)
        {
            var nav = new YamlNavigator();
            var stream = this.GetResourceStream(resourceName);
            var xpath = nav.ToNavigable(stream).CreateNavigator();
            this.TestContext.AddResult(xpath, Path.ChangeExtension(resourceName, ".xml"));
        }
    }
}
