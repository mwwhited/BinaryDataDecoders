using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;

public class EnumerableXPathNodeIterator(IEnumerable<IXPathNavigable> set) : XPathNodeIterator
{
    private int _pointer = -1;
    private readonly IEnumerable<IXPathNavigable> _set = set.ToArray();
    private readonly IEnumerator<IXPathNavigable> _enumerator = set.GetEnumerator();

    public override XPathNavigator? Current => _enumerator.Current.CreateNavigator();
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
