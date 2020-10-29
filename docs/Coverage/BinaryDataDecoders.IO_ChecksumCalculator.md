
# BinaryDataDecoders.IO.Functions.ChecksumCalculator
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.IO_ChecksumCalculator.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.IO.Functions.ChecksumCalculator           | 
| Assembly             | BinaryDataDecoders.IO                                        | 
| Coveredlines         | 4                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 25                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 2                                                            | 
| Totalbranches        | 2                                                            | 
| Branchcoverage       | 100                                                          | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO\Functions\ChecksumCalculator.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 2          | 100   | 100      | Simple16 | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO\Functions\ChecksumCalculator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Functions
〰4:   {
〰5:       /// <summary>
〰6:       /// This class contains various checksum calculation algorithms
〰7:       /// </summary>
〰8:       public class ChecksumCalculator : IChecksumCalculator
〰9:       {
〰10:          /// <summary>
〰11:          /// I'm not really sure is there is a &quot;proper&quot; name for this algorithm.
〰12:          ///
〰13:          /// Difference of all values in Span&lt;ushort&gt;
〰14:          /// </summary>
〰15:          /// <param name="buffer">input span to calculate span over. </param>
〰16:          /// <returns>checksum value</returns>
〰17:          public ushort Simple16(ReadOnlySpan<ushort> buffer)
〰18:          {
✔19:              int sum = -1;
✔20:              foreach (var term in buffer)
✔21:                  sum -= term;
✔22:              return (ushort)(sum % 0xffff);
〰23:          }
〰24:      }
〰25:  }

```
## Footer 
[Return to Summary](Summary.md)

