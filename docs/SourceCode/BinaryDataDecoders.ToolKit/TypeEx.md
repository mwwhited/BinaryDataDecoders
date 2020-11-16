# TypeEx.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\TypeEx.cs

## Public Static Class - TypeEx

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
 <paramname="classType">object to use as locater</param>
 <paramname="filename">name of resource</param>
 <returns>resource stream</returns>

#####  Parameters

 - this Type classType 
 - string filename 

#### Public Static Async Method - GetResourceAsStringAsync

##### Comments

 <summary>
 Access stream for resource found in the same name space as the referenced object 
 </summary>
 <paramname="context">object to use as locater</param>
 <paramname="filename">name of resource</param>
 <returns>string content of resource</returns>

#####  Parameters

 - this Type context 
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
 <paramname="type"></param>
 <returns></returns>

#####  Parameters

 - this Type type 

#### Public Static Method - GetXmlNamespaceForOutput

##### Comments

 <summary>
 Resolve XML Namespace for referenced object.  
 </summary>
 <remarks>
 This will be generated as followed unless the provided object type is tagged wit han XmlRootAttribute
 
 <c>clr:{full class with namespace}, {containing assembly name}:out&quot;</c>
 </remarks>
 <paramname="type"></param>
 <returns></returns>

#####  Parameters

 - this Type type 

#### Private Static ReadOnly Field - _simpleTypes

##### Summary

 * Type: 

#### Public Static Method - IsSimpleType

##### Comments

 <summary>
 check if type is "simple" .. primitive or [decimal, datetime, bool]
 </summary>
 <paramname="type"></param>
 <returns></returns>

#####  Parameters

 - this Type type 

#### Public Static Method - IsAnonymousType

#####  Parameters

 - this Type type 

#### Public Static Method - GetXmlElementName

#####  Parameters

 - this Type type 
 - bool excludeNamespace = false 

