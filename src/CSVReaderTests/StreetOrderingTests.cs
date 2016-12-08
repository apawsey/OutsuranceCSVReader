using System.Collections.Generic;
using System.Linq;
using CSVReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVReaderTests
{
    [TestClass]
    public class StreetOrderingTests
    {
        [TestMethod]
        public void BasicOrderingTest()
        {
            List<Person> records = new List<Person>
            {
                new Person("A","A","1 Alpha Street","A"),
                new Person("C","C","1 Charlie Street","C"),
                new Person("E","E","3 Echo Street","E"),
                new Person("D","D","452222 Delta Street","D"),
                new Person("B","B","99999 Bravo Street","B"),
            };
            List<Person> orderedRecords = records.OrderedByStreetName().ToList();
            Assert.IsTrue(orderedRecords[0].FirstName == "A");
            Assert.IsTrue(orderedRecords[1].FirstName == "B");
            Assert.IsTrue(orderedRecords[2].FirstName == "C");
            Assert.IsTrue(orderedRecords[3].FirstName == "D");
            Assert.IsTrue(orderedRecords[4].FirstName == "E");
        }
    }
}