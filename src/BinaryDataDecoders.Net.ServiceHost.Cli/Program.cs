using BinaryDataDecoders.Net.Services;
using BinaryDataDecoders.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.ServiceHost.Cli
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new List<IServerBase>()
            {
                new EchoServer(),
                new DiscardServer(),
                new DaytimeServer(),
                new TimeServer(),
                new ChargenServer(),
            };
            foreach (var service in services)
            {
                service.Start();
            }

            Console.WriteLine("Running!");
            while (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                Console.WriteLine("Enter anything to exit.");

            foreach (var service in services)
            {
                var dis = await service.StopAsync();
                await dis.DisposeAsync();
            }
        }
    }
}