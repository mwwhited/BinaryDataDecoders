using BinaryDataDecoders.Zoom.H4n;
using System;
using System.ComponentModel;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Controller.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ContainerConfiguration();
            //var asm = Path.GetDirectoryName(typeof(Program).Assembly.CodeBase);
            var files = Directory.GetFiles(".", "*.dll");
            var assemblies = from p in files
                             select System.Reflection.Assembly.LoadFile(Path.GetFullPath(p));

            configuration.WithAssemblies(assemblies);
            var container = configuration.CreateContainer();
            var devices = container.GetExports<IDeviceDefinition>().ToList();

            Console.WriteLine("=== Select Device ===");
            foreach (var item in devices.Select((device, index) => (device, index)))
            {
                var name = item.device.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description ??
                           item.device.GetType().Name;

                Console.WriteLine($"\t{item.index + 1}) {name}");
            }

            //IDeviceDefinition definition = null;
            //do
            //{
            //    var value = int.TryParse(Console.ReadLine(), out var index) ? index : 0;

            //    try
            //    {
            //        definition = devices[value - 1];
            //        break;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.Error.WriteLine(ex.Message);
            //    }
            //} while (true);


            //configuration.WithAssemblies()

            //configuration.WithAssemblies()

            // new SgStateDefinition();
            // new FaveroDefinition();

            //var definition = new RadexOneDefinition();
            //new SerialPortConsole().Execute(definition, x => (x % 10) switch
            //{
            //    1 => (IRadexObject)new ReadSerialNumberRequest((uint)x),
            //    // 2 => new ReadSerialNumberRequest((uint)x),
            //    // 3 => new DevicePing((uint)x),
            //    // 4 => new WriteSettingsRequest((uint)x, AlarmSettings.Audio, 30),
            //    7 => new ReadSettingsRequest((uint)x),
            //    //8 => new ResetAccumulatedRequest((uint)x),
            //    _ => new ReadValuesRequest((uint)x)
            //});

            var definition = new H4nDefinition();
            await new DeviceConsole().Execute(definition, id => (id % 10) switch
                {
                    2 => (IH4nMessage)new H4nRequest(H4nRequests.Channel1),
                    4 => (IH4nMessage)new H4nRequest(H4nRequests.Channel2),
                    6 => (IH4nMessage)new H4nRequest(H4nRequests.Channel2),
                    7 => (IH4nMessage)new H4nRequest(H4nRequests.Mic),
                    _ => (IH4nMessage)new H4nRequest(H4nRequests.Poll)
                });
            //id < 100 ? (IH4nMessage)new H4nNullRequest(): new H4nRequest(H4nRequests.Poll)

            // var definition = new Nema0183Definition();
            //new DeviceConsole().Execute(definition);

            Console.WriteLine("done");
        }
    }
}
