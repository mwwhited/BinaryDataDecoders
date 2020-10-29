# IOUtilities.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Archives\Tar\IOUtilities.cs

## Public Static Class - IOUtilities

### Members

#### Internal Static Method - CreateFile

##### Attributes

 - DllImport
 - (
 - "kernel32.dll"
 - ,
 - SetLastError
 - =
 - true
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Unicode
 - )

#####  Parameters

 - string lpFileName 
 - EFileAccess dwDesiredAccess 
 - EFileShare dwShareMode 
 - IntPtr lpSecurityAttributes 
 - ECreationDisposition dwCreationDisposition 
 - EFileAttributes dwFlagsAndAttributes 
 - IntPtr hTemplateFile 

#### Internal Static Field - INVALID_HANDLE_VALUE

##### Summary

 * Type: IntPtr 

#### Internal Static Field - FILE_ATTRIBUTE_DIRECTORY

##### Summary

 * Type: 

#### Internal Field - MAX_PATH

##### Summary

 * Type: 

#### Public Static Method - OpenFileStream

#####  Parameters

 - string fileName 
 - FileMode fileMode 
 - FileAccess fileAccess 
 - FileShare fileShare 

#### Internal Static Method - Convert

#####  Parameters

 - this FileAccess fileAccess 

#### Internal Static Method - Convert

#####  Parameters

 - this FileShare fileShare 

#### Internal Static Method - Convert

#####  Parameters

 - this FileMode fileMode 

