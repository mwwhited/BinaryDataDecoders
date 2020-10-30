# ExpressionTreeVisitor.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ExpressionCalculator\obj\Release\netstandard2.1\ExpressionTreeVisitor.cs

## Public Interface - IExpressionTreeVisitor

### Comments

 <summary>
 This interface defines a complete generic visitor for a parse tree produced
 by <seecref="ExpressionTreeParser"/>.
 </summary>
 <typeparamname="Result">The return type of the visit operation.</typeparam>

### Attributes

 - System
 - .
 - CodeDom
 - .
 - Compiler
 - .
 - GeneratedCode
 - (
 - "ANTLR"
 - ,
 - "4.8"
 - )
 - System
 - .
 - CLSCompliant
 - (
 - false
 - )

### Members

#### Method - VisitStart

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.start"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . StartContext context 

#### Method - VisitValue

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.value"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ValueContext context 

#### Method - VisitInnerExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.innerExpression"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . InnerExpressionContext context 

#### Method - VisitUnaryOperatorLeftExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.unaryOperatorLeftExpression"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorLeftExpressionContext context 

#### Method - VisitUnaryOperatorRightExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.unaryOperatorRightExpression"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorRightExpressionContext context 

#### Method - VisitExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.expression"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ExpressionContext context 

