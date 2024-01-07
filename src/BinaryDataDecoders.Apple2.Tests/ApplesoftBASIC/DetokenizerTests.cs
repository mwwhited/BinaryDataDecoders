using BinaryDataDecoders.Apple2.ApplesoftBASIC;
using BinaryDataDecoders.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Apple2.Tests.ApplesoftBASIC;

[TestClass]
public class DetokenizerTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(Detokenizer), Member = nameof(Detokenizer.GetLines))]
    public void GetLinesTest()
    {
        //Stage
        var example = Convert.FromBase64String(@"owEJCAoAiTqXAB4IFABEJNDnKDQpOrIgQ1RSTC1EADkIHgCiMjpBJNAiQVBQTEUgSUkiOrAxMDAw
AGoIKACiNDpBJNAiRE9TIFZFUlNJT04gMy4zICBTWVNURU0gTUFTVEVSIjqwMTAwMACMCDIAojc6
QSTQIkpBTlVBUlkgMSwgMTk4MyI6sDEwMDAAqAg8ALpEJDsiQkxPQUQgTE9BREVSLk9CSjAiAM8I
RgCMNDA5NjqyIEZBU1QgTE9BRCBJTiBJTlRFR0VSIEJBU0lDABAJUACiMTA6jMk5NTg6QSTQIkNP
UFlSSUdIVCBBUFBMRSBDT01QVVRFUixJTkMuIDE5ODAsMTk4MiI6sDEwMDAATwlaAEPQ4ijJMTEw
MSk6rUPQNsS6Op46QSTQIkJFIFNVUkUgQ0FQUyBMT0NLIElTIERPV04iOrAxMDAwOp0AXglkALrn
KDQpOyJGUCIAdQnoA7IgQ0VOVEVSIFNUUklORyBBJACVCfIDQtDTKDIwySjjKEEkKcsyKSk6rULQ
0TDEQtAxAKIJ/AOWQjq6QSQ6sQAAAIcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

        var bytes = example.Count(b => b != 0);

        //Mock

        //Test
        var detokenizer = new Detokenizer();
        var lines = detokenizer.GetLines(example);

        //Output
        var result = string.Join("\r\n", lines);
        this.TestContext.WriteLine(result);

        //Assert
        var line9 = lines.ElementAt(9);
        var expected = "90 C= PEEK ( - 1101):IF C= 6 THEN PRINT :INVERSE :A$= \"BE SURE CAPS LOCK IS DOWN\":GOSUB 1000:NORMAL ";
        Assert.AreEqual(expected, line9);

        //Verify
    }
    //IEnumerable<string> GetLines(ReadOnlySpan<byte> input)
}
