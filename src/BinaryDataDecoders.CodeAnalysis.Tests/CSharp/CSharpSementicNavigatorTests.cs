using BinaryDataDecoders.CodeAnalysis.CSharp;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp;

[TestClass]
public class CSharpSementicNavigatorTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    //[TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(SemanticModelNavigatorFactory), Member = nameof(SemanticModelNavigatorFactory.AsNode))]
    public void TestXPath()
    {
        var filePath = @"SampleClasses.cs";
        using var stream = this.GetResourceStream(filePath);
        var csharp = new CSharpSementicNavigator();
        var navigator = csharp.ToNavigable(stream).CreateNavigator();

        this.TestContext.AddResult(navigator);

        var query = navigator.Compile(@"//cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
        var manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");
        manager.AddNamespace("cs-s", "bdd:CodeAnalysis/Symbol");
        query.SetContext(manager);
        var selected = navigator.Select(query);
        this.TestContext.AddResult(selected, "QueryTypes.xml");
        Assert.AreEqual(13, selected.Count);

        var rootQuery = navigator.Compile("/");
        rootQuery.SetContext(manager);
        var root = navigator.Select(rootQuery);
        this.TestContext.AddResult(root, "QueryRoot.xml");
        Assert.AreEqual(1, root.Count);

        var querySymbols = navigator.Compile(@"//cs-s:*");
        querySymbols.SetContext(manager);
        var selectedSymbols = navigator.Select(querySymbols);
        this.TestContext.AddResult(selectedSymbols, "QuerySymbols.xml");


    }
}
