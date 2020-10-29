
# BinaryDataDecoders.IO.Pipelines.Segmenters.SegmentReadResult
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_SegmentReadResult.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Segmenters.SegmentReadResult | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 16                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Segmenters\SegmentReadResult.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Segmenters\SegmentReadResult.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Pipelines.Segmenters
〰4:   {
〰5:       internal class SegmentReadResult : ISegmentReadResult
〰6:       {
‼7:           public SegmentReadResult(SegmentationStatus Status, ReadOnlySequence<byte> remainingData)
〰8:           {
‼9:               this.Status = Status;
‼10:              this.RemainingData = remainingData;
‼11:          }
〰12:  
〰13:          public SegmentationStatus Status { get; }
〰14:          public ReadOnlySequence<byte> RemainingData { get; }
〰15:      }
〰16:  }

```
## Footer 
[Return to Summary](Summary.md)

