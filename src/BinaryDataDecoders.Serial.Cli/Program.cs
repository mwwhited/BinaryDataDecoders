using BinaryDataDecoders.Nmea;
using BinaryDataDecoders.Quarta.RadexOne;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
