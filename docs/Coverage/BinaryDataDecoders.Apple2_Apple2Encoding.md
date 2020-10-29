
# BinaryDataDecoders.Apple2.Text.Apple2Encoding
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Apple2_Apple2Encoding.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Apple2.Text.Apple2Encoding                | 
| Assembly             | BinaryDataDecoders.Apple2                                    | 
| Coveredlines         | 6                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 48                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 1                                                            | 
| Totalbranches        | 2                                                            | 
| Branchcoverage       | 50                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Text\Apple2Encoding.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | cctor | 
| 2          | 100   | 50.0     | GetChars | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Text\Apple2Encoding.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit;
〰2:   using System;
〰3:   using System.Diagnostics.CodeAnalysis;
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.Apple2.Text
〰7:   {
〰8:       /// <summary>
〰9:       /// Represents Apple ][ encoding of Unicode characters
〰10:      /// </summary>
〰11:      public class Apple2Encoding : ASCIIEncoding
〰12:      {
〰13:          /// <summary>
〰14:          /// Get common instance of Apple2Encoding
〰15:          /// </summary>
✔16:          public static Apple2Encoding Apple2 { get; } = new Apple2Encoding();
〰17:  
〰18:          /// <summary>
〰19:          /// Description for email tags
〰20:          /// </summary>
〰21:          [ExcludeFromCodeCoverage]
〰22:          public override string BodyName => "Apple ][";
〰23:          /// <summary>
〰24:          /// Name for encoding
〰25:          /// </summary>
〰26:          [ExcludeFromCodeCoverage]
〰27:          public override string EncodingName => "Apple ][";
〰28:  
〰29:          /// <summary>
〰30:          /// Decodes AppleIi byte array into string
〰31:          /// </summary>
〰32:          /// <param name="bytes"></param>
〰33:          /// <param name="byteCount"></param>
〰34:          /// <param name="chars"></param>
〰35:          /// <param name="charCount"></param>
〰36:          /// <returns></returns>
〰37:          public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
〰38:          {
✔39:              var len = byteCount < charCount ? byteCount : charCount;
〰40:  
✔41:              var byteSpan = new ReadOnlySpan<byte>(bytes, byteCount);
✔42:              var charSpan = new Span<char>(chars, charCount);
〰43:  
✔44:              byteSpan.CopyToWithTransform(charSpan, i => (char)(i & 0x7f));
⚠45:              return byteCount < charCount ? byteCount : charCount;
〰46:          }
〰47:      }
〰48:  }

```
## Footer 
[Return to Summary](Summary.md)

