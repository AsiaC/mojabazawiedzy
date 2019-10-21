using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class UseStart : IHome, IOffice
    {
        void IHome.Start()
        { Console.WriteLine("Start z IHome "); }
        void IOffice.Start()
        { Console.WriteLine("Start z IOffice "); }
    }
}
