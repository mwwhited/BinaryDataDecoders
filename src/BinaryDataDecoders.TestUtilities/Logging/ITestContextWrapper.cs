using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.TestUtilities.Logging;

public interface ITestContextWrapper
{
    TestContext Context { get; }
}
