# SandboxPath.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Security/SandboxPath.cs

## Public Static Class - SandboxPath

### Comments

 <summary>
 File IO sandboxing operation
 </summary>

### Members

#### Public Static Method - EnsureSafePath

##### Comments

 <summary>
 Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
 </summary>
 <paramname="basePath"></param>
 <paramname="filePath"></param>
 <returns></returns>
 <exceptioncref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>

#####  Parameters

 - string basePath 
 - string filePath 

