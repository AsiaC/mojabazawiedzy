using System;
using System.Collections.Generic;
using System.IO; //StreamReader
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReaderStringReader
{
    class Program
    {
        /*  //StreamReader
        static void Main(string[] args)
        {
            //gdy chceszs czytać z pliku to StreamReader
            
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
           // https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netframework-4.7.2
        }
         */

        //StringReader
        static void Main(string[] args)
         {
             ReadCharacters();
            Console.ReadKey();
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.stringreader?view=netframework-4.7.2
        }

        static async void ReadCharacters()
         {
             StringBuilder stringToRead = new StringBuilder();
             stringToRead.AppendLine("Characters in 1st line to read");
             stringToRead.AppendLine("and 2nd line");
             stringToRead.AppendLine("and the end");

             using (StringReader reader = new StringReader(stringToRead.ToString()))
             {
                 string readText = await reader.ReadToEndAsync();
                 Console.WriteLine(readText);
             }
         }
     
  
    }
}
