//using System;

//namespace BinaryDataDecoders.Zoom.H4n
//{
//    public class Class1
//    {
//        private void Wrapper1()
//        {

//            using (var serial = new SerialPort("COM7", 2400, Parity.None, 8, StopBits.One))
//            {
//                serial.Open();

//                /*
//                 Record: 0x81 0x00 | 0x80 0x00
//Play:   0x82 0x00 | 0x80 0x00
//Stop:   0x84 0x00 | 0x80 0x00
//ffwd:   0x88 0x00 | 0x80 0x00
//rwd:    0x90 0x00 | 0x80 0x00
//vol+:   0x80 0x08 | 0x80 0x00
//vol-:   0x80 0x10 | 0x80 0x00
//rec+:   0x80 0x20 | 0x80 0x00
//rec-:   0x80 0x40 | 0x80 0x00
//mic :   0x80 0x01 | 0x80 0x00
//ch1 :   0x80 0x02 | 0x80 0x00
//ch2 :   0x80 0x04 | 0x80 0x00
//*/
//                var running = true;

//                var task1 = Task.Run(async () =>
//                {
//                    while (running)
//                    {
//                        serial.Write(new byte[] { 0x82, 0x00 }, 0, 2);
//                        await Task.Delay(100);
//                        serial.Write(new byte[] { 0x80, 0x00 }, 0, 2);
//                        await Task.Delay(1000);
//                    }
//                });
//                var task2 = Task.Run(() =>
//                {
//                    while (running)
//                    {
//                        var inp = serial.ReadByte();
//                        Console.Write($"{(byte)inp:x2}");
//                    }
//                });

//                Console.ReadLine();
//                running = false;

//                Task.WaitAll(task1, task2);
//            }
//        }
//    }
//}
////http://www.g7smy.co.uk/2017/04/controlling-the-zoom-h2n-audio-recorder-with-arduino/

