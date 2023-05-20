# BinaryDataDecoders.ToolKit.ConsoleEx

## Summary

| Key             | Value                                  |
| :-------------- | :------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.ConsoleEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`           |
| Coveredlines    | `0`                                    |
| Uncoveredlines  | `43`                                   |
| Coverablelines  | `43`                                   |
| Totallines      | `86`                                   |
| Linecoverage    | `0`                                    |
| Coveredbranches | `0`                                    |
| Totalbranches   | `34`                                   |
| Branchcoverage  | `0`                                    |
| Coveredmethods  | `0`                                    |
| Totalmethods    | `3`                                    |
| Methodcoverage  | `0`                                    |

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
〰9:           public static Task<string?> ReadLineAsync() =>
‼10:              Task.FromResult(Console.ReadLine());
〰11:  
〰12:          public static string? Prompt(string? prompt = null, string? defaultValue = null)
〰13:          {
‼14:              if (!string.IsNullOrWhiteSpace(prompt))
‼15:                  Console.Write("{0} ", prompt);
‼16:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼17:                  Console.Write("{0}", defaultValue);
〰18:  
‼19:              var chars = new List<char>(defaultValue ?? "");
‼20:              while (true)
〰21:              {
‼22:                  var key = Console.ReadKey(true);
〰23:  
‼24:                  if (key.Key == ConsoleKey.Escape)
‼25:                      return null;
‼26:                  else if (key.Key == ConsoleKey.Enter)
〰27:                      break;
‼28:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰29:                  {
‼30:                      if (chars.Count > 0)
〰31:                      {
‼32:                          chars.RemoveAt(chars.Count - 1);
‼33:                          Console.Write((char)8);
‼34:                          Console.Write(" ");
‼35:                          Console.Write((char)8);
〰36:                      }
〰37:                  }
〰38:                  else
〰39:                  {
‼40:                      chars.Add(key.KeyChar);
‼41:                      Console.Write(key.KeyChar);
〰42:                  }
〰43:              }
‼44:              Console.WriteLine();
‼45:              var result = new string(chars.ToArray());
‼46:              return result;
〰47:          }
〰48:  
〰49:          public static string? PromptSecure(string? prompt = null, string? defaultValue = null, char hideWith = '*')
〰50:          {
‼51:              if (!string.IsNullOrWhiteSpace(prompt))
‼52:                  Console.Write($"{prompt} ");
‼53:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼54:                  Console.Write($"{new string(hideWith, defaultValue.Length)}");
〰55:  
‼56:              var chars = new List<char>(defaultValue ?? "");
‼57:              while (true)
〰58:              {
‼59:                  var key = Console.ReadKey(true);
〰60:  
‼61:                  if (key.Key == ConsoleKey.Escape)
‼62:                      return null;
‼63:                  else if (key.Key == ConsoleKey.Enter)
〰64:                      break;
‼65:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰66:                  {
‼67:                      if (chars.Count > 0)
〰68:                      {
‼69:                          chars.RemoveAt(chars.Count - 1);
‼70:                          Console.Write((char)8);
‼71:                          Console.Write(" ");
‼72:                          Console.Write((char)8);
〰73:                      }
〰74:                  }
〰75:                  else
〰76:                  {
‼77:                      chars.Add(key.KeyChar);
‼78:                      Console.Write(hideWith);
〰79:                  }
〰80:              }
‼81:              Console.WriteLine();
‼82:              var result = new string(chars.ToArray());
‼83:              return result;
〰84:          }
〰85:      }
〰86:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

