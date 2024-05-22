﻿using BinaryDataDecoders.ExpressionCalculator.Expressions;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions;

[TestClass]
public class ExpressionBaseTests
{
    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_Expression()
    {
        ExpressionBase<decimal> exp = "A+B";
        string result = exp;
        Assert.IsInstanceOfType(exp, typeof(BinaryOperatorExpression<decimal>));
        Assert.AreEqual("A + B", result);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_Variable()
    {
        ExpressionBase<decimal> exp = "A";
        string result = exp;
        Assert.IsInstanceOfType(exp, typeof(VariableExpression<decimal>));
        Assert.AreEqual("A", result);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_Number()
    {
        ExpressionBase<decimal> exp = "1.45";
        string result = exp;
        Assert.IsInstanceOfType(exp, typeof(NumberExpression<decimal>));
        Assert.AreEqual("1.45", result);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_OverlyComplex()
    {
        double result = ((ExpressionBase<decimal>)"A+B").PreEvaluate(("A", 1), ("B", 2.3));
        Assert.AreEqual(3.3, result);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_MoreOverlyComplex()
    {
        ExpressionBase<decimal> exp = "A+B";
        double result = ((ExpressionBase<decimal>)"A+B").PreEvaluate(("A", "B"), ("B", 2.3));
        Assert.AreEqual(4.6, result);
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
    public void ImplicitConvertTest_WayMoreOverlyComplex()
    {
        double result = "A+B".PreEvaluate(("A", "B+B"), ("B", 2.3));
        Assert.AreEqual(6.9, result);
    }
}
