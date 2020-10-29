
# BinaryDataDecoders.IO.Pipelines.Definitions.SegmentExtensionDefinition
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_SegmentExtensionDefinition.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Definitions.SegmentExtension | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 6                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 21                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\SegmentExtensionDefinition.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\SegmentExtensionDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit;
〰2:   using System;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰5:   {
〰6:       public class SegmentExtensionDefinition
〰7:       {
‼8:           public SegmentExtensionDefinition(Type type, int length, long postion, Endianness endianness)
〰9:           {
‼10:              Type = type;
‼11:              Length = length;
‼12:              Postion = postion;
‼13:              Endianness = endianness;
‼14:          }
〰15:  
〰16:          public Type Type { get; }
〰17:          public int Length { get; }
〰18:          public long Postion { get; }
〰19:          public Endianness Endianness { get; }
〰20:      }
〰21:  }

```
## Footer 
[Return to Summary](Summary.md)

