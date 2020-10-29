
# BinaryDataDecoders.ToolKit.ObjectEx
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_ObjectEx.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.ObjectEx                          | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 1                                                            | 
| Uncoveredlines       | 3                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 55                                                           | 
| Linecoverage         | 25                                                           | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ObjectEx.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | GetResourceStream | 
| 1          | 0     | 100      | GetResourceAsStringAsync | 
| 1          | 0     | 100      | GetXmlNamespace | 
| 1          | 0     | 100      | GetXmlNamespaceForOutput | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ObjectEx.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit
〰5:   {
〰6:       /// <summary>
〰7:       /// Extension methods for System.Object
〰8:       /// </summary>
〰9:       public static class ObjectEx
〰10:      {
〰11:          /// <summary>
〰12:          /// Access stream for resource found in the same name space as the referenced object
〰13:          /// </summary>
〰14:          /// <param name="context">object to use as locater</param>
〰15:          /// <param name="filename">name of resource</param>
〰16:          /// <returns>resource stream</returns>
〰17:          public static Stream? GetResourceStream(this object context, string filename) =>
✔18:              context.GetType().GetResourceStream(filename);
〰19:  
〰20:          /// <summary>
〰21:          /// Access stream for resource found in the same name space as the referenced object
〰22:          /// </summary>
〰23:          /// <param name="context">object to use as locater</param>
〰24:          /// <param name="filename">name of resource</param>
〰25:          /// <returns>string content of resource</returns>
〰26:          public static Task<string?> GetResourceAsStringAsync(this object context, string filename) =>
‼27:              context.GetResourceStream(filename).ReadAsStringAsync();
〰28:  
〰29:          /// <summary>
〰30:          /// Resolve XML Name space for referenced object.
〰31:          /// </summary>
〰32:          /// <remarks>
〰33:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰34:          ///
〰35:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰36:          /// </remarks>
〰37:          /// <param name="obj"></param>
〰38:          /// <returns></returns>
〰39:          public static string GetXmlNamespace(this object obj) =>
‼40:              obj.GetType().GetXmlNamespace();
〰41:  
〰42:          /// <summary>
〰43:          /// Resolve XML Namespace for referenced object.
〰44:          /// </summary>
〰45:          /// <remarks>
〰46:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰47:          ///
〰48:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰49:          /// </remarks>
〰50:          /// <param name="obj"></param>
〰51:          /// <returns></returns>
〰52:          public static string GetXmlNamespaceForOutput(this object obj) =>
‼53:              obj.GetType().GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰54:      }
〰55:  }

```
## Footer 
[Return to Summary](Summary.md)

