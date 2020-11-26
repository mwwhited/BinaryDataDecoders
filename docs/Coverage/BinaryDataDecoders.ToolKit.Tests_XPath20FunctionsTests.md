# BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.Extensions.XPath20FunctionsTests

## Summary

| Key             | Value                                                                       |
| :-------------- | :-------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.Extensions.XPath20FunctionsTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                          |
| Coveredlines    | `0`                                                                         |
| Uncoveredlines  | `32`                                                                        |
| Coverablelines  | `32`                                                                        |
| Totallines      | `237`                                                                       |
| Linecoverage    | `0`                                                                         |
| Coveredbranches | `0`                                                                         |
| Totalbranches   | `2`                                                                         |
| Branchcoverage  | `0`                                                                         |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 2          | 0     | 0        | `MaxTest`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Xml/Xsl/Extensions/XPath20FunctionsTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Xml.Xsl;
〰3:   using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.Diagnostics;
〰8:   using System.Linq;
〰9:   using System.Reflection;
〰10:  using System.Reflection.Emit;
〰11:  using System.Text;
〰12:  using System.Xml;
〰13:  using System.Xml.Linq;
〰14:  using System.Xml.XPath;
〰15:  using System.Xml.Xsl;
〰16:  
〰17:  namespace BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.Extensions
〰18:  {
〰19:      [TestClass]
〰20:      public class XPath20FunctionsTests
〰21:      {
‼22:          public TestContext TestContext { get; set; }
〰23:  
〰24:          //private static T ExtendType<T>()
〰25:          //{
〰26:          //    var type = typeof(T);
〰27:          //    var extendedMethods = from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
〰28:          //                          from attribute in method.GetCustomAttributes<XsltFunctionAttribute>()
〰29:          //                          select (attribute.Name, method);
〰30:  
〰31:          //    if (!extendedMethods.Any())
〰32:          //    {
〰33:          //        return Activator.CreateInstance<T>();
〰34:          //    }
〰35:  
〰36:          //    var typeSignature = $"{typeof(T).Name}_{Guid.NewGuid()}";
〰37:          //    var assemblyName = new AssemblyName(typeSignature);
〰38:          //    var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
〰39:          //    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
〰40:          //    var typeBuilder = moduleBuilder.DefineType(typeSignature,
〰41:          //            TypeAttributes.Public |
〰42:          //            TypeAttributes.Class |
〰43:          //            TypeAttributes.AutoClass |
〰44:          //            TypeAttributes.AnsiClass |
〰45:          //            TypeAttributes.BeforeFieldInit |
〰46:          //            TypeAttributes.AutoLayout,
〰47:          //            typeof(T));
〰48:  
〰49:          //    foreach (var extended in extendedMethods)
〰50:          //    {
〰51:          //        var methodBuilder = typeBuilder.DefineMethod(extended.Name, MethodAttributes.Public);
〰52:          //        var parameters = extended.method.GetParameters().Select(t => t.ParameterType).ToArray();
〰53:  
〰54:          //        methodBuilder.SetParameters(parameters);
〰55:          //        methodBuilder.SetReturnType(extended.method.ReturnType);
〰56:  
〰57:          //        var il = methodBuilder.GetILGenerator();
〰58:          //        il.Emit(OpCodes.Ldarg_0);
〰59:          //        foreach (var i in Enumerable.Range(1, parameters.Length))
〰60:          //            EmitLoadArg(il, i);
〰61:  
〰62:          //        il.EmitCall(OpCodes.Call, extended.method, parameters);
〰63:          //        il.Emit(OpCodes.Ret);
〰64:          //    }
〰65:  
〰66:          //    var typeInfo = typeBuilder.CreateTypeInfo();
〰67:          //    var newType = typeInfo.AsType();
〰68:          //    var newInstance = Activator.CreateInstance(newType);
〰69:          //    var casted = (T)newInstance;
〰70:          //    return casted;
〰71:  
〰72:          //    static void EmitLoadArg(ILGenerator il, int index)
〰73:          //    {
〰74:          //        switch (index)
〰75:          //        {
〰76:          //            case 0:
〰77:          //                il.Emit(OpCodes.Ldarg_0);
〰78:          //                break;
〰79:          //            case 1:
〰80:          //                il.Emit(OpCodes.Ldarg_1);
〰81:          //                break;
〰82:          //            case 2:
〰83:          //                il.Emit(OpCodes.Ldarg_2);
〰84:          //                break;
〰85:          //            case 3:
〰86:          //                il.Emit(OpCodes.Ldarg_3);
〰87:          //                break;
〰88:          //            default:
〰89:          //                if (index <= byte.MaxValue)
〰90:          //                {
〰91:          //                    il.Emit(OpCodes.Ldarg_S, (byte)index);
〰92:          //                }
〰93:          //                else
〰94:          //                {
〰95:          //                    il.Emit(OpCodes.Ldarg, index);
〰96:          //                }
〰97:          //                break;
〰98:          //        }
〰99:          //    }
〰100:         //}
〰101: 
〰102: 
〰103:         //[TestMethod]
〰104:         //public void ExtendTypeTest()
〰105:         //{
〰106:         //    var tb = ExtendType<FakeClass>();
〰107:         //    var tbt = tb.GetType();
〰108:         //    {
〰109:         //        var mi = tbt.GetMethod("do-work", BindingFlags.Public | BindingFlags.Instance);
〰110:         //        var ret = mi.Invoke(tb, new object[] { "Hi!" });
〰111:         //        this.TestContext.WriteLine($"{"do-work"}: {ret}");
〰112:         //    }
〰113:         //    {
〰114:         //        var mi = tbt.GetMethod("big-work", BindingFlags.Public | BindingFlags.Instance);
〰115:         //        var ret = mi.Invoke(tb, new object[] { "Hi!", "2", "3", "4", "5", "6" });
〰116:         //        this.TestContext.WriteLine($"{"big-work"}: {ret}");
〰117:         //    }
〰118:         //    {
〰119:         //        var mi = tbt.GetMethod("more-work", BindingFlags.Public | BindingFlags.Instance);
〰120:         //        var ret = mi.Invoke(tb, new object[] { "Hi!" });
〰121:         //        this.TestContext.WriteLine($"{"more-work"}: {ret}");
〰122:         //    }
〰123:         //    {
〰124:         //        var mi = tbt.GetMethod("other-work", BindingFlags.Public | BindingFlags.Instance);
〰125:         //        var ret = mi.Invoke(tb, new object[] { });
〰126:         //        this.TestContext.WriteLine($"{"other-work"}: {ret}");
〰127:         //    }
〰128:         //    {
〰129:         //        var mi = tbt.GetMethod("and-work", BindingFlags.Public | BindingFlags.Instance);
〰130:         //        var ret = mi.Invoke(tb, new object[] { });
〰131:         //        this.TestContext.WriteLine($"{"and-work"}: {ret}");
〰132:         //    }
〰133:         //}
〰134: 
〰135: 
〰136:         [TestMethod]
〰137:         //[TestCategory(TestCategories.Unit)]
〰138:         [TestTarget(typeof(XPath20Functions), Member = nameof(XPath20Functions.max))]
〰139:         public void MaxTest()
〰140:         {
‼141:             var xml = @"
‼142: <Summary>
‼143:     <Class>BinaryDataDecoders.Apple2.Text.Apple2Encoding</Class>
‼144:     <Assembly>BinaryDataDecoders.Apple2</Assembly>
‼145:     <Files>
‼146:       <File>C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Text\Apple2Encoding.cs</File>
‼147:     </Files>
‼148:     <Coveredlines>6</Coveredlines>
‼149:     <Uncoveredlines>0</Uncoveredlines>
‼150:     <Coverablelines>6</Coverablelines>
‼151:     <Totallines>48</Totallines>
‼152:     <Linecoverage>100</Linecoverage>
‼153:     <Coveredbranches>1</Coveredbranches>
‼154:     <Totalbranches>2</Totalbranches>
‼155:     <Branchcoverage>50</Branchcoverage>
‼156:     <Title>C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDecoders.sln - (0.2.0-beta.192)</Title>
‼157:   </Summary>";
‼158:             var xelement = XElement.Parse(xml);
‼159:             var nav = xelement.ToXPathNavigable().CreateNavigator();
〰160: 
‼161:             var nsmgr = new XmlNamespaceManager(nav.NameTable);
‼162:             var ns = nsmgr.NameTable as NameTable;
‼163:             var context = new XsltExtensionContext(ns);
‼164:             nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
〰165: 
‼166:             var selectorXPath = "*[not(self::Files or self::Title)]";
〰167: 
‼168:             var selected = nav.Select(selectorXPath);
〰169: 
‼170:             var capture = selected.Clone();
‼171:             while (capture.MoveNext())
〰172:             {
‼173:                 this.TestContext.WriteLine(capture.Current.Value);
〰174:             }
〰175: 
〰176: 
‼177:             var result = new XPath20Functions().apply("local-name(.)", selected);
‼178:             Assert.AreEqual(15m, result);
‼179:         }
〰180: 
〰181:         //public decimal abs(decimal input) => Math.Abs(input);
〰182: 
〰183:         //public decimal? max(XPathNodeIterator input) =>
〰184:         //    (from i in input.OfType<IXPathNavigable>()
〰185:         //     let n = i.CreateNavigator()
〰186:         //     where !string.IsNullOrWhiteSpace(n.Value)
〰187:         //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
〰188:         //     where d.HasValue
〰189:         //     select d).Max();
〰190: 
〰191:         //public decimal? min(XPathNodeIterator input) =>
〰192:         //    (from i in input.OfType<IXPathNavigable>()
〰193:         //     let n = i.CreateNavigator()
〰194:         //     where !string.IsNullOrWhiteSpace(n.Value)
〰195:         //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
〰196:         //     where d.HasValue
〰197:         //     select d).Min();
〰198: 
〰199:         //// https://www.w3.org/2005/xpath-functions/
〰200: 
〰201:         //public XPathNodeIterator distinct-values(XPathNodeIterator input) =>
〰202:         //     new EnumerableXPathNodeIterator(
〰203:         //        from i in input.OfType<IXPathNavigable>()
〰204:         //        let n = i.CreateNavigator()
〰205:         //        group n by n.Value into grouped
〰206:         //        from i in grouped
〰207:         //        select grouped.First());
〰208:     }
〰209: 
〰210:     public class XsltExtensionContext : XsltContext
〰211:     {
〰212:         public XsltExtensionContext(NameTable nameTable)
〰213:             : base(nameTable)
〰214:         {
〰215: 
〰216:         }
〰217: 
〰218:         public override bool Whitespace => true;
〰219: 
〰220:         public override int CompareDocument(string baseUri, string nextbaseUri)
〰221:         {
〰222:             throw new NotImplementedException();
〰223:         }
〰224: 
〰225:         public override bool PreserveWhitespace(XPathNavigator node) => true;
〰226: 
〰227:         public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
〰228:         {
〰229:             throw new NotImplementedException();
〰230:         }
〰231: 
〰232:         public override IXsltContextVariable ResolveVariable(string prefix, string name)
〰233:         {
〰234:             throw new NotImplementedException();
〰235:         }
〰236:     }
〰237: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

