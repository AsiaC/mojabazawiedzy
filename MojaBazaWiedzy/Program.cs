using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MojaBazaWiedzy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            QUESTION1();
            QUESTION2();
            //QUESTION3(); - brak
            QUESTION4();
            //QUESTION5(); - brak
            QUESTION6();
            QUESTION7();
            QUESTION8();
            QUESTION9();
            QUESTION10();
            QUESTION11();
            QUESTION12();
            QUESTION13();
            QUESTION14();
            QUESTION15();
            QUESTION16();
            QUESTION17();
            QUESTION18();
            QUESTION19();
            QUESTION20();
            QUESTION21();
            //QUESTION22();- brak
            QUESTION23();
            QUESTION24();
            //QUESTION25();- brak
            QUESTION26();
            QUESTION27();
            //QUESTION28();- brak
            //QUESTION29();- brak
            QUESTION30();
            QUESTION31();
            QUESTION68();
            QUESTION78();
            QUESTION155();
            QUESTION158();*/
            //QUESTION35();
            //QUESTION62();
            //QUESTION163();
            QUESTION37();

            Console.ReadKey();
        }
        private static void QUESTION1()
        { Console.WriteLine("W pliku word"); }
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
        private static void QUESTION10()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION11()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION12()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION13()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION14()
        { Console.WriteLine("W pliku word"); }
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
        private static void QUESTION16()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION17()
        { Console.WriteLine("W pliku word"); }
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
        private static void QUESTION20()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION21()
        { Console.WriteLine("W pliku word"); }
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
        private static void QUESTION24()
        { Console.WriteLine("W pliku word"); }

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
        public static void QUESTION29()
        {
            //class Scorecard
        }
        private static void QUESTION30()
        { Console.WriteLine("W pliku word"); }
        private static void QUESTION31()
        {
            String regExPattern = "href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))";
            Regex evaluator = new Regex(regExPattern, RegexOptions.Compiled);
            Console.WriteLine("WPROWADZ DANE");
            string inputData = Console.ReadLine();
            bool odp = evaluator.IsMatch(inputData);
            Console.WriteLine(odp);
        }
        private static void QUESTION68()
        {
            Console.WriteLine("QUESTION68");
            //string url = "https://www.google.com";
            string url = "http://www.google.com";
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();
            MatchCollection myMatches = Regex.Matches(url, pattern);

            foreach (Match currentMatch in myMatches)
            {
                result.Add(currentMatch.Value);
                //result.Add(currentMatch.Groups.ToString());
            }
            //result = (List<string>)myMatches.GetEnumerator();
            foreach (string wynik in result)
            {
                Console.WriteLine("wynik: " + wynik);
            }

        }
        private static void QUESTION78()
        {
            Console.WriteLine("QUESTION78");
            string input = "789-456-123";
            //string pattern = @"[0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9]";
            //string pattern = @"[0-9]*\-[0-9]*\-[0-9]*";
            string pattern = @"[0-9]{3}\-[0-9]{3}\-[0-9]{3}";

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            var validPhoneNumbers = new List<String>();
            var validPhoneNumbers2 = new List<String>();
            var validPhoneNumbers3 = new List<String>();
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    validPhoneNumbers.Add(match.Value);
                }
            }
            foreach (var item in validPhoneNumbers)
            {
                Console.WriteLine("validPhoneNumbers " + item);
            }

            validPhoneNumbers2 = (from Match match in matches
                                  where match.Success
                                  select match.Value).ToList();
            foreach (var item in validPhoneNumbers2)
            {
                Console.WriteLine("validPhoneNumbers2 " + item);
            }

            validPhoneNumbers3 = (from Match match in matches
                                  where match.Success
                                  select match.Success.ToString()).ToList();
            foreach (var item in validPhoneNumbers3)
            {
                Console.WriteLine("validPhoneNumbers3 " + item); //to zwróci true
            }

            //Match m = Regex.Match(input, pattern);
            //Console.WriteLine(m.ToString()); //bez to string też może być
        }
        private static void QUESTION155()
        {
            Console.WriteLine("QUESTION155");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Wpisz cenę: ");
                string price = Console.ReadLine();
                //string wzorCeny = @"^(-)?\d+(\.\d\d)?";

                //Nie bo !Regex a gdy true to "Valid price"
                //if (!Regex.IsMatch(price, @"^(-)?\d+(\.\d\d)?"))
                //    Console.WriteLine("Valid price");
                //else
                //    Console.WriteLine("Invalid price");

                //Nie bo (-)? Czyli zero lub jedno a ja nie mogę mieć wcale
                //if (Regex.IsMatch(price, @"^(-)?\d+(\.\d\d)?"))
                //    Console.WriteLine("Valid price");
                //else
                //    Console.WriteLine("Invalid price");

                Regex reg = new Regex(@"^\d+(\.\d\d)?");
                if (reg.IsMatch(price))
                    Console.WriteLine("Valid price");
                else
                    Console.WriteLine("Invalid price");

                //Nie bo (-)? Czyli zero lub jedno a ja nie mogę mieć wcale
                //    Regex reg2 = new Regex(@"^(-)?\d+(\.\d\d)?");
                //if(reg2.IsMatch(price))
                //    Console.WriteLine("Valid price");
                //else
                //    Console.WriteLine("Invalid price");

                Console.WriteLine("");
            }
        }
        private static void QUESTION158()
        {
            QUESTION68();
        }
        private static void QUESTION35()
        {
            //Dyrektywy preprocesora
            Console.WriteLine("W pliku word i DyrektywyPreprocesora i Q62");
        }
        private static void QUESTION62()
        {
            //Dyrektywy preprocesora
            Console.WriteLine("W pliku word i DyrektywyPreprocesora");

            double a = 5, b = 2, c = 1.1;
            double interestAmount = a * b * c;
            LogLine("Interest Amount: ", interestAmount.ToString("c"));
            Console.WriteLine("InterestAmount={0}", interestAmount);
        }
        [Conditional("DEBUG")]
        public static void LogLine(string message, string detail)
        {
            Console.WriteLine("Log: {0}={1}", message, detail);
        }

        private static void QUESTION163()
        {
            //Dyrektywy preprocesora
            Console.WriteLine("W pliku word i DyrektywyPreprocesora i Q62");
        }
        private static void QUESTION37()
        {
            
            int loanAmount=0;
            int loanTerm=2;
            decimal loanRate=3;
            //loanAmount<=0
            Trace.Assert(loanAmount>0);
            decimal interestAmount = loanAmount * loanTerm * loanRate;

            Console.WriteLine(interestAmount);

        }
    }
}
