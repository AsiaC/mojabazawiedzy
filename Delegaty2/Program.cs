using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty2
{
    class Program
    {
        static FileStream fs;
        static StreamWriter sw;
        public delegate void PrintMessage(string s);//deklaracaj delegatu
        public static void WriteToConsole(string s)
        {
            Console.WriteLine("Wiadomosc: {0}", s);
        }
        public static void WriteToFile(string s)
        {
            // FileMode.Append - jeżeli uruchomicie program kilka razy za każdym razem do pliku tekstowego zostanie dodana kolejna linika tekstu
            fs = new FileStream("c:\\wiadomosc.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s); // Zapisujemy dane do pliku
            sw.Flush(); // Czyszczenie naszego bufora
            sw.Close(); // Zamykamy obydwa strumienie
            fs.Close();
        }

        // Metoda jako parametr przyjmuje delagat Oraz wywołuje dany delegat ze stosowną wiadomością
        public static void SendString(PrintMessage pm)
        {
            pm("Witaj Świecie");
        }
        static void Main(string[] args)
        {
            PrintMessage pm1 = new PrintMessage(WriteToConsole); //w delegacie ->metoda która wypisuje Wiadomosc: ->nie jest to jeszcze pisane na konsole
            PrintMessage pm2 = new PrintMessage(WriteToFile);
            SendString(pm1);//delegat jest przekazywany do funkcji. W funkcji jest użycie/wywołanie delegata
            SendString(pm2);
            Console.ReadKey();
            // Wynik działania programu
            // Wiadomosc: Witaj Swiecie
            // Oraz proszę spojrzeć na dysk C, został utworzony nowy plik
            // Wewnątrz tekst: Witaj Świecie
        }
    }

}
