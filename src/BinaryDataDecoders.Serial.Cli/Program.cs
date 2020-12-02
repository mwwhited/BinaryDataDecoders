using BinaryDataDecoders.IO;
using BinaryDataDecoders.Nmea;
using BinaryDataDecoders.Quarta.RadexOne;
using System;
using System.ComponentModel;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ContainerConfiguration();
            //var asm = Path.GetDirectoryName(typeof(Program).Assembly.CodeBase);
            var files = Directory.GetFiles(".", "*.dll");
            var assemblies = from p in files
                             select System.Reflection.Assembly.LoadFile(Path.GetFullPath(p));

            configuration.WithAssemblies(assemblies);
            var container = configuration.CreateContainer();
            var devices = container.GetExports<IDeviceDefinition>().ToList();

            //Console.WriteLine("=== Select Device ===");
            //foreach (var item in devices.Select((device, index) => (device, index)))
            //{
            //    var name = item.device.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description ??
            //               item.device.GetType().Name;

            //    Console.WriteLine($"\t{item.index + 1}) {name}");
            //}

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

            var definition = new Nema0183Definition();
            new DeviceConsole().Execute(definition);
        }
        //IDeviceDefinition
    }
}
