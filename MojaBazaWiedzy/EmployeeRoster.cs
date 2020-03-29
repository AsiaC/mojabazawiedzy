using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    public class EmployeeRoster
    {
        public Dictionary<string, int> employees = new Dictionary<string, int>();
        public void Add(string name, int salary)
        {
            employees.Add(name, salary);
        }
        public int this[string name]
        {
            get {
                return employees[name];
            }
        }
    }
}
