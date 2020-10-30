# JsonPathParser.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Text.Json\obj\Debug\netstandard2.1\JsonPathParser.cs

## Public Class - JsonPathParser

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

#### Static Constructor - JsonPathParser


#### Public Constructor - JsonPathParser

#####  Parameters

 - ITokenStream input 

#### Public Constructor - JsonPathParser

#####  Parameters

 - ITokenStream input 
 - TextWriter output 
 - TextWriter errorOutput 

#### Public Method - path


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


#### Public Method - pathBase


#### Public Method - sequence


#### Public Method - function


#### Public Constructor - PathContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - path

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - ROOT


#### Public Method - RELATIVE


#### Public Constructor - PathBaseContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - pathBase

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - sequenceItem


#### Public Method - sequence


#### Public Constructor - SequenceContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - sequence

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - WILDCARD


#### Public Method - identity


#### Public Method - bracket


#### Public Method - filter


#### Public Method - function


#### Public Method - PATH_SEPERATOR


#### Public Method - DESCENDANTS


#### Public Constructor - SequenceItemContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - sequenceItem

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - WILDCARD


#### Public Method - NUMBER


#### Public Method - NUMBER

#####  Parameters

 - int i 

#### Public Method - @string


#### Public Method - @string

#####  Parameters

 - int i 

#### Public Method - range


#### Public Method - function


#### Public Constructor - BracketContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - bracket

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - query


#### Public Constructor - FilterContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - filter

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Field - rangeStart

##### Summary

 * Type: IToken 

#### Public Field - rangeEnd

##### Summary

 * Type: IToken 

#### Public Field - rangeStep

##### Summary

 * Type: IToken 

#### Public Method - NUMBER


#### Public Method - NUMBER

#####  Parameters

 - int i 

#### Public Constructor - RangeContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - range

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - path


#### Public Method - @string


#### Public Method - NUMBER


#### Public Constructor - OperandContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - operand

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Constructor - QueryContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Constructor - QueryContext


#### Public Method - CopyFrom

#####  Parameters

 - QueryContext context 

#### Public Field - relationLeft

##### Summary

 * Type: QueryContext 

#### Public Field - relationRight

##### Summary

 * Type: QueryContext 

#### Public Method - LOGICAL


#### Public Method - query


#### Public Method - query

#####  Parameters

 - int i 

#### Public Constructor - QueryLogicalContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Field - relationLeft

##### Summary

 * Type: OperandContext 

#### Public Field - relationRight

##### Summary

 * Type: OperandContext 

#### Public Method - RELATIONAL


#### Public Method - operand


#### Public Method - operand

#####  Parameters

 - int i 

#### Public Constructor - QueryRelationalContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - path


#### Public Constructor - QueryPathContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - query

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Private Method - query

#####  Parameters

 - int _p 

#### Public Method - IDENTITY


#### Public Constructor - IdentityContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - identity

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - QUOTED_STRING


#### Public Constructor - StringContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - @string

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - identity


#### Public Method - functionParameter


#### Public Method - functionParameter

#####  Parameters

 - int i 

#### Public Constructor - FunctionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - function

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - operand


#### Public Method - pathBase


#### Public Method - DECIMAL


#### Public Constructor - FunctionParameterContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

#### Public Method - functionParameter

##### Attributes

 - RuleVersion
 - (
 - 0
 - )


#### Public Method - Sempred

#####  Parameters

 - RuleContext _localctx 
 - int ruleIndex 
 - int predIndex 

#### Private Method - query_sempred

#####  Parameters

 - QueryContext _localctx 
 - int predIndex 

#### Private Static Field - _serializedATN

##### Summary

 * Type: 

#### Public Static ReadOnly Field - _ATN

##### Summary

 * Type: ATN 

## Public Class - StartContext

### Members

#### Public Method - path


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

## Public Class - PathContext

### Members

#### Public Method - pathBase


#### Public Method - sequence


#### Public Method - function


#### Public Constructor - PathContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - PathBaseContext

### Members

#### Public Method - ROOT


#### Public Method - RELATIVE


#### Public Constructor - PathBaseContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - SequenceContext

### Members

#### Public Method - sequenceItem


#### Public Method - sequence


#### Public Constructor - SequenceContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - SequenceItemContext

### Members

#### Public Method - WILDCARD


#### Public Method - identity


#### Public Method - bracket


#### Public Method - filter


#### Public Method - function


#### Public Method - PATH_SEPERATOR


#### Public Method - DESCENDANTS


#### Public Constructor - SequenceItemContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - BracketContext

### Members

#### Public Method - WILDCARD


#### Public Method - NUMBER


#### Public Method - NUMBER

#####  Parameters

 - int i 

#### Public Method - @string


#### Public Method - @string

#####  Parameters

 - int i 

#### Public Method - range


#### Public Method - function


#### Public Constructor - BracketContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - FilterContext

### Members

#### Public Method - query


#### Public Constructor - FilterContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - RangeContext

### Members

#### Public Field - rangeStart

##### Summary

 * Type: IToken 

#### Public Field - rangeEnd

##### Summary

 * Type: IToken 

#### Public Field - rangeStep

##### Summary

 * Type: IToken 

#### Public Method - NUMBER


#### Public Method - NUMBER

#####  Parameters

 - int i 

#### Public Constructor - RangeContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - OperandContext

### Members

#### Public Method - path


#### Public Method - @string


#### Public Method - NUMBER


#### Public Constructor - OperandContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - QueryContext

### Members

#### Public Constructor - QueryContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Constructor - QueryContext


#### Public Method - CopyFrom

#####  Parameters

 - QueryContext context 

## Public Class - QueryLogicalContext

### Members

#### Public Field - relationLeft

##### Summary

 * Type: QueryContext 

#### Public Field - relationRight

##### Summary

 * Type: QueryContext 

#### Public Method - LOGICAL


#### Public Method - query


#### Public Method - query

#####  Parameters

 - int i 

#### Public Constructor - QueryLogicalContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - QueryRelationalContext

### Members

#### Public Field - relationLeft

##### Summary

 * Type: OperandContext 

#### Public Field - relationRight

##### Summary

 * Type: OperandContext 

#### Public Method - RELATIONAL


#### Public Method - operand


#### Public Method - operand

#####  Parameters

 - int i 

#### Public Constructor - QueryRelationalContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - QueryPathContext

### Members

#### Public Method - path


#### Public Constructor - QueryPathContext

#####  Parameters

 - QueryContext context 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - IdentityContext

### Members

#### Public Method - IDENTITY


#### Public Constructor - IdentityContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - StringContext

### Members

#### Public Method - QUOTED_STRING


#### Public Constructor - StringContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - FunctionContext

### Members

#### Public Method - identity


#### Public Method - functionParameter


#### Public Method - functionParameter

#####  Parameters

 - int i 

#### Public Constructor - FunctionContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

## Public Class - FunctionParameterContext

### Members

#### Public Method - operand


#### Public Method - pathBase


#### Public Method - DECIMAL


#### Public Constructor - FunctionParameterContext

#####  Parameters

 - ParserRuleContext parent 
 - int invokingState 

#### Public Property - RuleIndex

##### Summary

 * Type: int 

#### Public Method - Accept

#####  Parameters

 - IParseTreeVisitor < TResult > visitor 

