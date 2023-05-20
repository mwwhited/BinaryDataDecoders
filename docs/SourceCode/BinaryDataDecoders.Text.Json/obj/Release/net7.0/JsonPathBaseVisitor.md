# JsonPathBaseVisitor.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Text.Json/obj/Release/net7.0/JsonPathBaseVisitor.cs

## Public Class - JsonPathBaseVisitor

### Comments

 <summary>
 This class provides an empty implementation of <seecref="IJsonPathVisitor{Result}"/>,
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
 Visit a parse tree produced by <seecref="JsonPathParser.start"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . StartContext context 

#### Public Method - VisitPath

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.path"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . PathContext context 

#### Public Method - VisitPathBase

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.pathBase"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . PathBaseContext context 

#### Public Method - VisitSequence

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.sequence"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . SequenceContext context 

#### Public Method - VisitSequenceItem

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.sequenceItem"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . SequenceItemContext context 

#### Public Method - VisitBracket

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.bracket"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . BracketContext context 

#### Public Method - VisitFilter

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.filter"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FilterContext context 

#### Public Method - VisitRange

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.range"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . RangeContext context 

#### Public Method - VisitOperand

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.operand"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . OperandContext context 

#### Public Method - VisitQueryLogical

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryLogical</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryLogicalContext context 

#### Public Method - VisitQueryRelational

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryRelational</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryRelationalContext context 

#### Public Method - VisitQueryPath

##### Comments

 <summary>
 Visit a parse tree produced by the <c>queryPath</c>
 labeled alternative in <seecref="JsonPathParser.query"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . QueryPathContext context 

#### Public Method - VisitIdentity

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.identity"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . IdentityContext context 

#### Public Method - VisitString

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.string"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . StringContext context 

#### Public Method - VisitFunction

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.function"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FunctionContext context 

#### Public Method - VisitFunctionParameter

##### Comments

 <summary>
 Visit a parse tree produced by <seecref="JsonPathParser.functionParameter"/>.
 <para>
 The default implementation returns the result of calling <seecref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
 on <paramrefname="context"/>.
 </para>
 </summary>
 <paramname="context">The parse tree.</param>
 <return>The visitor result.</return>

#####  Parameters

 - [ NotNull ] JsonPathParser . FunctionParameterContext context 

