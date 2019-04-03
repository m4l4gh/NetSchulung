using System;
using System.IO;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTestProject
{
    [TestClass]
    public class LoggingServiceTests
    {
        [TestMethod]
        public void ctor_Test()
        {
            var logger = new LoggingService();
            Assert.IsNotNull(logger);
        }

        [TestMethod]
        public void AppendLineToLogFile_Test()
        {
            var path = @"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt";
            if (File.Exists(path))
            {
                File.Delete(@"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt");
            }
            var logger = new LoggingService();
            logger.Init();
            logger.Log("Testeintrag");
            using (var sr = new StreamReader(@"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt"))
            {
                var logContent = sr.ReadToEnd();
                Assert.IsTrue(logContent.Contains("Testeintrag"), "Fehler");
            }

        }
        [TestMethod]
        public void AppendMultipleLines()
        {
            var logger = new LoggingService();
            logger.Init();
            var path = @"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt";
            using (var sw = new StreamWriter(path))
            {
                sw.Write("");
            }

            for (var i = 0; i < 3; i++)
            {
                logger.Log("test");
            }
            using (var sr=new StreamReader(@"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt"))
            {
                int index = -1;
                while (!sr.EndOfStream)
                {
                    index++;
                    var content = sr.ReadLine();
                    Assert.IsTrue(content.StartsWith("0") || content.StartsWith("1") || content.StartsWith("2"));
                }
            }            
        }

        [TestMethod]
        public void DeleteRowByIndex_Test()
        {
            var logger = new LoggingService();
            logger.Init();
            var path = @"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt";
            using (var sw = new StreamWriter(path))
            {
                sw.Write("");
            }

            for (var i = 0; i < 3; i++)
            {
                logger.Log("test");
            }
            logger.DeleteLine(1);

            using (var sr = new StreamReader(@"C:\Users\MLAMPL\AppData\Roaming\myapp\log.txt"))
            {
                int index = -1;
                while (!sr.EndOfStream)
                {
                    index++;
                    var content = sr.ReadLine();
                    Assert.IsFalse(content.StartsWith("1"),$"Index {index} wurde nicht gelöscht");
                }
            }
        }

        [TestMethod]
        public void InitTest()
        {
            var logger = new LoggingService();
            logger.Init();            

            Assert.AreNotEqual(logger.FilePath,string.Empty);
        }
    }
}
