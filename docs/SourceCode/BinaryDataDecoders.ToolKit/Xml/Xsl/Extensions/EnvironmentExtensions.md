# EnvironmentExtensions.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\EnvironmentExtensions.cs

## Public Class - EnvironmentExtensions

### Comments

 <summary>
 This is a wrapper around <c>System.Environment</c> intended for use with XslCompiledTransform
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
 - EnvironmentExtensions
 - )
 - )

### Members

#### Private ReadOnly Field - _ns

##### Summary

 * Type: XNamespace 

#### Public Constructor - EnvironmentExtensions


#### Public Method - GetValue

##### Comments

 <summary>
 Retrieves the value of an environment variable from the current process.
 </summary>
 <paramname="variableName">The name of the environment variable.</param>
 <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>

#####  Parameters

 - string variableName 

#### Public Method - GetValues

##### Comments

 <summary>
 Retrieves all environment variable names and their values from the current process.
 </summary>
 <returns>XML element with an attribute for each current environment variable</returns>


