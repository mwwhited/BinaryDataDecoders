using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp
{
    [TestClass]
    public class CSharpNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(SyntaxTreeNavigatorFactory), Member = nameof(SyntaxTreeNavigatorFactory.AsNode))]
        public void TestXPath()
        {
            var filePath = @"SampleClasses.cs";
            using var stream = this.GetResourceStream(filePath);
            var content = SourceText.From(stream);
            var syntax = CSharpSyntaxTree.ParseText(content);
            var node = syntax.AsNode(filePath);
            var nav = new ExtensibleNavigator(node);
            var navigator = nav.Clone();
            // this.TestContext.WriteLine(navigator.OuterXml);
            this.TestContext.AddResult(node);


            var query = navigator.Compile(@"//cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
            var manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");
            query.SetContext(manager);
            var selected = navigator.Select(query);

            Assert.AreEqual(13, selected.Count);

            var rootQuery = navigator.Compile("/");
            rootQuery.SetContext(manager);
            var root = navigator.Select(rootQuery);
            Assert.AreEqual(1, root.Count);

        }
    }
}
