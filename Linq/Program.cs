using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
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

    }
}
