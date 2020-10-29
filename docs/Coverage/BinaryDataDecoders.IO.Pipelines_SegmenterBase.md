
# BinaryDataDecoders.IO.Pipelines.Segmenters.SegmenterBase
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_SegmenterBase.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Segmenters.SegmenterBase     | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 7                                                            | 
| Coverablelines       | 7                                                            | 
| Totallines           | 50                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Segmenters\SegmenterBase.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Segmenters\SegmenterBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Pipelines.Segmenters
〰6:   {
〰7:       public abstract class SegmenterBase : ISegmenter
〰8:       {
‼9:           protected SegmenterBase(
‼10:              OnSegmentReceived onSegmentReceived,
‼11:              SegmentionOptions options
‼12:              )
〰13:          {
‼14:              OnSegmentReceived = onSegmentReceived;
‼15:              Options = options;
‼16:          }
〰17:  
〰18:          private OnSegmentReceived OnSegmentReceived { get; }
〰19:          public SegmentionOptions Options { get; }
〰20:  
〰21:          public async ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer)
〰22:          {
〰23:              var result = Read(buffer);
〰24:              if (result.status == SegmentationStatus.Complete)
〰25:              {
〰26:                  if (result.segment == null) throw new NotSupportedException("\"Valid\" segmentation without data is not possible");
〰27:  
〰28:                  await OnSegmentReceived(result.segment.Value);
〰29:                  buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End));
〰30:              }
〰31:              else if (result.status == SegmentationStatus.Invalid && Options.HasFlag(SegmentionOptions.SkipInvalidSegment))
〰32:              {
〰33:                  if (result.segment != null)
〰34:                  {
〰35:                      buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End)); //Assume this end marks the second start for next segment
〰36:                  }
〰37:                  else
〰38:                  {
〰39:                      buffer = buffer.Slice(buffer.GetPosition(0, buffer.End)); // if segment isn't provided just fast forward to end
〰40:                  }
〰41:  
〰42:                  return new SegmentReadResult(SegmentationStatus.Complete, buffer);
〰43:              }
〰44:  
〰45:              return new SegmentReadResult(result.status, buffer);
〰46:          }
〰47:  
〰48:          protected abstract (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer);
〰49:      }
〰50:  }

```
## Footer 
[Return to Summary](Summary.md)

