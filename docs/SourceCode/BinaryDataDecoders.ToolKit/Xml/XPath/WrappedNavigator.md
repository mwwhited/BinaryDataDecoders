# WrappedNavigator.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Xml/XPath/WrappedNavigator.cs

## Internal Class - WrappedNavigator

### Members

#### Private Field - _state

##### Summary

 * Type: WrapperState 

#### Private Field - _node

##### Summary

 * Type: IWrappedNode 

#### Public Method - Clone


#### Public Property - BaseURI

##### Summary

 * Type: string 

#### Public Property - IsEmptyElement

##### Summary

 * Type: bool 

#### Public Property - LocalName

##### Summary

 * Type: string 

#### Public Property - Name

##### Summary

 * Type: string 

#### Public Property - NamespaceURI

##### Summary

 * Type: string 

#### Public Property - NameTable

##### Summary

 * Type: XmlNameTable 

#### Public Property - NodeType

##### Summary

 * Type: XPathNodeType 

#### Public Property - Prefix

##### Summary

 * Type: string 

#### Public Property - Value

##### Summary

 * Type: string 

#### Public Method - LookupNamespace

#####  Parameters

 - string prefix 

#### Public Method - LookupPrefix

#####  Parameters

 - string namespaceURI 

#### Public Property - HasAttributes

##### Summary

 * Type: bool 

#### Public Property - HasChildren

##### Summary

 * Type: bool 

#### Public Method - IsSamePosition

#####  Parameters

 - XPathNavigator other 

#### Public Method - MoveTo

#####  Parameters

 - XPathNavigator other 

#### Public Method - MoveToFirstAttribute


#### Public Method - MoveToNextNamespace

#####  Parameters

 - XPathNamespaceScope namespaceScope 

#### Public Method - MoveToFirstNamespace

#####  Parameters

 - XPathNamespaceScope namespaceScope 

#### Public Method - MoveToId

#####  Parameters

 - string id 

#### Public Method - MoveToNextAttribute


#### Public Method - MoveToFirstChild


#### Private Method - MoveToFirstChildInternal


#### Public Method - MoveToNext


#### Private Method - MoveToNextInternal


#### Public Method - MoveToPrevious


#### Private Method - MoveToPreviousInternal


#### Public Method - MoveToParent


#### Public Method - MoveToRoot


