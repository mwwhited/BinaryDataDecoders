# ExtensibleElementNode.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleElementNode.cs

## Public Class - ExtensibleElementNode

### Attributes

 - DebuggerDisplay
 - (
 - "E:>{Name}"
 - )

### Members

#### Public Constructor - ExtensibleElementNode

#####  Parameters

 - XName name 
 - object item 
 - Func < object , string ? > ? valueSelector = null 
 - Func < object , IEnumerable < ( XName name , string ? value ) > ? > ? attributeSelector = null 
 - Func < object , IEnumerable < ( XName name , object child ) > ? > ? childSelector = null 
 - Func < object , IEnumerable < XName > ? > ? namespacesSelector = null 
 - Predicate < object > ? preserveWhitespace = null 

## Public Class - ExtensibleElementNode

### Attributes

 - DebuggerDisplay
 - (
 - "E:>{Name}"
 - )

### Members

#### Private ReadOnly Field - _item

##### Summary

 * Type: T 

#### Private ReadOnly Field - _valueSelector

##### Summary

 * Type: 

#### Private ReadOnly Field - _preserveWhitespace

##### Summary

 * Type: 

#### Private ReadOnly Field - _attributeSelector

##### Summary

 * Type: 

#### Private ReadOnly Field - _childSelector

##### Summary

 * Type: 

#### Private ReadOnly Field - _namespacesSelector

##### Summary

 * Type: 

#### Private ReadOnly Field - _value

##### Summary

 * Type: 

#### Private ReadOnly Field - _children

##### Summary

 * Type: 

#### Private ReadOnly Field - _attributes

##### Summary

 * Type: 

#### Private ReadOnly Field - _namespaces

##### Summary

 * Type: 

#### Public Constructor - ExtensibleElementNode

#####  Parameters

 - XName name 
 - T item 
 - Func < T , string ? > ? valueSelector = null 
 - Func < T , IEnumerable < ( XName name , string ? value ) > ? > ? attributeSelector = null 
 - Func < T , IEnumerable < ( XName name , T child ) > ? > ? childSelector = null 
 - Func < T , IEnumerable < XName > ? > ? namespacesSelector = null 
 - Predicate < T > ? preserveWhitespace = null 

#### Constructor - ExtensibleElementNode

#####  Parameters

 - INode ? parent 
 - XName name 
 - T item 
 - Func < T , string ? > ? valueSelector 
 - Func < T , IEnumerable < ( XName name , string ? value ) > ? > ? attributeSelector 
 - Func < T , IEnumerable < ( XName name , T child ) > ? > ? childSelector 
 - Func < T , IEnumerable < XName > ? > ? namespacesSelector 
 - Predicate < T > ? preserveWhitespace = null 

#### Public Property - FirstChild

##### Summary

 * Type: INode ? 

#### Public Property - FirstAttribute

##### Summary

 * Type: IAttributeNode ? 

#### Public Property - FirstNamespace

##### Summary

 * Type: INamespaceNode ? 

#### Public Property - Next

##### Summary

 * Type: INode ? 

#### Public Property - Previous

##### Summary

 * Type: INode ? 

#### Public Property - Parent

##### Summary

 * Type: INode ? 

#### Public Property - Name

##### Summary

 * Type: XName 

#### Public Property - Value

##### Summary

 * Type: string ? 

#### Public Property - NodeType

##### Summary

 * Type: XPathNodeType 

#### Property - Next

##### Summary

 * Type: INode ? ISimpleNode . 

#### Property - Previous

##### Summary

 * Type: INode ? ISimpleNode . 

