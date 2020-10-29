# PipelineBuilder.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.IO.Pipelines\PipelineBuilder.cs

## Public Static Class - PipelineBuilder

### Members

#### Public Static Method - Follow

#####  Parameters

 - this Stream stream 
 - int minimumBufferSize = 4096 

#### Internal Static Method - FollowStream

#####  Parameters

 - this Pipe pipe 
 - Stream stream 
 - int minimumBufferSize = 4096 

#### Internal Static Method - FollowStream

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - Stream stream 
 - int minimumBufferSize = 4096 

#### Public Static Method - With

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - ISegmenter segmenter 

#### Public Static Method - With

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - Stream stream 

#### Public Static Method - OnError

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - OnPipelineError onPipelineError 

#### Public Static Method - OnReaderError

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - OnPipelineError onPipelineError 

#### Public Static Method - OnWriterError

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - OnPipelineError onPipelineError 

#### Public Static Method - RunAsync

#####  Parameters

 - this IPipelineBuildDefinition pipeline 
 - CancellationToken cancellationToken = default 

