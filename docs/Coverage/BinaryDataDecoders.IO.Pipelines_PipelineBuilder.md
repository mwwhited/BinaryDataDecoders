
# BinaryDataDecoders.IO.Pipelines.PipelineBuilder
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO.Pipelines_PipelineBuilder.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Pipelines.PipelineBuilder              | 
| Assembly             | BinaryDataDecoders.IO.Pipelines                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 49                                                           | 
| Coverablelines       | 49                                                           | 
| Totallines           | 125                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 30                                                           | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\PipelineBuilder.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | Follow | 
| 1          | 0     | 100      | FollowStream | 
| 4          | 0     | 0        | FollowStream | 
| 4          | 0     | 0        | With | 
| 4          | 0     | 0        | With | 
| 4          | 0     | 0        | OnError | 
| 4          | 0     | 0        | OnReaderError | 
| 4          | 0     | 0        | OnWriterError | 
| 6          | 0     | 0        | RunAsync | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\PipelineBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using BinaryDataDecoders.IO.Pipelines.Factories;
〰3:   using System;
〰4:   using System.IO;
〰5:   using System.IO.Pipelines;
〰6:   using System.Threading;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.IO.Pipelines
〰10:  {
〰11:      public static class PipelineBuilder
〰12:      {
〰13:          public static IPipelineBuildDefinition Follow(this Stream stream, int minimumBufferSize = 4096)
〰14:          {
‼15:              return new Pipe().FollowStream(stream, minimumBufferSize);
〰16:          }
〰17:          internal static IPipelineBuildDefinition FollowStream(this Pipe pipe, Stream stream, int minimumBufferSize = 4096)
〰18:          {
‼19:              return new PipelineBuildDefinition(pipe).FollowStream(stream, minimumBufferSize);
〰20:          }
〰21:          internal static IPipelineBuildDefinition FollowStream(this IPipelineBuildDefinition pipeline, Stream stream, int minimumBufferSize = 4096)
〰22:          {
‼23:              if (!(pipeline is PipelineBuildDefinition def))
〰24:              {
‼25:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰26:              }
‼27:              else if (def.PipeWriter != null)
〰28:              {
‼29:                  throw new NotSupportedException("this pipeline already has a writer");
〰30:              }
‼31:              def.PipeWriter = new StreamPipelineFactory().CreateWriter(def, stream, minimumBufferSize);
‼32:              return def;
〰33:          }
〰34:  
〰35:          public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, ISegmenter segmenter)
〰36:          {
‼37:              if (!(pipeline is PipelineBuildDefinition def))
〰38:              {
‼39:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰40:              }
‼41:              else if (def.PipeReader != null)
〰42:              {
‼43:                  throw new NotSupportedException("this pipeline already has a reader");
〰44:              }
‼45:              def.PipeReader = new SegmentPipeFactory().CreateReader(def, segmenter);
‼46:              return def;
〰47:          }
〰48:          public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, Stream stream)
〰49:          {
‼50:              if (!(pipeline is PipelineBuildDefinition def))
〰51:              {
‼52:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰53:              }
‼54:              else if (def.PipeReader != null)
〰55:              {
‼56:                  throw new NotSupportedException("this pipeline already has a reader");
〰57:              }
‼58:              def.PipeReader = new StreamPipelineFactory().CreateReader(pipeline: def, stream);
‼59:              return def;
〰60:          }
〰61:  
〰62:          public static IPipelineBuildDefinition OnError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
〰63:          {
‼64:              if (!(pipeline is PipelineBuildDefinition def))
〰65:              {
‼66:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰67:              }
‼68:              else if (def.PipeReader != null)
〰69:              {
‼70:                  throw new NotSupportedException("this pipeline already has a reader");
〰71:              }
‼72:              def.OnError = onPipelineError;
‼73:              return def;
〰74:          }
〰75:          public static IPipelineBuildDefinition OnReaderError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
〰76:          {
‼77:              if (!(pipeline is PipelineBuildDefinition def))
〰78:              {
‼79:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰80:              }
‼81:              else if (def.PipeReader != null)
〰82:              {
‼83:                  throw new NotSupportedException("this pipeline already has a reader");
〰84:              }
‼85:              def.OnReaderError = onPipelineError;
‼86:              return def;
〰87:          }
〰88:          public static IPipelineBuildDefinition OnWriterError(this IPipelineBuildDefinition pipeline, OnPipelineError onPipelineError)
〰89:          {
‼90:              if (!(pipeline is PipelineBuildDefinition def))
〰91:              {
‼92:                  throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰93:              }
‼94:              else if (def.PipeReader != null)
〰95:              {
‼96:                  throw new NotSupportedException("this pipeline already has a reader");
〰97:              }
‼98:              def.OnWriterError = onPipelineError;
‼99:              return def;
〰100:         }
〰101: 
〰102:         public static Task RunAsync(this IPipelineBuildDefinition pipeline, CancellationToken cancellationToken = default)
〰103:         {
‼104:             if (!(pipeline is PipelineBuildDefinition def))
〰105:             {
‼106:                 throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰107:             }
‼108:             else if (def.PipeWriter == null)
〰109:             {
‼110:                 throw new NotSupportedException("this pipeline is not configured with a writer");
〰111:             }
‼112:             else if (def.PipeReader == null)
〰113:             {
‼114:                 throw new NotSupportedException("this pipeline is not configured with a reader");
〰115:             }
〰116: 
‼117:             cancellationToken.Register(() => def.CancellationTokenSource.Cancel());
〰118: 
‼119:             return Task.WhenAll(
‼120:                 Task.Run(async () => await def.PipeWriter),
‼121:                 Task.Run(async () => await def.PipeReader)
‼122:                 );
〰123:         }
〰124:     }
〰125: }

```
## Footer 
[Return to Summary](Summary.md)

