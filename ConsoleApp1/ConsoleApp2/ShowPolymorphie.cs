using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ShowPolymorphie
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Sum (double a, double b, double c=0)       
        {
            return (int)(a + b + c);
        }

        //public double Sum(double a, double b, double c = 0)
        //{

        //}
    }
}
