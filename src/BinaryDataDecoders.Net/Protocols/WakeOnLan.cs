using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Protocols;

public class WakeOnLan
{
    public static byte[] BuildMagicPacket(string macAddress)
    {
        var clientMac = MacAddressEx.Parse(macAddress);
        var message = new[]{
            [0xff,0xff,0xff,0xff,0xff,0xff,],
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
            clientMac,
        };
        var payload = message.SelectMany(b => b).ToArray();
        return payload;
    }

    public static async Task<bool> Wake(string macAddress, string ipAddress = "255.255.255.255")
    {
        var clientAddress = IPAddress.Parse(ipAddress);
        var magicPacket = WakeOnLan.BuildMagicPacket(macAddress);

        // http://en.wikipedia.org/wiki/Wake-on-LAN#Principle_of_operation
        using var client = new UdpClient();
        client.Connect(clientAddress, 65535);
        client.EnableBroadcast = true;
        client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);

        var result = await client.SendAsync(magicPacket, magicPacket.Length);

        return result == 102; /* MagicPacket length should be broadcast MAC + target MAX x 16 */
    }
}
