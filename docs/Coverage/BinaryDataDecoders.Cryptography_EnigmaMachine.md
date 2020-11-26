# BinaryDataDecoders.Cryptography.Enigma.EnigmaMachine

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaMachine` |
| Assembly        | `BinaryDataDecoders.Cryptography`                      |
| Coveredlines    | `52`                                                   |
| Uncoveredlines  | `18`                                                   |
| Coverablelines  | `70`                                                   |
| Totallines      | `143`                                                  |
| Linecoverage    | `74.2`                                                 |
| Coveredbranches | `21`                                                   |
| Totalbranches   | `32`                                                   |
| Branchcoverage  | `65.6`                                                 |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 8          | 85.71 | 50.0     | `ctor`             |
| 1          | 100   | 100      | `get_Position`     |
| 2          | 100   | 100      | `set_Position`     |
| 1          | 0     | 100      | `get_RingSettings` |
| 2          | 100   | 100      | `set_RingSettings` |
| 2          | 0     | 0        | `get_PlugBoard`    |
| 4          | 80.0  | 75.00    | `set_PlugBoard`    |
| 1          | 0     | 100      | `get_Rotors`       |
| 1          | 0     | 100      | `get_Reflector`    |
| 14         | 75.00 | 71.42    | `Process`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaMachine.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.Cryptography.Enigma
〰7:   {
〰8:       // https://en.wikipedia.org/wiki/Enigma_rotor_details
〰9:       // http://enigmaco.de/enigma/enigma.html
〰10:      public class EnigmaMachine
〰11:      {
〰12:          private string[] plugboard;
〰13:          private int[] postions;
〰14:          private int[] ringSettings;
〰15:          private readonly EnigmaRotor[] rotors;
〰16:          private EnigmaReflector reflector;
✔17:          public EnigmaMachine(EnigmaRotor[] rotors,
✔18:                               EnigmaReflector reflector,
✔19:                               //string start = null,
✔20:                               string ringSettings = null,
✔21:                               string plugBoard = null)
〰22:          {
⚠23:              if (rotors == null || rotors.Length < 3 || rotors.Length > 5)
‼24:                  throw new InvalidOperationException("Invalid Rotor Set");
⚠25:              if (reflector == null)
‼26:                  throw new InvalidOperationException("Invalid Reflector");
〰27:  
✔28:              this.rotors = rotors.Reverse().ToArray();
✔29:              this.reflector = reflector;
✔30:              this.Position = null;  //(start ?? new string('A', rotors.Length));
✔31:              this.RingSettings = ringSettings;
✔32:          }
〰33:  
〰34:          public string Position
〰35:          {
〰36:              get
〰37:              {
✔38:                  return (this.postions
✔39:                              .Reverse()
✔40:                              .Select(p => (char)(p + 'A'))
✔41:                              .AsString()
✔42:                              + new string('A', this.rotors.Length)
✔43:                              ).Substring(0, this.rotors.Length);
〰44:              }
〰45:              set
〰46:              {
✔47:                  this.postions = (value ?? new string('A', this.rotors.Length)).Select(i => i - 'A')
✔48:                                       .Concat(new int[this.rotors.Length])
✔49:                                       .Take(this.rotors.Length)
✔50:                                       .Reverse()
✔51:                                       .ToArray();
✔52:              }
〰53:          }
〰54:  
〰55:          public string RingSettings
〰56:          {
〰57:              get
〰58:              {
‼59:                  return (this.ringSettings
‼60:                              .Reverse()
‼61:                              .Select(p => (char)(p + 'A'))
‼62:                              .AsString()
‼63:                              + new string('A', this.rotors.Length)
‼64:                              ).Substring(0, this.rotors.Length);
〰65:              }
〰66:              private set
〰67:              {
✔68:                  this.ringSettings = (value?? new string('A', this.rotors.Length)).Select(i => i - 'A')
✔69:                                           .Concat(new int[this.rotors.Length])
✔70:                                           .Take(this.rotors.Length)
✔71:                                           .Reverse()
✔72:                                           .ToArray();
✔73:              }
〰74:          }
〰75:  
〰76:          public string PlugBoard
〰77:          {
〰78:              get
〰79:              {
‼80:                  return string.Join(" ", this.plugboard ?? new string[0]);
〰81:              }
〰82:              set
〰83:              {
✔84:                  var cleaned = value.Clean().AsString();
⚠85:                  if (cleaned.Length % 2 == 0 && cleaned.GroupBy(c => c).Any(c => c.Count() != 1))
‼86:                      throw new InvalidOperationException("Invalid Plug Board");
〰87:  
✔88:                  this.plugboard = cleaned.SplitAt(2).ToArray();
✔89:              }
〰90:          }
〰91:  
〰92:          public string Rotors
〰93:          {
‼94:              get { return string.Join(";", this.rotors.Select(r => r.Number));  }
〰95:          }
〰96:          public string Reflector
〰97:          {
‼98:              get { return this.reflector.Number; }
〰99:          }
〰100: 
〰101:         public string Process(string input)
〰102:         {
✔103:             input = input.Clean().AsString().SwapSet(this.plugboard);
✔104:             var start = this.Position;
✔105:             var set = this.rotors;
✔106:             var rs = this.ringSettings;
✔107:             var l = 26; // set[0].Length;
〰108: 
✔109:             var cOut = new List<char>();
〰110: 
✔111:             foreach (var c in input.Select(x => x - 'A'))
〰112:             {
✔113:                 this.postions[0] = (this.postions[0] + 1) % l;
⚠114:                 if (this.rotors[0].RotateOn.Contains((char)(this.postions[0] + 'A')))
〰115:                 {
‼116:                     this.postions[1] = (this.postions[1] + 1) % l;
〰117: 
‼118:                     if (this.rotors[1].RotateOn.Contains((char)(this.postions[1] + 'A')))
〰119:                     {
‼120:                         this.postions[2] = (this.postions[2] + 1) % l;
〰121: 
‼122:                         if (this.rotors.Length > 3 &&
‼123:                             this.rotors[2].RotateOn.Contains((char)(this.postions[2] + 'A')))
〰124:                         {
‼125:                             this.postions[3] = (this.postions[3] + 1) % l;
〰126:                         }
〰127:                     }
〰128:                 }
〰129: 
✔130:                 var indexes = this.postions;
〰131: 
✔132:                 var m = c;
✔133:                 for (var i = 0; i < set.Length; i++)
✔134:                     m = (set[i].Wiring[(m + indexes[i] + rs[i]) % l] - indexes[i] - 'A' + l) % l;
✔135:                 m = (reflector.Wiring[m] - 'A' + l) % l;
✔136:                 for (var i = set.Length - 1; i > -1; i--)
✔137:                     m = (set[i].Wiring.IndexOf((char)(((m + indexes[i]) % l) + 'A')) - indexes[i] - rs[i] + l) % l;
✔138:                 cOut.Add((char)(m + 'A'));
〰139:             }
✔140:             return cOut.AsString().SwapSet(this.plugboard);
〰141:         }
〰142:     }
〰143: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

