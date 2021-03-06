﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //Regex
using System.Threading.Tasks;

namespace RegexNauka
{
    class Program
    {
        static void Main(string[] args)
        {/*
            //spr czy uż wprowadził poprawny adres email
            Regex regEmail = new Regex(@"^[a-z][a-z0-9_]*@[a-z0-9]*\.[a-z]{2,3}$");
            Console.WriteLine("Podaj email");
            string napis = Console.ReadLine();
            Console.WriteLine("Podany adres: {0} to {1}poprawny adres email", napis, regEmail.IsMatch(napis)?"":"nie");

            //w dłuższym pierwszym tekscie szuka dopasowania do drugiego
            Match m = Regex.Match("Dowolny ulubiony kolor", @"kolor?");
            Console.WriteLine(m.ToString()); //WYPISZE: kolor

            //Za pomocą metody NextMatch() można zwrócić kolejne dopasowania
            Match m1 = Regex.Match("Tylko jeden kolor? Mam na myśli dwa kolory!",@"kolory?");
            Match m2 = m1.NextMatch();
            Console.WriteLine(m1); // kolor
            Console.WriteLine(m2); // kolory

            //Metoda Matches() zwraca wszystkie dopasowania w postaci tablicy.
            foreach (Match ms in Regex.Matches("Tylko jeden kolor? Mam na myśli dwa kolory !", @"kolory?"))
                Console.WriteLine("Matches: "+ms); //zwróci kolor, kolory


            //często używanym operatorem w wyr regularnych jest alternatywa(|). Poniższe polecenie powoduje dopasowanie imion Karol i Karolina:
            //Nawiasy wokół alternatywy pozwalają na oddzielenie alternatyw od pozostałej części wyrażenia
            Console.WriteLine(Regex.IsMatch("Ka", "Kar(ol|olina)?")); // prawda
            //? odnosi sie do wszystkich znaków w nawiasie, Gdyby nie było nawiasu to odnosi sie tylko do ostatniego znaku przed

            //?
            Console.WriteLine("Sprawdzenie jak działa ? ");
            Regex wyrazenie = new Regex(@"pomidory?");
            string testAsi = "pom";
            bool odp=wyrazenie.IsMatch(testAsi);
            Console.WriteLine("wynik mojego testu={0}",odp); //false
            string testAsi2 = "pomidor";
            bool odp2 = wyrazenie.IsMatch(testAsi2);
            Console.WriteLine("wynik mojego testu={0}", odp2); //true
            string testAsi3 = "pomidory";
            bool odp3 = wyrazenie.IsMatch(testAsi3);
            Console.WriteLine("wynik mojego testu={0}", odp3); //true

            //Kompilowane wyrażenia regularne
            Console.WriteLine("spr Kompilowane wyrażenia regularne");
            Regex wyr = new Regex(@"pomidory?",RegexOptions.Compiled);
            Console.WriteLine(wyr.Match("pomidor")); //Match ma 2 argumenty pierwszy to ciąg znaków w którym szukamy, drugi to czego szukamy
            Console.WriteLine(wyr.Match("pomidory"));

            //walidacja url i zapis do listy
                Console.WriteLine("QUESTION68");
                //string url = "https://www.google.com";
                string url = "http://www.google.com";
                const string pattern = @"http://(www\.)?([^\.]+)\.com";
                List<string> result = new List<string>();
                MatchCollection myMatches = Regex.Matches(url, pattern);

                foreach (Match currentMatch in myMatches)
                {
                    result.Add(currentMatch.Value);
                }

                foreach (string wynik in result)
                {
                    Console.WriteLine("wynik: " + wynik);
                }

            //walidacja nr tel
            Console.WriteLine("QUESTION78");
            string input = "789-456-123";
                //string pattern = @"[0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9]";
                //string pattern = @"[0-9]*\-[0-9]*\-[0-9]*";
                string wzorTelefonu = @"[0-9]{3}\-[0-9]{3}\-[0-9]{3}"; //{3}-trzy wystąpienia
                Match mat = Regex.Match(input, wzorTelefonu);
                Console.WriteLine(mat.ToString());
*/
            //walidacja ceny, żeby była dodatnia oraz z 2 miejscami po przecinku
            Console.WriteLine("QUESTION155");
            string cena0 = "6.55";
            string cena1 = "-6.55";
            double cena2 = 6;
            string cena22 = cena2.ToString();
            double cena3 = -6;
            string cena33 = (-6).ToString();
            double cena4 = -6.55;
            double cena5 = 6.556;
            //string wzorCeny = @"^(-)?\d+(\.\d\d)?"; //cały nawias odwołuje się do ?
            string wzorCeny = @"^\d+(\.\d\d)?";
            Match ma0 = Regex.Match(cena0,wzorCeny);
            Console.WriteLine(ma0.ToString());

            Match ma1 = Regex.Match(cena1, wzorCeny);
            Console.WriteLine(ma1.ToString());

            Match ma2 = Regex.Match(cena22, wzorCeny);
            Console.WriteLine(ma2.ToString());

            Match ma3 = Regex.Match(cena33, wzorCeny);
            Console.WriteLine(ma3.ToString());

            Match ma4 = Regex.Match(cena4.ToString(), wzorCeny);
            Console.WriteLine(ma4.ToString());

            Match ma5 = Regex.Match(cena5.ToString(), wzorCeny);
            Console.WriteLine(ma5.ToString());

            Regex wy5 = new Regex(wzorCeny, RegexOptions.Compiled);
            Console.WriteLine(wy5.Match(cena5.ToString()));


            Console.ReadKey();
            /*
. Dowolny znak oprócz znaku nowego wiersza
^ Początek wiersza
$ Koniec wiersza
* Zero lub więcej wystąpień danego zestawu znaków (wyrażeń)
? Zero lub jedno wystąpienie danego zestawu znaków
+ Jedno lub więcej wystąpień danego zestawu znaków
[a-c] Dowolny znak ze zbioru znajdującego się wewnątrz nawiasów kwadratowych
[^ ab] Wszystkie znaki oprócz tych z zestawu znajdujących się wewnątrz nawiasów kwadratowych
| Lub
{x} Dokładnie X wystąpień danego zestawu znaków (wyrażeń)
{x,} Co najmniej X wystąpień danego zestawu znaków (wyrażeń)
{x,y} Co najmniej X wystąpień i maksymalnie Y wystąpień danego zestawu znaków
\d Cyfra
\znak Oznacza ten znak
a|b Alternatywa — a lub b
\b Granica słowa
\n Nowa linia
             */
        }
    }
}
