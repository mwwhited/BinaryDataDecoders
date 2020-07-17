using BinaryDataDecoders.ExpressionCalculator.Parser;
using BinaryDataDecoders.ExpressionCalculator.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ExpressionParser = BinaryDataDecoders.ExpressionCalculator.Parser.ExpressionParser<double>;

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

        public void OptimizerTests(string input, string result)
        {
            TestContext.WriteLine($"Input: {input}");
            var parsed = new ExpressionParser().Parse(input);
            TestContext.WriteLine($"As Parsed: {parsed}");
            var optimized = parsed.Optimize();
            TestContext.WriteLine($"As optimized: {optimized}");
            Assert.AreEqual(result, optimized.ToString());
        }

        //[TestMethod]
        //public void ParseAllOperatorsTest() => Assert.AreEqual("2 + 3 * 4 ^ 5 % 6 / 7 - 8", new Exp().Parse("2+3*4^5%6/7-8").ToString());

        /*
        package tests;

        import static org.junit.jupiter.api.Assertions.*;

        import java.math.BigDecimal;
        import java.util.*;
        import org.junit.jupiter.api.*;
        import expressions.NotSupportedException;
        import tools.*;

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
            @DisplayName("Execute all supported operations")
            public void simplify_allOperators_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("2+3*4^5%6/7-8");
                var optimized = ExpressionOptimizer.Optimize(expression, null);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("-6", result);
            }

            @Test
            @DisplayName("Execute all supported operations")
            public void parse_allOperators_test(TestInfo testInfo) {
                var input = "2+3*4^5%6/7-8";
                var expression = ExpressionParser.Parse(input);
                var result = expression.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + input + "\t=>\t" + expression);
                assertEquals("2 + 3 * 4 ^ 5 % 6 / 7 - 8", result);
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

            @Test
            public void power_NToZero_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N^0");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("1", result);
            }

            @Test
            public void power_Zero2Zero_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0^0");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("1", result);
            }

            @Test
            public void power_ZeroToN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0^N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void power_NToOne_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N^1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void multiply_ZeroToN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0*N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void multiply_NToZero_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N*0");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void multiply_OneoToN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("1*N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void multiply_NToOne_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N*1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void multiply_NegativeOneToN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("-1*N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("-N", result);
            }

            @Test
            public void multiply_NToNegativeOne_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N*-1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("-N", result);
            }

            @Test
            public void divide_ZeroByN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0/N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test // ArithmeticException
            public void divide_NByZero_test(TestInfo testInfo) { // expect throw
                var expression = ExpressionParser.Parse("N/0");
                try {
                    ExpressionOptimizer.Optimize(expression);
                    fail("Expeced Divide by Zero Exception");
                } catch (java.lang.ArithmeticException e) {
                    // Note: Expected to get here!
                    System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\tERROR: " + e.getMessage() + "!");
                }
            }

            @Test
            public void divide_NByN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N/N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("1", result);
            }

            @Test
            public void divide_NBy1_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N/1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void modulo_ZeroByN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0%N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void modulo_NByZero_test(TestInfo testInfo) { // expect throw
                var expression = ExpressionParser.Parse("N%0");
                try {
                    ExpressionOptimizer.Optimize(expression);
                    fail("Expeced Divide by Zero Exception");
                } catch (java.lang.ArithmeticException e) {
                    // Note: Expected to get here!
                    System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\tERROR: " + e.getMessage() + "!");
                }
            }

            @Test
            public void modulo_NByN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N%N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void modulo_NByOne_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N%1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void modulo_NByNegativeOne_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N%-1");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("0", result);
            }

            @Test
            public void add_ZeroToN_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("0+N");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void add_NToZero_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N+0");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }

            @Test
            public void subtract_NLessZero_test(TestInfo testInfo) {
                var expression = ExpressionParser.Parse("N-0");
                var optimized = ExpressionOptimizer.Optimize(expression);
                var result = optimized.toString();
                System.out.println(testInfo.getDisplayName() + ":\t" + expression + "\t=>\t" + optimized);
                assertEquals("N", result);
            }
        }

                */

    }
}
