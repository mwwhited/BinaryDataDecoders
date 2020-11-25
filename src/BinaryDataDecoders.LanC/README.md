

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static List<string> buffer = new List<string>();

        static void Main(string[] args)
        {
            using (var sp = new SerialPort("COM16", 57600))
            {
                sp.Open();

                sp.DataReceived += Sp_DataReceived;
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    sp.BaseStream.Write(new byte[] { 0x18, 0x33 }, 0, 2);
                    sp.BaseStream.Flush();
                };
                File.WriteAllLines("results.txt", buffer);
            }
        }

        private static void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is SerialPort sp)
            {
                var read = sp.ReadLine();
                var message = read.Split('<').First().Split('-');
                byte[] bytes;
                try
                {
                    bytes = message.Take(6).Select(b => Convert.ToByte(b, 16)).ToArray();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    bytes = new byte[6];
                }

                var line = string.Join("\t", message.OfType<object>().Concat(new object[] { DateTime.Now.Ticks, (LanCStatusCode)bytes[2] }));
                buffer.Add(line);
                if (bytes[0] == 0x99)
                    Console.WriteLine(line);
            }
        }
    }

/*
 * http://www.boehmel.de/lanc.htm#byte0
 */
```