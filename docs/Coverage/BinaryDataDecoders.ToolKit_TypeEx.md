
# BinaryDataDecoders.ToolKit.TypeEx
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_TypeEx.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.TypeEx                            | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 1                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 5                                                            | 
| Totallines           | 63                                                           | 
| Linecoverage         | 20                                                           | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 6                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\TypeEx.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | GetResourceStream | 
| 4          | 0     | 0        | GetXmlNamespace | 
| 2          | 0     | 0        | GetXmlNamespaceForOutput | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\TypeEx.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Linq;
〰4:   using System.Reflection;
〰5:   using System.Threading.Tasks;
〰6:   using System.Xml.Serialization;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit
〰9:   {
〰10:      /// <summary>
〰11:      /// Extension methods for System.Object
〰12:      /// </summary>
〰13:      public static class TypeEx
〰14:      {
〰15:          /// <summary>
〰16:          /// Access stream for resource found in the same name space as the referenced object
〰17:          /// </summary>
〰18:          /// <param name="classType">object to use as locater</param>
〰19:          /// <param name="filename">name of resource</param>
〰20:          /// <returns>resource stream</returns>
〰21:          public static Stream GetResourceStream(this Type classType, string filename) =>
✔22:               classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");
〰23:  
〰24:          /// <summary>
〰25:          /// Access stream for resource found in the same name space as the referenced object
〰26:          /// </summary>
〰27:          /// <param name="context">object to use as locater</param>
〰28:          /// <param name="filename">name of resource</param>
〰29:          /// <returns>string content of resource</returns>
〰30:          public static async Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
〰31:              (await context.GetResourceStream(filename).ReadAsStringAsync()) ??"";
〰32:  
〰33:          /// <summary>
〰34:          /// Resolve XML Name space for referenced object.
〰35:          /// </summary>
〰36:          /// <remarks>
〰37:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰38:          ///
〰39:          /// <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
〰40:          /// </remarks>
〰41:          /// <param name="type"></param>
〰42:          /// <returns></returns>
〰43:          public static string GetXmlNamespace(this Type type)
〰44:          {
‼45:              var ns = type.GetCustomAttribute<XmlRootAttribute>()?.Namespace;
‼46:              if (string.IsNullOrWhiteSpace(ns)) return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
‼47:              return ns;
〰48:          }
〰49:  
〰50:          /// <summary>
〰51:          /// Resolve XML Namespace for referenced object.
〰52:          /// </summary>
〰53:          /// <remarks>
〰54:          /// This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
〰55:          ///
〰56:          /// <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
〰57:          /// </remarks>
〰58:          /// <param name="type"></param>
〰59:          /// <returns></returns>
〰60:          public static string GetXmlNamespaceForOutput(this Type type) =>
‼61:              type?.GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
〰62:      }
〰63:  }

```
## Footer 
[Return to Summary](Summary.md)

