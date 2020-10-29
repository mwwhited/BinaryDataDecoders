
# BinaryDataDecoders.IO.Pipelines.Definitions.OnPipelineErrorExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_OnPipelineErrorExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Definitions.OnPipelineErrorE | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 5                                                            | 
| Coverablelines       | 5                                                            | 
| Totallines           | 20                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\OnPipelineErrorExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | cctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\OnPipelineErrorExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Diagnostics;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰6:   {
〰7:       internal static class OnPipelineErrorExtensions
〰8:       {
〰9:           internal static async Task<PipelineErrorHandling> Handle(this OnPipelineError? handler, object sender, Exception exception)
〰10:          {
〰11:              return await (handler ?? DefaultPipelineError).Invoke(sender, exception);
〰12:          }
〰13:  
‼14:          internal static readonly OnPipelineError DefaultPipelineError = (s, e) =>
‼15:          {
‼16:              Debug.WriteLine($"Exception On: {s} => {e.Message}");
‼17:              return Task.FromResult(PipelineErrorHandling.Throw);
‼18:          };
〰19:      }
〰20:  }

```
## Footer 
[Return to Summary](Summary.md)

