using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivarePublicProtected
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Person a1 = new Person();
            a1.Lp = 1;
            a1.Name = "Ewa";
            a1.SecondName = "Ala";
            a1.Surname = "Cz";
            Console.WriteLine(""+a1.Lp1());

            Employee b1 = new Employee();
            b1.Lp = 10;
            b1.Name = "Asia";
            b1.SecondName = "Basia";
            b1.Surname = "Cz";
            b1.EmployeeType = "advisory";
           */                                  
            Console.ReadKey();
        }
    }
    public class Person
    {
        private int Lp { get; set; } //w main-NIE mozna, w tej klasie-mozna, w klasie dziedziczącej-NIE mozna
        internal string Name { get; set; } //w main-mozna, w tej klasie-mozna, w klasie dziedziczącej-mozna TO GDZIE NIE MOZNA?? Gdy mamy do czynienia z różnymi assembly
        protected string SecondName { get; set; } //w main-NIE mozna, w tej klasie-mozna, w klasie dziedziczącej-mozna
        public string Surname { get; set; } //w main- mozna, w tej klasie-mozna, w klasie dziedziczącej-mozna

        public int Lp2()
        { return Lp + 1; }
        public string Name2()
        { return Name = Name + "A"; }
        public string SecondName2()
        { return SecondName = SecondName + "A"; }
        public string Surname2()
        { return Surname = Surname + "A"; }
    }
    public class Employee : Person
    {
        protected string EmployeeType { get; set; } //w main-NIE mozna, 
        private string EmployeeTypeChanged()
        { return EmployeeType = EmployeeType + " new";        }
       // public int Lp3()
       // { return Lp + 10;        }
        public string Name3( )
        { return Name=Name + "B";        }
        public string SecondName3()
        { return SecondName = SecondName + "B"; }
        public string Surname3()
        { return Surname = Surname + "B"; }
    }
}
