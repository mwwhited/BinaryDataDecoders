# BinaryDataDecoders.IO.Pipelines.Factories.StreamPipelineFactory

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Factories.StreamPipelineFactory` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                 |
| Coveredlines    | `0`                                                               |
| Uncoveredlines  | `27`                                                              |
| Coverablelines  | `27`                                                              |
| Totallines      | `75`                                                              |
| Linecoverage    | `0`                                                               |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `12`                                                              |
| Branchcoverage  | `0`                                                               |
| Coveredmethods  | `0`                                                               |
| Totalmethods    | `2`                                                               |
| Methodcoverage  | `0`                                                               |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 12         | 0     | 0        | `CreateWriter` |
| 1          | 0     | 100      | `CreateReader` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Factories/StreamPipelineFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using System;
〰3:   using System.IO;
〰4:   using System.Threading.Tasks;
〰5:   
〰6:   namespace BinaryDataDecoders.IO.Pipelines.Factories
〰7:   {
〰8:   
〰9:       internal class StreamPipelineFactory
〰10:      {
〰11:          //https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/
〰12:          internal async Task CreateWriter(PipelineBuildDefinition def, Stream stream, int minimumBufferSize)
〰13:          {
‼14:              var context = new
‼15:              {
‼16:                  pipeline = def.Pipe.Writer,
‼17:                  onError = def.OnWriterError ?? def.OnError,
‼18:                  cancellationToken = def.CancellationTokenSource.Token,
‼19:                  owner = stream,
‼20:              };
〰21:  
‼22:              var completed = false;
‼23:              while (!context.cancellationToken.IsCancellationRequested)
〰24:              {
〰25:                  // Allocate at least 512 bytes from the PipeWriter
‼26:                  var memory = context.pipeline.GetMemory(minimumBufferSize);
〰27:                  try
〰28:                  {
‼29:                      var read = await context.owner.ReadAsync(memory, context.cancellationToken);
‼30:                      if (read == 0)
〰31:                      {
‼32:                          break;
〰33:                      }
〰34:  
〰35:                      // Tell the PipeWriter how much was read from the Socket
‼36:                      context.pipeline.Advance(read);
‼37:                  }
‼38:                  catch (Exception ex)
〰39:                  {
‼40:                      var errorHandling = await context.onError.Handle(context.owner, ex);
〰41:                      switch (errorHandling)
〰42:                      {
〰43:                          case ErrorHandling.Ignore:
〰44:                              //Note: do nothing
〰45:                              break;
〰46:  
〰47:                          case ErrorHandling.Stop:
‼48:                              completed = true;
‼49:                              break;
〰50:  
〰51:                          default:
〰52:                          case ErrorHandling.Throw:
‼53:                              context.pipeline.Complete(ex);
‼54:                              return;
〰55:                      }
‼56:                  }
〰57:  
〰58:                  // Make the data available to the PipeReader
‼59:                  var result = await context.pipeline.FlushAsync();
‼60:                  if (result.IsCompleted || completed)
〰61:                  {
〰62:                      break;
〰63:                  }
〰64:              }
〰65:  
〰66:              // Tell the PipeReader that there's no more data coming
‼67:              context.pipeline.Complete();
‼68:          }
〰69:  
〰70:          internal Task? CreateReader(PipelineBuildDefinition pipeline, Stream stream)
〰71:          {
‼72:              throw new NotImplementedException();
〰73:          }
〰74:      }
〰75:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

