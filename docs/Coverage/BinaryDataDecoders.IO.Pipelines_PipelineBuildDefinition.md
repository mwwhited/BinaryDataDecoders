# BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDefinition

## Summary

| Key             | Value                                                                 |
| :-------------- | :-------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDefinition` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                     |
| Coveredlines    | `0`                                                                   |
| Uncoveredlines  | `8`                                                                   |
| Coverablelines  | `8`                                                                   |
| Totallines      | `19`                                                                  |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Definitions/PipelineBuildDefinition.cs

```CSharp
〰1:   using System.IO.Pipelines;
〰2:   using System.Threading;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰6:   {
〰7:       internal class PipelineBuildDefinition : IPipelineBuildDefinition
〰8:       {
‼9:           internal PipelineBuildDefinition(Pipe pipe) => this.Pipe = pipe;
〰10:  
‼11:          internal Pipe Pipe { get; }
‼12:          internal OnException? OnError { get; set; }
‼13:          internal Task? PipeWriter { get; set; }
‼14:          internal OnException? OnWriterError { get; set; }
‼15:          internal Task? PipeReader { get; set; }
‼16:          internal OnException? OnReaderError { get; set; }
‼17:          internal CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
〰18:      }
〰19:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

