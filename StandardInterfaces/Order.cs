using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardInterfaces
{
    class Order : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1; //obecna instancja jest dalej niż obj
            Order o = obj as Order;
            if (o == null)
            {
                throw new ArgumentException("Onject is not an Order");
            }
            return this.Created.CompareTo(o.Created);
        }
    }
}
