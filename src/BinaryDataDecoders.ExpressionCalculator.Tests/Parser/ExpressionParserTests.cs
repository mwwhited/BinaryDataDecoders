using BinaryDataDecoders.ExpressionCalculator.Expressions;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ExpressionParser = BinaryDataDecoders.ExpressionCalculator.Parser.ExpressionParser<decimal>;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Parser
{
    [TestClass]
    public class ExpressionParserTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow("2+3*4^5%6/7-8", "2 + 3 * 4 ^ 5 % 6 / 7 - 8", DisplayName = "Parse all operators test")]
        [DataRow("A+B+1", "A + B + 1", DisplayName = "Simple test with variable")]
        [DataRow("Abc1", "Abc1", DisplayName = "Just variable")]
        [DataRow("1.34", "1.34", DisplayName = "Just decimal value")]
        public void SimpleParserTests(string input, string result)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            Assert.AreEqual(result, parsed.ToString());
        }

        [DataTestMethod]
        [DataRow("(A)", "A", DisplayName = "Reduce extra outer wrapping expression")]
        [DataRow("(A+(B))", "A + B", DisplayName = "Reduce extra wrapping expression")]

        [DataRow("B^1", "B", DisplayName = "Reduce raised to power of 1")]
        [DataRow("B*1", "B", DisplayName = "Reduce B times 1")]
        [DataRow("1*B", "B", DisplayName = "Reduce 1 times B")]
        [DataRow("B*-1", "-B", DisplayName = "Reduce B times -1")]
        [DataRow("-1*B", "-B", DisplayName = "Reduce -1 times B")]
        [DataRow("B/*1", "B", DisplayName = "Reduce B divided 1")]
        [DataRow("B/-1", "-B", DisplayName = "Reduce B divided -1")]
        [DataRow("B+0", "B", DisplayName = "Reduce B + 0")]
        [DataRow("0+B", "B", DisplayName = "Reduce 0 + B")]
        [DataRow("B-0", "B", DisplayName = "Reduce B - 0")]
        [DataRow("0-B", "-B", DisplayName = "Reduce 0 - B")]

        [DataRow("2+3*4^5%6/7-8", "-6", DisplayName = "Simplify all operators test")]

        [DataRow("2+3", "5", DisplayName = "Simplify 2+3")]
        [DataRow("B/B", "1", DisplayName = "Simplify B/B")]
        [DataRow("B%B", "0", DisplayName = "Simplify B%B")]
        [DataRow("B^0", "1", DisplayName = "Simplify B^0")]
        [DataRow("0^B", "0", DisplayName = "Simplify 0^B")]
        [DataRow("0*B", "0", DisplayName = "Simplify 0*B")]
        [DataRow("B*0", "0", DisplayName = "Simplify B*0")]
        [DataRow("0/B", "0", DisplayName = "Simplify 0/B")]
        [DataRow("0%B", "0", DisplayName = "Simplify 0%B")]
        [DataRow("B%1", "0", DisplayName = "Simplify B%1")]
        [DataRow("B%-1", "0", DisplayName = "Simplify B%-1")]

        [DataRow("-(B)", "-B", DisplayName = "Simplify -(B)")]
        [DataRow("-(3)", "-3", DisplayName = "Simplify -(3)")]
        [DataRow("-3", "-3", DisplayName = "Simplify -3")]
        [DataRow("--B", "B", DisplayName = "Simplify --B")]
        public void OptimizerTests(string input, string result)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            var optimized = parsed.Optimize();
            TestContext.WriteLine($"As Optimized: {optimized}");
            Assert.AreEqual(result, optimized.ToString());
        }

        [DataTestMethod]
        [DataRow("B/0", DisplayName = "Simplify B/0")]
        [DataRow("B%0", DisplayName = "Simplify B%0")]
        [ExpectedException(typeof(DivideByZeroException))]
        public void OptimizerTests_WithExceptions(string input)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            var optimized = parsed.Optimize();
            TestContext.WriteLine($"As Optimized: {optimized}");
            Assert.Fail("You shouldn't get here");
        }

        [DataTestMethod]
        [DataRow("A+B+C", "A, B, C", DisplayName = "Get Distinct Variables")]
        [DataRow("A+B+B", "A, B", DisplayName = "Get Distinct Variables (ignore duplicate)")]
        public void GetDistinctVariablesTests(string input, string result)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            var variables = string.Join(", ", parsed.GetDistinctVariableNames());
            TestContext.WriteLine($"Variables: {variables}");
            Assert.AreEqual(result, variables.ToString());
        }

        [DataTestMethod]
        [DataRow("A", DisplayName = "Check Expressions \"A\"")]
        [DataRow("A*1", DisplayName = "Check Expressions \"A*1\"")]
        [DataRow("(A*B)+C", DisplayName = "Check Expressions \"(A*B)+C\"")]
        [DataRow("(A*B)", DisplayName = "Check Expressions \"(A*B)\"")]
        [DataRow("(A-B)/A", DisplayName = "Check Expressions \"(A-B)/A\"")]
        [DataRow("(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))", DisplayName = "Check Expressions \"(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))\"")]
        [DataRow("((A+B+((C*D)+E))*F)+G+((D/H)*I)+J", DisplayName = "Check Expressions \"((A+B+((C*D)+E))*F)+G+((D/H)*I)+J\"")]
        [DataRow("A*(B/C)+D", DisplayName = "Check Expressions \"A*(B/C)+D\"")]
        [DataRow("A*B+C", DisplayName = "Check Expressions \"A*B+C\"")]
        [DataRow("(((A-(B*C))/D)*E)+F", DisplayName = "Check Expressions \"(((A-(B*C))/D)*E)+F\"")]
        [DataRow("(A/B)-(C+D+E+F)", DisplayName = "Check Expressions \"(A/B)-(C+D+E+F)\"")]
        [DataRow("((A*B)*C)+D", DisplayName = "Check Expressions \"((A*B)*C)+D\"")]
        [DataRow("(((A*B)*C)*D)+E", DisplayName = "Check Expressions \"(((A*B)*C)*D)+E\"")]
        [DataRow("(((A/B)+(-1*C))*(D*E)*F)+G", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*(D*E)*F)+G\"")]
        [DataRow("(A*B*(C/D))+E", DisplayName = "Check Expressions \"(A*B*(C/D))+E\"")]
        [DataRow("(A*(B/C)+D)", DisplayName = "Check Expressions \"(A*(B/C)+D)\"")]
        [DataRow("A+B", DisplayName = "Check Expressions \"A+B\"")]
        [DataRow("((A/B)*(C*D)*E)+F", DisplayName = "Check Expressions \"((A/B)*(C*D)*E)+F\"")]
        [DataRow("((A+((B*C)+D))*E)+F+(C*G)+H", DisplayName = "Check Expressions \"((A+((B*C)+D))*E)+F+(C*G)+H\"")]
        [DataRow("(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H", DisplayName = "Check Expressions \"(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H\"")]
        [DataRow("(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))", DisplayName = "Check Expressions \"(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))\"")]
        [DataRow("((A*B)+C)+((D*B)+E)", DisplayName = "Check Expressions \"((A*B)+C)+((D*B)+E)\"")]
        [DataRow("(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)\"")]
        [DataRow("(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))\"")]
        [DataRow("(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)", DisplayName = "Check Expressions \"(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)\"")]
        [DataRow("(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)", DisplayName = "Check Expressions \"(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)\"")]
        [DataRow("((A*B)+C)+(-1*A)", DisplayName = "Check Expressions \"((A*B)+C)+(-1*A)\"")]
        [DataRow("(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I", DisplayName = "Check Expressions \"(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I\"")]
        [DataRow("((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I", DisplayName = "Check Expressions \"((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I\"")]
        [DataRow("((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)", DisplayName = "Check Expressions \"((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)\"")]
        [DataRow("(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))", DisplayName = "Check Expressions \"(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))\"")]
        [DataRow("(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)", DisplayName = "Check Expressions \"(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)\"")]
        [DataRow("(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L", DisplayName = "Check Expressions \"(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L\"")]
        [DataRow("(((A+(-1*B))*C)+D)+(B+(-1*A))", DisplayName = "Check Expressions \"(((A+(-1*B))*C)+D)+(B+(-1*A))\"")]
        [DataRow("((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))", DisplayName = "Check Expressions \"((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))\"")]
        [DataRow("((A+((B*C)+D))*E)+F+((C/G)*H)+I", DisplayName = "Check Expressions \"((A+((B*C)+D))*E)+F+((C/G)*H)+I\"")]
        [DataRow("(A+B)*C+D+(A+B)*E+F", DisplayName = "Check Expressions \"(A+B)*C+D+(A+B)*E+F\"")]
        [DataRow("A*B", DisplayName = "Check Expressions \"A*B\"")]
        [DataRow("((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G", DisplayName = "Check Expressions \"((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G\"")]
        [DataRow("((A/(1-B))*C)+D", DisplayName = "Check Expressions \"((A/(1-B))*C)+D\"")]
        [DataRow("(((A-(B*C))/(1-D))*E)+F", DisplayName = "Check Expressions \"(((A-(B*C))/(1-D))*E)+F\"")]
        [DataRow("(A*(1+(-1*B))+C)*D+E", DisplayName = "Check Expressions \"(A*(1+(-1*B))+C)*D+E\"")]
        [DataRow("(A+B)*C+D", DisplayName = "Check Expressions \"(A+B)*C+D\"")]
        [DataRow("(((A/B)*C*D)*E*F)+G", DisplayName = "Check Expressions \"(((A/B)*C*D)*E*F)+G\"")]
        [DataRow("((A-B)*C)+D", DisplayName = "Check Expressions \"((A-B)*C)+D\"")]
        [DataRow("((A/B)*C)+D", DisplayName = "Check Expressions \"((A/B)*C)+D\"")]
        [DataRow("((((A*B)+C)/D)*E)+F", DisplayName = "Check Expressions \"((((A*B)+C)/D)*E)+F\"")]
        [DataRow("((A/B)*C*D*E)+F", DisplayName = "Check Expressions \"((A/B)*C*D*E)+F\"")]
        [DataRow("(A*B*C)+D", DisplayName = "Check Expressions \"(A*B*C)+D\"")]
        [DataRow("(((A*B)+C)*D)+E", DisplayName = "Check Expressions \"(((A*B)+C)*D)+E\"")]
        [DataRow("(((A/B)*C*D)*E)+F", DisplayName = "Check Expressions \"(((A/B)*C*D)*E)+F\"")]
        [DataRow("(A*1)", DisplayName = "Check Expressions \"(A*1)\"")]
        [DataRow("(((A/B)+(-1*C))*D*E*F)+G", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*D*E*F)+G\"")]
        [DataRow("((A*B)+C)+(D*E*F)", DisplayName = "Check Expressions \"((A*B)+C)+(D*E*F)\"")]
        [DataRow("((A/(1+(-1*(B+C))))*D)+E", DisplayName = "Check Expressions \"((A/(1+(-1*(B+C))))*D)+E\"")]
        [DataRow("((A-(B*C))*D)+E", DisplayName = "Check Expressions \"((A-(B*C))*D)+E\"")]
        [DataRow("(((A+(-1*B))/C)*(D*E)*F)+G", DisplayName = "Check Expressions \"(((A+(-1*B))/C)*(D*E)*F)+G\"")]
        [DataRow("((A/B)*((C*D)*E)*F)+G", DisplayName = "Check Expressions \"((A/B)*((C*D)*E)*F)+G\"")]
        [DataRow("((((A/B)*C)+D)*((E*F)*G))+H", DisplayName = "Check Expressions \"((((A/B)*C)+D)*((E*F)*G))+H\"")]
        [DataRow("(((A/B)+(-1*C))*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A/B)+(-1*C))*((D*E)*F)*G)+H\"")]
        [DataRow("(((A+(-1*B))/C)*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A+(-1*B))/C)*((D*E)*F)*G)+H\"")]
        [DataRow("(((A/B)*(((C*D)*E)*F))+(C*D*G))+H", DisplayName = "Check Expressions \"(((A/B)*(((C*D)*E)*F))+(C*D*G))+H\"")]
        [DataRow("((A*B)+((A*C)-A)*D)+E", DisplayName = "Check Expressions \"((A*B)+((A*C)-A)*D)+E\"")]
        [DataRow("((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H", DisplayName = "Check Expressions \"((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H\"")]
        [DataRow("(((A/B)*((C*D)*E)*F)*G)+H", DisplayName = "Check Expressions \"(((A/B)*((C*D)*E)*F)*G)+H\"")]
        [DataRow("((A/B)*(((C*D)*E)*F))+G", DisplayName = "Check Expressions \"((A/B)*(((C*D)*E)*F))+G\"")]
        [DataRow("((A/B)*((C*D)*E))+F", DisplayName = "Check Expressions \"((A/B)*((C*D)*E))+F\"")]
        [DataRow("(A/(A+B))", DisplayName = "Check Expressions \"(A/(A+B))\"")]
        public void VerifyOptimizerForComplexExpressions(string input)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            var optimized = parsed.Optimize();
            TestContext.WriteLine($"As Optimized: {optimized}");

            var testValues = parsed.GenerateTestValues(includeNegatives: true);
            var variables = string.Join(", ", testValues.Select(kvp => (Name: kvp.Key, Value: kvp.Value)));
            TestContext.WriteLine($"Variables: {variables}");

            var resultAsParsed = parsed.Evaluate(testValues);
            var resultAsOptimized = optimized.Evaluate(testValues);

            TestContext.WriteLine($"Parsed Result: {resultAsParsed}");
            TestContext.WriteLine($"Optimized Result: {resultAsOptimized}");

            Assert.AreEqual(resultAsParsed, resultAsOptimized);
        }

        [TestMethod, Ignore]
        public void TestBuilder()
        {
            var formulas = @"XYZ";

            var expressions = from line in formulas.Split(Environment.NewLine)
                              let expression = line.ParseAsExpression<double>()
                              where expression != null
                              let variables = expression.GetDistinctVariableNames()
                              let replacements = variables.Select((v, i) => (v, new string((char)('A' + i), 1)))
                              let replaced = expression.ReplaceVariables(replacements)
                              select replaced; //.Distinct();

            var expressionStrings = expressions.Select(s => s.ToString().Replace(" ", "")).Distinct();

            foreach (var expression in expressionStrings)
            {
                this.TestContext.WriteLine($"{expression}");
                // this.TestContext.WriteLine($@"[DataRow(""{expression}"",DisplayName = ""Check Expressions \""{expression}\"""")]");
            }
        }

        //[TestMethod]
        //public void ParseAllOperatorsTest() => Assert.AreEqual("2 + 3 * 4 ^ 5 % 6 / 7 - 8", new Exp().Parse("2+3*4^5%6/7-8").ToString());

        /*
 
        public class OptimizerTests {

            @Test
            @DisplayName("Evaluated")
            public void evaluationTest(TestInfo testInfo) throws NotSupportedException {
                var expression = ExpressionParser.Parse("A+B");
                var variables = new HashMap<String, BigDecimal>();
                variables.put("A", new BigDecimal(1));
                variables.put("B", new BigDecimal(2));

                var optimized = ExpressionOptimizer.Optimize(expression);
                BigDecimal result;
                result = optimized.Evaluate(variables);
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized + "="
                        + result + "\t" + variables);
                assertEquals("A + B", optimized.toString());
                assertEquals(new BigDecimal(3), result);
            }

            @Test
            @DisplayName("Evaluated Negative/double negative Variable")
            public void evaluationNegativeMinusTest(TestInfo testInfo) throws NotSupportedException {
                var expression = ExpressionParser.Parse("-A---B");
                var variables = new HashMap<String, BigDecimal>();
                variables.put("A", new BigDecimal(1));
                variables.put("B", new BigDecimal(2));

                var optimized = ExpressionOptimizer.Optimize(expression);
                BigDecimal result;
                result = optimized.Evaluate(variables);
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized + "="
                        + result + "\t" + variables);
                assertEquals("-A - B", optimized.toString());
                assertEquals(new BigDecimal(-3), result);
            }

            @Test
            @DisplayName("Pre-Evaluate")
            public void preeval_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("A+B");
                var variables = new HashMap<String, BigDecimal>();
                variables.put("A", new BigDecimal(1));
                variables.put("B", new BigDecimal(2));
                var optimized = ExpressionOptimizer.PreEvaluate(expression, variables);
                var result = optimized.toString();
                System.out.println(
                        testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized + "\t" + variables);
                assertEquals("1 + 2", result);
            }

            @Test
            @DisplayName("Optimize with Pre-Evaluate")
            public void preevalAndOptimize_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("A+B+C");
                var variables = new HashMap<String, BigDecimal>();
                variables.put("A", new BigDecimal(1));
                variables.put("B", new BigDecimal(2));
                var optimized = ExpressionOptimizer.Optimize(expression, variables);
                var result = optimized.toString();
                System.out.println(
                        testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized + "\t" + variables);
                assertEquals("3 + C", result);
            }

            @Test
            @DisplayName("Complex Optimize with Pre-Evaluate")
            public void preevalAndOptimize_complex_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("3*A*(B*4)+D*(3+0^0)");
                var variables = new HashMap<String, BigDecimal>();
                variables.put("D", new BigDecimal(3));
                variables.put("B", new BigDecimal(2));
                var optimized = ExpressionOptimizer.Optimize(expression, variables);
                var result = optimized.toString();
                System.out.println(
                        testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized + "\t" + variables);
                assertEquals("24 * A + 12", result);
            }

            @Test
            public void ensureVariableNamesFromExpression_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("(A+B)*C");
                var variables = ExpressionIterator.GetDistinctVariableNames(expression).toArray(String[]::new);
                var variableStr = Arrays.toString(variables);
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + variableStr);
                assertEquals("[A, B, C]", variableStr);
            }

            @Test
            public void ensureOrderOfOperations_afterOptimize_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("(A+B)*C");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var expressionStr = expression.toString();
                var optimizedStr = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals(expressionStr, optimizedStr);
            }

            @Test
            public void simplify_andOrder_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("A+3+B");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("3 + A + B", result);
            }

            @Test
            public void simplify_andOrderDeeper_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("3*A*B*4");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("12 * A * B", result);
            }

            @Test
            @DisplayName("Optimize with complex re-order and reduction")
            public void simplify_andOrderComplex_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("3*A*(B*4)+D*(3+0^0)");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("12 * A * B + 4 * D", result);
            }

            @Test
            @DisplayName("Optimize simple reduction")
            public void simplify_numeric_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("2+3");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("5", result);
            }

            @Test
            @DisplayName("Optimize simple reduction for long chain")
            public void simplify_numericLong_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("2+3+4+5");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("14", result);
            }

            @Test
            @DisplayName("Optimize simple reduction with variable")
            public void simplify_moreComplexNumeric_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("A*(2+3)");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("5 * A", result);
            }


            @Test
            @DisplayName("Optimize complex reduction and trim")
            public void multipass_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("(A/A)/(A/A)*(A/A)/(A/A)");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("1", result);
            }

            @Test
            @DisplayName("Optimize extra wrapping")
            public void removeExtraWrapping_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("((A)+(B))");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("A + B", result);
            }


                */

    }
}
