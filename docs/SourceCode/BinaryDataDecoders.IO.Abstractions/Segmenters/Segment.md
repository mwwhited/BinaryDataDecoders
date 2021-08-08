# Segment.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.Abstractions/Segmenters/Segment.cs

## Public Static Class - Segment

### Members

#### Public Static Method - StartsWith

#####  Parameters

 - ControlCharacters start 

#### Public Static Method - StartsWith

#####  Parameters

 - params byte [  ] starts 

#### Public Static Method - StartsWithMask

#####  Parameters

 - byte mask 

#### Public Static Method - PassThough


#### Public Static Method - AndEndsWith

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - ControlCharacters end 

#### Public Static Method - AndEndsWith

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - byte end 

#### Public Static Method - ExtendedWithLengthAt

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - long position 
 - Endianness endianness 

#### Public Static Method - WithMaxLength

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - long maxLength 

#### Public Static Method - WithOptions

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - SegmentionOptions options 

#### Public Static Method - AndIsLength

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - long length 

#### Public Static Method - ThenDo

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - OnSegmentReceived onSegmentReceived 

#### Public Static Method - ThenAs

#####  Parameters

 - this ISegmentBuildDefinition builder 
 - IMessageDecoder < TMessage > decoder 
 - OnMessageReceived < TMessage > onMessageReceived 

