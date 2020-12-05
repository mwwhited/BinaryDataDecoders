using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryDataDecoders.TestUtilities.Logging
{
    public class TestContextWrapper : ITestContextWrapper
    {
        public TestContextWrapper(TestContext context) => this.Context = context;
        public TestContext Context { get; }
    }
}
