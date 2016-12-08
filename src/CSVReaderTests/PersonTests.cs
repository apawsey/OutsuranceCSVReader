using CSVReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVReaderTests
{
    [TestClass]
    public class PersonTests
    {
        

        [TestMethod]
        public void ConstructorTest() 
        {
            Person person = new Person("A","B","C","D");
            Assert.IsTrue(person.FirstName== "A");
            Assert.IsTrue(person.LastName == "B");
            Assert.IsTrue(person.Address == "C");
            Assert.IsTrue(person.PhoneNumber == "D");
        }
    }
}
