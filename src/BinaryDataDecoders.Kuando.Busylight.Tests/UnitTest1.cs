using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight.Tests;

[TestClass]
public class UnitTest1
{
    public TestContext TestContext { get; set; }


    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void BuidlRequestTest()
    {
        Span<BusylightCommand> commands = new[]
        {
            new BusylightCommand
            {
                NextStep= 1,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0xff, Green= 0x00, Blue = 0x00, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
            new BusylightCommand
            {
                NextStep= 2,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0xff, Green= 0xff, Blue = 0x00, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
            new BusylightCommand
            {
                NextStep= 3,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0x00, Green= 0xff, Blue = 0x00, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
            new BusylightCommand
            {
                NextStep= 4,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0x00, Green= 0xff, Blue = 0xff, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
            new BusylightCommand
            {
                NextStep= 5,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0x00, Green= 0x00, Blue = 0xff, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
            new BusylightCommand
            {
                NextStep= 0,
                Repeat = 0x01,
                Color = new BusylightColor{ Red = 0xff, Green= 0x00, Blue = 0xff, },
                On = 0x05,
                Off = 0x00,
                Audio= BusylightAudio.None,
            },
        };
        var requestBuffer = MemoryMarshal.Cast<BusylightCommand, byte>(commands);

        if (requestBuffer.Length > 56) throw new InvalidOperationException();

        Span<byte> outBuffer = new byte[65];
        requestBuffer.CopyTo(outBuffer[1..]);

        outBuffer[57] = 6; //_dpi_box_sensivity
        outBuffer[58] = 4; // _dpi_box_timeout
        outBuffer[59] = 85; //_dpi_box_triggertime

        outBuffer[60] = outBuffer[61] = outBuffer[62] = 0xff;

        var checksum = new[] { outBuffer[..63].ToArray().Aggregate((ushort)0, (v, i) => (ushort)(v + i)) };
        var checksumBuffer = MemoryMarshal.Cast<ushort, byte>(checksum);

        checksumBuffer.CopyTo(outBuffer[63..]);

        var bytes = outBuffer.ToArray();
        var hex = bytes.ToHexString(",0x");

        TestContext.WriteLine(hex);
    }

    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public async Task TestMethod1()
    {
        await new Class1().Start(new System.Threading.CancellationTokenSource());
    }


    private byte[] GenerateCommands(dynamic[] commands)
    {
        int i;
        byte[] nextStep = new byte[65];
        nextStep[0] = 0;
        int num = 1;
        for (i = 0; i < (int)commands.Length; i++)
        {
            if ((commands[i].NextStep & 240) != 0)
            {
                nextStep[num] = commands[i].NextStep;
            }
            else
            {
                nextStep[num] = (byte)(commands[i].NextStep | 16);
            }
            num++;
            nextStep[num] = commands[i].RepeatInterval;
            num++;
            if (commands[i].Color != null)
            {
                nextStep[num] = 0x00; // Convert.ToByte(commands[i].Color.RedRgbValue);
                num++;
                nextStep[num] = 0x00; // Convert.ToByte(commands[i].Color.GreenRgbValue);
                num++;
                nextStep[num] = 0x00; //  Convert.ToByte(commands[i].Color.BlueRgbValue);
                num++;
            }
            nextStep[num] = commands[i].OnTimeSteps;
            num++;
            nextStep[num] = commands[i].OffTimeSteps;
            num++;
            nextStep[num] = commands[i].AudioByte;
            num++;
        }
        if (num < (int)nextStep.Length)
        {
            for (i = num; i < (int)nextStep.Length; i++)
            {
                nextStep[i] = 0;
            }
        }
        nextStep[57] = 6; // this._dpi_box_sensivity;
        nextStep[58] = 4; // this._dpi_box_timeout;
        nextStep[59] = 85; // this._dpi_box_triggertime;
        for (i = 60; i <= 62; i++)
        {
            nextStep[i] = 255;
        }
        ushort num1 = 0;
        for (i = 1; i < 63; i++)
        {
            num1 = (ushort)(num1 + nextStep[i]);
        }
        nextStep[63] = (byte)(num1 / 256);
        nextStep[64] = (byte)(num1 % 256);

        return nextStep;
    }
}
