# BinaryDataDecoders.Net.Protocols.WakeOnLan

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Protocols.WakeOnLan` |
| Assembly        | `BinaryDataDecoders.Net`                     |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `31`                                         |
| Coverablelines  | `31`                                         |
| Totallines      | `51`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `2`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `BuildMagicPacket` |
| 1          | 0     | 100      | `Wake`             |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Protocols/WakeOnLan.cs

```CSharp
〰1:   using System.Linq;
〰2:   using System.Net;
〰3:   using System.Net.Sockets;
〰4:   using System.Threading.Tasks;
〰5:   
〰6:   namespace BinaryDataDecoders.Net.Protocols;
〰7:   
〰8:   public class WakeOnLan
〰9:   {
〰10:      public static byte[] BuildMagicPacket(string macAddress)
〰11:      {
‼12:          var clientMac = MacAddressEx.Parse(macAddress);
‼13:          var message = new[]{
‼14:              [0xff,0xff,0xff,0xff,0xff,0xff,],
‼15:              clientMac,
‼16:              clientMac,
‼17:              clientMac,
‼18:              clientMac,
‼19:              clientMac,
‼20:              clientMac,
‼21:              clientMac,
‼22:              clientMac,
‼23:              clientMac,
‼24:              clientMac,
‼25:              clientMac,
‼26:              clientMac,
‼27:              clientMac,
‼28:              clientMac,
‼29:              clientMac,
‼30:              clientMac,
‼31:          };
‼32:          var payload = message.SelectMany(b => b).ToArray();
‼33:          return payload;
〰34:      }
〰35:  
〰36:      public static async Task<bool> Wake(string macAddress, string ipAddress = "255.255.255.255")
〰37:      {
‼38:          var clientAddress = IPAddress.Parse(ipAddress);
‼39:          var magicPacket = WakeOnLan.BuildMagicPacket(macAddress);
〰40:  
〰41:          // http://en.wikipedia.org/wiki/Wake-on-LAN#Principle_of_operation
‼42:          using var client = new UdpClient();
‼43:          client.Connect(clientAddress, 65535);
‼44:          client.EnableBroadcast = true;
‼45:          client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
〰46:  
‼47:          var result = await client.SendAsync(magicPacket, magicPacket.Length);
〰48:  
‼49:          return result == 102; /* MagicPacket length should be broadcast MAC + target MAX x 16 */
‼50:      }
〰51:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

