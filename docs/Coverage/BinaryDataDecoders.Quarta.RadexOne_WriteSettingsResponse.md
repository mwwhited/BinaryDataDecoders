
# BinaryDataDecoders.Quarta.RadexOne.WriteSettingsResponse
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Quarta.RadexOne_WriteSettingsResponse.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Quarta.RadexOne.WriteSettingsResponse     | 
| Assembly             | BinaryDataDecoders.Quarta.RadexOne                           | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 1                                                            | 
| Coverablelines       | 1                                                            | 
| Totallines           | 43                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\WriteSettingsResponse.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\WriteSettingsResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {
〰6:       /// <summary>
〰7:       /// Response message after Write Settings is requested
〰8:       /// </summary>
〰9:       [MessageMatchPattern(
〰10:          "7AFF-2080-0600-00000000-0000|0208+",
〰11:          Mask = "ffff-ffff-ffff-00000000-0000|ffff+"
〰12:          )]
〰13:      [StructLayout(LayoutKind.Explicit, Size = 18)]
〰14:      public struct WriteSettingsResponse : IRadexObject
〰15:      {
〰16:          //<: 7AFF 2080 0600 FA05 ____ 647A 0208 ____ FDF7
〰17:          [FieldOffset(0)]
〰18:          private readonly ushort Prefix;
〰19:          [FieldOffset(2)]
〰20:          private readonly ushort Command;
〰21:          [FieldOffset(4)]
〰22:          private readonly ushort ExtensionLength;
〰23:          /// <summary>
〰24:          /// packetnumber is returned by response and may be used for correlation.
〰25:          /// </summary>
〰26:          [FieldOffset(6)]
〰27:          public readonly uint PacketNumber;
〰28:          [FieldOffset(10)]
〰29:          private readonly ushort CheckSum0;
〰30:  
〰31:          [FieldOffset(12)]
〰32:          private readonly ushort SubCommand;
〰33:          [FieldOffset(16)]
〰34:          private readonly ushort CheckSum1;
〰35:  
〰36:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰37:          public override string ToString()
〰38:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰39:          {
‼40:              return $"Write Settings:\t({PacketNumber}:0x{PacketNumber:X2})";
〰41:          }
〰42:      }
〰43:  }

```
## Footer 
[Return to Summary](Summary.md)

