﻿# BinaryDataDecoders.Cryptography.Vigenere

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Vigenere` |
| Assembly        | `BinaryDataDecoders.Cryptography`          |
| Coveredlines    | `11`                                       |
| Uncoveredlines  | `17`                                       |
| Coverablelines  | `28`                                       |
| Totallines      | `77`                                       |
| Linecoverage    | `39.2`                                     |
| Coveredbranches | `6`                                        |
| Totalbranches   | `24`                                       |
| Branchcoverage  | `25`                                       |
| Coveredmethods  | `3`                                        |
| Totalmethods    | `6`                                        |
| Methodcoverage  | `50`                                       |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 4          | 0     | 0        | `Encode`   |
| 4          | 0     | 0        | `Decode`   |
| 4          | 0     | 0        | `BuildKey` |
| 4          | 80.0  | 50.0     | `Encode`   |
| 4          | 80.0  | 50.0     | `Decode`   |
| 4          | 75.00 | 50.0     | `BuildKey` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Vigenere.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Threading.Tasks;
〰6:   
〰7:   namespace BinaryDataDecoders.Cryptography;
〰8:   
〰9:   public class Vigenere : Caesar
〰10:  {
〰11:  
〰12:      /// <summary>
〰13:      /// https://en.wikipedia.org/wiki/Vigen%C3%A8re_cipher
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      /// <param name="code"></param>
〰17:      /// <returns></returns>
〰18:      public string Encode(string input, string code) =>
‼19:          (input, BuildKey(input.Length, code)) switch
‼20:          {
‼21:              (null, _) => "",
‼22:              (string, string key) => new string(input.Zip(key).Select(item => Encode(item.First, item.Second)).ToArray())
‼23:          };
〰24:      public string Decode(string input, string code) =>
‼25:          (input, BuildKey(input.Length, code)) switch
‼26:          {
‼27:              (null, _) => "",
‼28:              (string, string key) => new string(input.Zip(key).Select(item => Decode(item.First, item.Second)).ToArray())
‼29:          };
〰30:  
〰31:      public string BuildKey(int length, string? code)
〰32:      {
‼33:          code = new string((code ?? string.Empty).Where(c => char.IsLetter(c)).ToArray());
‼34:          if (string.IsNullOrWhiteSpace(code))
‼35:              return new string(Enumerable.Range(0, length).Select(i => (char)('A' + (i % 26))).ToArray());
‼36:          return string.Join("", Enumerable.Range(0, length / code.Length + 1).Select(_ => code))[..length];
〰37:      }
〰38:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography/Vigenere.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Threading.Tasks;
〰6:   
〰7:   namespace BinaryDataDecoders.Cryptography;
〰8:   
〰9:   public class Vigenere : Caesar
〰10:  {
〰11:  
〰12:      /// <summary>
〰13:      /// https://en.wikipedia.org/wiki/Vigen%C3%A8re_cipher
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      /// <param name="code"></param>
〰17:      /// <returns></returns>
〰18:      public string Encode(string input, string code) =>
⚠19:          (input, BuildKey(input.Length, code)) switch
✔20:          {
‼21:              (null, _) => "",
✔22:              (string, string key) => new string(input.Zip(key).Select(item => Encode(item.First, item.Second)).ToArray())
✔23:          };
〰24:      public string Decode(string input, string code) =>
⚠25:          (input, BuildKey(input.Length, code)) switch
✔26:          {
‼27:              (null, _) => "",
✔28:              (string, string key) => new string(input.Zip(key).Select(item => Decode(item.First, item.Second)).ToArray())
✔29:          };
〰30:  
〰31:      public string BuildKey(int length, string? code)
〰32:      {
⚠33:          code = new string((code ?? string.Empty).Where(c => char.IsLetter(c)).ToArray());
⚠34:          if (string.IsNullOrWhiteSpace(code))
‼35:              return new string(Enumerable.Range(0, length).Select(i => (char)('A' + (i % 26))).ToArray());
✔36:          return string.Join("", Enumerable.Range(0, length / code.Length + 1).Select(_ => code))[..length];
〰37:      }
〰38:  }
〰39:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

