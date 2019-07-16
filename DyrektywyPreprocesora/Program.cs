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

            //#pragma
            //When building an application, you sometimes willingly write some code that triggers a warning.You don’t want to change the code, but you do want to hide the warning. You can do this by using the
            //#pragma warning directive. (disabling and enabling all warnings)

            //#pragma warning disable
            //                while (false)
            //                {
            //                    Console.WriteLine(“Unreachable code”);
            //                }
            //#pragma warning restore

            //You can also choose to disable or restore specific warnings, as shown.The compiler won’t report a warning for the int i statement, but it will report a warning for the unreachable code.You can find the specific error codes in your Output Window in Visual Studio.
            //Disabling and enabling specific warnings
            
            //#pragma warning disable 0162, 0168
            //int i;
            //#pragma warning restore 0162
            //            while (false)
            //            {
            //                Console.WriteLine(“Unreachable code”);
            //            }
            //#pragma warning restore
                       
            Console.ReadKey();
        }
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }
    }
}
