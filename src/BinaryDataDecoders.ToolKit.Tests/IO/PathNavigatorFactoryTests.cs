using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.TestUtilities;

namespace BinaryDataDecoders.ToolKit.Tests.IO
{
    [TestClass]
    public class PathNavigatorFactoryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.DevLocal)]
        public void ToNavigableTest()
        {
            var di = new DirectoryInfo("../../../../");
            var xpath = di.ToNavigable().CreateNavigator();
            this.TestContext.AddResult(xpath);
        }
    }
}
