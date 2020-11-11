# BinaryDataDecoders.Apple2.ApplesoftBASIC.Detokenizer

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.ApplesoftBASIC.Detokenizer` |
| Assembly        | `BinaryDataDecoders.Apple2`                            |
| Coveredlines    | `22`                                                   |
| Uncoveredlines  | `0`                                                    |
| Coverablelines  | `22`                                                   |
| Totallines      | `63`                                                   |
| Linecoverage    | `100`                                                  |
| Coveredbranches | `22`                                                   |
| Totalbranches   | `26`                                                   |
| Branchcoverage  | `84.6`                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 26         | 100   | 84.61    | `GetLines` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\ApplesoftBASIC\Detokenizer.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Apple2.ApplesoftBASIC
〰6:   {
〰7:       /// <summary>
〰8:       /// ApplesSoft Basic detokenizer
〰9:       /// </summary>
〰10:      public class Detokenizer
〰11:      {
✔12:          private readonly TokenMap _map = new TokenMap();
〰13:  
〰14:          /// <summary>
〰15:          /// transform byte data into readable AppleSoft BASIC code.
〰16:          /// </summary>
〰17:          /// <param name="input"></param>
〰18:          /// <returns></returns>
〰19:          public IEnumerable<string> GetLines(IEnumerable<byte> input)
〰20:          {
✔21:              var e = input.GetEnumerator();
〰22:  
⚠23:              var header1 = (byte)(e.MoveNext() ? e.Current : 0);
⚠24:              var header2 = (byte)(e.MoveNext() ? e.Current : 0);
〰25:  
〰26:              //yield return $"$$$ HEADER: 0x{header1:X}, 0x{header2:X}";
✔27:              yield return $"$$$ FILE SIZE :{BitConverter.ToUInt16(new[] { header1, header2 })}";
〰28:  
✔29:              var notDone = false;
〰30:              do
〰31:              {
⚠32:                  var addressOfNextLine = BitConverter.ToUInt16(new[] { (byte)((notDone = e.MoveNext()) ? e.Current : 0), (byte)(e.MoveNext() ? e.Current : 0) });
✔33:                  var lineNumber = BitConverter.ToUInt16(new[] { (byte)((notDone = e.MoveNext()) ? e.Current : 0), (byte)(e.MoveNext() ? e.Current : 0) });
〰34:  
✔35:                  if (addressOfNextLine == 0 || lineNumber == 0) continue;
〰36:  
✔37:                  var nextLine = false;
✔38:                  var sb = new StringBuilder($"{lineNumber} "); //0x{addressOfNextLine:X}]\t
〰39:                  do
〰40:                  {
⚠41:                      var v = (byte)((nextLine = e.MoveNext()) ? e.Current : 0);
✔42:                      if (nextLine = (v == 0))
〰43:                      {
〰44:                          //End of Line
✔45:                          yield return sb.ToString();
✔46:                          sb.Clear();
〰47:                      }
✔48:                      else if ((v & 0x80) == 0)
〰49:                      {
〰50:                          //Character
✔51:                          sb.Append((char)v);
〰52:                      }
〰53:                      else
〰54:                      {
〰55:                          //Token
✔56:                          var token = _map.GetToken(v) + " ";
✔57:                          sb.Append(token);
〰58:                      }
✔59:                  } while (!nextLine);
✔60:              } while (notDone);
✔61:          }
〰62:      }
〰63:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

