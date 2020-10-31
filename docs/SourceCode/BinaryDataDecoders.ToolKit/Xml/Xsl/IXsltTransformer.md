# IXsltTransformer.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\Xsl\IXsltTransformer.cs

## Public Interface - IXsltTransformer

### Comments

 <summary>
 Interface for IXsltTransformer
 </summary>

### Members

#### Method - ReadAsXml

##### Comments

 <summary>
 Read input file as XML
 </summary>
 <paramname="fileName"></param>
 <returns></returns>

#####  Parameters

 - string fileName 

#### Method - Transform

##### Comments

 <summary>
 Single action transform
 </summary>
 <paramname="template">path for xslt stylesheet</param>
 <paramname="input">source XML file</param>
 <paramname="output">resulting text content</param>

#####  Parameters

 - string template 
 - string input 
 - string output 

#### Method - Transform

##### Comments

 <summary>
 Single action transform
 </summary>
 <paramname="template">path for xslt stylesheet</param>
 <paramname="inputSource"></param>
 <paramname="input">source XPathNavigable</param>
 <paramname="output">resulting text content</param>

#####  Parameters

 - string template 
 - string inputSource 
 - IXPathNavigable input 
 - string output 

#### Method - TransformAll

##### Comments

 <summary>
 Multiaction action transform. 
 </summary>
 <paramname="template">path for xslt stylesheet</param>
 <paramname="input">Wild card allowed for multiple files</param>
 <paramname="output">Output and suffix per file.</param>

#####  Parameters

 - string template 
 - string input 
 - string output 

#### Method - TransformAll

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

#### Method - TransformMerge

##### Comments

 <summary>
 Multi-action transform. Merge globbed files an handoff to single style
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

