# NugetManager.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.PackMan.Cli/NugetManager.cs

## Public Class - NugetManager

### Members

#### Private ReadOnly Field - _nugetLogger

##### Summary

 * Type: ILogger 

#### Private ReadOnly Field - _logger

##### Summary

 * Type: 

#### Public Constructor - NugetManager

#####  Parameters

 - ILogger nugetLogger 
 - ILogger < NugetManager > logger 

#### Public Method - SplitVersions

#####  Parameters

 - string ? inputVersions 

#### Public Method - OpenXml

#####  Parameters

 - string versionPropsFile 
 - bool withImport = false 

#### Public Method - UpdateTargetVersions

#####  Parameters

 - XDocument xDocument 
 - IEnumerable < ( string name , string ? version ) > properties 

#### Public Async Method - UpdateNugetVersionsAsync

#####  Parameters

 - XDocument versionXml 
 - string nugetUrl 
 - FeedType feedType 
 - CancellationToken cancellationToken 

#### Public Method - Save

#####  Parameters

 - XDocument versionXml 
 - string filePath 

#### Public Method - GetProperties

#####  Parameters

 - XDocument versionXml 

