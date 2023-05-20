# BinaryDataDecoders.Cryptography.Caesar

## Summary

| Key             | Value                                    |
| :-------------- | :--------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Caesar` |
| Assembly        | `BinaryDataDecoders.Cryptography`        |
| Coveredlines    | `27`                                     |
| Uncoveredlines  | `3`                                      |
| Coverablelines  | `30`                                     |
| Totallines      | `52`                                     |
| Linecoverage    | `90`                                     |
| Coveredbranches | `23`                                     |
| Totalbranches   | `28`                                     |
| Branchcoverage  | `82.1`                                   |
| Coveredmethods  | `7`                                      |
| Totalmethods    | `7`                                      |
| Methodcoverage  | `100`                                    |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 2          | 80.0  | 50.0     | `Encode`    |
| 2          | 80.0  | 50.0     | `Decode`    |
| 1          | 100   | 100      | `Encode`    |
| 1          | 100   | 100      | `Decode`    |
| 8          | 100   | 100      | `Encode`    |
| 8          | 100   | 100      | `Decode`    |
| 8          | 83.33 | 62.50    | `GetOffset` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Caesar.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.Cryptography
〰5:   {
〰6:       public class Caesar
〰7:       {
〰8:           /// <summary>
〰9:           /// https://en.wikipedia.org/wiki/Caesar_cipher
〰10:          /// </summary>
〰11:          /// <param name="input"></param>
〰12:          /// <param name="code"></param>
〰13:          /// <returns></returns>
〰14:          public string Encode(string input, char code) =>
⚠15:              (GetOffset(code), input) switch
✔16:              {
‼17:                  (_, null) => "",
✔18:                  (int offset, _) => new string(input.Select(c => Encode(c, offset)).ToArray())
✔19:              };
〰20:          public string Decode(string input, char code) =>
⚠21:              (GetOffset(code), input) switch
✔22:              {
‼23:                  (_, null) => "",
✔24:                  (int offset, _) => new string(input.Select(c => Decode(c, offset)).ToArray())
✔25:              };
〰26:  
✔27:          public char Encode(char input, char code) => Encode(input, GetOffset(code));
✔28:          public char Decode(char input, char code) => Decode(input, GetOffset(code));
〰29:  
〰30:          public char Encode(char input, int offset) =>
✔31:              input switch
✔32:              {
✔33:                  >= 'A' and <= 'Z' => (char)('A' + ((input - 'A' + offset) % 26)),
✔34:                  >= 'a' and <= 'z' => (char)('a' + ((input - 'a' + offset) % 26)),
✔35:                  _ => input
✔36:              };
〰37:          public char Decode(char input, int offset) =>
✔38:              input switch
✔39:              {
✔40:                  >= 'A' and <= 'Z' => (char)('A' + ((input + 26 - 'A' - offset) % 26)),
✔41:                  >= 'a' and <= 'z' => (char)('a' + ((input + 26 - 'a' - offset) % 26)),
✔42:                  _ => input
✔43:              };
〰44:  
⚠45:          public int GetOffset(char code) => code switch
✔46:          {
✔47:              >= 'A' and <= 'Z' => code - 'A',
✔48:              >= 'a' and <= 'z' => code - 'a',
‼49:              _ => throw new ArgumentOutOfRangeException(nameof(code), "\"code\" must be between 'A' and 'Z'")
✔50:          };
〰51:      }
〰52:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

