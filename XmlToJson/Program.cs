using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlToJson
{
    class Program
    {

//JsonConvert is from the namespace Newtonsoft.Json
//Project->Manage NuGet packages->Search for "newtonsoft json"->install

        static void Main(string[] args)
        {
            
            ConvertFromXmlToJson(WczytajPlik());

            Console.ReadKey();
        }


        public static string WczytajPlik()
        {
            string text = File.ReadAllText(@"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\MojaBazaWiedzy\XmlToJson\bin\Debug\xml1.xml");
            return text;
        }

        public static void ZapiszPlik(string textjson)
        {
            string lokalizationJson=@"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\MojaBazaWiedzy\XmlToJson\bin\Debug\json1.json";
            if (!File.Exists(lokalizationJson))
            {
                var myFile=File.Create(lokalizationJson);
                myFile.Close();
            }
            File.WriteAllText(lokalizationJson, textjson);

        }


        public static void ConvertFromXmlToJson(string text)
        {
//            string xml = @"<?xml version='1.0' standalone='no'?>
//<root>
//  <person id='1'>
//  <name>Alan</name>
//  <url>http://www.google.com</url>
//  </person>
//  <person id='2'>
//  <name>Louis</name>
//  <url>http://www.yahoo.com</url>
//  </person>
//</root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);

            string json = JsonConvert.SerializeXmlNode(doc);
            ZapiszPlik(json);
            Console.WriteLine(json);

        }
    }
}
