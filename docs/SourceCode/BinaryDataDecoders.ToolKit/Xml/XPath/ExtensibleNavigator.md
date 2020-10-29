# ExtensibleNavigator.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleNavigator.cs

## Public Class - ExtensibleNavigator

### Members

#### Private Field - _current

##### Summary

 * Type: INode 

#### Private ReadOnly Field - _namespacePrefixes

##### Summary

 * Type: 

#### Public Constructor - ExtensibleNavigator

#####  Parameters

 - INode current 
 - string ? baseUri = null 

#### Private Constructor - ExtensibleNavigator

#####  Parameters

 - INode current 
 - string ? baseUri 
 - XmlNameTable ? nameTable 
 - IDictionary < string , string > ? namespacePrefixes 

#### Public Property - Name

##### Summary

 * Type: string 

#### Public Property - LocalName

##### Summary

 * Type: string 

#### Public Property - NamespaceURI

##### Summary

 * Type: string 

#### Public Property - NodeType

##### Summary

 * Type: XPathNodeType 

#### Public Property - Prefix

##### Summary

 * Type: string 

#### Public Method - LookupPrefix

#####  Parameters

 - string namespaceURI 

#### Public Method - LookupNamespace

#####  Parameters

 - string prefix 

#### Public Property - Value

##### Summary

 * Type: string 

#### Public Property - IsEmptyElement

##### Summary

 * Type: bool 

#### Public Property - HasAttributes

##### Summary

 * Type: bool 

#### Public Property - HasChildren

##### Summary

 * Type: bool 

#### Public Property - BaseURI

##### Summary

 * Type: string 

#### Public Property - NameTable

##### Summary

 * Type: XmlNameTable 

#### Public Method - Clone


#### Public Method - MoveToId

#####  Parameters

 - string id 

#### Public Method - IsSamePosition

#####  Parameters

 - XPathNavigator other 

#### Public Method - MoveTo

#####  Parameters

 - XPathNavigator other 

#### Public Method - MoveToFirstNamespace

#####  Parameters

 - XPathNamespaceScope namespaceScope 

#### Public Method - MoveToNextNamespace

#####  Parameters

 - XPathNamespaceScope namespaceScope 

#### Public Method - MoveToFirstAttribute


#### Public Method - MoveToNextAttribute


#### Public Method - MoveToParent


#### Public Method - MoveToFirstChild


#### Public Method - MoveToNext


#### Public Method - MoveToPrevious


