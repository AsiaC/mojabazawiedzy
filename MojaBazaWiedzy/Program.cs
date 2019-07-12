using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace MojaBazaWiedzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kolekcje();
            //Linq();
            //QUESTION2();
            QUESTION4();
            QUESTION6();
            Console.ReadKey();
        }

        public static void Kolekcje()
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
            ht.Add("006",null);
            if(ht.ContainsKey("005")) //jeśli istnieje klucz 005
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
        public static void Linq()
        {
            //LINQ uzywa wyraźeń lambda, ale może też używać query expression, te dwie składnie uzupełniają sie
            skladniaLAMBDA();
            skladniaQUERYEXPRESSION();
        }
        private static void skladniaLAMBDA()
        {  
            string[] TableStrings = { "kot", "pies", "kon", "chomik", "hipopotam", "żyrafa", "nosorożec" };
            int[] TableInt = { 16, 22, 3, 9, 5, 7 };

            Console.WriteLine("w nowej tabeli umiesc te składowe gdzie kozdego pojedyńczego długość > 4");
            IEnumerable<string> WyrazyDluzszeNiz4 = TableStrings.Where(x => x.Length > 4);
            foreach (var item in WyrazyDluzszeNiz4)
                Console.WriteLine(item);

            Console.WriteLine("w nowej tabeli umiesc te składowe gdzie kozdy pojedyńczy ma litere o");
            IEnumerable<string> WyrazyZO = TableStrings.Where(x => x.Contains("o"));
            foreach (var item in WyrazyZO)
                Console.WriteLine(item);

            Console.WriteLine("pobiera wszystkie łańcuchy zawierające literę a, sortuje je wg długości i zamienia wszystkie litery na wielkie");
            IEnumerable<string> sortujeIUppercase = TableStrings.Where(x => x.Contains("o")).OrderBy(x => x.Length).Select(x => x.ToUpper());
            foreach (var item in sortujeIUppercase)
                Console.WriteLine(item);

            IEnumerable<string> sortujeIUppercase2 = TableStrings
                .Where(x => x.Contains("o"))
                .Select(x => x.ToUpper())
                .OrderBy(x => x.Length);
            foreach (var item in sortujeIUppercase2)
                Console.WriteLine(item);
            /*Operator Where już przedstawiliśmy. Jego działanie polega na zwróceniu przefiltrowanej wersji sekwencji
wejściowej.Operator OrderBy zwraca posortowaną wersję sekwencji wejściowej, a metoda Select —
sekwencję, w której każdy element wejściowy jest przekształcony lub przedstawiony(ang.projected)
za pomocą danego wyrażenia lambda(w tym przypadku n.ToUpper()).Dane są przepuszczane przez
łańcuch operatorów od lewej, więc najpierw zostały przefiltrowane, potem posortowane, a na koniec
przekształcone.*/

            //Wyrażenie lambda pobierające wartość i zwracające wartość logiczną nazywa się predykatem.

            Console.WriteLine("Sort Alfabetyczny");
            IEnumerable<string> Alfabetycznie = TableStrings.OrderBy(x => x);
            foreach (var item in Alfabetycznie)
                Console.WriteLine(item);

            Console.WriteLine("Sort Alfabetyczny2");
            IEnumerable<int> Alfabetycznie2 = TableInt.OrderBy(x => x);
            foreach (var item in Alfabetycznie2)
                Console.WriteLine(item);

            Console.WriteLine("Operator Take zwraca x pierwszych elementów, a resztę odrzuca");
            IEnumerable<string> Wez3Pierwsze = TableStrings.Take(3);
            foreach (var item in Wez3Pierwsze)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Operator Skip ignoruje x pierwszych elementów i zwraca pozostałe:");
            IEnumerable<string> Odrzuc3pierwsze = TableStrings.Skip(4);
            foreach (var item in Odrzuc3pierwsze)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Operator Reverse odwraca kolejność elementów");
            IEnumerable<string> OdwrocKolejnosc = TableStrings.Reverse();
            foreach (var item in OdwrocKolejnosc)
            {
                Console.WriteLine(item);
            }


            //Operatory elementów wybierają po jednym elemencie z sekwencji wejściowej.
            string firstElement = TableStrings.First();
            Console.WriteLine("firstelement={0}", firstElement);
            string lastElement = TableStrings.Last();
            Console.WriteLine("lastElement={0}", lastElement);
            string secondElement = TableStrings.ElementAt(1);
            Console.WriteLine("second element={0}", secondElement);

            //Operatory agregacji zwracają wartość skalarną
            int count = TableInt.Count();
            int min = TableInt.Min();
            Console.WriteLine("count={0}, min={1}", count, min);

            //Kwantyfikatory zwracają wartości typu bool:
            bool hasTheNumberNine = TableInt.Contains(9); // prawda
            bool hasMoreThanZeroElements = TableInt.Any(); // prawda
            bool hasAnOddElement = TableInt.Any(n => n % 2 != 0); // prawda

            //Niektóre operatory zapytań przyjmują po dwie sekwencje wejściowe. Należą do nich operator Concat dodający jedną sekwencję do drugiej oraz Union robiący to samo, tylko z eliminacją duplikatów:
            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };
            IEnumerable<int> concat = seq1.Concat(seq2); // { 1, 2, 3, 3, 4, 5 }
            IEnumerable<int> union = seq1.Union(seq2); // { 1, 2, 3, 4, 5 }

            //Filtrowanie 
            //Where, Take, TakeWhile, Skip, SkipWhile, Distinct
        }
        private static void skladniaQUERYEXPRESSION()
        {
            //Początek każdego wyrażenia zapytaniowego stanowi klauzula from, a koniec — select lub group.

            string[] names = { "Jan", "Olga", "Daria", "Robert", "Zenon" };
            IEnumerable<string> query =
                                        from n in names
                                        where n.Contains("a") // filtrowanie elementów
                                        orderby n.Length // sortowanie elementów
                                        select n.ToUpper(); // przekształcanie elementów (projekcja)
            foreach (string name in query) Console.Write(name + " ");
            Console.WriteLine();

            IEnumerable<string> query2 =
                            from n in names
                            where n.Contains("a") // filtrowanie elementów
                            select n;
            foreach (var item in query2) Console.Write(item + " ");
            Console.WriteLine();

            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            // Query Expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                orderby score descending //malejaco czyli od najwiekszej
                select score; //must end with select or group
            foreach (var item in scoreQuery) Console.Write(item + " ");
            Console.WriteLine();

            //wykonywanie opóźnione
            var numbers = new List<int>();
            numbers.Add(1);
            IEnumerable<int> query1 = numbers.Select(n => n * 10); // budowa zapytania
            numbers.Add(2); // dodanie elementu
            foreach (int n in query1) Console.Write(n + " "); // 10|20|
            Console.WriteLine();

            //zapisanie wyniku do listy nowej
            var numbers2 = new List<int>() { 1, 2 };
            List<int> timesTen = numbers2
            .Select(n => n * 10)
            .ToList(); // natychmiast wysyła dane do listy List<int>
            numbers2.Clear();
            Console.WriteLine(timesTen.Count); // nadal 2
        }
        private static void QUESTION2()
        {/*QUESTION 2 
You are developing an application. 
The application calls a method that returns an array of integers named employeeIds. 
You define an integer variable named employeeIdToRemove and assign a value to it. 
You declare an array named filteredEmployeeIds. 
You have the following requirements:
- Remove duplicate integers from the employeeIds array. 
- Sort the array in order from the highest value to the lowest value. 
- Remove the integer value stored in the employeeIdToRemove variable from the employeeIds array. 
You need to create a LINQ query to meet the requirements. 
 */         //int[] table1= { 11, 2, 3, 4, 5 };
            //int[] employeeIds = new int[table1.Length];
            //employeeIds = zwrocTablice(table1);
            int[] employeeIds = { 2, 6, 8, 2, 13, 1, 9, 6, 7 };
            foreach (var item in employeeIds)
            {
                Console.WriteLine(item);
            }
            var employeeIdToRemove = 13;
            int[] filteredEmployeeIds1 = employeeIds.Where(value => value != employeeIdToRemove).OrderBy(x => x).ToArray();
            int[] filteredEmployeeIds2 = employeeIds.Where(value => value != employeeIdToRemove).OrderByDescending(x => x).ToArray();
            int[] filteredEmployeeIds3 = employeeIds.Distinct().Where(value => value != employeeIdToRemove).OrderByDescending(x => x).ToArray();
            int[] filteredEmployeeIds4 = employeeIds.Distinct().OrderByDescending(x => x).ToArray();
            foreach (var item in filteredEmployeeIds1) Console.Write(item + " ");//1 2 2 6 6 7 8 9
            Console.WriteLine();
            foreach (var item in filteredEmployeeIds2) Console.Write(item + " ");//9 8 7 6 6 2 2 1
            Console.WriteLine();
            foreach (var item in filteredEmployeeIds3) Console.Write(item + " "); //9 8 7 6 2 1
            Console.WriteLine();
            foreach (var item in filteredEmployeeIds4) Console.Write(item + " "); //13 9 8 7 6 2 1
            Console.WriteLine();
        }
        private static void QUESTION4()
        {
            //używa klasy Loan i LoanCollection  
            Loan lo1 = new Loan("pożyczka pierwsza");
            Loan lo2 = new Loan("pożyczka druga");
            Loan lo3 = new Loan("pożyczka trzecia");
            Loan[] arr = new Loan[] { lo1, lo2, lo3 };
           
            LoanCollection loan = new LoanCollection(arr);
        }
        private static void QUESTION6()
        {
            decimal[] loanAmounts = { 303m, 4000m, 85579m, 501.51m, 603m, 1200m, 400m, 22m };
            IEnumerable<decimal> loanQuery =
                from amount in loanAmounts
                where amount % 2 == 0
                orderby amount descending
                select amount;

            foreach (var item in loanQuery) Console.Write(item + " "); //4000 1200 400 22
            Console.WriteLine();
        }
        private static void QUESTION7()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?redirectedfrom=MSDN&view=netframework-4.7.2 
            string Filename = @"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\Nauka7\file1.txt";
            using (var fs = File.Open(Filename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }

            }

            string Filename2 = @"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\Nauka7\file2.txt";
            using (var fs2 = File.Open(Filename2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(fs2))
                {
                    writer.Write(303);
                    writer.Write(720);
                }
            }
            using (var fs3 = File.Open(Filename2, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader reader = new BinaryReader(fs3))
                {
                    int a = reader.ReadInt32();
                    int b = reader.ReadInt32();
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }
            }

        }
        private static void QUESTION8()
        {//używa klasy Name
            string Filename = @"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\Nauka7\Nauka7\json1.json";
            var json = File.ReadAllText(Filename);
            Name a = ConvertToName(json);
            Console.WriteLine(a.FirstName + " " + a.LastName);
        }
        private static Name ConvertToName(string json)
        {
            var ser = new JavaScriptSerializer(); //Przestrzeń nazw:System.Web.Script.Serialization(add using)   Assembly:System.Web.Extensions.dll(add reference)
            return ser.Deserialize<Name>(json);
        }
        public static void QUESTION9()
        {//tworze xml i obiekt w nim taki jak ponizej (serializuję)
            //https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer?view=netframework-4.7.2
            string fileName = "XMLFile2.xml"; //C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\Nauka7\Nauka7\bin\Debug
            Name1 p1 = new Name1("David", "Jones");
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(Name1));
            ser.WriteObject(writer, p1);
            writer.Close();

            Console.ReadKey();
        }

        public static void QUESTION15()
        {
            Animal a = new Animal();
            Save(a);
            Zyrafa b = new Zyrafa();
            Save(b);
        }
        public class Animal //nie 
        {
            public string gatunek { get; set; }
            public int lbLap { get; set; }
            public string imie { get; set; }
        }
        public class Zyrafa : Animal
        { public string długoscSzyi { get; set; } }
        public class Pingwin : Animal
        { public int iloscSprawnychskrzydel { get; set; } }
        public static void Save<T>(T target) where T : Animal, new()
        { Console.WriteLine("Wywoluje Statyczna metode poza klasami Save. Wywolano dla: {0}", target); }
        public static void QUESTION18()
        {//??????????????????????????????????????????????????????????????????????????????????????????????????????????
            IEnumerable<string> enumerable = new string[] { "A", "B", "C" };
            // Z użyciem foreach dostępnego w IEnumerable:
            foreach (string s in enumerable)
                Console.WriteLine(s);

            // Z użyciem Enumeratora:
            IEnumerator<string> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string s = enumerator.Current;
                Console.WriteLine(s);
            }

            TabDelimitedFormatter a = new TabDelimitedFormatter();
            a.GetOutput(enumerator, 3);


        }
        public interface IOutputFormatter<T>
        {
            string GetOutput(IEnumerator<T> iterator, int recordSize);
        }
        public class TabDelimitedFormatter : IOutputFormatter<string>
        {
            readonly Func<int, char> suffix = col => col % 2 == 0 ? '\n' : '\t';
            public string GetOutput(IEnumerator<string> iterator, int recordSize)
            {
                /*string output = null;
                for (int i = 1; iterator.MoveNext(); i++)
                {
                    output = string.Concat(output, iterator.Current, suffix(i));
                }
                return output;*/

                var output = new StringBuilder();
                Console.WriteLine("output {0}", output.ToString());
                for (int i = 1; iterator.MoveNext(); i++)
                {
                    output.Append(iterator.Current);
                    output.Append(suffix(i));
                }
                Console.WriteLine("output end {0}", output.ToString());
                return output.ToString();
            }
        }
        public static void QUESTION19()
        {
            Calculate(5);
        }
        public static void Calculate(float amount)
        {
            object amountRef = amount;
            int balance = (int)(float)amountRef;
            Console.WriteLine(balance);
        }
        public static void QUESTION23()
        {
            Lease a = new Lease();

        }
        //public delegate void MaximumTermReachedHendler(object source, EventHandler e);
        public delegate void MaximumTermReachedHendler(int a);
        public class Lease
        {
            public event MaximumTermReachedHendler OnMaximumTermReached;
            private int _term;
            private const int MaximunTerm = 5;
            private const decimal Rate = 0.034m;
            public int Term
            {
                get { return _term; }
                set
                {
                    if (value <= MaximunTerm)
                        _term = value;
                    else
                    {
                        if (OnMaximumTermReached != null)
                            //OnMaximumTermReached(this, new EventArgs());
                            OnMaximumTermReached(5);
                    }
                }
            }
        }
        public static void QUESTION26()
        {
            try
            {
                string line;
                using (StreamReader sr = new StreamReader("log2.txt")) //wypisze zawartość pliku
                //using (StringReader sr = new StringReader("log.txt")) //wypisze nazwę pliku tylko to co przekazałam log.txt
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                throw;// new FileNotFoundException("blad:{e}", e.ToString());
                //throw new FileNotFoundException();
            }
        }
        public static void QUESTION27()
        {
            Kiosk a = new Kiosk();


        }

    }
}
