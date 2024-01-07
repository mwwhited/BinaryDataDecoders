using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using BinaryDataDecoders.ToolKit;

namespace BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;

/// <summary>
/// wrapper around MS Test Results intended for use with XslCompiledTransform
/// </summary>
public class TrxExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input">{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}TestMethod</param>
    /// <returns></returns>
    public XPathNavigator GetTestTargets(XPathNavigator? input)
    {
        XNamespace ns = this.GetXmlNamespace() + ":out";
        try
        {

            /*
          <TestMethod codeBase="C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator.Tests\bin\Debug\netcoreapp3.1\BinaryDataDecoders.ExpressionCalculator.Tests.dll"
                adapterTypeName="executor://mstestadapter/v2" 
                className="BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests"
                name="GetDistinctVariablesTests" />
            */

            var codeBase = input?.GetAttribute("codeBase", "");
            var className = input?.GetAttribute("className", "");
            var name = input?.GetAttribute("name", "");

            if (!File.Exists(codeBase))
                return new XElement(ns + "targets", new XComment($"File: \"{codeBase}\" not found")).ToXPathNavigable().CreateNavigator();

            var assembly = string.IsNullOrWhiteSpace(codeBase) ? null : Assembly.LoadFrom(codeBase);
            var testClass = string.IsNullOrWhiteSpace(className) ? null : assembly?.GetType(className);
            var testMethod = string.IsNullOrWhiteSpace(name) ? null : testClass?.GetMethod(name);
            var attributes = testMethod?.GetCustomAttributes<TestTargetAttribute>() ?? Enumerable.Empty<TestTargetAttribute>();

            var xml = new XElement(ns + "targets",
                from a in attributes
                select new XElement(ns + "target",
                    new XAttribute("name", a.Class.Name),
                    (string.IsNullOrWhiteSpace(a.Class.Namespace) ? null : new XAttribute("namespace", a.Class.Namespace)),
                    (string.IsNullOrWhiteSpace(a.Class.Assembly.FullName) ? null : new XAttribute("assembly", a.Class.Assembly.FullName)),
                    (string.IsNullOrWhiteSpace(a.Member) ? null : new XAttribute("member", a.Member))
                    )
                );

            var xPathNavigable = xml.ToXPathNavigable();
            var xPathNavigator = xPathNavigable.CreateNavigator();
            return xPathNavigator;
        }
        catch (Exception ex)
        {
            return new XElement(ns + "targets", new XComment(ex.Message)).ToXPathNavigable().CreateNavigator();
        }
    }
}
