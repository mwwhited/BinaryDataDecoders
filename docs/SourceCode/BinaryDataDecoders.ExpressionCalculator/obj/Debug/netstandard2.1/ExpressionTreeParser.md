# ExpressionTreeParser.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ExpressionCalculator\obj\Debug\netstandard2.1\ExpressionTreeParser.cs

## Public Class - ExpressionTreeParser

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

#### Static Field - decisionToDFA

##### Summary

 * Type: 

#### Static Field - sharedContextCache

##### Summary

 * Type: PredictionContextCache 

#### Public Field - T__0

##### Summary

 * Type: 

#### Public Field - RULE_start

##### Summary

 * Type: 

#### Public Static ReadOnly Field - ruleNames

##### Summary

 * Type: 

#### Private Static ReadOnly Field - _LiteralNames

##### Summary

 * Type: 

#### Private Static ReadOnly Field - _SymbolicNames

##### Summary

 * Type: 

#### Public Static ReadOnly Field - DefaultVocabulary

##### Summary

 * Type: IVocabulary 

#### Public Property - Vocabulary

##### Attributes

 - NotNull

##### Summary

 * Type: [ NotNull ] IVocabulary 

#### Public Property - GrammarFileName

##### Summary

 * Type: string 

#### Public Property - RuleNames

##### Summary

 * Type: string [  ] 

#### Public Property - SerializedAtn

##### Summary

 * Type: string 

#### Static Constructor - ExpressionTreeParser


#### Public Constructor - ExpressionTreeParser

#####  Parameters

 - ITokenStream input 

#### Public Constructor - ExpressionTreeParser

#####  Parameters

 - ITokenStream input 
 - TextWriter output 
 - TextWriter errorOutput 

#### Public Method - expression


#### Public Method - Eof


#### Public Constructor - StartContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - start

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - NUMBER


#### Public Method - VARIABLE


#### Public Constructor - ValueContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - value

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Field - inner

##### Summary

 * Type: ExpressionContext 

#### Public Method - expression


#### Public Constructor - InnerExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - innerExpression

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Method - SUB


#### Public Method - value


#### Public Method - innerExpression


#### Public Method - unaryOperatorLeftExpression


#### Public Constructor - UnaryOperatorLeftExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - unaryOperatorLeftExpression

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Method - value


#### Public Method - FACTORIAL


#### Public Method - innerExpression


#### Public Method - unaryOperatorRightExpression


#### Public Constructor - UnaryOperatorRightExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - unaryOperatorRightExpression

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Private Method - unaryOperatorRightExpression

#####  Parameters

 - int _p 

#### Public Field - left

##### Summary

 * Type: ExpressionContext 

#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Field - right

##### Summary

 * Type: ExpressionContext 

#### Public Method - value


#### Public Method - unaryOperatorLeftExpression


#### Public Method - unaryOperatorRightExpression


#### Public Method - innerExpression


#### Public Method - expression


#### Public Method - expression

#####  Parameters

 - int i 

#### Public Method - POW


#### Public Method - MUL


#### Public Method - DIV


#### Public Method - MOD


#### Public Method - ADD


#### Public Method - SUB


#### Public Constructor - ExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - expression

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Private Method - expression

#####  Parameters

 - int _p 

#### Public Method - Sempred

#####  Parameters

 - RuleContext _localctx 
 - int ruleIndex 
 - int predIndex 

#### Private Method - unaryOperatorRightExpression_sempred

#####  Parameters

 - UnaryOperatorRightExpressionContext _localctx 
 - int predIndex 

#### Private Method - expression_sempred

#####  Parameters

 - ExpressionContext _localctx 
 - int predIndex 

#### Private Static Field - _serializedATN

##### Summary

 * Type: 

#### Public Static ReadOnly Field - _ATN

##### Summary

 * Type: ATN 

## Public Class - StartContext

### Members

#### Public Method - expression


#### Public Method - Eof


#### Public Constructor - StartContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - ValueContext

### Members

#### Public Method - NUMBER


#### Public Method - VARIABLE


#### Public Constructor - ValueContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - InnerExpressionContext

### Members

#### Public Field - inner

##### Summary

 * Type: ExpressionContext 

#### Public Method - expression


#### Public Constructor - InnerExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - UnaryOperatorLeftExpressionContext

### Members

#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Method - SUB


#### Public Method - value


#### Public Method - innerExpression


#### Public Method - unaryOperatorLeftExpression


#### Public Constructor - UnaryOperatorLeftExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - UnaryOperatorRightExpressionContext

### Members

#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Method - value


#### Public Method - FACTORIAL


#### Public Method - innerExpression


#### Public Method - unaryOperatorRightExpression


#### Public Constructor - UnaryOperatorRightExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - ExpressionContext

### Members

#### Public Field - left

##### Summary

 * Type: ExpressionContext 

#### Public Field - @operator

##### Summary

 * Type: IToken 

#### Public Field - right

##### Summary

 * Type: ExpressionContext 

#### Public Method - value


#### Public Method - unaryOperatorLeftExpression


#### Public Method - unaryOperatorRightExpression


#### Public Method - innerExpression


#### Public Method - expression


#### Public Method - expression

#####  Parameters

 - int i 

#### Public Method - POW


#### Public Method - MUL


#### Public Method - DIV


#### Public Method - MOD


#### Public Method - ADD


#### Public Method - SUB


#### Public Constructor - ExpressionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

