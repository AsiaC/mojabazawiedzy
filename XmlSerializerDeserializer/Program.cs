using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlSerializerDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {//https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer?view=netframework-4.7.2

            try
            {
                WriteObject("DataContractSerializerExample.xml"); //serializacja, tworze xml, stworzyło sie C:\Users\jczaplicka001\Documents\ASIA_IT\Visual Studio Projekty moje\Nauka7\XmlSerializerDeserializer\bin\Debug
                ReadObject("DataContractSerializerExample.xml"); //deserializacja  z xml obiekty
                WriteObjectList("DataContractSerializerExample2.xml");
            }
            catch (SerializationException serExc)
            {
                Console.WriteLine("Serialization Failed");
                Console.WriteLine(serExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("The serialization operation failed: {0} StackTrace: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }
        public static void WriteObject(string fileName)
        {
            Console.WriteLine("Creating a Person object and serializing it.");
            Person p1 = new Person("Zighetti", "Joanna", 201);
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(Person));
            ser.WriteObject(writer, p1);
            writer.Close();
        }
        
        public static void ReadObject(string fileName)
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Person));

            // Deserialize the data and read it from the instance.
            Person deserializedPerson = (Person)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            Console.WriteLine(String.Format("{0} {1} {2}", deserializedPerson.FirstName, deserializedPerson.LastName, deserializedPerson.ID));
        }
        
        
        // You must apply a DataContractAttribute or SerializableAttribute to a class to have it serialized by the DataContractSerializer.
        [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
        class Person : IExtensibleDataObject
        {
            [DataMember]
            public string FirstName;
            [DataMember(Order=2)]
            public string LastName;
            [DataMember(Order=1)]
            public int ID;

            public Person(string newfName, string newLName, int newID)
            {
                FirstName = newfName;
                LastName = newLName;
                ID = newID;
            }

            private ExtensionDataObject extensionData_Value;

            public ExtensionDataObject ExtensionData
            {
                get
                {
                    return extensionData_Value;
                }
                set
                {
                    extensionData_Value = value;
                }
            }
        }

        [DataContract(Name = "People", Namespace = "http://www.contoso.com")]
        class People
        {
            [DataMember]
            public List<Person> myList = new List<Person>();
            internal void addPerson(Person p1)
            {
                myList.Add(p1);
            }
        }
        public static void WriteObjectList(string fileName)
        {
            Console.WriteLine("Creating a People object and serializing it.");
            Person p1 = new Person("Zighetti", "Joanna", 201);
            Person p2 = new Person("Czapl", "Anna", 10);
            List<Person> a = new List<Person>();
            a.Add(p1);
            a.Add(p2);
            People b = new People();
            b.addPerson(p1);
            b.addPerson(p2);
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(People));
            ser.WriteObject(writer, b);
            writer.Close();
        }

    }
}
