# ApplicationInformation.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Reflection/ApplicationInformation.cs

## Public Class - ApplicationInformation

### Comments

 <summary>
 Gets the executing assembly.
 </summary>
 <value>The executing assembly.</value>

### Members

#### Public Property - ExecutingAssembly

##### Comments

 <summary>
 Gets the executing assembly.
 </summary>
 <value>The executing assembly.</value>

##### Summary

 * Type:   < summary > 
  Gets the executing assembly. 
   </ summary > 
   < value > The executing assembly. </ value > 
  Assembly 

#### Private Field - executingAssembly

##### Summary

 * Type: Assembly 

#### Public Property - ExecutingAssemblyVersion

##### Comments

 <summary>
 Gets the executing assembly version.
 </summary>
 <value>The executing assembly version.</value>

##### Summary

 * Type:   < summary > 
  Gets the executing assembly version. 
   </ summary > 
   < value > The executing assembly version. </ value > 
  Version 

#### Private Field - executingAssemblyVersion

##### Summary

 * Type: Version 

#### Public Property - CompileDate

##### Comments

 <summary>
 Gets the compile date of the currently executing assembly.
 </summary>
 <value>The compile date.</value>

##### Summary

 * Type:   < summary > 
  Gets the compile date of the currently executing assembly. 
   </ summary > 
   < value > The compile date. </ value > 
  DateTime 

#### Private Field - compileDate

##### Summary

 * Type: 

#### Private Method - RetrieveLinkerTimestamp

##### Comments

 <summary>
 Retrieves the linker timestamp.
 </summary>
 <paramname="filePath">The file path.</param>
 <returns></returns>
 <remarks>http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html</remarks>

#####  Parameters

 - string filePath 

