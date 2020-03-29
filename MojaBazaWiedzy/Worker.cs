using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class Worker
    {
        void DoWork(object obj)
        {
            Console.WriteLine("In DoWork(object)");
        }
        void DoWork(Widget widget)
        {
            Console.WriteLine("In DoWork(Widget)");
        }
        void DoWork(ItemBase itembase)
        {
            Console.WriteLine("In DoWork(ItemBase)");
        }
        public void Run()
        {
            object o = new Widget();
            DoWork((Widget)o);
        }
    }
}
