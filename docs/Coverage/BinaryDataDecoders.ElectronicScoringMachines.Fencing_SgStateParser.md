# BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateParser

## Summary

| Key             | Value                                                                            |
| :-------------- | :------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateParser` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                           |
| Coveredlines    | `0`                                                                              |
| Uncoveredlines  | `68`                                                                             |
| Coverablelines  | `68`                                                                             |
| Totallines      | `149`                                                                            |
| Linecoverage    | `0`                                                                              |
| Coveredbranches | `0`                                                                              |
| Totalbranches   | `116`                                                                            |
| Branchcoverage  | `0`                                                                              |
| Coveredmethods  | `0`                                                                              |
| Totalmethods    | `2`                                                                              |
| Methodcoverage  | `0`                                                                              |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 116        | 0     | 0        | `Parse` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/SaintGeorge/SgStateParser.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using System;
〰4:   using System.Linq;
〰5:   using static BinaryDataDecoders.IO.Bytes;
〰6:   
〰7:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
〰8:   {
〰9:       public class SgStateParser : IParseScoreMachineState
〰10:      {
‼11:          private IScoreMachineState last = ScoreMachineState.Empty;
〰12:          public IScoreMachineState Parse(ReadOnlySpan<byte> frame)
〰13:          {
‼14:              if (frame == null || frame.Length == 0 || frame[0] != 0x01 || frame.ToArray().Last() != 0x04) return last;
〰15:  
‼16:              if (frame.StartsWith(Soh, Dc3, S, T, Sotx))
〰17:              {
〰18:                  // ST011:00501000301300
〰19:                  // Left 5, Red and yellow
〰20:                  // Right 11 yellow
〰21:                  //ST005:01100000301300
〰22:                  // Left 11, Red and yellow
〰23:                  // Right 0 none
〰24:                  // ST005:011000000
〰25:                  // ST005:01100000000300 no priority
〰26:                  // Left 11, none
〰27:                  // Right 0 none
〰28:                  //ST000:00002010000100 (right priority)
〰29:                  //ST000:00002010000100
〰30:                  // Left 11, none
〰31:                  // Right 0 red
〰32:                  //ST000:00002010000200 (left priority)
〰33:  
〰34:                  // var data = Encoding.ASCII.GetString(frame.ToArray());
‼35:                  var mem = new Memory<byte>(frame.ToArray());
‼36:                  var subFrames = mem.Split(Sotx);
〰37:  
‼38:                  var scoreSf = subFrames.ElementAt(1).Split((byte)0x3a);
〰39:  
〰40:                  static byte GetScore(Memory<byte> s)
〰41:                  {
‼42:                      return (byte)((s.Span[0] - _0) * 100 + (s.Span[1] - _0) * 10 + (s.Span[2] - _0));
〰43:                  }
〰44:  
‼45:                  var scores = new[]
‼46:                  {
‼47:                      GetScore(scoreSf.ElementAt(0)),//right
‼48:                      GetScore(scoreSf.ElementAt(1)), //left
‼49:                  };
〰50:  
〰51:  
‼52:                  Cards? greenCards = (Cards)subFrames.ElementAtOrDefault(2).Span[1] - _0; // parts.Length < 3 ? (Cards?)null : (Cards)(parts[2][1] - (byte)By._0);
‼53:                  Cards? redCards = (Cards)subFrames.ElementAtOrDefault(3).Span[1] - _0; // parts.Length < 4 ? (Cards?)null : (Cards)(parts[3][1] - (byte)By._0);
〰54:  
‼55:                  var red = new Fencer(scores[1], redCards ?? last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
‼56:                  var green = new Fencer(scores[0], greenCards ?? last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);
〰57:  
‼58:                  return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰59:              }
‼60:              else if (frame.StartsWith(Soh, Dc3, L, R) && frame[5] == G && frame[7] == W && frame[9] == w)
〰61:              {
〰62:                  // var data = Encoding.ASCII.GetString(frame.ToArray());
〰63:  
〰64:                  // LR0G1W0w0 Green (touch right)
〰65:                  // LR1G0W0w0 Red (touch left)
〰66:                  // LR0G0W0w1 green off target
〰67:                  // LR0G0W1w0 red off target
〰68:  
‼69:                  var redLights =
‼70:                      (frame[4] == _1 ? Lights.Touch : Lights.None) |
‼71:                      (frame[8] == _1 ? Lights.White : Lights.None)
‼72:                      ;
〰73:  
‼74:                  var greenLights =
‼75:                      (frame[6] == _1 ? Lights.Touch : Lights.None) |
‼76:                      (frame[10] == _1 ? Lights.White : Lights.None)
‼77:                      ;
〰78:  
‼79:                  var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, redLights, last?.Left.Priority ?? false);
‼80:                  var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, greenLights, last?.Right.Priority ?? false);
‼81:                  return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰82:              }
‼83:              else if (frame.StartsWith(Soh, Dc3, R, _, F, _S, Sotx) && frame.Length > 12)
〰84:              {
〰85:                  // R_F$0000__:02:59.___
‼86:                  var mem = new Memory<byte>(frame.ToArray());
‼87:                  var subFrames = mem.Split(Sotx);
‼88:                  var chunk = subFrames.ElementAtOrDefault(1);
〰89:  
‼90:                  var decoded = new
‼91:                  {
‼92:                      c1 = (chunk.Span[8] - _0) * 10 + chunk.Span[9] - _0,
‼93:                      c2 = (chunk.Span[11] - _0) * 10 + chunk.Span[12] - _0,
‼94:                  };
〰95:  
‼96:                  var time = new TimeSpan(0, decoded.c1, decoded.c2);
‼97:                  return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
〰98:              }
‼99:              else if (frame.StartsWith(Soh, Dc2, P))
〰100:             {
〰101:                 // var data = Encoding.ASCII.GetString(frame.ToArray());
〰102:                 // P?AA8G
〰103:                 // 01 12 50 3f 00 02 00 41 41 48 47 04
‼104:                 var redPriority = (frame[2] & Eotx) == 0x01;
‼105:                 var greenPriority = (frame[2] & Eotx) == 0x01;
〰106: 
‼107:                 var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, redPriority);
‼108:                 var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, greenPriority);
〰109: 
‼110:                 return last = new ScoreMachineState(red, green, last?.Clock ?? new TimeSpan(), last?.Match ?? 0);
〰111:             }
‼112:             else if (frame.StartsWith(Soh, Dc3, S))
〰113:             {
〰114:                 //S01:06
‼115:                 var mem = new Memory<byte>(frame.ToArray());
‼116:                 var subFrames = mem.Split(S);
‼117:                 var scoreSf = subFrames.ElementAt(1).Split(_C);
〰118:                 static byte GetScore(Memory<byte> s)
〰119:                 {
‼120:                     return (byte)((s.Span[0] - _0) * 10 + (s.Span[1] - _0));
〰121:                 }
〰122: 
‼123:                 var scores = new[]
‼124:                 {
‼125:                     GetScore(scoreSf.ElementAt(0)),//right
‼126:                     GetScore(scoreSf.ElementAt(1)), //left
‼127:                 };
〰128: 
‼129:                 var red = new Fencer(scores[1], last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
‼130:                 var green = new Fencer(scores[0], last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);
〰131: 
‼132:                 return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰133:             }
‼134:             else if (frame.StartsWith(Soh, Dc3, T))
〰135:             {
〰136:                 //T02:16
‼137:                 var decoded = new
‼138:                 {
‼139:                     c1 = (frame[3] - _0) * 10 + frame[4] - _0,
‼140:                     c2 = (frame[6] - _0) * 10 + frame[7] - _0,
‼141:                 };
〰142: 
‼143:                 var time = new TimeSpan(0, decoded.c1, decoded.c2);
‼144:                 return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
〰145:             }
‼146:             return last;
〰147:         }
〰148:     }
〰149: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

