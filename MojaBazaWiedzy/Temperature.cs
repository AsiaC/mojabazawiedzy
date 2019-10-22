using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class Temperature : IComparable
    {
        public double Farenheit { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            var otherTemp = obj as Temperature;

            if (otherTemp != null)
            {
                
                Console.WriteLine("1 -1=>FALSE 0=>TRUE(equals) ");
                return this.Farenheit.CompareTo(otherTemp.Farenheit);
                //return otherTemp.Farenheit.CompareTo(this.Farenheit);
            }
            throw new ArgumentException("Object is not a Tempreture");
        }
    }
}
