using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JsonSerializeDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.web.script.serialization.javascriptserializer?view=netframework-4.7.2
            var RegisteredUsers = new List<Person>();
            RegisteredUsers.Add(new Person() { Id = 1, Name = "Bryon Hetrick", Registered = true });
            RegisteredUsers.Add(new Person() { Id = 2, Name = "Nicole Wilcox", Registered = true });
            RegisteredUsers.Add(new Person() { Id = 3, Name = "Adrian Martinson", Registered = false });
            RegisteredUsers.Add(new Person() { Id = 4, Name = "Nora Osborn", Registered = false });

            var serializer = new JavaScriptSerializer();
            //ZAMIANA NA JSON
            string serializedResult = serializer.Serialize(RegisteredUsers);
            // Produces string value of:
            // [
            //     {"PersonID":1,"Name":"Bryon Hetrick","Registered":true},
            //     {"PersonID":2,"Name":"Nicole Wilcox","Registered":true},
            //     {"PersonID":3,"Name":"Adrian Martinson","Registered":false},
            //     {"PersonID":4,"Name":"Nora Osborn","Registered":false}
            // ]

            //ZAMIANA Z JSON NA LISTE
            List<Person> deserializedResult = serializer.Deserialize<List<Person>>(serializedResult);
            // Produces List with 4 Person objects

            Console.ReadKey();
        }
    }
}
