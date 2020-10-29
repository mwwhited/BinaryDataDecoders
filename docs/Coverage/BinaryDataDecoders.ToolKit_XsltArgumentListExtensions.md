
# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltArgumentListExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XsltArgumentListExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.XsltArgumentListExtension | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 6                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 35                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 2                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltArgumentListExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 2          | 0     | 0        | AddExtensions | 
| 1          | 0     | 100      | AddExtensionObject | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltArgumentListExtensions.cs

```CSharp
〰1:   using System.Xml.Xsl;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰4:   {
〰5:       /// <summary>
〰6:       /// Extension methods for XsltArgumentList
〰7:       /// </summary>
〰8:       public static class XsltArgumentListExtensions
〰9:       {
〰10:          /// <summary>
〰11:          /// simplify chaining XsltArgumentList and AddExtensionObject
〰12:          /// </summary>
〰13:          /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
〰14:          /// <param name="extensionObjects">set of objects to be assigned</param>
〰15:          /// <returns>instance of xsltArgumentList</returns>
〰16:          public static XsltArgumentList AddExtensions(this XsltArgumentList xsltArgumentList, params object[] extensionObjects)
〰17:          {
‼18:              foreach (var extensionObject in extensionObjects)
‼19:                  xsltArgumentList.AddExtensionObject(extensionObject);
‼20:              return xsltArgumentList;
〰21:          }
〰22:          /// <summary>
〰23:          /// simplify chaining XsltArgumentList and AddExtensionObject
〰24:          /// </summary>
〰25:          /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
〰26:          /// <param name="extensionObject">instance of objects to be assigned</param>
〰27:          /// <returns>instance of xsltArgumentList</returns>
〰28:          public static XsltArgumentList AddExtensionObject(this XsltArgumentList xsltArgumentList, object extensionObject)
〰29:          {
‼30:              var ns = extensionObject.GetXmlNamespace();
‼31:              xsltArgumentList.AddExtensionObject(ns, extensionObject);
‼32:              return xsltArgumentList;
〰33:          }
〰34:      }
〰35:  }

```
## Footer 
[Return to Summary](Summary.md)

