# BinaryDataDecoders.Zoom.H4n.H4nDefinition

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Zoom.H4n.H4nDefinition` |
| Assembly        | `BinaryDataDecoders.Zoom.H4n`               |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `7`                                         |
| Coverablelines  | `7`                                         |
| Totallines      | `90`                                        |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `2`                                         |
| Branchcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_SegmentDefintion` |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `get_Decoder`          |
| 1          | 0     | 100      | `get_Encoder`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Zoom.H4n/H4nDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.IO;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using BinaryDataDecoders.IO.Ports;
〰4:   using BinaryDataDecoders.IO.Segmenters;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.ComponentModel;
〰8:   using System.Composition;
〰9:   using System.IO;
〰10:  using System.Linq;
〰11:  using System.Threading;
〰12:  using System.Threading.Tasks;
〰13:  using static BinaryDataDecoders.Zoom.H4n.H4nStatus;
〰14:  
〰15:  namespace BinaryDataDecoders.Zoom.H4n
〰16:  {
〰17:      [SerialPort(2400)] //, ReadTimeout = 500, WriteTimeout = 500)]
〰18:      [Description("Zoom H4N")]
〰19:      [Export(typeof(IDeviceDefinition))]
〰20:      public class H4nDefinition :
〰21:          IDeviceDefinitionReceiver<IH4nMessage>,
〰22:          IDeviceDefinitionTransmitter<IH4nMessage>,
〰23:          IDeviceDefinitionInitialize
〰24:      {
‼25:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼26:              Segment.StartsWithMask((byte)(Record | Peak | Mic | Led1 | Led2))
‼27:                     .AndIsLength(1)
‼28:                     .WithOptions(SegmentionOptions.SkipInvalidSegment);
〰29:  
‼30:          public IMessageDecoder<IH4nMessage> Decoder { get; } = new H4nDecoder();
〰31:  
‼32:          public IMessageEncoder<IH4nMessage> Encoder { get; } = new MessageEncoder<IH4nMessage>();
〰33:  
〰34:          public async Task InitializeAsync(IDeviceAdapter device, CancellationToken token)
〰35:          {
〰36:              try
〰37:              {
〰38:                  var stream = device.Stream;
〰39:  
〰40:                  var buffered = device as IBufferedDeviceAdapter;
〰41:                  //TODO: this is getting stuck... need to change from stream to IDeviceStream and expose bytes to read.
〰42:                  //TODO: should have a max counter and exception if triggered
〰43:                  do
〰44:                  {
〰45:                      do
〰46:                      {
〰47:                          stream.WriteByte(0x00);
〰48:                          await stream.FlushAsync(token);
〰49:                          await Task.Delay(30);
〰50:                         // var bytes = buffered.BytesToRead;
〰51:                      }
〰52:                      while ( buffered.BytesToRead < 4); //!token.IsCancellationRequested &&
〰53:  
〰54:                     // if (token.IsCancellationRequested) break;
〰55:  
〰56:                      var buffer = new byte[buffered.BytesToRead];
〰57:                      var result = await stream.ReadAsync(buffer, token);
〰58:  
‼59:                      if (buffer.Any(b => (0x7f & b) > 0)) break;
〰60:                     // if (token.IsCancellationRequested) break;
〰61:  
〰62:                      stream.WriteByte(0xa1);
〰63:                      await stream.FlushAsync(token);
〰64:                      stream.WriteByte(0x80);
〰65:                      await stream.FlushAsync(token);
〰66:                      stream.WriteByte(0x00);
〰67:                      await stream.FlushAsync(token);
〰68:                  } while (!token.IsCancellationRequested);
〰69:              }
〰70:              catch (Exception ex)
〰71:              {
〰72:                  throw;
〰73:              }
〰74:          }
〰75:  
〰76:          //send request, pause 100ms, send poll
〰77:          //Record: 0x81 0x00 | 0x80 0x00
〰78:          //Play:   0x82 0x00 | 0x80 0x00
〰79:          //Stop:   0x84 0x00 | 0x80 0x00
〰80:          //ffwd:   0x88 0x00 | 0x80 0x00
〰81:          //rwd:    0x90 0x00 | 0x80 0x00
〰82:          //vol+:   0x80 0x08 | 0x80 0x00
〰83:          //vol-:   0x80 0x10 | 0x80 0x00
〰84:          //rec+:   0x80 0x20 | 0x80 0x00
〰85:          //rec-:   0x80 0x40 | 0x80 0x00
〰86:          //mic :   0x80 0x01 | 0x80 0x00
〰87:          //ch1 :   0x80 0x02 | 0x80 0x00
〰88:          //ch2 :   0x80 0x04 | 0x80 0x00
〰89:      }
〰90:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

