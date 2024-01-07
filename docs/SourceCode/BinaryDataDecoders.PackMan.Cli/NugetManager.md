# NugetManager.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.PackMan.Cli/NugetManager.cs

## Public Class - NugetManager

### Members

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

