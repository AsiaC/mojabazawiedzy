using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesMethods
{
    class Program
    {
        static void Main(string[] args)
        {//https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Typy_generyczne
        //http://kurs.aspnetmvc.pl/Csharp/Metody_generyczne

            int a, b;
            char c, d;
            a = 10;
            b = 20;
            c = 'A';
            d = 'B';
            // Wartości przed zamianą
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Swap(ref a, ref b);
            // Wartości po zmianie
            Console.WriteLine("a = {0}, b = {1}", a, b);
            // Sprawdzmy teraz innych typ danych
            // Wartości przed zamianą
            Console.WriteLine("a = {0}, b = {1}", c, d);
            Swap(ref c, ref d);
            // Wartości po zmianie
            Console.WriteLine("a = {0}, b = {1}", c, d);
            Console.ReadKey();
            // Wynik działania programu
            // a = 10, b = 20
            // a = 20, b = 10
            // a = A, b = B
            // a = B, b = A
        }
        // Generyczna metoda to zamiany kolejności parametrów
        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        //oniższa metoda zwraca typ generyczny i pobiera parametr generyczny. 
        //więc jeśli podamy jako parametr typ string zostanie również zwrócony typ string, natomiast jeśli podamy jako parametr typ int to metoda zwróci wartość typu int.
        public static T GenerycznaMetoda<T>(T parametr)
        {
            return parametr;
        }
    }
}
