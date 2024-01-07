# BinaryDataDecoders.IO.Pipelines.PipelineBuilder

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Pipelines.PipelineBuilder` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                 |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `49`                                              |
| Coverablelines  | `49`                                              |
| Totallines      | `122`                                             |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `30`                                              |
| Branchcoverage  | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `9`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `Follow`        |
| 1          | 0     | 100      | `FollowStream`  |
| 4          | 0     | 0        | `FollowStream`  |
| 4          | 0     | 0        | `With`          |
| 4          | 0     | 0        | `With`          |
| 4          | 0     | 0        | `OnError`       |
| 4          | 0     | 0        | `OnReaderError` |
| 4          | 0     | 0        | `OnWriterError` |
| 6          | 0     | 0        | `RunAsync`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/PipelineBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using BinaryDataDecoders.IO.Pipelines.Factories;
〰3:   using BinaryDataDecoders.IO.Segmenters;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.IO.Pipelines;
〰7:   using System.Threading;
〰8:   using System.Threading.Tasks;
〰9:   
〰10:  namespace BinaryDataDecoders.IO.Pipelines;
〰11:  
〰12:  public static class PipelineBuilder
〰13:  {
〰14:      public static IPipelineBuildDefinition Follow(this Stream stream, int minimumBufferSize = 4096) =>
‼15:          new Pipe().FollowStream(stream, minimumBufferSize);
〰16:      internal static IPipelineBuildDefinition FollowStream(this Pipe pipe, Stream stream, int minimumBufferSize = 4096) =>
‼17:          new PipelineBuildDefinition(pipe).FollowStream(stream, minimumBufferSize);
〰18:  
〰19:      internal static IPipelineBuildDefinition FollowStream(this IPipelineBuildDefinition pipeline, Stream stream, int minimumBufferSize = 4096)
〰20:      {
‼21:          if (pipeline is not PipelineBuildDefinition def)
〰22:          {
‼23:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰24:          }
‼25:          else if (def.PipeWriter != null)
〰26:          {
‼27:              throw new NotSupportedException("this pipeline already has a writer");
〰28:          }
‼29:          def.PipeWriter = new StreamPipelineFactory().CreateWriter(def, stream, minimumBufferSize);
‼30:          return def;
〰31:      }
〰32:  
〰33:      public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, ISegmenter segmenter)
〰34:      {
‼35:          if (pipeline is not PipelineBuildDefinition def)
〰36:          {
‼37:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰38:          }
‼39:          else if (def.PipeReader != null)
〰40:          {
‼41:              throw new NotSupportedException("this pipeline already has a reader");
〰42:          }
‼43:          def.PipeReader = new SegmentPipeFactory().CreateReader(def, segmenter);
‼44:          return def;
〰45:      }
〰46:      public static IPipelineBuildDefinition With(this IPipelineBuildDefinition pipeline, Stream stream)
〰47:      {
‼48:          if (pipeline is not PipelineBuildDefinition def)
〰49:          {
‼50:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰51:          }
‼52:          else if (def.PipeReader != null)
〰53:          {
‼54:              throw new NotSupportedException("this pipeline already has a reader");
〰55:          }
‼56:          def.PipeReader = new StreamPipelineFactory().CreateReader(pipeline: def, stream);
‼57:          return def;
〰58:      }
〰59:  
〰60:      public static IPipelineBuildDefinition OnError(this IPipelineBuildDefinition pipeline, OnException onPipelineError)
〰61:      {
‼62:          if (pipeline is not PipelineBuildDefinition def)
〰63:          {
‼64:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰65:          }
‼66:          else if (def.PipeReader != null)
〰67:          {
‼68:              throw new NotSupportedException("this pipeline already has a reader");
〰69:          }
‼70:          def.OnError = onPipelineError;
‼71:          return def;
〰72:      }
〰73:      public static IPipelineBuildDefinition OnReaderError(this IPipelineBuildDefinition pipeline, OnException onPipelineError)
〰74:      {
‼75:          if (pipeline is not PipelineBuildDefinition def)
〰76:          {
‼77:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰78:          }
‼79:          else if (def.PipeReader != null)
〰80:          {
‼81:              throw new NotSupportedException("this pipeline already has a reader");
〰82:          }
‼83:          def.OnReaderError = onPipelineError;
‼84:          return def;
〰85:      }
〰86:      public static IPipelineBuildDefinition OnWriterError(this IPipelineBuildDefinition pipeline, OnException onPipelineError)
〰87:      {
‼88:          if (pipeline is not PipelineBuildDefinition def)
〰89:          {
‼90:              throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰91:          }
‼92:          else if (def.PipeReader != null)
〰93:          {
‼94:              throw new NotSupportedException("this pipeline already has a reader");
〰95:          }
‼96:          def.OnWriterError = onPipelineError;
‼97:          return def;
〰98:      }
〰99:  
〰100:     public static Task RunAsync(this IPipelineBuildDefinition pipeline, CancellationToken cancellationToken = default)
〰101:     {
‼102:         if (pipeline is not PipelineBuildDefinition def)
〰103:         {
‼104:             throw new NotSupportedException($"{pipeline.GetType()} is not supported");
〰105:         }
‼106:         else if (def.PipeWriter == null)
〰107:         {
‼108:             throw new NotSupportedException("this pipeline is not configured with a writer");
〰109:         }
‼110:         else if (def.PipeReader == null)
〰111:         {
‼112:             throw new NotSupportedException("this pipeline is not configured with a reader");
〰113:         }
〰114: 
‼115:         cancellationToken.Register(() => def.CancellationTokenSource.Cancel());
〰116: 
‼117:         return Task.WhenAll(
‼118:             Task.Run(async () => await def.PipeWriter, cancellationToken),
‼119:             Task.Run(async () => await def.PipeReader, cancellationToken)
‼120:             );
〰121:     }
〰122: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

