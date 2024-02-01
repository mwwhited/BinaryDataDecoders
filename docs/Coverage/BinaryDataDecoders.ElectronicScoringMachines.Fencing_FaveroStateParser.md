# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroStateParser

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroStateParser` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                          |
| Coveredlines    | `40`                                                                            |
| Uncoveredlines  | `1`                                                                             |
| Coverablelines  | `41`                                                                            |
| Totallines      | `108`                                                                           |
| Linecoverage    | `97.5`                                                                          |
| Coveredbranches | `6`                                                                             |
| Totalbranches   | `10`                                                                            |
| Branchcoverage  | `60`                                                                            |
| Coveredmethods  | `1`                                                                             |
| Totalmethods    | `1`                                                                             |
| Methodcoverage  | `100`                                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 6          | 96.29 | 50.0     | `Parse` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Favero/FaveroStateParser.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using System;
〰4:   
〰5:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
〰6:   
〰7:   public class FaveroStateParser : IParseScoreMachineState
〰8:   {
〰9:       public IScoreMachineState Parse(ReadOnlySpan<byte> frame)
〰10:      {
⚠11:          if (frame == null || frame.Length == 0) return null;
〰12:  
〰13:          //  1° byte: FFh  = Start string
〰14:          // The FFh value identifies the beginning of the string.
⚠15:          if (frame[0] != 0xff)
‼16:              throw new ArgumentException("invalid prefix", nameof(frame));
〰17:  
〰18:          ////TODO: Fix the CRC
〰19:          ////var crc = (((int)message.Take(9).Select(b => (int)b).Sum()) & 0xff);
〰20:          ////var crc = message.Take(9).Aggregate(0, (p, i) => (((p & 0x0f) + (i & 0x0f)) & 0x0f) | (((p & 0x0f0) + (i & 0xf0)) & 0xf0));
〰21:          ////var crc = message.Take(9).Aggregate(0, (p, i) => p ^ i);
〰22:          ////var crc = message.Take(9).Aggregate(0, (p, i) => (p + i) & 0xff);
〰23:          ////if (message[9] != crc)
〰24:          ////    throw new InvalidOperationException("invalid CRC");
〰25:  
〰26:          //  /*
〰27:          //10° byte:  CRC , it is the sum without carry of the 9 previous bytes.
〰28:          //*/
〰29:          //  byte crc = 0; // frame[0];
〰30:          //  for (var x = 1; x < 10; x++)
〰31:          //  {
〰32:          //      crc = (byte)(crc ^ frame[x]);
〰33:          //  }
〰34:          //  //var crc = frame.Take(9).Aggregate(0, (a, i) => a ^ i);
〰35:  
〰36:          // 6° byte: XXh  = Define the state of the lamps
✔37:          var lamps = ParseLights(frame[5]);
〰38:  
〰39:          // 7° byte: 0Xh  = Number of matches and Priority signals.
✔40:          var match = Match(frame[6]);
✔41:          var priority = ParsePriority(frame[6]);
〰42:  
〰43:          // 8° byte: XXh  This byte is only for our use. Do not consider this byte.
〰44:  
〰45:          // 9° byte:  Red and Yellow penalty cards.
✔46:          var cards = ParseCards(frame[8]);
〰47:  
✔48:          return new ScoreMachineState(
✔49:              left: new Fencer(
✔50:                  // 3° byte: XXh  = Left score
✔51:                  score: (byte)frame[2].AsBCD(),
✔52:                  cards: cards.left,
✔53:                  lights: lamps.left,
✔54:                  priority: priority.left),
✔55:  
✔56:              right: new Fencer(
✔57:                  // 2° byte: XXh  = Right score
✔58:                  score: (byte)frame[1].AsBCD(),
✔59:                  cards: cards.right,
✔60:                  lights: lamps.right,
✔61:                  priority: priority.right),
✔62:  
✔63:              // 4° byte: XXh  = Seconds of the time (units and tens)
✔64:              // 5° byte: 0Xh  = Minutes of the time (only units)
✔65:              clock: new TimeSpan(0, ((byte)(frame[4] & 0x0f)).AsBCD(), frame[3].AsBCD()),
✔66:              match: match
✔67:              );
〰68:  
〰69:          //Bit D0 = Left white lamp
〰70:          //Bit D1 = Right white lamp
〰71:          //Bit D2 = RED lamp(left)
〰72:          //Bit D3 = GREEN lamp(right)
〰73:          //Bit D4 = Right yellow lamp
〰74:          //Bit D5 = Left yellow lamp
〰75:          //Bit D6 = 0  not used
〰76:          //Bit D7 = 0  not used
✔77:          (Lights left, Lights right) ParseLights(byte subFrame) => (
✔78:              left: (Lights)((subFrame & 0x5) | (subFrame >> 4 & 0x2)),
✔79:              right: (Lights)(((subFrame >> 1) & 0x5) | (subFrame >> 3 & 0x2))
✔80:              );
〰81:  
〰82:          // The D0 e D1 bits define the number of matches (from 0 to 3):
〰83:          //    D1=0 D0=0  Num.Matchs = 0
〰84:          //    D1=0 D0=1  Num.Matchs = 1
〰85:          //    D1=1 D0=0  Num.Matchs = 2
〰86:          //    D1=1 D0=1  Num.Matchs = 3
✔87:          byte Match(byte subFrame) => (byte)(subFrame & 0x3);
〰88:  
〰89:          //The D2 e D3 bits define the signals of Priorite:
〰90:          //   D2 = Right Priorite(if= 1 is ON)
〰91:          //   D3 = Left Priorite(if= 1 is ON)
✔92:          (bool left, bool right) ParsePriority(byte subFrame) => (
✔93:              left: (subFrame & 0x08) != 0x00,
✔94:              right: (subFrame & 0x04) != 0x00
✔95:              );
〰96:  
〰97:          //D0 = Right RED penalty card
〰98:          //D1 = Left RED penalty card
〰99:          //D2 = Right YELLOW penalty card
〰100:         //D3 = Left YELLOW penalty card
✔101:         (Cards left, Cards right) ParseCards(byte subFrame) => (
✔102:           left: Card((byte)((subFrame >> 1) & 0x5)),
✔103:           right: Card((byte)(subFrame & 0x5))
✔104:           );
⚠105:         Cards Card(byte subFrame) => ((subFrame & 0x01) != 0 ? Cards.Red : Cards.None) | ((subFrame & 0x04) != 0 ? Cards.Yellow : Cards.None);
〰106:     }
〰107: }
〰108: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

