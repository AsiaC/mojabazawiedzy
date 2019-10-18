using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    public class Class1a// : IEquatable<Class1a>
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public bool Equals(Class1a other)
        {
            if (other == null) return false;
            if (this.ID != other.ID) return false;
            //if (!this.Name.Equals(other.Name)) return false;
            if (!Object.Equals(this.Name, other.Name)) return false;
            return true;
        }

        /*
        bool IEquatable<Class1a>.Equals(Class1a other)
        {
            return true;
            //if (other == null) return false;
            //if (!this.Name.Equals(other.Name)) return false;
            //if (!Object.Equals(this.Name, other.Name)) return false;
            //if (this.ID != other.ID) return false;
            
        }
        */
        public Class1a(int v1, string v2)
        {
            this.ID = v1;
            this.Name = v2;
        }
        
    }
}
