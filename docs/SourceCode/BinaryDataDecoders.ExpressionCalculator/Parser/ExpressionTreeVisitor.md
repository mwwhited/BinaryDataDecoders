# ExpressionTreeVisitor.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ExpressionCalculator/Parser/ExpressionTreeVisitor.cs

## Public Class - ExpressionTreeVisitor

### Members

#### Private Static ReadOnly Field - _evaluator

##### Summary

 * Type: 

#### Public Method - VisitStart

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . StartContext context 

#### Public Method - VisitErrorNode

#####  Parameters

 - IErrorNode node 

#### Public Method - VisitExpression

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ExpressionContext context 

#### Public Method - VisitInnerExpression

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . InnerExpressionContext context 

#### Public Method - VisitValue

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . ValueContext context 

#### Private Method - VisitVariable

#####  Parameters

 - ITerminalNode node 

#### Private Method - VisitNumber

#####  Parameters

 - ITerminalNode node 

#### Public Method - VisitUnaryOperatorLeftExpression

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorLeftExpressionContext context 

#### Public Method - VisitUnaryOperatorRightExpression

#####  Parameters

 - [ NotNull ] ExpressionTreeParser . UnaryOperatorRightExpressionContext context 

#### Private Method - ChainVisit

#####  Parameters

 - params IParseTree [  ] nodes 

#### Private Method - EnsureChildCount

#####  Parameters

 - TParserRuleContext context 
 - string ? expected = null 
 - int childCount = 2 

