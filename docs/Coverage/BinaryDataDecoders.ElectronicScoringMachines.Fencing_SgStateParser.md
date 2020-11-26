# BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateParser

## Summary

| Key             | Value                                                                            |
| :-------------- | :------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateParser` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                           |
| Coveredlines    | `0`                                                                              |
| Uncoveredlines  | `68`                                                                             |
| Coverablelines  | `68`                                                                             |
| Totallines      | `150`                                                                            |
| Linecoverage    | `0`                                                                              |
| Coveredbranches | `0`                                                                              |
| Totalbranches   | `116`                                                                            |
| Branchcoverage  | `0`                                                                              |

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
〰5:   using System.Text;
〰6:   using static BinaryDataDecoders.ToolKit.Bytes;
〰7:   
〰8:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
〰9:   {
〰10:      public class SgStateParser : IParseScoreMachineState
〰11:      {
‼12:          private IScoreMachineState last = ScoreMachineState.Empty;
〰13:          public IScoreMachineState Parse(ReadOnlySpan<byte> frame)
〰14:          {
‼15:              if (frame == null || frame.Length == 0 || frame[0] != 0x01 || frame.ToArray().Last() != 0x04) return last;
〰16:  
‼17:              if (frame.StartsWith(Soh, Dc3, S, T, Sotx))
〰18:              {
〰19:                  // ST011:00501000301300
〰20:                  // Left 5, Red and yellow
〰21:                  // Right 11 yellow
〰22:                  //ST005:01100000301300
〰23:                  // Left 11, Red and yellow
〰24:                  // Right 0 none
〰25:                  // ST005:011000000
〰26:                  // ST005:01100000000300 no priorty
〰27:                  // Left 11, none
〰28:                  // Right 0 none
〰29:                  //ST000:00002010000100 (right proproty)
〰30:                  //ST000:00002010000100
〰31:                  // Left 11, none
〰32:                  // Right 0 red
〰33:                  //ST000:00002010000200 (left priority)
〰34:  
〰35:                  // var data = Encoding.ASCII.GetString(frame.ToArray());
‼36:                  var mem = new Memory<byte>(frame.ToArray());
‼37:                  var subFrames = mem.Split(Sotx);
〰38:  
‼39:                  var scoreSf = subFrames.ElementAt(1).Split((byte)0x3a);
〰40:  
〰41:                  static byte GetScore(Memory<byte> s)
〰42:                  {
‼43:                      return (byte)((s.Span[0] - _0) * 100 + (s.Span[1] - _0) * 10 + (s.Span[2] - _0));
〰44:                  }
〰45:  
‼46:                  var scores = new[]
‼47:                  {
‼48:                      GetScore(scoreSf.ElementAt(0)),//right
‼49:                      GetScore(scoreSf.ElementAt(1)), //left
‼50:                  };
〰51:  
〰52:  
‼53:                  Cards? greenCards = (Cards)subFrames.ElementAtOrDefault(2).Span[1] - _0; // parts.Length < 3 ? (Cards?)null : (Cards)(parts[2][1] - (byte)By._0);
‼54:                  Cards? redCards = (Cards)subFrames.ElementAtOrDefault(3).Span[1] - _0; // parts.Length < 4 ? (Cards?)null : (Cards)(parts[3][1] - (byte)By._0);
〰55:  
‼56:                  var red = new Fencer(scores[1], redCards ?? last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
‼57:                  var green = new Fencer(scores[0], greenCards ?? last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);
〰58:  
‼59:                  return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰60:              }
‼61:              else if (frame.StartsWith(Soh, Dc3, L, R) && frame[5] == G && frame[7] == W && frame[9] == w)
〰62:              {
〰63:                  // var data = Encoding.ASCII.GetString(frame.ToArray());
〰64:  
〰65:                  // LR0G1W0w0 Green (touch right)
〰66:                  // LR1G0W0w0 Red (touch left)
〰67:                  // LR0G0W0w1 green off target
〰68:                  // LR0G0W1w0 red off target
〰69:  
‼70:                  var redLights =
‼71:                      (frame[4] == _1 ? Lights.Touch : Lights.None) |
‼72:                      (frame[8] == _1 ? Lights.White : Lights.None)
‼73:                      ;
〰74:  
‼75:                  var greenLights =
‼76:                      (frame[6] == _1 ? Lights.Touch : Lights.None) |
‼77:                      (frame[10] == _1 ? Lights.White : Lights.None)
‼78:                      ;
〰79:  
‼80:                  var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, redLights, last?.Left.Priority ?? false);
‼81:                  var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, greenLights, last?.Right.Priority ?? false);
‼82:                  return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰83:              }
‼84:              else if (frame.StartsWith(Soh, Dc3, R, _, F, _S, Sotx) && frame.Length > 12)
〰85:              {
〰86:                  // R_F$0000__:02:59.___
‼87:                  var mem = new Memory<byte>(frame.ToArray());
‼88:                  var subFrames = mem.Split(Sotx);
‼89:                  var chunk = subFrames.ElementAtOrDefault(1);
〰90:  
‼91:                  var decoded = new
‼92:                  {
‼93:                      c1 = (chunk.Span[8] - _0) * 10 + chunk.Span[9] - _0,
‼94:                      c2 = (chunk.Span[11] - _0) * 10 + chunk.Span[12] - _0,
‼95:                  };
〰96:  
‼97:                  var time = new TimeSpan(0, decoded.c1, decoded.c2);
‼98:                  return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
〰99:              }
‼100:             else if (frame.StartsWith(Soh, Dc2, P))
〰101:             {
〰102:                 // var data = Encoding.ASCII.GetString(frame.ToArray());
〰103:                 // P?AA8G
〰104:                 // 01 12 50 3f 00 02 00 41 41 48 47 04
‼105:                 var redPriority = (frame[2] & Eotx) == 0x01;
‼106:                 var greenPriority = (frame[2] & Eotx) == 0x01;
〰107: 
‼108:                 var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, redPriority);
‼109:                 var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, greenPriority);
〰110: 
‼111:                 return last = new ScoreMachineState(red, green, last?.Clock ?? new TimeSpan(), last?.Match ?? 0);
〰112:             }
‼113:             else if (frame.StartsWith(Soh, Dc3, S))
〰114:             {
〰115:                 //S01:06
‼116:                 var mem = new Memory<byte>(frame.ToArray());
‼117:                 var subFrames = mem.Split(S);
‼118:                 var scoreSf = subFrames.ElementAt(1).Split(_C);
〰119:                 static byte GetScore(Memory<byte> s)
〰120:                 {
‼121:                     return (byte)((s.Span[0] - _0) * 10 + (s.Span[1] - _0));
〰122:                 }
〰123: 
‼124:                 var scores = new[]
‼125:                 {
‼126:                     GetScore(scoreSf.ElementAt(0)),//right
‼127:                     GetScore(scoreSf.ElementAt(1)), //left
‼128:                 };
〰129: 
‼130:                 var red = new Fencer(scores[1], last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
‼131:                 var green = new Fencer(scores[0], last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);
〰132: 
‼133:                 return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
〰134:             }
‼135:             else if (frame.StartsWith(Soh, Dc3, T))
〰136:             {
〰137:                 //T02:16
‼138:                 var decoded = new
‼139:                 {
‼140:                     c1 = (frame[3] - _0) * 10 + frame[4] - _0,
‼141:                     c2 = (frame[6] - _0) * 10 + frame[7] - _0,
‼142:                 };
〰143: 
‼144:                 var time = new TimeSpan(0, decoded.c1, decoded.c2);
‼145:                 return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
〰146:             }
‼147:             return last;
〰148:         }
〰149:     }
〰150: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

