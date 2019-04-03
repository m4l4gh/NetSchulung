using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTestProject
{
    [TestClass]
    public class ShowKapselungTests
    {
        [TestMethod]
        public void DemoKapselung()
        {
            var mock = new ShowKapselung();
            mock.TestA();
            //mock.TestB();
            //mock.TestC();

            var child = new Child();
            child.ParentMethodC();

            //var parent = new ParentAbstract();
            var childAbstr = new ChildOfAbstr();

        }
    }
}
