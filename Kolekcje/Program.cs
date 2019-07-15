using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcje
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1

            //ArrayList
            Console.WriteLine("ArrayList");
            ArrayList arraylist = new ArrayList();
            //arraylist.Add(13);
            //arraylist.Add(11);
            arraylist.Add("Asia");
            arraylist.Add("Ala");
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Liczba elementów, które ArrayLista może zawierać: {0}", arraylist.Capacity);
            Console.WriteLine("Liczba elementów: {0}", arraylist.Count);
            arraylist.Sort(); //tylko gdzy mam obiekty tego samego rodzaju, bo mogę mieć różne ale różnych nie mogę sortować
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Hashtable
            Console.WriteLine("Hashtable");
            Hashtable ht = new Hashtable();
            ht.Add("001", "Audi");
            ht.Add("002", "Pagani");
            ht.Add("003", "Lamborghini");
            ht.Add("004", "Nissan");
            ht.Add("005", "Volvo");
            ht.Add("006", null);
            if (ht.ContainsKey("005")) //jeśli istnieje klucz 005
                Console.WriteLine("Wartość klucza 005 : {0}", ht["005"]);
            if (ht.ContainsValue("Volvo"))// Możemy sprawdzić czy w kolekcji jest konkretna wartość
                Console.WriteLine("Volvo jest elementem kolekcji");
            // Pobierzemy teraz wszystkie klucze
            ICollection key = ht.Keys;
            foreach (string k in key)
            {
                Console.WriteLine("Klucz: {0} || wartość: {1}", k, ht[k]);
            }
            ht.Clear(); //czyślimy całą zawartość
            Console.WriteLine("Pozostała liczba elementów: {0}", ht.Count); //0 elementów
            Console.WriteLine();

            //SortedList 
            Console.WriteLine("SortedList ");
            SortedList sl = new SortedList();
            sl.Add("001", "Audi"); // Dodajemy pary: klucz/wartość
            sl.Add("002", "Pagani");
            sl.Add("005", "Volvo");
            sl.Add("004", "Nissan"); // element ten zostaje dodany do listy przed pozycją 005
            sl.Add("003", "Lamborghini"); // element ten zostaje dodany do listy przed powyższym elementem
            // Dostęp przez klucz -> jak HashTable
            if (sl.ContainsKey("004"))
                Console.WriteLine("Wartość: {0}", sl["004"]);
            // Dostęp przez wartość -> jak ArrayList
            if (sl.ContainsValue("Nissan"))
                Console.WriteLine("Nissan jest elementem kolekcji");
            ICollection keys = sl.Keys;
            foreach (string k in keys)
            {
                Console.WriteLine("Klucz: {0} || wartość: {1}", k, sl[k]);
            }
            Console.WriteLine();

            //Stack
            Console.WriteLine("Stack");
            Stack st = new Stack();
            st.Push("A");
            st.Push("B");
            st.Push("C");
            st.Push("D");
            // Nasz stos jest pełny. Zgodnie z definicją kolejny element powinien trafić na pierwszą pozycję
            st.Push("TEST");
            Console.WriteLine("Zawartość stosu: ");
            foreach (var item in st)
            {
                Console.WriteLine(item);
            }
            // usuwamy 2 pozycje
            st.Pop(); //usunie sie TEST
            st.Pop(); //usunie sie D
            // Możemy również zwrócić obiekt na szczycie stosu bez usuwania
            Console.WriteLine("Pierwszy element: {0}", st.Peek()); //C
            Console.WriteLine();

            //Queue 
            Console.WriteLine("Queue");
            Queue q = new Queue();
            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            q.Enqueue("D");
            q.Dequeue(); //first-in, first-out. Pierwszy dodany el to pierwszy do usunięcia.Usuneliśmy A
            Console.WriteLine("Zawartość kolejki: ");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            // Spróbujmy jeszcze zobaczyć jaki element usuwamy
            string tekst = (string)q.Dequeue();
            Console.WriteLine("Usuneliśmy: {0}", tekst); //Usunelismy B
            Console.WriteLine();

            //BitArray 
            Console.WriteLine("BitArray");
            // Tworzymy dwie tablice o rozmiarze 8 bitów
            BitArray ba1 = new BitArray(8);
            BitArray ba2 = new BitArray(8);
            byte[] a = { 60 };
            byte[] b = { 13 };
            // zapisujemy wartości w naszych tablicach
            ba1 = new BitArray(a);
            ba2 = new BitArray(b);
            // Zawartość pierwszej z nich
            Console.WriteLine("Tablica bitów ba: 60");
            for (int i = 0; i < ba1.Count; i++)
            {
                // Co oznacza poniższy zapis
                // Na każdy wyraz poświęcamy 6 znaków
                // Ale z wyrównianiem do lewej strony
                // Gdybyśmy zapis zmienili na {0, 6} 
                // Wyrównanie byłoby do prawej strony
                Console.Write("{0, -6}", ba1[i]);
            }
            Console.WriteLine();
            // Zawartość drugiej z nich
            Console.WriteLine("Tablica bitów ba: 13");
            for (int i = 0; i < ba2.Count; i++)
            {
                Console.Write("{0, -6}", ba2[i]);
            }
            Console.WriteLine();
            // Połączmy teraz obie tablie operatorem logicznym AND
            BitArray ba3 = new BitArray(8);
            ba3 = ba1.And(ba2);
            Console.WriteLine("Tablica bitów ba3: ba1 i ba2");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6}", ba3[i]);
            }
            // Wynik działania programu
            // Tablica bitów ba: 60
            // False False True  True  True  True  False False
            // Tablica bitów ba: 13
            // True  False True  True  False False False False
            // Tablica bitów ba3: ba1 i ba2
            // False False True  True  False False False False
        }
    }
}
