# ChecksumCalculator.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO/Functions/ChecksumCalculator.cs

## Public Class - ChecksumCalculator

### Comments

 <summary>
 This class contains various checksum calculation algorithms
 </summary>

### Members

#### Public Method - Simple16

##### Comments

 <summary>
 I'm not really sure is there is a &quot;proper&quot; name for this algorithm.
 
 Difference of all values in Span&lt;ushort&gt;
 </summary>
 <paramname="buffer">input span to calculate span over. </param>
 <returns>checksum value</returns>

#####  Parameters

 - ReadOnlySpan < ushort > buffer 

