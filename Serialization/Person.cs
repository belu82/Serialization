using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
  

    [Serializable()]
    public class Person : ISerializable, IDeserializationCallback
    {
        public int age { get; set; }
        private string Name { get; set; }
        private DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public Person()
        {

        }
        public Person(string name, DateTime birthDate, Gender gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Gender = gender;
            CalculateAge();
        }

        private void CalculateAge()
        {
            age = (DateTime.Today).Year - BirthDate.Year;
        }
        /*
        public int Age {
            get { DateTime today = DateTime.Now;
                age = today.Year - BirthDate.Year;
                if(today < BirthDate.AddYears(age))
                {
                    age--;
                }
                return age;
            }
        }
        */

        public override string ToString()
        {
            return string.Format("Name: {0}; Birthday: {1}; Age: {2}; Gender: {3}", Name, BirthDate, age, Gender); 
        }

        public void Serialize(string output)
        {
            
            Person person = new Person(Name, BirthDate, Gender);
            Stream stream = new FileStream(output, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(stream, person);
            }
            catch(SerializationException e)
            {
                Console.WriteLine("Failed" + e.Message);                                    
            }
            finally
            {
                stream.Close();
            }
           

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Birthday", BirthDate);
            info.AddValue("Gender", Gender);
        }


        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            BirthDate = (DateTime)info.GetValue("Birthday", typeof(DateTime));
            Gender = (Gender)info.GetValue("Gender", (typeof(Gender)));
        }

        public void Deserialization()
        {
            Stream stream = File.Open(@"d:\teszt\ser.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Deserialize(stream);
            Console.WriteLine(ToString());
            stream.Close();

        }

        public void OnDeserialization(object sender)
        {
            age = (DateTime.Today).Year - BirthDate.Year;
        }
    }
    public enum Gender
    {
        Male, 
        Female
    }

    
    
   
}
