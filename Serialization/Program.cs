using System;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Jani" ,new DateTime(1982,01,01), Gender.Male);
            
            person.Serialize(@"d:\teszt\ser.txt");
            person.Deserialization();
            Console.WriteLine(person.ToString()); 
            Console.ReadKey();


        }
    }
}
