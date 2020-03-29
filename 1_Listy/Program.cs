using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Listy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region teoria listy
            /*wszystkie metody:
             * https://docs.microsoft.com/pl-pl/dotnet/api/system.collections.generic.list-1?view=netframework-4.8#methods
             * 
            // Add+Insert
            public void Add(T item); //Adds an element at the end of a List<T>.
            public void AddRange(IEnumerable<T> collection); //Adds elements of the specified collection at the end of a List<T>.
            public void Insert(int index, T item); //Wstawia element do List<T> o określonym indeksie.
            public void InsertRange(int index, IEnumerable<T> collection); //Wstawia elementy kolekcji do elementu List<T> pod określonym indeksem.

            // Remove
            public bool Remove(T item);//Usuwa pierwsze wystąpienie określonego obiektu z List<T>.
            public void RemoveAt(int index);//Usuwa element w określonym indeksie obiektu List<T>.
            public void RemoveRange(int index, int count); // Usuwa zakres elementów z List<T>.
            public int RemoveAll(Predicate<T> match); //Usuwa wszystkie elementy odpowiadające warunkom zdefiniowanym przez określony predykat.

            Equals(Object)	//Określa, czy dany obiekt jest taki sam, jak bieżący obiekt.(Odziedziczone po Object)
            Exists(Predicate<T>)	//Określa, czy List<T> zawiera elementy, które pasują do warunków zdefiniowanych przez określony predykat.
            Find(Predicate<T>)	// Wyszukuje element, który odpowiada warunkom zdefiniowanym przez określony predykat, i zwraca pierwsze wystąpienie w całym List<T>.
            FindAll(Predicate<T>) //pobiera wszystkie elementy, które pasują do warunków zdefiniowanych przez określony predykat.
            */
            #endregion


            List<string> words = new List<string>(); // nowa lista typu string
            List<Student> myStudents = new List<Student>() {
                new Student (){Name="Anna", Surname = "Kowalska", AlbumNumber=1 },
                new Student (){Name="Tom", Surname = "Nowak", AlbumNumber=2 },
                new Student (){Name="Olga", Surname = "Jelen", AlbumNumber=3 }, };
            List<Student> myStudents2 = new List<Student>() {
                new Student ("Adam","Lis", 4),
                new Student ("Piotr", "Krasko", 5) };
            List<Student> myStudents3 = new List<Student>() { };
            myStudents3.AddRange(myStudents);
            myStudents3.AddRange(myStudents2);
            int i = 1;
            foreach (var student in myStudents3)
            {
                Console.WriteLine("{0} {1} {2} {3}",i, student.Name, student.Surname, student.AlbumNumber);
                i++;
            }

            Console.ReadKey();

            words.Add("melon");
            words.Add("awokado");
            words.AddRange(new[] { "banan", "pomarańcza" });

            words.Insert(0, "liczi"); // wstawianie na początku
            words.InsertRange(0, new[] { "pomelo", "nashi" }); // wstawianie na początku

            words.Remove("melon");
            words.RemoveAt(3); // usunięcie czwartego elementu
            words.RemoveRange(0, 2); // usunięcie dwóch pierwszych elementów
            words.RemoveAll(s => s.StartsWith("n")); // usunięcie wszystkich łańcuchów zaczynających się literą 'n'

            Console.WriteLine(words[0]); // pierwsze słowo
            Console.WriteLine(words[words.Count - 1]); // ostatnie słowo
            foreach (string s in words) Console.WriteLine(s); // wszystkie słowa
            List<string> subset = words.GetRange(1, 2); // drugie i trzecie słowo

            List<string> upperCastWords = words.ConvertAll(s => s.ToUpper());
            List<int> lengths = words.ConvertAll(s => s.Length);




            //lambda =>
            //https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
            //(input-parameters) => { <sequence-of-statements> }

            //linq
            //https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/concepts/linq/

            var cust = new Student { Name = "Mike", Phone = "555-1212" };

            var newLargeOrderCustomers = from o in IncomingOrders
                                         where o.OrderSize > 5
                                         select new Customer { Name = o.Name, Phone = o.Phone };

            var newLargeOrderCustomers = IncomingOrders.Where(x => x.OrderSize > 5).Select(y => new Customer { Name = y.Name, Phone = y.Phone });



        }
    }
}
