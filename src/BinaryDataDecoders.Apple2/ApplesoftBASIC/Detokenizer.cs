using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.Apple2.ApplesoftBASIC
{
    /// <summary>
    /// ApplesSoft Basic detokenizer
    /// </summary>
    public class Detokenizer
    {
        private readonly TokenMap _map = new();

        /// <summary>
        /// transform byte data into readable AppleSoft BASIC code.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IEnumerable<string> GetLines(IEnumerable<byte> input)
        {
            var e = input.GetEnumerator();

            var header1 = (byte)(e.MoveNext() ? e.Current : 0);
            var header2 = (byte)(e.MoveNext() ? e.Current : 0);

            //yield return $"$$$ HEADER: 0x{header1:X}, 0x{header2:X}";
            yield return $"$$$ FILE SIZE :{BitConverter.ToUInt16(new[] { header1, header2 })}";

            bool notDone;
            do
            {
                var addressOfNextLine = BitConverter.ToUInt16(new[] { (byte)(e.MoveNext() ? e.Current : 0), (byte)(e.MoveNext() ? e.Current : 0) });
                var lineNumber = BitConverter.ToUInt16(new[] { (byte)((notDone = e.MoveNext()) ? e.Current : 0), (byte)(e.MoveNext() ? e.Current : 0) });

                if (addressOfNextLine == 0 || lineNumber == 0) continue;

                bool nextLine;
                var sb = new StringBuilder($"{lineNumber} "); //0x{addressOfNextLine:X}]\t
                do
                {
                    var v = (byte)(e.MoveNext() ? e.Current : 0);
                    if (nextLine = (v == 0))
                    {
                        //End of Line
                        yield return sb.ToString();
                        sb.Clear();
                    }
                    else if ((v & 0x80) == 0)
                    {
                        //Character
                        sb.Append((char)v);
                    }
                    else
                    {
                        //Token
                        var token = _map.GetToken(v) + " ";
                        sb.Append(token);
                    }
                } while (!nextLine);
            } while (notDone);
        }
    }
}
