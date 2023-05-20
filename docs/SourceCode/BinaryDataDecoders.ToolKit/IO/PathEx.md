# PathEx.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/IO/PathEx.cs

## Public Static Class - PathEx

### Comments

 <summary>
 Extensions for path strings
 </summary>

### Members

#### Public Static Method - CreateParentIfNotExists

##### Comments

 <summary>
 Create parent directory is does not exist
 </summary>
 <paramname="path"></param>
 <returns>return input path to support chaining</returns>

#####  Parameters

 - this string path 

#### Public Static Method - EndsInDirectorySeparator

#####  Parameters

 - string path 

#### Public Static Method - FixUpPath

#####  Parameters

 - string path 

#### Public Static Method - GetBasePath

#####  Parameters

 - string path 

#### Public Static Method - EnumerateFiles

#####  Parameters

 - string ? wildcardPath 

#### Public Static Method - EnumerateDirectories

#####  Parameters

 - string path 
 - string wildcardPath 

#### Internal Static Method - EnumerateDirectories

#####  Parameters

 - string path 
 - IEnumerator < string > enumerator 

