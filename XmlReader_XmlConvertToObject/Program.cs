using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlReader_XmlConvertToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection<Rate> rateCollection = new Collection<Rate>();
            string rateXML = System.IO.File.ReadAllText(@"C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\MojaBazaWiedzy\XmlReader_XmlConvertToObject\myXMLFile1.xml");
            //string _filename = "C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\MojaBazaWiedzy\XmlReader_XmlConvertToObject\myXMLFile1.xml";
            using (XmlReader reader = XmlReader.Create(new StringReader(rateXML)))
            {
                while(reader.ReadToFollowing("rate"))//
                {
                    Rate rate = new Rate();
                    reader.MoveToFirstAttribute();//
                    rate.Category = reader.Value;
                    reader.MoveToNextAttribute();//
                    DateTime rateDate;
                    if (DateTime.TryParse(reader.Value, out rateDate))
                    {
                        rate.Date = rateDate;
                    }
                   // reader.MoveToElement();
                    reader.ReadToFollowing("value"); //si
                    //reader.MoveToContent();
                    decimal value;
                    if (decimal.TryParse(reader.ReadElementContentAsString(), out value))
                    {
                        rate.Value = value;
                    }
                    

                    /*
                    reader.MoveToContent();
                    if (reader.Name == "rate")
                    {
                        decimal.TryParse(reader.ReadElementContentAsString(), out value);
                        rate.Value = value;
                    }
                    */


                    rateCollection.Add(rate);
                }
            }

            foreach (var item in rateCollection)
            {
                Console.WriteLine("Category={0}, Date={1}, Value={2}", item.Category, item.Date, item.Value);
            }
            Console.ReadKey();
        }
    }
    public class Rate
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
