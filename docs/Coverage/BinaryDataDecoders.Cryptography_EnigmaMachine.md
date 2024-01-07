# BinaryDataDecoders.Cryptography.Enigma.EnigmaMachine

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaMachine` |
| Assembly        | `BinaryDataDecoders.Cryptography`                      |
| Coveredlines    | `47`                                                   |
| Uncoveredlines  | `83`                                                   |
| Coverablelines  | `130`                                                  |
| Totallines      | `287`                                                  |
| Linecoverage    | `36.1`                                                 |
| Coveredbranches | `26`                                                   |
| Totalbranches   | `84`                                                   |
| Branchcoverage  | `30.9`                                                 |
| Coveredmethods  | `6`                                                    |
| Totalmethods    | `20`                                                   |
| Methodcoverage  | `30`                                                   |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 8          | 0     | 0        | `ctor`             |
| 2          | 0     | 0        | `get_Positions`    |
| 2          | 0     | 0        | `set_Positions`    |
| 2          | 0     | 0        | `get_RingSettings` |
| 2          | 0     | 0        | `set_RingSettings` |
| 2          | 0     | 0        | `get_PlugBoard`    |
| 10         | 0     | 0        | `set_PlugBoard`    |
| 1          | 0     | 100      | `get_Rotors`       |
| 1          | 0     | 100      | `get_Reflector`    |
| 14         | 0     | 0        | `Process`          |
| 8          | 77.77 | 50.0     | `ctor`             |
| 2          | 100   | 50.0     | `get_Positions`    |
| 2          | 100   | 50.0     | `set_Positions`    |
| 2          | 0     | 0        | `get_RingSettings` |
| 2          | 100   | 100      | `set_RingSettings` |
| 2          | 0     | 0        | `get_PlugBoard`    |
| 10         | 80.0  | 80.0     | `set_PlugBoard`    |
| 1          | 0     | 100      | `get_Rotors`       |
| 1          | 0     | 100      | `get_Reflector`    |
| 14         | 75.00 | 71.42    | `Process`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaMachine.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰6:   
〰7:   // https://en.wikipedia.org/wiki/Enigma_rotor_details
〰8:   // http://enigmaco.de/enigma/enigma.html
〰9:   public class EnigmaMachine
〰10:  {
〰11:      private string[]? plugboard;
〰12:      private int[]? postions;
〰13:      private int[]? ringSettings;
〰14:      private readonly EnigmaRotor[] rotors;
〰15:      private readonly EnigmaReflector reflector;
〰16:  
〰17:      public EnigmaMachine(EnigmaRotor[] rotors,
〰18:                           EnigmaReflector reflector,
〰19:                           //string start = null,
〰20:                           string? ringSettings = default,
〰21:                           string? plugBoard = default)
〰22:      {
‼23:          if (rotors == null || rotors.Length < 3 || rotors.Length > 5)
‼24:              throw new InvalidOperationException("Invalid Rotor Set");
‼25:          if (reflector == null)
‼26:              throw new InvalidOperationException("Invalid Reflector");
〰27:  
‼28:          this.rotors = rotors.Reverse().ToArray();
‼29:          this.reflector = reflector;
〰30:          //this.Positions = default;  //(start ?? new string('A', rotors.Length));
‼31:          this.RingSettings = ringSettings;
‼32:          this.PlugBoard = plugBoard;
‼33:      }
〰34:  
〰35:      public string Positions
〰36:      {
〰37:          get
〰38:          {
‼39:              return (this.postions?
‼40:                          .Reverse()
‼41:                          .Select(p => (char)(p + 'A'))
‼42:                          .AsString()
‼43:                          + new string('A', this.rotors.Length)
‼44:                          )[..this.rotors.Length];
〰45:          }
〰46:          set
〰47:          {
‼48:              this.postions = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
‼49:                                   .Concat(new int[this.rotors.Length])
‼50:                                   .Take(this.rotors.Length)
‼51:                                   .Reverse()
‼52:                                   .ToArray();
‼53:          }
〰54:      }
〰55:  
〰56:      public string? RingSettings
〰57:      {
〰58:          get
〰59:          {
‼60:              return (this.ringSettings?
‼61:                          .Reverse()
‼62:                          .Select(p => (char)(p + 'A'))
‼63:                          .AsString()
‼64:                          + new string('A', this.rotors.Length)
‼65:                          )[..this.rotors.Length];
〰66:          }
〰67:          private set
〰68:          {
‼69:              this.ringSettings = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
‼70:                                       .Concat(new int[this.rotors.Length])
‼71:                                       .Take(this.rotors.Length)
‼72:                                       .Reverse()
‼73:                                       .ToArray();
‼74:          }
〰75:      }
〰76:  
〰77:      public string? PlugBoard
〰78:      {
〰79:          get
〰80:          {
‼81:              return string.Join(" ", this.plugboard ?? []);
〰82:          }
〰83:          set
〰84:          {
‼85:              var cleaned = value?.Clean().AsString() ?? "";
‼86:              if (cleaned.Length % 2 == 0 && cleaned.GroupBy(c => c).Any(c => c.Count() != 1))
‼87:                  throw new InvalidOperationException("Invalid Plug Board");
〰88:  
‼89:              this.plugboard = cleaned?.SplitAt(2).ToArray();
‼90:          }
〰91:      }
〰92:  
〰93:      public string Rotors
〰94:      {
‼95:          get { return string.Join(";", this.rotors.Select(r => r.Number)); }
〰96:      }
〰97:      public string Reflector
〰98:      {
‼99:          get { return this.reflector.Number; }
〰100:     }
〰101: 
〰102:     public string Process(string input)
〰103:     {
‼104:         input = input.Clean().AsString().SwapSet(this.plugboard);
‼105:         var start = this.Positions;
‼106:         var set = this.rotors;
‼107:         var rs = this.ringSettings;
‼108:         var l = 26; // set[0].Length;
〰109: 
‼110:         var cOut = new List<char>();
〰111: 
‼112:         foreach (var c in input.Select(x => x - 'A'))
〰113:         {;
‼114:             this.postions[0] = (this.postions[0] + 1) % l;
‼115:             if (this.rotors[0].RotateOn.Contains((char)(this.postions[0] + 'A')))
〰116:             {
‼117:                 this.postions[1] = (this.postions[1] + 1) % l;
〰118: 
‼119:                 if (this.rotors[1].RotateOn.Contains((char)(this.postions[1] + 'A')))
〰120:                 {
‼121:                     this.postions[2] = (this.postions[2] + 1) % l;
〰122: 
‼123:                     if (this.rotors.Length > 3 &&
‼124:                         this.rotors[2].RotateOn.Contains((char)(this.postions[2] + 'A')))
〰125:                     {
‼126:                         this.postions[3] = (this.postions[3] + 1) % l;
〰127:                     }
〰128:                 }
〰129:             }
〰130: 
‼131:             var indexes = this.postions;
〰132: 
‼133:             var m = c;
‼134:             for (var i = 0; i < set.Length; i++)
‼135:                 m = (set[i].Wiring[(m + indexes[i] + rs[i]) % l] - indexes[i] - 'A' + l) % l;
‼136:             m = (reflector.Wiring[m] - 'A' + l) % l;
‼137:             for (var i = set.Length - 1; i > -1; i--)
‼138:                 m = (set[i].Wiring.IndexOf((char)(((m + indexes[i]) % l) + 'A')) - indexes[i] - rs[i] + l) % l;
‼139:             cOut.Add((char)(m + 'A'));
〰140:         }
‼141:         return cOut.AsString().SwapSet(this.plugboard);
〰142:     }
〰143: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaMachine.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰6:   
〰7:   // https://en.wikipedia.org/wiki/Enigma_rotor_details
〰8:   // http://enigmaco.de/enigma/enigma.html
〰9:   public class EnigmaMachine
〰10:  {
〰11:      private string[]? plugboard;
〰12:      private int[]? postions;
〰13:      private int[]? ringSettings;
〰14:      private readonly EnigmaRotor[] rotors;
〰15:      private readonly EnigmaReflector reflector;
〰16:  
〰17:      public EnigmaMachine(EnigmaRotor[] rotors,
〰18:                           EnigmaReflector reflector,
〰19:                           //string start = null,
〰20:                           string? ringSettings = default,
〰21:                           string? plugBoard = default)
〰22:      {
⚠23:          if (rotors == null || rotors.Length < 3 || rotors.Length > 5)
‼24:              throw new InvalidOperationException("Invalid Rotor Set");
⚠25:          if (reflector == null)
‼26:              throw new InvalidOperationException("Invalid Reflector");
〰27:  
✔28:          this.rotors = rotors.Reverse().ToArray();
✔29:          this.reflector = reflector;
〰30:          //this.Positions = default;  //(start ?? new string('A', rotors.Length));
✔31:          this.RingSettings = ringSettings;
✔32:          this.PlugBoard = plugBoard;
✔33:      }
〰34:  
〰35:      public string Positions
〰36:      {
〰37:          get
〰38:          {
⚠39:              return (this.postions?
✔40:                          .Reverse()
✔41:                          .Select(p => (char)(p + 'A'))
✔42:                          .AsString()
✔43:                          + new string('A', this.rotors.Length)
✔44:                          )[..this.rotors.Length];
〰45:          }
〰46:          set
〰47:          {
⚠48:              this.postions = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
✔49:                                   .Concat(new int[this.rotors.Length])
✔50:                                   .Take(this.rotors.Length)
✔51:                                   .Reverse()
✔52:                                   .ToArray();
✔53:          }
〰54:      }
〰55:  
〰56:      public string? RingSettings
〰57:      {
〰58:          get
〰59:          {
‼60:              return (this.ringSettings?
‼61:                          .Reverse()
‼62:                          .Select(p => (char)(p + 'A'))
‼63:                          .AsString()
‼64:                          + new string('A', this.rotors.Length)
‼65:                          )[..this.rotors.Length];
〰66:          }
〰67:          private set
〰68:          {
✔69:              this.ringSettings = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
✔70:                                       .Concat(new int[this.rotors.Length])
✔71:                                       .Take(this.rotors.Length)
✔72:                                       .Reverse()
✔73:                                       .ToArray();
✔74:          }
〰75:      }
〰76:  
〰77:      public string? PlugBoard
〰78:      {
〰79:          get
〰80:          {
‼81:              return string.Join(" ", this.plugboard ?? []);
〰82:          }
〰83:          set
〰84:          {
✔85:              var cleaned = value?.Clean().AsString() ?? "";
⚠86:              if (cleaned.Length % 2 == 0 && cleaned.GroupBy(c => c).Any(c => c.Count() != 1))
‼87:                  throw new InvalidOperationException("Invalid Plug Board");
〰88:  
⚠89:              this.plugboard = cleaned?.SplitAt(2).ToArray();
✔90:          }
〰91:      }
〰92:  
〰93:      public string Rotors
〰94:      {
‼95:          get { return string.Join(";", this.rotors.Select(r => r.Number)); }
〰96:      }
〰97:      public string Reflector
〰98:      {
‼99:          get { return this.reflector.Number; }
〰100:     }
〰101: 
〰102:     public string Process(string input)
〰103:     {
✔104:         input = input.Clean().AsString().SwapSet(this.plugboard);
✔105:         var start = this.Positions;
✔106:         var set = this.rotors;
✔107:         var rs = this.ringSettings;
✔108:         var l = 26; // set[0].Length;
〰109: 
✔110:         var cOut = new List<char>();
〰111: 
✔112:         foreach (var c in input.Select(x => x - 'A'))
〰113:         {;
✔114:             this.postions[0] = (this.postions[0] + 1) % l;
⚠115:             if (this.rotors[0].RotateOn.Contains((char)(this.postions[0] + 'A')))
〰116:             {
‼117:                 this.postions[1] = (this.postions[1] + 1) % l;
〰118: 
‼119:                 if (this.rotors[1].RotateOn.Contains((char)(this.postions[1] + 'A')))
〰120:                 {
‼121:                     this.postions[2] = (this.postions[2] + 1) % l;
〰122: 
‼123:                     if (this.rotors.Length > 3 &&
‼124:                         this.rotors[2].RotateOn.Contains((char)(this.postions[2] + 'A')))
〰125:                     {
‼126:                         this.postions[3] = (this.postions[3] + 1) % l;
〰127:                     }
〰128:                 }
〰129:             }
〰130: 
✔131:             var indexes = this.postions;
〰132: 
✔133:             var m = c;
✔134:             for (var i = 0; i < set.Length; i++)
✔135:                 m = (set[i].Wiring[(m + indexes[i] + rs[i]) % l] - indexes[i] - 'A' + l) % l;
✔136:             m = (reflector.Wiring[m] - 'A' + l) % l;
✔137:             for (var i = set.Length - 1; i > -1; i--)
✔138:                 m = (set[i].Wiring.IndexOf((char)(((m + indexes[i]) % l) + 'A')) - indexes[i] - rs[i] + l) % l;
✔139:             cOut.Add((char)(m + 'A'));
〰140:         }
✔141:         return cOut.AsString().SwapSet(this.plugboard);
〰142:     }
〰143: }
〰144: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

