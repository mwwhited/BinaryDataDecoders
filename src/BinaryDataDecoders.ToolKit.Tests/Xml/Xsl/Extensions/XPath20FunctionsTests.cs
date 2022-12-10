using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.Extensions
{
    [TestClass]
    public class XPath20FunctionsTests
    {
        public TestContext TestContext { get; set; }

        //private static T ExtendType<T>()
        //{
        //    var type = typeof(T);
        //    var extendedMethods = from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
        //                          from attribute in method.GetCustomAttributes<XsltFunctionAttribute>()
        //                          select (attribute.Name, method);

        //    if (!extendedMethods.Any())
        //    {
        //        return Activator.CreateInstance<T>();
        //    }

        //    var typeSignature = $"{typeof(T).Name}_{Guid.NewGuid()}";
        //    var assemblyName = new AssemblyName(typeSignature);
        //    var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
        //    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        //    var typeBuilder = moduleBuilder.DefineType(typeSignature,
        //            TypeAttributes.Public |
        //            TypeAttributes.Class |
        //            TypeAttributes.AutoClass |
        //            TypeAttributes.AnsiClass |
        //            TypeAttributes.BeforeFieldInit |
        //            TypeAttributes.AutoLayout,
        //            typeof(T));

        //    foreach (var extended in extendedMethods)
        //    {
        //        var methodBuilder = typeBuilder.DefineMethod(extended.Name, MethodAttributes.Public);
        //        var parameters = extended.method.GetParameters().Select(t => t.ParameterType).ToArray();

        //        methodBuilder.SetParameters(parameters);
        //        methodBuilder.SetReturnType(extended.method.ReturnType);

        //        var il = methodBuilder.GetILGenerator();
        //        il.Emit(OpCodes.Ldarg_0);
        //        foreach (var i in Enumerable.Range(1, parameters.Length))
        //            EmitLoadArg(il, i);

        //        il.EmitCall(OpCodes.Call, extended.method, parameters);
        //        il.Emit(OpCodes.Ret);
        //    }

        //    var typeInfo = typeBuilder.CreateTypeInfo();
        //    var newType = typeInfo.AsType();
        //    var newInstance = Activator.CreateInstance(newType);
        //    var casted = (T)newInstance;
        //    return casted;

        //    static void EmitLoadArg(ILGenerator il, int index)
        //    {
        //        switch (index)
        //        {
        //            case 0:
        //                il.Emit(OpCodes.Ldarg_0);
        //                break;
        //            case 1:
        //                il.Emit(OpCodes.Ldarg_1);
        //                break;
        //            case 2:
        //                il.Emit(OpCodes.Ldarg_2);
        //                break;
        //            case 3:
        //                il.Emit(OpCodes.Ldarg_3);
        //                break;
        //            default:
        //                if (index <= byte.MaxValue)
        //                {
        //                    il.Emit(OpCodes.Ldarg_S, (byte)index);
        //                }
        //                else
        //                {
        //                    il.Emit(OpCodes.Ldarg, index);
        //                }
        //                break;
        //        }
        //    }
        //}


        //[TestMethod, TestCategory(TestCategories.DevLocal)]
        //public void ExtendTypeTest()
        //{
        //    var tb = ExtendType<FakeClass>();
        //    var tbt = tb.GetType();
        //    {
        //        var mi = tbt.GetMethod("do-work", BindingFlags.Public | BindingFlags.Instance);
        //        var ret = mi.Invoke(tb, new object[] { "Hi!" });
        //        this.TestContext.WriteLine($"{"do-work"}: {ret}");
        //    }
        //    {
        //        var mi = tbt.GetMethod("big-work", BindingFlags.Public | BindingFlags.Instance);
        //        var ret = mi.Invoke(tb, new object[] { "Hi!", "2", "3", "4", "5", "6" });
        //        this.TestContext.WriteLine($"{"big-work"}: {ret}");
        //    }
        //    {
        //        var mi = tbt.GetMethod("more-work", BindingFlags.Public | BindingFlags.Instance);
        //        var ret = mi.Invoke(tb, new object[] { "Hi!" });
        //        this.TestContext.WriteLine($"{"more-work"}: {ret}");
        //    }
        //    {
        //        var mi = tbt.GetMethod("other-work", BindingFlags.Public | BindingFlags.Instance);
        //        var ret = mi.Invoke(tb, new object[] { });
        //        this.TestContext.WriteLine($"{"other-work"}: {ret}");
        //    }
        //    {
        //        var mi = tbt.GetMethod("and-work", BindingFlags.Public | BindingFlags.Instance);
        //        var ret = mi.Invoke(tb, new object[] { });
        //        this.TestContext.WriteLine($"{"and-work"}: {ret}");
        //    }
        //}


        [TestMethod, TestCategory(TestCategories.DevLocal)]
        //[TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(XPath20Functions), Member = nameof(XPath20Functions.max))]
        public void MaxTest()
        {
            var xml = @"
<Summary>
    <Class>BinaryDataDecoders.Apple2.Text.Apple2Encoding</Class>
    <Assembly>BinaryDataDecoders.Apple2</Assembly>
    <Files>
      <File>C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Text\Apple2Encoding.cs</File>
    </Files>
    <Coveredlines>6</Coveredlines>
    <Uncoveredlines>0</Uncoveredlines>
    <Coverablelines>6</Coverablelines>
    <Totallines>48</Totallines>
    <Linecoverage>100</Linecoverage>
    <Coveredbranches>1</Coveredbranches>
    <Totalbranches>2</Totalbranches>
    <Branchcoverage>50</Branchcoverage>
    <Title>C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDecoders.sln - (0.2.0-beta.192)</Title>
  </Summary>";
            var xelement = XElement.Parse(xml);
            var nav = xelement.ToXPathNavigable().CreateNavigator();

            var nsmgr = new XmlNamespaceManager(nav.NameTable);
            var ns = nsmgr.NameTable as NameTable;
            var context = new XsltExtensionContext(ns);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");

            var selectorXPath = "*[not(self::Files or self::Title)]";

            var selected = nav.Select(selectorXPath);

            var capture = selected.Clone();
            while (capture.MoveNext())
            {
                this.TestContext.WriteLine(capture.Current.Value);
            }


            var result = new XPath20Functions().apply("local-name(.)", selected);
            //Assert.AreEqual(15m, result);

            Assert.Inconclusive();
        }

        //public decimal abs(decimal input) => Math.Abs(input);

        //public decimal? max(XPathNodeIterator input) =>
        //    (from i in input.OfType<IXPathNavigable>()
        //     let n = i.CreateNavigator()
        //     where !string.IsNullOrWhiteSpace(n.Value)
        //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
        //     where d.HasValue
        //     select d).Max();

        //public decimal? min(XPathNodeIterator input) =>
        //    (from i in input.OfType<IXPathNavigable>()
        //     let n = i.CreateNavigator()
        //     where !string.IsNullOrWhiteSpace(n.Value)
        //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
        //     where d.HasValue
        //     select d).Min();

        //// https://www.w3.org/2005/xpath-functions/

        //public XPathNodeIterator distinct-values(XPathNodeIterator input) =>
        //     new EnumerableXPathNodeIterator(
        //        from i in input.OfType<IXPathNavigable>()
        //        let n = i.CreateNavigator()
        //        group n by n.Value into grouped
        //        from i in grouped
        //        select grouped.First());
    }

    public class XsltExtensionContext : XsltContext
    {
        public XsltExtensionContext(NameTable nameTable)
            : base(nameTable)
        {

        }

        public override bool Whitespace => true;

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            throw new NotImplementedException();
        }

        public override bool PreserveWhitespace(XPathNavigator node) => true;

        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            throw new NotImplementedException();
        }

        public override IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            throw new NotImplementedException();
        }
    }
}
