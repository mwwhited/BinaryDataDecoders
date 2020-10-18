using BinaryDataDecoders.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp
{
    [TestClass]
    public class CSharpNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestXPath()
        {
            var targetFile = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.Tests\CSharp\SampleClasses.cs";
            var nav = new CSharpNavigator().ToNavigable(targetFile);
            var real = nav.CreateNavigator();
            /*
             * 
	xmlns:cs-n="bdd:CodeAnalysis/Node"
	xmlns:cs-t="bdd:CodeAnalysis/Token"
	xmlns:cs-r="bdd:CodeAnalysis/Trivia"
            */

            var navigator = nav.CreateNavigator();
            var query = navigator.Compile(@"/cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
            var manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");
            query.SetContext(manager);
            var selected = navigator.Select(query);

            while (selected.MoveNext())
            {
                this.TestContext.WriteLine(new string('-', 15));
                this.TestContext.WriteLine(selected.Current.Name);
                this.TestContext.WriteLine(selected.Current.LocalName);
                this.TestContext.WriteLine(selected.Current.NamespaceURI);
                this.TestContext.WriteLine(selected.Current.Value);
            }
            //https://docs.microsoft.com/en-us/dotnet/standard/data/xml/xpath-queries-and-namespaces
        }

        //[TestMethod]
        //public void XPathItemNodeTest()
        //{
        //    var targetFile = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.Tests\CSharp\SampleClasses.cs";
        //    var nav = new CSharpNavigator().Pointer(targetFile);
        //    var xnode = new ExtensibleElementNode<ISyntaxPointer>(
        //        XName.Get(nav.Name, nav.NamespaceUri),
        //        nav,
        //        n => n.Value,
        //        n => n.Attributes.Select(a => (XName.Get(a.Name, a.NamespaceUri), a.Value)),
        //        n => n.Children.Select(c => (XName.Get(c.Name, c.NamespaceUri), c))
        //        );

        //    var oNavigator = new ExtensibleNavigator(xnode, targetFile);
        //    oNavigator.MoveToRoot();
        //    //var pre = oNavigator.Prefix;
        //    //var v = oNavigator.Value;
        //    var ix = oNavigator.InnerXml;
        //    this.TestContext.WriteLine(oNavigator.OuterXml);
        //}

        //[TestMethod]
        //public void TestXPath2()
        //{
        //    var targetFile = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.Tests\CSharp\SampleClasses.cs";
        //    var nav = new CSharpNavigator().ToNavigable(targetFile);
        //    var real = nav.CreateNavigator();

        //    var navigator = nav.CreateNavigator();
        //    var manager = new XmlNamespaceManager(navigator.NameTable);
        //    manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");

        //    var root = navigator.Compile(@"/");
        //    root.SetContext(manager);

        //    var rootNode = navigator.Select(root);
        //    if (rootNode.MoveNext())
        //    {
        //        var cu = navigator.Clone();
        //        var cuq = cu.Compile("cs-n:CompilationUnit");
        //        cuq.SetContext(manager);
        //        var compilationUnits = cu.Select(cuq);
        //        if (compilationUnits.MoveNext())
        //        {
        //            var t = cu.Clone();
        //            var tq = t.Compile("//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
        //            tq.SetContext(manager);
        //            var types = t.Select(tq);

        //            while (types.MoveNext())
        //            {

        //                this.TestContext.WriteLine(new string('-', 15));
        //                this.TestContext.WriteLine(types.Current.Name);
        //                this.TestContext.WriteLine(types.Current.LocalName);
        //                this.TestContext.WriteLine(types.Current.NamespaceURI);
        //                this.TestContext.WriteLine(types.Current.Value);
        //            }
        //        }

        //    }

        //    //cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");


        //    //query.
        //    //var selected = navigator.Select(query);

        //    //while (selected.MoveNext())
        //    //{
        //    //    this.TestContext.WriteLine(new string('-', 15));
        //    //    this.TestContext.WriteLine(selected.Current.Name);
        //    //    this.TestContext.WriteLine(selected.Current.LocalName);
        //    //    this.TestContext.WriteLine(selected.Current.NamespaceURI);
        //    //    this.TestContext.WriteLine(selected.Current.Value);
        //    //}
        //    //https://docs.microsoft.com/en-us/dotnet/standard/data/xml/xpath-queries-and-namespaces
        //}
    }
}
