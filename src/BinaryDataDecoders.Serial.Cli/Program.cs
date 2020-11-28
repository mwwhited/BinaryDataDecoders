using BinaryDataDecoders.Quarta.RadexOne;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var definition = new RadexOneDefinition();
            new SerialPortConsole().Execute(definition, x => (x % 10) switch
            {
                1 => (IRadexObject)new ReadSerialNumberRequest((uint)x),
                // 2 => new ReadSerialNumberRequest((uint)x),

                // 3 => new DevicePing((uint)x),
                // 0 => new DevicePing((uint)x),

                // 4 => new WriteSettingsRequest((uint)x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                // 5 => new WriteSettingsRequest((uint)x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                // 6 => new WriteSettingsRequest((uint)x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                // 4 => new WriteSettingsRequest((uint)x, AlarmSettings.Audio, 30),
                7 => new ReadSettingsRequest((uint)x),

                //8 => new ResetAccumulatedRequest((uint)x),

                _ => new ReadValuesRequest((uint)x)
            });
        }
    }
}
