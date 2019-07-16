using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DyrektywyPreprocesora
{
    class Program
    {
        //Inne wywołanie procesora gdy Debug a inne gdy Release
        static void Main(string[] args)
        {
            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            //Console.ReadLine();
#if DEBUG //RELEASE
            Console.WriteLine("jestem w kodzie, który sie nie wykona dla Release");
#endif
            //[Conditional("DEBUG")] Atrybut oznaczony atrybutem Conditional zostanie skompilowany tylko wtedy, gdy obecny będzie Określony symbol preprocesora
            //tego warto używac przed klasami żeby nie kompilować nie potrzebnie

            Console.ReadKey();
        }
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }
    }
}
