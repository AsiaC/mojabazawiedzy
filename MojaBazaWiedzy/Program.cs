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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Reflection;
using System.Net;

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
            //QUESTION37();
            //QUESTION117();
            //QUESTION89();
            //QUESTIONALL236();
            //QUESTIONALL229();
            //QUESTIONALL219();
            //QUESTIONALL218();
            //QUESTIONALL212();
            //QUESTIONALL211();
            //QUESTIONALL193();
            //QUESTIONALL177();
            //QUESTIONALL165();
            //QUESTIONALL72();
            QUESTIONALL79();
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
            //OK
            foreach (Match currentMatch in myMatches)
            {
                result.Add(currentMatch.Value);
                //result.Add(currentMatch.Groups.ToString());
            }


            //result=(List<string>)myMatches.SyncRoot; BŁAD KONWERSJI
            //result = (List<string>)myMatches.GetEnumerator(); BŁAD KONWERSJI

            //result = (from System.Text.RegularExpressions.Match m in myMatches select m.Value).ToList<string>(); OK

            //result = (from System.Text.RegularExpressions.Match m in myMatches where !m.Success select m.Value).ToList<string>(); NIE BO: !SUCCESS

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

        private static void QUESTION117()
        {
            //SignAndVerify();
            GetHash("a", "b");
        }
        public static byte[] GetHash(string filename, string algorithmType)
        {
            var hasher = HashAlgorithm.Create(algorithmType);
            var fileBytes = System.IO.File.ReadAllBytes(filename);
            //hasher.ComputeHash(fileBytes);
            //return hasher.Hash();
            //var outputBuffer = new byte[fileBytes.Length];
            //hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
            //return outputBuffer;     
            //hasher.ComputeHash(fileBytes);
            //return hasher.Hash;

            var outputBuffer = new byte[fileBytes.Length];
            hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
            hasher.TransformFinalBlock(fileBytes, fileBytes.Length - 1, fileBytes.Length);
            return outputBuffer;
        }

        public static void SignAndVerify()
        {
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "cn = WouterDeKort");
            // Uncomment this line to make the verification step fail
            // signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }
        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }
        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash,CryptoConfig.MapNameToOID("SHA1"),
                signature);
        }
        private static byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }
        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore",StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            //X509Certificate2 certificate = "CN=CERT_SIGN_TEST_CERT";
            //if (my.Certificates.Count > 0)
            
            var certificate = my.Certificates[0];
            
            return certificate;
        }
        private static void QUESTION89()
        {
            
        }
        public bool ValidateJson(string json, Dictionary<string, object> result)
        {
            //nie bo tu w tej linijce bład podkreśla
            //DataConractSerializer serializer = new DataContractSerializer();

            //nie bo w linijce serializer.Deserialize<Dictionary<string, object>>(json); podkreśla: Deserialize<Dictionary<string, object>>(json);
            //var serializer = new NetDataContractSerializer();

            //tu bład: NetDataContractSerializer
            //JavaScriptSerializer serializer = new NetDataContractSerializer();

            //OK
            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            //nie bo podkreśla: Deserialize<Dictionary<string, object>>(json); 
            //var serializer = new DataContractSerializer();

            //nie bo podkreśla: Deserialize<Dictionary<string, object>>(json); 
            //XmlObjectSerializer serializer = new XmlObjectSerializer();

            //OK
            var serializer = new JavaScriptSerializer();

            //nie bo podkreśla: Deserialize<Dictionary<string, object>>(json); 
            //var serializer = new XmlObjectSerializer();

            //nie bo podkreśla całe XmlSerrializer
            //XmlSerrializer serrializer = new XmlSerrializer();

            //nie bo podkreśla serializer
            //NetDataContractSerializer serialozer = new NetDataContractSerializer();

            try
            {
                result = serializer.Deserialize<Dictionary<string, object>>(json);
                return true;
            }
            catch {
                return false;
            }
        }
        private static void QUESTIONALL236()
        {
            ProcessFile("plik1", "zawartość pliku");
        }
        protected static void ProcessFile(string fileName, string value)
        {
            StreamWriter streamWriter = null;
            streamWriter = new StreamWriter(fileName);
            streamWriter.Write(value);
            streamWriter.Close();

        }
        private static void QUESTIONALL229()
        {
            Console.WriteLine("QUESTIONALL229");
            Class2 a1 = new Class2();
            a1.Method1();
        }
        public class Class1 : Class2 { }
        public interface INewInterface { void Method1(); }
        public class Class2 : INewInterface {
            internal void Method1()
            {

                throw new NotImplementedException();
            }

            void INewInterface.Method1()
            {
                throw new NotImplementedException();
            }

            //void INewInterface.Method1() { throw new NotImplementedException(); }
        }
        private static void QUESTIONALL219()
        {
            Console.WriteLine("QUESTIONALL219");
            DoWork();
        }
        static TraceSource ts = new TraceSource("Contoso",SourceLevels.ActivityTracing );
        public static void DoWork()
        {
            var orginalId = Trace.CorrelationManager.ActivityId;
            try {
                var guid = Guid.NewGuid();
                ts.TraceTransfer(1, "Changing activity", guid);
                Trace.CorrelationManager.ActivityId = guid;
                ts.TraceEvent(TraceEventType.Start, 0, "Start");

            }
            finally {
                ts.TraceTransfer(1,"Changing activity", orginalId);
                ts.TraceEvent(TraceEventType.Stop, 0, "Stop");
                Trace.CorrelationManager.ActivityId = orginalId;
            }
        }
        /*private static void QUESTIONALL218()
        {
            Console.WriteLine("QUESTIONALL218");
            DateTime dat= DateTime.Today;
            DisplayTemperture(dat, 25.25);
        }
        public static void DisplayTemperture(DateTime date, double temp)
        {
            string output;
            output = string.Format("Temperature at {0:t} on {0:mm/dd/yy}", date, temp){1:N2};
            string lblMessage = output;
            Console.WriteLine(lblMessage);
        }
        */
        /* public static void QUESTIONALL212()
         {
             List<Type> types = (AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(t => t.GetTypes())
                 .Where(t => t.IsClass && t.Assembly == this.GetType().Select)).ToList<Type>();
         }
         */
        public static void QUESTIONALL211()
        {
            MyClass a = new MyClass();
            a.doOperation("AddNum",2,3);
        }
        public class MyClass
        {
            public int AddNum(int numb1, int numb2)
            {
                Console.WriteLine("metoda AddNum");
                int result = numb1 + numb2;
                return result;
            }
            public int SubNumb(int numb1, int numb2)
            {
                Console.WriteLine("metoda SubNum");
                int result = numb1 - numb2;
                return result;
            }
            public string doOperation(string operationName, int numb1, int numb2)
            {
                object[] mParam = new object[] { numb1, numb2 };
                MyClass myClassObj = new MyClass();
                Type myTypeObj = myClassObj.GetType();
                MethodInfo myMethodInfo = myTypeObj.GetMethod(operationName);
                //Console.WriteLine(myMethodInfo.Invoke(myClassObj, mParam).ToString());
                return myMethodInfo.Invoke(myClassObj, mParam).ToString();
            }
        }
        public static void QUESTIONALL193()
        {
            Class1a a = new Class1a(1,"AS");
            Class1a b = new Class1a(1,"AS");
            Console.WriteLine(a.Equals(b));

            Class1a c = new Class1a(2, "AS"); //inne id
            Console.WriteLine(a.Equals(c));

            Class1a d = new Class1a(1, "ASA"); //inne name
            Console.WriteLine(a.Equals(d));

            Class1a e = new Class1a(3, "ASI");//oba inne
            Console.WriteLine(a.Equals(e));

            Console.WriteLine(a.Equals(null));

        }
        public static void QUESTIONALL192()
        {

        }
        public async void GetData(WebResponse response)
        {
            string urlText;
            var sr = new StreamReader(response.GetResponseStream());
            urlText = await sr.ReadToEndAsync();
        }
        public static void QUESTIONALL177()
        {
            Class1a a = new Class1a(1, "AS");
            Class1a b = new Class1a(1, "AS");
            Class1a c = new Class1a(2, "AS"); 
            Class1a d = new Class1a(1, "ASA"); 
            Class1a e = new Class1a(3, "ASI");
            List<Class1a> lista = new List<Class1a>();
            lista.Add(a);
            lista.Add(b);
            lista.Add(c);
            lista.Add(d);
            lista.Add(e);
            //string result = "";
            if (lista is List<Class1a>)
                Console.WriteLine("lista is List<Class1a>");
            if (lista is List<Class1a>[])
                Console.WriteLine("lista is List<Class1a>[]");

            if (lista.GetType() is List<Class1a>[])
                Console.WriteLine("lista.GetType() is List<Class1a>[]");

            if (lista.GetType() is List<Class1a>)
                Console.WriteLine("lista.GetType() is List<Class1a>");
        }
        public static void QUESTIONALL165()
        {
            List<Producta> products = new List<Producta>()
            {
                new Producta(){ Name="Strawberry", CategoryID=1},
                new Producta(){ Name="Banana", CategoryID=1},
            };
            List<Producta> B_Products = (List<Producta>)
            //Product[] B_Product = (Product[])
            //Array<Product>B_Products=(Array<Product>)
                (
                from product in products
                where product.Name.StartsWith("B")
                //select new { Name=product.Name}
                select product
                ).ToList();
            

        }
        public static void QUESTIONALL72()
        {
            ArrayList array1 = new ArrayList();
            int var1 = 10;
            int var2;
            array1.Add(var1);
            var2 = (int)array1[0];

        }
        public static void QUESTIONALL79()
        {

        }
    }
}
