# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests

## Summary

| Key             | Value                                                                             |
| :-------------- | :-------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                   |
| Coveredlines    | `0`                                                                               |
| Uncoveredlines  | `1`                                                                               |
| Coverablelines  | `1`                                                                               |
| Totallines      | `387`                                                                             |
| Linecoverage    | `0`                                                                               |
| Coveredbranches | `0`                                                                               |
| Totalbranches   | `0`                                                                               |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator.Tests\Parser\ExpressionParserTests.cs

```CSharp
〰1:   using Antlr4.Runtime.Misc;
〰2:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰3:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰4:   using BinaryDataDecoders.ExpressionCalculator.Parser;
〰5:   using BinaryDataDecoders.TestUtilities;
〰6:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰7:   using System;
〰8:   using System.Linq;
〰9:   using System.Runtime.InteropServices;
〰10:  
〰11:  namespace BinaryDataDecoders.ExpressionCalculator.Tests.Parser
〰12:  {
〰13:      #region Per Numeric Type
〰14:      [TestClass]
〰15:      public class DecimalExpressionParserTests : ExpressionParserTests<decimal>
〰16:      {
〰17:      }
〰18:      [TestClass]
〰19:      public class DoubleExpressionParserTests : ExpressionParserTests<double>
〰20:      {
〰21:      }
〰22:      [TestClass]
〰23:      public class FloatExpressionParserTests : ExpressionParserTests<float>
〰24:      {
〰25:      }
〰26:  
〰27:      [TestClass]
〰28:      public class Int8ExpressionParserTests : ExpressionParserTests<sbyte>
〰29:      {
〰30:          public Int8ExpressionParserTests() : base(skipDecimal: true) { }
〰31:      }
〰32:      [TestClass]
〰33:      public class Int16ExpressionParserTests : ExpressionParserTests<short>
〰34:      {
〰35:          public Int16ExpressionParserTests() : base(skipDecimal: true) { }
〰36:      }
〰37:      [TestClass]
〰38:      public class Int32ExpressionParserTests : ExpressionParserTests<int>
〰39:      {
〰40:          public Int32ExpressionParserTests() : base(skipDecimal: true) { }
〰41:      }
〰42:      [TestClass]
〰43:      public class Int64ExpressionParserTests : ExpressionParserTests<long>
〰44:      {
‼45:          public Int64ExpressionParserTests() : base(skipDecimal: true) { }
〰46:      }
〰47:  
〰48:      [TestClass]
〰49:      public class UInt8ExpressionParserTests : ExpressionParserTests<byte>
〰50:      {
〰51:          public UInt8ExpressionParserTests() : base(skipDecimal: true, skipNegative: true) { }
〰52:      }
〰53:      [TestClass]
〰54:      public class UInt16ExpressionParserTests : ExpressionParserTests<ushort>
〰55:      {
〰56:          public UInt16ExpressionParserTests() : base(skipDecimal: true, skipNegative: true) { }
〰57:      }
〰58:      [TestClass]
〰59:      public class UInt32ExpressionParserTests : ExpressionParserTests<uint>
〰60:      {
〰61:          public UInt32ExpressionParserTests() : base(skipDecimal: true, skipNegative: true) { }
〰62:      }
〰63:      [TestClass]
〰64:      public class UInt64ExpressionParserTests : ExpressionParserTests<ulong>
〰65:      {
〰66:          public UInt64ExpressionParserTests() : base(skipDecimal: true, skipNegative: true) { }
〰67:      }
〰68:  
〰69:      #endregion Per Numeric Type
〰70:  
〰71:      public abstract class ExpressionParserTests<T>
〰72:          where T : struct, IComparable<T>, IEquatable<T>
〰73:      {
〰74:          private readonly bool _skipDecimal;
〰75:          private readonly bool _skipNegative;
〰76:          private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰77:  
〰78:          protected ExpressionParserTests(
〰79:              bool skipDecimal = false,
〰80:              bool skipNegative = false
〰81:              )
〰82:          {
〰83:              _skipDecimal = skipDecimal;
〰84:              _skipNegative = skipNegative;
〰85:          }
〰86:  
〰87:          public TestContext TestContext { get; set; }
〰88:  
〰89:  
〰90:          [DataTestMethod, TestCategory(TestCategories.Unit)]
〰91:          [ExpectedException(typeof(ParseCanceledException))]
〰92:          [DataRow("-A!")]
〰93:          [DataRow("B/*1")]
〰94:          [DataRow("B**")]
〰95:          [DataRow("B**A")]
〰96:          [DataRow("B***A")]
〰97:          [DataRow("B*+*A")]
〰98:          [DataRow("B*-*A")]
〰99:          [DataRow("")]
〰100:         [DataRow("b")]
〰101:         [DataRow("b+1")]
〰102:         [TestTarget(typeof(ExpressionParser<>), Member = nameof(ExpressionParser<double>.Parse))]
〰103:         //TODO: this should throw a parse error !!![DataRow("1e")]
〰104:         public void PoorlyFormedExpressions(string input)
〰105:         {
〰106:             try
〰107:             {
〰108:                 TestContext.WriteLine($"Input: {input}");
〰109:                 var parsed = new ExpressionParser<T>().Parse(input);
〰110:                 Assert.Fail("You shouldn't get here!");
〰111:             }
〰112:             catch (Exception ex)
〰113:             {
〰114:                 this.TestContext.WriteLine(ex.Message);
〰115:                 this.TestContext.WriteLine(ex.GetType().ToString());
〰116:                 throw;
〰117:             }
〰118:         }
〰119: 
〰120:         [DataTestMethod, TestCategory(TestCategories.Unit)]
〰121:         [DataRow("2+3*4^5%6/7-8", "2 + 3 * 4 ^ 5 % 6 / 7 - 8", DisplayName = "Parse all operators test")]
〰122:         [DataRow("A+B+1", "A + B + 1", DisplayName = "Simple test with variable")]
〰123:         [DataRow("Abc1", "Abc1", DisplayName = "Just variable")]
〰124:         [DataRow("1.34", "1.34", DisplayName = "Just decimal value")]
〰125:         [DataRow("A!", "A!", DisplayName = "Simple factorial")]
〰126:         [DataRow("-(A!)", "-(A!)", DisplayName = "Negative factorial")]
〰127:         [DataRow("((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H", "((((((A - B - 1 * E - 6) / C) + 0.999999) / 1000000) * 1000000) * ((D * E) * F) * G) + H", DisplayName = "Parse Complex Expression")]
〰128:         [DataRow("B*--A", "B * --A")]
〰129:         [TestTarget(typeof(ExpressionParser<>), Member = nameof(ExpressionParser<double>.Parse))]
〰130:         public void SimpleParserTests(string input, string result)
〰131:         {
〰132:             if (_skipDecimal && input.Contains("."))
〰133:             {
〰134:                 Assert.Inconclusive("Decimals not supported");
〰135:             }
〰136:             else
〰137:             {
〰138:                 TestContext.WriteLine($"Input: {input}");
〰139:                 var parsed = new ExpressionParser<T>().Parse(input);
〰140:                 TestContext.WriteLine($"As Parsed: {parsed}");
〰141:                 Assert.AreEqual(result, parsed.ToString());
〰142:             }
〰143:         }
〰144: 
〰145:         [DataTestMethod, TestCategory(TestCategories.Unit)]
〰146:         [DataRow("(A)", "A")]
〰147:         [DataRow("(A+(B))", "A + B")]
〰148:         [DataRow("B^1", "B")]
〰149:         [DataRow("B*1", "B")]
〰150:         [DataRow("1*B", "B")]
〰151:         [DataRow("B*-1", "-B")]
〰152:         [DataRow("-1*B", "-B")]
〰153:         [DataRow("B/1", "B")]
〰154:         [DataRow("B/-1", "-B")]
〰155:         [DataRow("B+0", "B")]
〰156:         [DataRow("0+B", "B")]
〰157:         [DataRow("B-0", "B")]
〰158:         [DataRow("0-B", "-B")]
〰159: 
〰160:         [DataRow("2+3*4^5%6/7-8", "-6")]
〰161: 
〰162:         [DataRow("2+3", "5")]
〰163:         [DataRow("B/B", "1")]
〰164:         [DataRow("B%B", "0")]
〰165:         [DataRow("B^0", "1")]
〰166:         [DataRow("0^B", "0")]
〰167:         [DataRow("0*B", "0")]
〰168:         [DataRow("B*0", "0")]
〰169:         [DataRow("0/B", "0")]
〰170:         [DataRow("0%B", "0")]
〰171:         [DataRow("B%1", "0")]
〰172:         [DataRow("B%-1", "0")]
〰173: 
〰174:         [DataRow("-(B)", "-B")]
〰175:         [DataRow("-(3)", "-3")]
〰176:         [DataRow("-3", "-3")]
〰177:         [DataRow("--B", "B")]
〰178:         [DataRow("---B", "-B")]
〰179:         [DataRow("-1*(A*B)", "-(A * B)")]
〰180:         [DataRow("A!", "A!")]
〰181:         [DataRow("(A)!", "A!")]
〰182:         [DataRow("3!!", "720")]
〰183:         [DataRow("2!!!", "2")]
〰184:         [DataRow("N!!", "N!!")]
〰185:         [DataRow("N!!!", "N!!!")]
〰186:         [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.Optimize))]
〰187:         public void OptimizerTests(string input, string result)
〰188:         {
〰189:             if (Marshal.SizeOf<T>() == 1 && input.Contains("!!"))
〰190:             {
〰191:                 Assert.Inconclusive($"{nameof(input)}: \"{input}\" not supported");
〰192:                 return;
〰193:             }
〰194:             try
〰195:             {
〰196:                 TestContext.WriteLine($"Input: {input}");
〰197:                 var parsed = new ExpressionParser<T>().Parse(input);
〰198:                 TestContext.WriteLine($"As Parsed: {parsed}");
〰199:                 var optimized = parsed.Optimize();
〰200:                 TestContext.WriteLine($"As Optimized: {optimized}");
〰201: 
〰202:                 if (_skipNegative && result.StartsWith("-"))
〰203:                 {
〰204:                     Assert.Inconclusive($"Negative not supported");
〰205:                 }
〰206:                 else
〰207:                 {
〰208:                     Assert.AreEqual(result, optimized.ToString());
〰209:                 }
〰210:             }
〰211:             catch (NotSupportedException nse) when (_skipNegative && nse.Message == nameof(IExpressionEvaluator<T>.Negate))
〰212:             {
〰213:                 Assert.Inconclusive($"{nse.Message} not supported");
〰214:             }
〰215:         }
〰216: 
〰217:         [DataTestMethod, TestCategory(TestCategories.Unit)]
〰218:         [DataRow("B/0")]
〰219:         [DataRow("B%0")]
〰220:         [ExpectedException(typeof(DivideByZeroException))]
〰221:         [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.Optimize))]
〰222:         public void OptimizerTests_WithExceptions(string input)
〰223:         {
〰224:             TestContext.WriteLine($"Input: {input}");
〰225:             var parsed = new ExpressionParser<T>().Parse(input);
〰226:             TestContext.WriteLine($"As Parsed: {parsed}");
〰227:             var optimized = parsed.Optimize();
〰228:             TestContext.WriteLine($"As Optimized: {optimized}");
〰229:             Assert.Fail("You shouldn't get here");
〰230:         }
〰231: 
〰232:         [DataTestMethod, TestCategory(TestCategories.Unit)]
〰233:         [DataRow("A+B+C", "A, B, C")]
〰234:         [DataRow("A+B+B", "A, B")]
〰235:         [DataRow("Abc+XyW1", "Abc, XyW1")]
〰236:         [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.GetDistinctVariableNames))]
〰237:         public void GetDistinctVariablesTests(string input, string result)
〰238:         {
〰239:             TestContext.WriteLine($"Input: {input}");
〰240:             var parsed = new ExpressionParser<T>().Parse(input);
〰241:             TestContext.WriteLine($"As Parsed: {parsed}");
〰242:             var variables = string.Join(", ", parsed.GetDistinctVariableNames());
〰243:             TestContext.WriteLine($"Variables: {variables}");
〰244:             Assert.AreEqual(result, variables.ToString());
〰245:         }
〰246: 
〰247:         [DataTestMethod, TestCategory(TestCategories.Unit)]
〰248:         [DataRow("A", DisplayName = "Check Expressions \"A\"")]
〰249:         [DataRow("A*1", DisplayName = "Check Expressions \"A*1\"")]
〰250:         [DataRow("(A*B)+C", DisplayName = "Check Expressions \"(A*B)+C\"")]
〰251:         [DataRow("(A*B)", DisplayName = "Check Expressions \"(A*B)\"")]
〰252:         [DataRow("(A-B)/A", DisplayName = "Check Expressions \"(A-B)/A\"")]
〰253:         [DataRow("(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))", DisplayName = "Check Expressions \"(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))\"")]
〰254:         [DataRow("((A+B+((C*D)+E))*F)+G+((D/H)*I)+J", DisplayName = "Check Expressions \"((A+B+((C*D)+E))*F)+G+((D/H)*I)+J\"")]
〰255:         [DataRow("A*(B/C)+D", DisplayName = "Check Expressions \"A*(B/C)+D\"")]
〰256:         [DataRow("A*B+C", DisplayName = "Check Expressions \"A*B+C\"")]
〰257:         [DataRow("(((A-(B*C))/D)*E)+F", DisplayName = "Check Expressions \"(((A-(B*C))/D)*E)+F\"")]
〰258:         [DataRow("(A/B)-(C+D+E+F)", DisplayName = "Check Expressions \"(A/B)-(C+D+E+F)\"")]
〰259:         [DataRow("((A*B)*C)+D", DisplayName = "Check Expressions \"((A*B)*C)+D\"")]
〰260:         [DataRow("(((A*B)*C)*D)+E", DisplayName = "Check Expressions \"(((A*B)*C)*D)+E\"")]
〰261:         [DataRow("(((A/B)+(-1*C))*(D*E)*F)+G", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*(D*E)*F)+G\"")]
〰262:         [DataRow("(A*B*(C/D))+E", DisplayName = "Check Expressions \"(A*B*(C/D))+E\"")]
〰263:         [DataRow("(A*(B/C)+D)", DisplayName = "Check Expressions \"(A*(B/C)+D)\"")]
〰264:         [DataRow("A+B", DisplayName = "Check Expressions \"A+B\"")]
〰265:         [DataRow("((A/B)*(C*D)*E)+F", DisplayName = "Check Expressions \"((A/B)*(C*D)*E)+F\"")]
〰266:         [DataRow("((A+((B*C)+D))*E)+F+(C*G)+H", DisplayName = "Check Expressions \"((A+((B*C)+D))*E)+F+(C*G)+H\"")]
〰267:         [DataRow("(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H", DisplayName = "Check Expressions \"(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H\"")]
〰268:         [DataRow("(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))", DisplayName = "Check Expressions \"(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))\"")]
〰269:         [DataRow("((A*B)+C)+((D*B)+E)", DisplayName = "Check Expressions \"((A*B)+C)+((D*B)+E)\"")]
〰270:         [DataRow("(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)\"")]
〰271:         [DataRow("(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))\"")]
〰272:         [DataRow("(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)", DisplayName = "Check Expressions \"(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)\"")]
〰273:         [DataRow("(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)\"")]
〰274:         [DataRow("((A*B)+C)+(-1*A)", DisplayName = "Check Expressions \"((A*B)+C)+(-1*A)\"")]
〰275:         [DataRow("(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I", DisplayName = "Check Expressions \"(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I\"")]
〰276:         [DataRow("((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I", DisplayName = "Check Expressions \"((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I\"")]
〰277:         [DataRow("((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)", DisplayName = "Check Expressions \"((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)\"")]
〰278:         [DataRow("(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))", DisplayName = "Check Expressions \"(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))\"")]
〰279:         [DataRow("(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)", DisplayName = "Check Expressions \"(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)\"")]
〰280:         [DataRow("(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L", DisplayName = "Check Expressions \"(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L\"")]
〰281:         [DataRow("(((A+(-1*B))*C)+D)+(B+(-1*A))", DisplayName = "Check Expressions \"(((A+(-1*B))*C)+D)+(B+(-1*A))\"")]
〰282:         [DataRow("((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))", DisplayName = "Check Expressions \"((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))\"")]
〰283:         [DataRow("((A+((B*C)+D))*E)+F+((C/G)*H)+I", DisplayName = "Check Expressions \"((A+((B*C)+D))*E)+F+((C/G)*H)+I\"")]
〰284:         [DataRow("(A+B)*C+D+(A+B)*E+F", DisplayName = "Check Expressions \"(A+B)*C+D+(A+B)*E+F\"")]
〰285:         [DataRow("A*B", DisplayName = "Check Expressions \"A*B\"")]
〰286:         [DataRow("((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G", DisplayName = "Check Expressions \"((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G\"")]
〰287:         [DataRow("((A/(1-B))*C)+D", DisplayName = "Check Expressions \"((A/(1-B))*C)+D\"")]
〰288:         [DataRow("(((A-(B*C))/(1-D))*E)+F", DisplayName = "Check Expressions \"(((A-(B*C))/(1-D))*E)+F\"")]
〰289:         [DataRow("(A*(1+(-1*B))+C)*D+E", DisplayName = "Check Expressions \"(A*(1+(-1*B))+C)*D+E\"")]
〰290:         [DataRow("(A+B)*C+D", DisplayName = "Check Expressions \"(A+B)*C+D\"")]
〰291:         [DataRow("(((A/B)*C*D)*E*F)+G", DisplayName = "Check Expressions \"(((A/B)*C*D)*E*F)+G\"")]
〰292:         [DataRow("((A-B)*C)+D", DisplayName = "Check Expressions \"((A-B)*C)+D\"")]
〰293:         [DataRow("((A/B)*C)+D", DisplayName = "Check Expressions \"((A/B)*C)+D\"")]
〰294:         [DataRow("((((A*B)+C)/D)*E)+F", DisplayName = "Check Expressions \"((((A*B)+C)/D)*E)+F\"")]
〰295:         [DataRow("((A/B)*C*D*E)+F", DisplayName = "Check Expressions \"((A/B)*C*D*E)+F\"")]
〰296:         [DataRow("(A*B*C)+D", DisplayName = "Check Expressions \"(A*B*C)+D\"")]
〰297:         [DataRow("(((A*B)+C)*D)+E", DisplayName = "Check Expressions \"(((A*B)+C)*D)+E\"")]
〰298:         [DataRow("(((A/B)*C*D)*E)+F", DisplayName = "Check Expressions \"(((A/B)*C*D)*E)+F\"")]
〰299:         [DataRow("(A*1)", DisplayName = "Check Expressions \"(A*1)\"")]
〰300:         [DataRow("(((A/B)+(-1*C))*D*E*F)+G", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*D*E*F)+G\"")]
〰301:         [DataRow("((A*B)+C)+(D*E*F)", DisplayName = "Check Expressions \"((A*B)+C)+(D*E*F)\"")]
〰302:         [DataRow("((A/(1+(-1*(B+C))))*D)+E", DisplayName = "Check Expressions \"((A/(1+(-1*(B+C))))*D)+E\"")]
〰303:         [DataRow("((A-(B*C))*D)+E", DisplayName = "Check Expressions \"((A-(B*C))*D)+E\"")]
〰304:         [DataRow("(((A+(-1*B))/C)*(D*E)*F)+G", DisplayName = "Check Expressions \"(((A+(-1*B))/C)*(D*E)*F)+G\"")]
〰305:         [DataRow("((A/B)*((C*D)*E)*F)+G", DisplayName = "Check Expressions \"((A/B)*((C*D)*E)*F)+G\"")]
〰306:         [DataRow("((((A/B)*C)+D)*((E*F)*G))+H", DisplayName = "Check Expressions \"((((A/B)*C)+D)*((E*F)*G))+H\"")]
〰307:         [DataRow("(((A/B)+(-1*C))*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*((D*E)*F)*G)+H\"")]
〰308:         [DataRow("(((A+(-1*B))/C)*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A+(-1*B))/C)*((D*E)*F)*G)+H\"")]
〰309:         [DataRow("(((A/B)*(((C*D)*E)*F))+(C*D*G))+H", DisplayName = "Check Expressions \"(((A/B)*(((C*D)*E)*F))+(C*D*G))+H\"")]
〰310:         [DataRow("((A*B)+((A*C)-A)*D)+E", DisplayName = "Check Expressions \"((A*B)+((A*C)-A)*D)+E\"")]
〰311:         [DataRow("((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H\"")]
〰312:         [DataRow("(((A/B)*((C*D)*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A/B)*((C*D)*E)*F)*G)+H\"")]
〰313:         [DataRow("((A/B)*(((C*D)*E)*F))+G", DisplayName = "Check Expressions \"((A/B)*(((C*D)*E)*F))+G\"")]
〰314:         [DataRow("((A/B)*((C*D)*E))+F", DisplayName = "Check Expressions \"((A/B)*((C*D)*E))+F\"")]
〰315:         [DataRow("(A/(A+B))", DisplayName = "Check Expressions \"(A/(A+B))\"")]
〰316:         [DataRow("A!")]
〰317:         [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.Optimize))]
〰318:         public void VerifyOptimizerForComplexExpressions(string input)
〰319:         {
〰320:             var includesFactorial = input.Contains("!");
〰321:             var x = 0;
〰322:         tryAgain:
〰323:             try
〰324:             {
〰325:                 if (_skipDecimal && input.Contains("."))
〰326:                 {
〰327:                     Assert.Inconclusive("Decimals not supported");
〰328:                 }
〰329:                 else
〰330:                 {
〰331:                     TestContext.WriteLine($"Input: {input}");
〰332:                     var parsed = new ExpressionParser<T>().Parse(input);
〰333:                     TestContext.WriteLine($"As Parsed: {parsed}");
〰334:                     var optimized = parsed.Optimize();
〰335:                     TestContext.WriteLine($"As Optimized: {optimized}");
〰336: 
〰337:                     var testValues = parsed.GenerateTestValues(includeNegatives: !includesFactorial, scale: includesFactorial ? 1 : 4);
〰338: 
〰339:                     var variables = string.Join(", ", testValues.Select(kvp => (Name: kvp.Key, kvp.Value)));
〰340:                     TestContext.WriteLine($"Variables: {variables}");
〰341: 
〰342:                     var resultAsParsed = parsed.Evaluate(testValues);
〰343:                     var resultAsOptimized = optimized.Evaluate(testValues);
〰344: 
〰345:                     TestContext.WriteLine($"Parsed Result: {resultAsParsed}");
〰346:                     TestContext.WriteLine($"Optimized Result: {resultAsOptimized}");
〰347: 
〰348:                     Assert.AreEqual(resultAsParsed, resultAsOptimized);
〰349:                 }
〰350:             }
〰351:             catch (NotSupportedException nse) when (_skipNegative && nse.Message == nameof(IExpressionEvaluator<T>.Negate))
〰352:             {
〰353:                 Assert.Inconclusive($"{nse.Message} not supported");
〰354:             }
〰355:             catch (DivideByZeroException)
〰356:             {
〰357:                 if (x++ > 2)
〰358:                 {
〰359:                     throw;
〰360:                 }
〰361:                 goto tryAgain;
〰362:             }
〰363:         }
〰364: 
〰365:         [TestMethod, Ignore]
〰366:         public void TestBuilder()
〰367:         {
〰368:             var formulas = @"XYZ";
〰369: 
〰370:             var expressions = from line in formulas.Split(Environment.NewLine)
〰371:                               let expression = line.ParseAsExpression<double>()
〰372:                               where expression != null
〰373:                               let variables = expression.GetDistinctVariableNames()
〰374:                               let replacements = variables.Select((v, i) => (v, new string((char)('A' + i), 1)))
〰375:                               let replaced = expression.ReplaceVariables(replacements)
〰376:                               select replaced; //.Distinct();
〰377: 
〰378:             var expressionStrings = expressions.Select(s => s.ToString().Replace(" ", "")).Distinct();
〰379: 
〰380:             foreach (var expression in expressionStrings)
〰381:             {
〰382:                 this.TestContext.WriteLine($"{expression}");
〰383:                 // this.TestContext.WriteLine($@"[DataRow(""{expression}"",DisplayName = ""Check Expressions \""{expression}\"""")]");
〰384:             }
〰385:         }
〰386:     }
〰387: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

