using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public class EnumerableXPathNodeIterator : XPathNodeIterator
    {
        private int _pointer;
        private readonly IEnumerable<IXPathNavigable> _set;
        private readonly IEnumerator<IXPathNavigable> _enumerator;

        public EnumerableXPathNodeIterator(IEnumerable<IXPathNavigable> set)
        {
            _set = set.ToArray();
            _pointer = -1;
            _enumerator = set.GetEnumerator();
        }

        public override XPathNavigator Current => _enumerator.Current.CreateNavigator();
        public override int CurrentPosition => _pointer;

        public override XPathNodeIterator Clone()
        {
            var newIterator = new EnumerableXPathNodeIterator(_set);
            while (newIterator.CurrentPosition < _pointer && newIterator.MoveNext()) ;
            return newIterator;
        }

        public override bool MoveNext()
        {
            if (_enumerator.MoveNext())
            {
                _pointer++;
                return true;
            }
            return false;
        }
    }
}
