# PathExtensions.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\PathExtensions.cs

## Public Class - PathExtensions

### Comments

 <summary>
 wrapper around File IO functions intended for use with XslCompiledTransform
 </summary>

### Attributes

 - XmlRoot
 - (
 - Namespace
 - =
 - XmlNamespaces
 - .
 - Base
 - +
 - nameof
 - (
 - PathExtensions
 - )
 - )

### Members

#### Public Constructor - PathExtensions

##### Comments

 <summary>
 
 </summary>
 <paramname="sandbox">base path used to sand-box requests</param>

#####  Parameters

 - string sandbox 

#### Private ReadOnly Field - _sandbox

##### Summary

 * Type: 

#### Private ReadOnly Field - _ns

##### Summary

 * Type: XNamespace 

#### Public Method - GetDirectoryName

##### Comments

 <summary>
 Returns the directory information for the specified path string.
 </summary>
 <paramname="path">The path of a file or directory.</param>
 <returns>
 Directory information for path, or null if path denotes a root directory or is
 null. Returns System.String.Empty if path does not contain directory information.
 </returns>

#####  Parameters

 - string file 

#### Public Method - GetFileName

##### Comments

 <summary>
 Returns the file name and extension of the specified path string.
 </summary>
 <paramname="file">The path string from which to obtain the file name and extension.</param>
 <returns>
 The characters after the last directory separator character in path. If the last
 character of path is a directory or volume separator character, this method returns
 System.String.Empty. If path is null, this method returns null.
 </returns>

#####  Parameters

 - string file 

#### Public Method - GetFileNameWithoutExtension

##### Comments

 <summary>
 Returns the file name of the specified path string without the extension.
 </summary>
 <paramname="file">The path of the file.</param>
 <returns>
 The string returned by System.IO.Path.GetFileName(System.ReadOnlySpan{System.Char}),
 minus the last period (.) and all characters following it.
 </returns>

#####  Parameters

 - string file 

#### Public Method - GetExtension

##### Comments

 <summary>
 Returns the extension (including the period ".") of the specified path string.
 </summary>
 <paramname="file">The path string from which to get the extension.</param>
 <returns></returns>

#####  Parameters

 - string file 

#### Public Method - ChangeExtension

##### Comments

 <summary>
 Changes the extension of a path string.
 </summary>
 <paramname="file">The path information to modify. The path cannot contain any of the characters
 defined in System.IO.Path.GetInvalidPathChars.</param>
 <paramname="extension">The new extension (with or without a leading period). Specify null to remove
 an existing extension from path.</param>
 <returns>The modified path information. On Windows-based desktop platforms, if path is
 null or an empty string (""), the path information is returned unmodified. If
 extension is null, the returned string contains the specified path with its extension
 removed. If path has no extension, and extension is not null, the returned path
 string contains extension appended to the end of path.</returns>

#####  Parameters

 - string file 
 - string extension 

#### Public Method - ListFiles

##### Comments

 <summary>
 Returns the names of files (including their paths) that match the specified search
 pattern in the specified directory.
 </summary>
 <paramname="path">The relative or absolute path to the directory to search. This string is not
 case-sensitive.</param>
 <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
 that match the specified search pattern, or an empty array if no files are found.</returns>

#####  Parameters

 - string path 

#### Public Method - ListFilesFiltered

##### Comments

 <summary>
 Returns the names of files (including their paths) that match the specified search
 pattern in the specified directory.
 </summary>
 <paramname="path">The relative or absolute path to the directory to search. This string is not
 case-sensitive.</param>
 <paramname="pattern">The search string to match against the names of files in path. This parameter
 can contain a combination of valid literal path and wildcard (* and ?) characters,
 but it doesn't support regular expressions.</param>
 <returns>An XPathNavigator of the full names (including paths) for the files in the specified directory
 that match the specified search pattern, or an empty array if no files are found.</returns>

#####  Parameters

 - string path 
 - string pattern 

