using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Typy_generyczne
            //http://kurs.aspnetmvc.pl/Csharp/Klasy_generyczne
            //Możliwe jest ograniczenie typów jakie może przyjąć klasa generyczna. Aby ograniczyć typ należy użyć słowa kluczowego where:

            // Utworzenie tablicy liczb całkowitych oraz jej wypełnienie
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            for (int i = 0; i < 5; i++)
            {
                intArray.setGenericValue(i, i * 3);
            }
            // Wypisanie wszystkich danych
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Liczba: {0}", intArray.getGenericItem(i));
            }
            // Używając tej samej generycznej klasy jesteśmy w stanie zadeklarować innym typ danych
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            for (int i = 0; i < 5; i++)
            {
                charArray.setGenericValue(i, (char)(i + 97));
            }
            // Wypisanie wszystkich danych
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(charArray.getGenericItem(i));
            }
            Console.ReadKey();
            // Wynik działania programu
            // Liczba: 0
            // Liczba: 3
            // Liczba: 6
            // Liczba: 9
            // Liczba: 12
            // a
            // b
            // c
            // d
            // e
        }
    }
    class MyGenericArray<T>
    {
        private int[] array; //zwykła tablica ze zdefiniowanym typem
        private T[] genericArray;
        //konstruktor
        public MyGenericArray(int size)
        {
            array = new int[size + 1];
            genericArray = new T[size + 1];
        }

        public int getItem(int index) // metoda zwracająca typ danych jako int
        {
            return array[index];
        }
        public T getGenericItem(int index)  // metoda pozwalająca na zwrócenie dowolnego typu danych
        {
            return genericArray[index];
        }

        public void setValue(int index, int value) // metoda ustawiająca dane typu całkowitego (int)
        {
            array[index] = value;
        }
        
        public void setGenericValue(int index, T value) //metoda pozwalająca na ustawienie dowolnego typu danych
        {
            genericArray[index] = value;
        }
    }
}
