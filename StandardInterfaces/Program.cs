using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
            {
                new Order { Created = new DateTime(2010, 12, 1) },
                new Order { Created = new DateTime(2010, 1, 1) },
                new Order { Created = new DateTime(2010, 10, 1) }

            };

            Order a = new Order { Created = new DateTime(2010, 12, 1) };
            Order b = new Order { Created = new DateTime(2010, 1, 1) };
            int result= a.CompareTo(b);
            Console.WriteLine("Legenda wyniku: ");
            Console.WriteLine("x<0 objekt < przekazanego w ()");
            Console.WriteLine("x=0 objekt = przekazanego w ()");
            Console.WriteLine("x>0 objekt > przekazanego w (), w przypadku daty to jest późniejsza data ");
            Console.WriteLine(result);
            //CompareTo słuzy do wskazywania późniejszego/wiekszego elementu. Sort() wykotrzysuje CompareTo()
            Console.WriteLine("nieposortowana lista:");
            foreach (var item in orders)
            {
                Console.WriteLine(item.Created);
            }
            orders.Sort();
            Console.WriteLine("Posortowana lista:");
            foreach (var item in orders)
            {
                Console.WriteLine(item.Created);
            }
            Console.ReadKey();
        }
    }
}
