# JsonPathVisitor.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Text.Json\obj\Debug\netstandard2.1\JsonPathVisitor.cs

## Public Interface - IJsonPathVisitor

### Comments

 <summary>
 This interface defines a complete generic visitor for a parse tree produced
 by <seecref="JsonPathParser"/>.
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
 Visit a parse tree produced by <seecref="JsonPathParser.start"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . StartContext context 

#### Method - VisitPath

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.path"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . PathContext context 

#### Method - VisitPathBase

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.pathBase"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . PathBaseContext context 

#### Method - VisitSequence

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.sequence"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . SequenceContext context 

#### Method - VisitSequenceItem

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.sequenceItem"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . SequenceItemContext context 

#### Method - VisitBracket

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.bracket"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . BracketContext context 

#### Method - VisitFilter

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.filter"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FilterContext context 

#### Method - VisitRange

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.range"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . RangeContext context 

#### Method - VisitOperand

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.operand"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . OperandContext context 

#### Method - VisitQueryLogical

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryLogical</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryLogicalContext context 

#### Method - VisitQueryRelational

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryRelational</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryRelationalContext context 

#### Method - VisitQueryPath

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryPath</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryPathContext context 

#### Method - VisitIdentity

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.identity"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . IdentityContext context 

#### Method - VisitString

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.string"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . StringContext context 

#### Method - VisitFunction

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.function"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FunctionContext context 

#### Method - VisitFunctionParameter

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.functionParameter"/>.
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FunctionParameterContext context 

