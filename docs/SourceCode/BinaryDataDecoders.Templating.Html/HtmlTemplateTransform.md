# HtmlTemplateTransform.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Templating.Html/HtmlTemplateTransform.cs

## Public Class - HtmlTemplateTransform

### Attributes

 - TemplateTransform
 - (
 - MediaTypes
 - .
 - Html
 - )

### Members

#### Private ReadOnly Field - _instanceFactory

##### Summary

 * Type: IInstanceFactory 

#### Private ReadOnly Field - _htmlVisitor

##### Summary

 * Type: IHtmlDocumentVistor 

#### Public Constructor - HtmlTemplateTransform

#####  Parameters

 - IInstanceFactory instanceFactory 
 - IHtmlDocumentVistor htmlVisitor 

#### Public Method - ToXPathNavigator

#####  Parameters

 - string content 

#### Public Async Method - Transform

#####  Parameters

 - object source 
 - string template 

