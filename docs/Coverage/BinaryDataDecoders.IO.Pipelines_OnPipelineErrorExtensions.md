# BinaryDataDecoders.IO.Pipelines.Definitions.OnPipelineErrorExtensions

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Definitions.OnPipelineErrorExtensions` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                       |
| Coveredlines    | `0`                                                                     |
| Uncoveredlines  | `6`                                                                     |
| Coverablelines  | `6`                                                                     |
| Totallines      | `17`                                                                    |
| Linecoverage    | `0`                                                                     |
| Coveredbranches | `0`                                                                     |
| Totalbranches   | `2`                                                                     |
| Branchcoverage  | `0`                                                                     |
| Coveredmethods  | `0`                                                                     |
| Totalmethods    | `2`                                                                     |
| Methodcoverage  | `0`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 2          | 0     | 0        | `Handle` |
| 1          | 0     | 100      | `cctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Definitions/OnPipelineErrorExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Diagnostics;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Pipelines.Definitions;
〰6:   
〰7:   internal static class OnPipelineErrorExtensions
〰8:   {
〰9:       internal static async Task<ErrorHandling> Handle(this OnException? handler, object sender, Exception exception) =>
‼10:          await (handler ?? DefaultPipelineError).Invoke(sender, exception);
〰11:  
‼12:      internal static readonly OnException DefaultPipelineError = (s, e) =>
‼13:      {
‼14:          Debug.WriteLine($"Exception On: {s} => {e.Message}");
‼15:          return Task.FromResult(ErrorHandling.Throw);
‼16:      };
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

