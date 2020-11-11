# BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDefinition

## Summary

| Key             | Value                                                                 |
| :-------------- | :-------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDefinition` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                     |
| Coveredlines    | `0`                                                                   |
| Uncoveredlines  | `10`                                                                  |
| Coverablelines  | `10`                                                                  |
| Totallines      | `27`                                                                  |
| Linecoverage    | `0`                                                                   |
| Coveredbranches | `0`                                                                   |
| Totalbranches   | `0`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 0     | 100      | `ctor`                        |
| 1          | 0     | 100      | `get_Pipe`                    |
| 1          | 0     | 100      | `get_OnError`                 |
| 1          | 0     | 100      | `get_PipeWriter`              |
| 1          | 0     | 100      | `get_OnWriterError`           |
| 1          | 0     | 100      | `get_PipeReader`              |
| 1          | 0     | 100      | `get_OnReaderError`           |
| 1          | 0     | 100      | `get_CancellationTokenSource` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\PipelineBuildDefinition.cs

```CSharp
〰1:   using System.IO.Pipelines;
〰2:   using System.Threading;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰6:   {
〰7:       internal class PipelineBuildDefinition : IPipelineBuildDefinition
〰8:       {
‼9:           internal PipelineBuildDefinition(Pipe pipe)
〰10:          {
‼11:              this.Pipe = pipe;
‼12:          }
〰13:  
‼14:          internal Pipe Pipe { get; }
〰15:  
‼16:          internal OnPipelineError? OnError { get; set; }
〰17:  
〰18:  
‼19:          internal Task? PipeWriter { get; set; }
‼20:          internal OnPipelineError? OnWriterError { get; set; }
〰21:  
‼22:          internal Task? PipeReader { get; set; }
‼23:          internal OnPipelineError? OnReaderError { get; set; }
〰24:  
‼25:          internal CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
〰26:      }
〰27:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

