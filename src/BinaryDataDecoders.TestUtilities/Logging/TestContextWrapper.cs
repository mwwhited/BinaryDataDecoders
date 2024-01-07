using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.TestUtilities.Logging;

public class TestContextWrapper(TestContext context) : ITestContextWrapper
{
    public TestContext Context { get; } = context;
}
