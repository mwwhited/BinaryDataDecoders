# BinaryDataDecoders.ToolKit.ConsoleEx

## Summary

| Key             | Value                                  |
| :-------------- | :------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.ConsoleEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`           |
| Coveredlines    | `0`                                    |
| Uncoveredlines  | `43`                                   |
| Coverablelines  | `43`                                   |
| Totallines      | `85`                                   |
| Linecoverage    | `0`                                    |
| Coveredbranches | `0`                                    |
| Totalbranches   | `34`                                   |
| Branchcoverage  | `0`                                    |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `ReadLineAsync` |
| 16         | 0     | 0        | `Prompt`        |
| 18         | 0     | 0        | `PromptSecure`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/ConsoleEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit
〰6:   {
〰7:       public static class ConsoleEx
〰8:       {
‼9:           public static Task<string> ReadLineAsync() => Task.FromResult(Console.ReadLine());
〰10:  
〰11:          public static string? Prompt(string? prompt = null, string? defaultValue = null)
〰12:          {
‼13:              if (!string.IsNullOrWhiteSpace(prompt))
‼14:                  Console.Write("{0} ", prompt);
‼15:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼16:                  Console.Write("{0}", defaultValue);
〰17:  
‼18:              var chars = new List<char>(defaultValue ?? "");
‼19:              while (true)
〰20:              {
‼21:                  var key = Console.ReadKey(true);
〰22:  
‼23:                  if (key.Key == ConsoleKey.Escape)
‼24:                      return null;
‼25:                  else if (key.Key == ConsoleKey.Enter)
〰26:                      break;
‼27:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰28:                  {
‼29:                      if (chars.Count > 0)
〰30:                      {
‼31:                          chars.RemoveAt(chars.Count - 1);
‼32:                          Console.Write((char)8);
‼33:                          Console.Write(" ");
‼34:                          Console.Write((char)8);
〰35:                      }
〰36:                  }
〰37:                  else
〰38:                  {
‼39:                      chars.Add(key.KeyChar);
‼40:                      Console.Write(key.KeyChar);
〰41:                  }
〰42:              }
‼43:              Console.WriteLine();
‼44:              var result = new string(chars.ToArray());
‼45:              return result;
〰46:          }
〰47:  
〰48:          public static string? PromptSecure(string? prompt = null, string? defaultValue = null, char hideWith = '*')
〰49:          {
‼50:              if (!string.IsNullOrWhiteSpace(prompt))
‼51:                  Console.Write($"{prompt} ");
‼52:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼53:                  Console.Write($"{new string(hideWith, defaultValue.Length)}");
〰54:  
‼55:              var chars = new List<char>(defaultValue ?? "");
‼56:              while (true)
〰57:              {
‼58:                  var key = Console.ReadKey(true);
〰59:  
‼60:                  if (key.Key == ConsoleKey.Escape)
‼61:                      return null;
‼62:                  else if (key.Key == ConsoleKey.Enter)
〰63:                      break;
‼64:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰65:                  {
‼66:                      if (chars.Count > 0)
〰67:                      {
‼68:                          chars.RemoveAt(chars.Count - 1);
‼69:                          Console.Write((char)8);
‼70:                          Console.Write(" ");
‼71:                          Console.Write((char)8);
〰72:                      }
〰73:                  }
〰74:                  else
〰75:                  {
‼76:                      chars.Add(key.KeyChar);
‼77:                      Console.Write(hideWith);
〰78:                  }
〰79:              }
‼80:              Console.WriteLine();
‼81:              var result = new string(chars.ToArray());
‼82:              return result;
〰83:          }
〰84:      }
〰85:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

