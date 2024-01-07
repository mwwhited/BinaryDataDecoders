# INugetManager.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.PackMan.Cli/INugetManager.cs

## Public Interface - INugetManager

### Members

#### Method - OpenXml

#####  Parameters

 - string versionPropsFile 
 - bool followImports = false 

#### Method - SplitVersions

#####  Parameters

 - string ? inputVersions 

#### Method - UpdateNugetVersionsAsync

#####  Parameters

 - XDocument versionXml 
 - string nugetUrl 
 - FeedType feedType 
 - CancellationToken cancellationToken 

#### Method - UpdateTargetVersions

#####  Parameters

 - XDocument xDocument 
 - IEnumerable < ( string name , string ? version ) > properties 

#### Method - Save

#####  Parameters

 - XDocument versionXml 
 - string filePath 

#### Method - GetProperties

#####  Parameters

 - XDocument versionXml 

