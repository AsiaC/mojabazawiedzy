using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class Kiosk
    {
        static Catalog _catalog = null;
        static object _lock = new object();
        public static Catalog Catalog
        {
            get
            {
                if (_catalog == null)
                    lock (_lock)
                        if (_catalog == null)
                            _catalog = new Catalog();
                return _catalog;
            }
        }
    }
}
