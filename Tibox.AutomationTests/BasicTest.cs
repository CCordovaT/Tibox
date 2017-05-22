using System;
using System.Linq;
using Tibox.Automation;
using Xunit;

namespace Tibox.AutomationTests
{
    public class BasicTest
    {
        [Fact]
        public void TestMethod1()
        {
            var test = new SimpleTest();
            test.Navigate();
        }
    }
}
