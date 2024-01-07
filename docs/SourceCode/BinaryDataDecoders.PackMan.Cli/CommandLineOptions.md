# CommandLineOptions.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.PackMan.Cli/CommandLineOptions.cs

## Public Class - CommandLineOptions

### Members

#### Public Property - SourceFile

##### Attributes

 - CommandOption
 - (
 - "s"
 - ,
 - "source"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "input file (Directory.Packages.props)"
 - )

##### Summary

 * Type: [ CommandOption ( "s" , "source" , Required = false , HelpText = "input file (Directory.Packages.props)" ) ] string 

#### Public Property - OutputFile

##### Attributes

 - CommandOption
 - (
 - "o"
 - ,
 - "output"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "output file (Directory.Packages.props)"
 - )

##### Summary

 * Type: [ CommandOption ( "o" , "output" , Required = false , HelpText = "output file (Directory.Packages.props)" ) ] string ? 

#### Public Property - NoSave

##### Attributes

 - CommandOption
 - (
 - "n"
 - ,
 - "no-save"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Do not save changes"
 - )

##### Summary

 * Type: [ CommandOption ( "n" , "no-save" , Required = false , HelpText = "Do not save changes" ) ] bool 

#### Public Property - NoNuget

##### Attributes

 - CommandOption
 - (
 - "no-nuget"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Do not update nuget"
 - )

##### Summary

 * Type: [ CommandOption ( "no-nuget" , Required = false , HelpText = "Do not update nuget" ) ] bool 

#### Public Property - TargetVersions

##### Attributes

 - CommandOption
 - (
 - "t"
 - ,
 - "target-versions"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Set Target Property Version (XXX,1.2.3;YYY;2.3.4)"
 - )

##### Summary

 * Type: [ CommandOption ( "t" , "target-versions" , Required = false , HelpText = "Set Target Property Version (XXX,1.2.3;YYY;2.3.4)" ) ] string ? 

#### Public Property - NugetUrl

##### Attributes

 - CommandOption
 - (
 - "nuget-url"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Nuget API URL (https://api.nuget.org/v3/index.json)"
 - )

##### Summary

 * Type: [ CommandOption ( "nuget-url" , Required = false , HelpText = "Nuget API URL (https://api.nuget.org/v3/index.json)" ) ] string 

#### Public Property - FeedType

##### Attributes

 - CommandOption
 - (
 - "nuget-feed-type"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Nuget API URL (https://api.nuget.org/v3/index.json)"
 - )

##### Summary

 * Type: [ CommandOption ( "nuget-feed-type" , Required = false , HelpText = "Nuget API URL (https://api.nuget.org/v3/index.json)" ) ] FeedType 

#### Public Property - GetProperties

##### Attributes

 - CommandOption
 - (
 - "get-properties"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Read properties in Directory.Packages.props (and children)"
 - )

##### Summary

 * Type: [ CommandOption ( "get-properties" , Required = false , HelpText = "Read properties in Directory.Packages.props (and children)" ) ] bool 

#### Public Property - FollowImports

##### Attributes

 - CommandOption
 - (
 - "follow-imports"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Replace Import values with Children"
 - )

##### Summary

 * Type: [ CommandOption ( "follow-imports" , Required = false , HelpText = "Replace Import values with Children" ) ] bool 

#### Public Property - GetProperty

##### Attributes

 - CommandOption
 - (
 - "g"
 - ,
 - "get-property"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Read selected property"
 - )

##### Summary

 * Type: [ CommandOption ( "g" , "get-property" , Required = false , HelpText = "Read selected property" ) ] string ? 

#### Public Property - GetVersion

##### Attributes

 - CommandOption
 - (
 - "v"
 - ,
 - "get-version"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Read Version"
 - )

##### Summary

 * Type: [ CommandOption ( "v" , "get-version" , Required = false , HelpText = "Read Version" ) ] bool 

#### Public Property - UpdateProjects

##### Attributes

 - CommandOption
 - (
 - "update-projects"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Update project references"
 - )

##### Summary

 * Type: [ CommandOption ( "update-projects" , Required = false , HelpText = "Update project references" ) ] bool 

#### Public Property - Projects

##### Attributes

 - CommandOption
 - (
 - "projects"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Projects List"
 - )

##### Summary

 * Type: [ CommandOption ( "projects" , Required = false , HelpText = "Projects List" ) ] string ? 

#### Public Property - ProjectsPath

##### Attributes

 - CommandOption
 - (
 - "projects-path"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "Projects Source Path"
 - )

##### Summary

 * Type: [ CommandOption ( "projects-path" , Required = false , HelpText = "Projects Source Path" ) ] string ? 

