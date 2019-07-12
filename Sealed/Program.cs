using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealed
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class X
    {
        protected virtual void F()
        { Console.WriteLine("X.F"); }
        protected virtual void F2()
        { Console.WriteLine("X.F2"); }
    }
    class Y : X
    {
        sealed protected override void F()
        { Console.WriteLine("Y.F"); }
        protected override void F2()
        { Console.WriteLine("X.F2"); }
    }
    class Z : Y
    {
        //protected override void F()  // Attempting to override F causes compiler error CS0239.  NIE MOGĘ UZYC TEJ METODY BO W y JEST ONA SEALED
        //{            Console.WriteLine("C.F");        }
        protected override void F2()  // OK Overriding F2 is allowed.  
        {            Console.WriteLine("Z.F2");        }
    }
}
