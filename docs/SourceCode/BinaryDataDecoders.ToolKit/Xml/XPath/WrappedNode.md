# WrappedNode.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Xml/XPath/WrappedNode.cs

## Internal Class - WrappedNode

### Attributes

 - DebuggerDisplay
 - (
 - "{Current}-{Source}"
 - )

### Members

#### Private Constructor - WrappedNode

#####  Parameters

 - string source 
 - IXPathNavigable nav 
 - IWrappedNode ? previous 

#### Public Property - Source

##### Summary

 * Type: string 

#### Public Property - Previous

##### Summary

 * Type: IWrappedNode ? 

#### Public Property - Current

##### Summary

 * Type: XPathNavigator 

#### Public Property - Next

##### Summary

 * Type: IWrappedNode ? 

#### Public Property - First

##### Summary

 * Type: IWrappedNode 

#### Public Property - Last

##### Summary

 * Type: IWrappedNode 

#### Public Static Method - Build

#####  Parameters

 - IEnumerable < ( string source , IXPathNavigable ? navigator ) > children 

