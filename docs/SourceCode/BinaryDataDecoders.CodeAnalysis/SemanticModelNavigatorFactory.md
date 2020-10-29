# SemanticModelNavigatorFactory.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.CodeAnalysis\SemanticModelNavigatorFactory.cs

## Public Static Class - SemanticModelNavigatorFactory

### Members

#### Public Static Method - ToNavigable

#####  Parameters

 - this SemanticModel tree 
 - string ? baseUri = null 

#### Public Static Method - AsNode

#####  Parameters

 - this SemanticModel pointer 
 - string ? baseUri = null 

#### Private Static Method - GetSymbolAttributes

#####  Parameters

 - ISymbol symbol 

#### Private Static Method - AddSymbols

#####  Parameters

 - this IEnumerable < ( XName , string ? ) > ? existing 
 - SemanticModel semantic 
 - SyntaxNode ? node 

#### Private Static Method - BuildChildren

#####  Parameters

 - SemanticModel semantic 
 - SyntaxNode ? node 
 - ChildSyntaxList children 

#### Private Static Method - GetSymbolChildren

#####  Parameters

 - ISymbol symbol 
 - SemanticModel semantic 

