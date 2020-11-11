# BinaryDataDecoders.IO.Pipelines.Factories.SegmentPipeFactory

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Factories.SegmentPipeFactory` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                              |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `30`                                                           |
| Coverablelines  | `30`                                                           |
| Totallines      | `76`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `22`                                                           |
| Branchcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 22         | 0     | 0        | `CreateReader` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Factories\SegmentPipeFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using BinaryDataDecoders.IO.Pipelines.Segmenters;
〰3:   using System;
〰4:   using System.Threading.Tasks;
〰5:   
〰6:   namespace BinaryDataDecoders.IO.Pipelines.Factories
〰7:   {
〰8:       internal class SegmentPipeFactory
〰9:       {
〰10:          internal async Task CreateReader(PipelineBuildDefinition def, ISegmenter segmenter)
〰11:          {
‼12:              var context = new
‼13:              {
‼14:                  pipeline = def.Pipe.Reader,
‼15:                  onError = def.OnReaderError ?? def.OnError,
‼16:                  cancellationToken = def.CancellationTokenSource.Token,
‼17:                  owner = segmenter,
‼18:              };
〰19:  
‼20:              var completed = false;
‼21:              while (!context.cancellationToken.IsCancellationRequested)
〰22:              {
‼23:                  var result = await context.pipeline.ReadAsync(context.cancellationToken);
〰24:                  try
〰25:                  {
‼26:                      var buffer = result.Buffer;
〰27:  
‼28:                      while (!context.cancellationToken.IsCancellationRequested)
〰29:                      {
‼30:                          var read = await segmenter.TryReadAsync(buffer);
‼31:                          buffer = read.RemainingData;
‼32:                          if (read.Status == SegmentationStatus.Incomplete)
〰33:                          {
〰34:                              break;
〰35:                          }
‼36:                          else if (read.Status == SegmentationStatus.Invalid)
〰37:                          {
‼38:                              throw new InvalidSegmentationException();
〰39:                          }
〰40:                      }
〰41:  
〰42:                      // Tell the PipeReader how much of the buffer we have consumed
‼43:                      context.pipeline.AdvanceTo(buffer.Start, buffer.End);
‼44:                  }
‼45:                  catch (Exception ex)
〰46:                  {
‼47:                      var errorHandling = await context.onError.Handle(context.owner, ex);
〰48:                      switch (errorHandling)
〰49:                      {
〰50:                          case PipelineErrorHandling.Ignore:
〰51:                              //Note: do nothing
〰52:                              break;
〰53:  
〰54:                          case PipelineErrorHandling.Stop:
‼55:                              completed = true;
‼56:                              break;
〰57:  
〰58:                          default:
〰59:                          case PipelineErrorHandling.Throw:
‼60:                              context.pipeline.Complete(ex);
‼61:                              return;
〰62:                      }
‼63:                  }
〰64:  
〰65:                  // Stop reading if there's no more data coming
‼66:                  if (result.IsCompleted || completed)
〰67:                  {
〰68:                      break;
〰69:                  }
‼70:              }
〰71:  
〰72:              //Mark the PipeReader as complete
‼73:              context.pipeline.Complete();
‼74:          }
〰75:      }
〰76:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

