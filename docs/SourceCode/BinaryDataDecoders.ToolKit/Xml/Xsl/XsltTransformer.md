# XsltTransformer.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltTransformer.cs

## Public Class - XsltTransformer

### Comments

 <summary>
 Implementation of XsltTransformer
 </summary>

### Members

#### Private ReadOnly Field - _sandbox

##### Summary

 * Type: 

#### Private ReadOnly Field - _extensions

##### Summary

 * Type: 

#### Public Constructor - XsltTransformer

##### Comments

 <summary>
 create instance of XsltTransformer
 </summary>
 <paramname="extensions">optional extensions for XSLT Transform</param>

#####  Parameters

 - string sandbox 
 - params object [  ] extensions 

#### Public Method - ReadAsXml

##### Comments

 <summary>
 Read input file as XML
 </summary>
 <paramname="fileName"></param>
 <returns></returns>

#####  Parameters

 - string fileName 

#### Public Method - Transform

##### Comments

 <summary>
 Single action transform
 </summary>
 <paramname="template">path for XSLT style-sheet</param>
 <paramname="input">source XML file</param>
 <paramname="output">resulting text content</param>

#####  Parameters

 - string template 
 - string input 
 - string output 

#### Public Method - Transform

##### Comments

 <summary>
 Single action transform
 </summary>
 <paramname="template">path for XSLT style-sheet</param>
 <paramname="inputSource"></param>
 <paramname="input">source XML file</param>
 <paramname="output">resulting text content</param>

#####  Parameters

 - string template 
 - string inputSource 
 - IXPathNavigable input 
 - string output 

#### Public Method - TransformAll

##### Comments

 <summary>
 Multi-action transform. 
 </summary>
 <paramname="template">path for XSLT style-sheet</param>
 <paramname="input">Wild card allowed for multiple files</param>
 <paramname="output">Output and suffix per file.</param>

#####  Parameters

 - string template 
 - string input 
 - string output 
 - string ? excludeInputSource = null 

#### Public Method - TransformAll

##### Comments

 <summary>
 Multi-action transform. 
 </summary>
 <paramname="template">path for XSLT style-sheet</param>
 <paramname="input">Wild card allowed for multiple files</param>
 <paramname="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
 <paramname="output">Output and suffix per file.</param>

#####  Parameters

 - string template 
 - string input 
 - Func < string , IXPathNavigable > inputNavigatorFactory 
 - string output 
 - string ? excludeInputSource = null 

#### Public Method - TransformMerge

#####  Parameters

 - string template 
 - string input 
 - Func < string , IXPathNavigable > inputNavigatorFactory 
 - string output 
 - string ? excludeInputSource = null 

