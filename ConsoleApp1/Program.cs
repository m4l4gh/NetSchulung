using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var logger = new LoggingService();
            }
            catch (UnauthorizedAccessException unae)
            {
                Console.WriteLine(unae.Message);
            }
            catch (Exception)
            {

                throw new DemoException("test");
            }
        }
    }

    public class DemoException:Exception
    {
        public DemoException(string msg)
        {

        }
    }
}
