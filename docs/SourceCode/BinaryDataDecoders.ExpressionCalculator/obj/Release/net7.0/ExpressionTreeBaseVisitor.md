# ExpressionTreeBaseVisitor.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ExpressionCalculator/obj/Release/net7.0/ExpressionTreeBaseVisitor.cs

## Public Class - ExpressionTreeBaseVisitor

### Comments

 <summary>
 This class provides an empty implementation of <seecref="IExpressionTreeVisitor{Result}"/>,
 which can be extended to create a visitor which only needs to handle a subset
 of the available methods.
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
 - "4.12.0"
 - )
 - System
 - .
 - Diagnostics
 - .
 - DebuggerNonUserCode
 - System
 - .
 - CLSCompliant
 - (
 - false
 - )

### Members

#### Public Method - VisitStart

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.start"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . StartContext context 

#### Public Method - VisitValue

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.value"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ValueContext context 

#### Public Method - VisitInnerExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.innerExpression"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . InnerExpressionContext context 

#### Public Method - VisitUnaryOperatorLeftExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.unaryOperatorLeftExpression"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorLeftExpressionContext context 

#### Public Method - VisitUnaryOperatorRightExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.unaryOperatorRightExpression"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorRightExpressionContext context 

#### Public Method - VisitExpression

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="ExpressionTreeParser.expression"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ExpressionContext context 

