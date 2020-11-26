# BinaryDataDecoders.ToolKit.ConsoleEx

## Summary

| Key             | Value                                  |
| :-------------- | :------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.ConsoleEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`           |
| Coveredlines    | `0`                                    |
| Uncoveredlines  | `42`                                   |
| Coverablelines  | `42`                                   |
| Totallines      | `82`                                   |
| Linecoverage    | `0`                                    |
| Coveredbranches | `0`                                    |
| Totalbranches   | `34`                                   |
| Branchcoverage  | `0`                                    |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 16         | 0     | 0        | `Prompt`       |
| 18         | 0     | 0        | `PromptSecure` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/ConsoleEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit
〰5:   {
〰6:       public static class ConsoleEx
〰7:       {
〰8:           public static string? Prompt(string? prompt = null, string? defaultValue = null)
〰9:           {
‼10:              if (!string.IsNullOrWhiteSpace(prompt))
‼11:                  Console.Write("{0} ", prompt);
‼12:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼13:                  Console.Write("{0}", defaultValue);
〰14:  
‼15:              var chars = new List<char>(defaultValue ?? "");
‼16:              while (true)
〰17:              {
‼18:                  var key = Console.ReadKey(true);
〰19:  
‼20:                  if (key.Key == ConsoleKey.Escape)
‼21:                      return null;
‼22:                  else if (key.Key == ConsoleKey.Enter)
〰23:                      break;
‼24:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰25:                  {
‼26:                      if (chars.Count > 0)
〰27:                      {
‼28:                          chars.RemoveAt(chars.Count - 1);
‼29:                          Console.Write((char)8);
‼30:                          Console.Write(" ");
‼31:                          Console.Write((char)8);
〰32:                      }
〰33:                  }
〰34:                  else
〰35:                  {
‼36:                      chars.Add(key.KeyChar);
‼37:                      Console.Write(key.KeyChar);
〰38:                  }
〰39:              }
‼40:              Console.WriteLine();
‼41:              var result = new string(chars.ToArray());
‼42:              return result;
〰43:          }
〰44:  
〰45:          public static string? PromptSecure(string? prompt = null, string? defaultValue = null, char hideWith = '*')
〰46:          {
‼47:              if (!string.IsNullOrWhiteSpace(prompt))
‼48:                  Console.Write($"{prompt} ");
‼49:              if (!string.IsNullOrWhiteSpace(defaultValue))
‼50:                  Console.Write($"{new string(hideWith, defaultValue.Length)}");
〰51:  
‼52:              var chars = new List<char>(defaultValue ?? "");
‼53:              while (true)
〰54:              {
‼55:                  var key = Console.ReadKey(true);
〰56:  
‼57:                  if (key.Key == ConsoleKey.Escape)
‼58:                      return null;
‼59:                  else if (key.Key == ConsoleKey.Enter)
〰60:                      break;
‼61:                  else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
〰62:                  {
‼63:                      if (chars.Count > 0)
〰64:                      {
‼65:                          chars.RemoveAt(chars.Count - 1);
‼66:                          Console.Write((char)8);
‼67:                          Console.Write(" ");
‼68:                          Console.Write((char)8);
〰69:                      }
〰70:                  }
〰71:                  else
〰72:                  {
‼73:                      chars.Add(key.KeyChar);
‼74:                      Console.Write(hideWith);
〰75:                  }
〰76:              }
‼77:              Console.WriteLine();
‼78:              var result = new string(chars.ToArray());
‼79:              return result;
〰80:          }
〰81:      }
〰82:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

