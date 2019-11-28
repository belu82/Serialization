using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void PersonTest()
        {
            Person person = new Person("Lali", DateTime.Now, Gender.Female);
            person.ToString();
        }

    
    }
}