using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTestProject
{
    [TestClass]
    public class ShowPolymorphieTests
    {
        [TestMethod]
        public void DemoPolymorphie()
        {
            var mock = new ShowPolymorphie();
            var rtn = mock.Sum(1, 5);
            Assert.IsTrue(rtn == 6);

            rtn = mock.Sum(1.5, 4.5);
            Assert.IsTrue(rtn == 6);

            rtn = mock.Sum(a: 1.2, b: 3.5);
        }
    }
}
