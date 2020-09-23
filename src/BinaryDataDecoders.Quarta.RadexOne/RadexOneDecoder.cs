using BinaryDataDecoders.ToolKit;
using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{

    public class RadexOneDecoder
    {
        /*
         * 	§ Prefix [0x7a, 0x00]
			§ Response? [0x02, 0x80]
			§ Extension Length? [0xLL, 0xHH]
			§ Packet Number [0xLL, 0XHH]
			§ Zero Reserved [0x00, 0x00]
			§ CheckSum [FFFF - Sum(Prefix…ZeroReserve) % FFFF]
			§ Extensions --- (Number of Bytes referenced by Extension Length
 				□ Response Type 
					® [0x00, 0x08] Return Data ReadZero 
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {ambient}
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {accumulated}
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {cpm}
						◊ Reserved [0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x00] Return Serial Number/Version Read
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x02, 0x08] Acknowledge Write Settings 
						◊ Zero Reserved [0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x08] Return Read Settings
						◊ Zero Reserved [0x00, 0x00]
						◊ Target Value [0x05, 0x00]
						◊ Zero Reserved [0x00, 0x00]
						◊ Alarm Setting [0x03] {0x01 = Vibration, 0x02 = 0 Audio}
						◊ Threshold [0xLL, 0xHH]
						◊ Zero Reserved [0x00, 0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
        */
        public IRadexObject Decode(ReadOnlySequence<byte> sequence)
        {
            Span<byte> data = new byte[sequence.Length];
            sequence.CopyTo(data);
            var values = MemoryMarshal.Cast<byte, ushort>(data);
            if (values[2] == 0)
            {
                var read = MemoryMarshal.Cast<byte, DevicePing>(data);
                IRadexObject result = read[0];
                return result;
            }
            else
            {
                switch (values[6])
                {
                    case 0x00_01:
                        {
                            var read = MemoryMarshal.Cast<byte, ReadSerialNumberResponse>(data);
                            IRadexObject result = read[0];
                            return result;
                        }

                    case 0x08_00:
                        {
                            var read = MemoryMarshal.Cast<byte, ReadValuesResponse>(data);
                            IRadexObject result = read[0];
                            return result;
                        }

                    case 0x08_01:
                        {
                            var read = MemoryMarshal.Cast<byte, ReadSettingsResponse>(data);
                            IRadexObject result = read[0];
                            return result;
                        }

                    case 0x08_02:
                        {
                            var read = MemoryMarshal.Cast<byte, WriteSettingsResponse>(data);
                            IRadexObject result = read[0];
                            return result;
                        }

                    case 0x08_03:
                        {
                            var read = MemoryMarshal.Cast<byte, ResetAccumulatedResponse>(data);
                            IRadexObject result = read[0];
                            return result;
                        }

                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }

}
