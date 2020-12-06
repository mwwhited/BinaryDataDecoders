using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
}
