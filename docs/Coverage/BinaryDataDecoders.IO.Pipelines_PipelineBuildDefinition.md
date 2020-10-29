
# BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDefinition
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_PipelineBuildDefinition.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.Definitions.PipelineBuildDef | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 27                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Definitions\PipelineBuildDefinition.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
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
〰14:          internal Pipe Pipe { get; }
〰15:  
〰16:          internal OnPipelineError? OnError { get; set; }
〰17:  
〰18:  
〰19:          internal Task? PipeWriter { get; set; }
〰20:          internal OnPipelineError? OnWriterError { get; set; }
〰21:  
〰22:          internal Task? PipeReader { get; set; }
〰23:          internal OnPipelineError? OnReaderError { get; set; }
〰24:  
‼25:          internal CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
〰26:      }
〰27:  }

```
## Footer 
[Return to Summary](Summary.md)

