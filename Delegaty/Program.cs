using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty
{
    class Program
    {
        static void Main(string[] args)
        {
            // tworzenie dwóch innych instancji delegatów, każdy z nich ma po jednej metodzie różnej, ale metod w delegacie mogłoby byćwiecej
            ChangeNumber cn1 = new ChangeNumber(AddNumber); 
            ChangeNumber cn2 = new ChangeNumber(MultiplyNumber);
            // wywoływanie metod używajac delegatów
            cn1(5);
            Console.WriteLine("Wartość liczby: {0}", GetNumber());
            cn2(10);
            Console.WriteLine("Wartość liczby: {0}", GetNumber());
            Console.ReadKey();
            // Wynik działania programu
            // Wartosc liczby: 10
            // Wartosc liczby: 100
        }
        static int number = 5;
        public static int AddNumber(int i) //metoda, ma taką samą sygnaturę jak delegat (parametr i zwraca o samo co delegat)
        {
            number += i;
            return number;
        }
        public static int MultiplyNumber(int i) //metoda, ma taką samą sygnaturę jak delegat (parametr i zwraca o samo co delegat)
        {
            number *= i;
            return number;
        }
        public static int GetNumber()
        { return number; }

    }
    delegate int ChangeNumber(int i); //deklarowanie delegatu
    
}
