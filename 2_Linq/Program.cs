using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //lambda =>
            //https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
            //(input-parameters) => { <sequence-of-statements> }

            //linq
            //https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/concepts/linq/

            //var cust = new Student { Name = "Mike", Phone = "555-1212" };

            //var newLargeOrderCustomers = from o in IncomingOrders
            //                             where o.OrderSize > 5
            //                             select new Student { Name = o.Name, Phone = o.Phone };

            //var newLargeOrderCustomers = IncomingOrders.Where(x => x.OrderSize > 5).Select(y => new Student { Name = y.Name, Phone = y.Phone });

            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

            //FORMATOWANIE KODU VS
            // http://paweltymura.pl/2016/04/14/tip-porzadkowanie-kodu-visual-studio/
            
            //Query Expression
            IEnumerable<Student> studentQuery =
            from student in students
            where student.Scores[0] > 90
            select student;
            //METODY W qUERY eXPRESSION
            //https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/concepts/linq/query-expression-syntax-for-standard-query-operators
            //Select
            //SelectMany
            //Where


        }
    }
}
