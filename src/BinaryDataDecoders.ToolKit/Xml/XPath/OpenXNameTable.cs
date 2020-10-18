using System.Xml;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public class OpenXNameTable : XmlNameTable
    {
        private readonly NameTable _nameTable = new NameTable();

        public override string Add(char[] array, int offset, int length) =>
            _nameTable.Add(array, offset, length);
        public override string Add(string array) =>
            _nameTable.Add(array);

        public override string Get(char[] array, int offset, int length) =>
            _nameTable.Get(array, offset, length);

        public override string Get(string array) =>
            _nameTable.Add(array);
    }
}
