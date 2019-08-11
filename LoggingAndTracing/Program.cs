using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAndTracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("start application");
            //Debug.Indent(); //to daje wcięcie/tabulator
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
            Console.ReadKey();
        }
    }
}
