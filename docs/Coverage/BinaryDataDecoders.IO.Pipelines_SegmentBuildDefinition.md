
# BinaryDataDecoders.IO.Pipelines.Definitions.SegmentBuildDefinition
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_SegmentBuildDefinition.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Definitions.SegmentBuildDefi | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 3                                                            | 
| Coverablelines       | 3                                                            | 
| Totallines           | 17                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\SegmentBuildDefinition.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\SegmentBuildDefinition.cs

```CSharp
〰1:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰2:   {
〰3:       internal class SegmentBuildDefinition : ISegmentBuildDefinition
〰4:       {
‼5:           internal SegmentBuildDefinition(byte startsWith)
〰6:           {
‼7:               this.StartsWith = startsWith;
‼8:           }
〰9:   
〰10:          internal SegmentExtensionDefinition? ExtensionDefinition { get; set; }
〰11:          internal SegmentionOptions Options { get; set; }
〰12:          internal byte StartsWith { get; }
〰13:          internal byte? EndsWith { get; set; }
〰14:          internal long? Length { get; set; }
〰15:          internal long? MaxLength { get; set; }
〰16:      }
〰17:  }

```
## Footer 
[Return to Summary](Summary.md)

