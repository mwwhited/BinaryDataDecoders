# ObjectEx.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\ObjectEx.cs

## Public Static Class - ObjectEx

### Comments

 <summary>
 Extension methods for System.Object
 </summary>

### Members

#### Public Static Method - GetResourceStream

##### Comments

 <summary>
 Access stream for resource found in the same name space as the referenced object
 </summary>
 <paramname="context">object to use as locater</param>
 <paramname="filename">name of resource</param>
 <returns>resource stream</returns>

#####  Parameters

 - this object context 
 - string filename 

#### Public Static Method - GetResourceAsStringAsync

##### Comments

 <summary>
 Access stream for resource found in the same name space as the referenced object 
 </summary>
 <paramname="context">object to use as locater</param>
 <paramname="filename">name of resource</param>
 <returns>string content of resource</returns>

#####  Parameters

 - this object context 
 - string filename 

#### Public Static Method - GetXmlNamespace

##### Comments

 <summary>
 Resolve XML Name space for referenced object.  
 </summary>
 <remarks>
 This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
 
 <c>clr:{full class with namespace}, {containing assembly name}&quot;</c>
 </remarks>
 <paramname="obj"></param>
 <returns></returns>

#####  Parameters

 - this object obj 

#### Public Static Method - GetXmlNamespaceForOutput

##### Comments

 <summary>
 Resolve XML Namespace for referenced object.  
 </summary>
 <remarks>
 This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
 
 <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
 </remarks>
 <paramname="obj"></param>
 <returns></returns>

#####  Parameters

 - this object obj 

#### Public Static Method - GetXmlElementName

#####  Parameters

 - this object @object 
 - bool excludeNamespace = false 

#### Public Static Method - GetXmlItemName

#####  Parameters

 - this IEnumerable enumerable 
 - bool excludeNamespace 

#### Public Static Method - GetXmlItemName

#####  Parameters

 - this IEnumerable enumerable 
 - XName ? elementName = null 

