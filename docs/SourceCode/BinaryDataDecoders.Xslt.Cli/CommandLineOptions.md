# CommandLineOptions.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Xslt.Cli\CommandLineOptions.cs

## Public Class - CommandLineOptions

### Members

#### Public Property - Input

##### Attributes

 - Option
 - (
 - 'i'
 - ,
 - "input"
 - ,
 - Required
 - =
 - true
 - ,
 - HelpText
 - =
 - "input file (xml?)"
 - )

##### Summary

 * Type: [ Option ( 'i' , "input" , Required = true , HelpText = "input file (xml?)" ) ] string 

#### Public Property - InputType

##### Attributes

 - Option
 - (
 - 'x'
 - ,
 - "input-type"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "input file type (default XML)"
 - )

##### Summary

 * Type: [ Option ( 'x' , "input-type" , Required = false , HelpText = "input file type (default XML)" ) ] InputTypes 

#### Public Property - Template

##### Attributes

 - Option
 - (
 - 't'
 - ,
 - "template"
 - ,
 - Required
 - =
 - true
 - ,
 - HelpText
 - =
 - "input stylesheet/template file (xslt)"
 - )

##### Summary

 * Type: [ Option ( 't' , "template" , Required = true , HelpText = "input stylesheet/template file (xslt)" ) ] string 

#### Public Property - Output

##### Attributes

 - Option
 - (
 - 'o'
 - ,
 - "output"
 - ,
 - Required
 - =
 - true
 - ,
 - HelpText
 - =
 - "output file"
 - )

##### Summary

 * Type: [ Option ( 'o' , "output" , Required = true , HelpText = "output file" ) ] string 

#### Public Property - Sandbox

##### Attributes

 - Option
 - (
 - 's'
 - ,
 - "sandbox"
 - ,
 - Required
 - =
 - false
 - ,
 - HelpText
 - =
 - "if not provided will be set to parent of output"
 - )

##### Summary

 * Type: [ Option ( 's' , "sandbox" , Required = false , HelpText = "if not provided will be set to parent of output" ) ] string 

