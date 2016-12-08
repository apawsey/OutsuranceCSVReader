using System.Collections.Generic;
using CSVReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVReaderTests
{
    [TestClass]
    public class NameFrequenciesTests
    {
        [TestMethod]
        public void TestBasicNameCounts()
        {
            //Test basic counting of first and last names individually
            List<Person> records = new List<Person>
            {
                new Person("A","B","C","D"),
                new Person("A","B","C","D"),
                new Person("C","D","E","F"),
                new Person("E","F","G","H"),
            };
            Dictionary<string, int> nameFrequencies = records.GetNameFrequencies();
            Assert.IsTrue(nameFrequencies["A"] == 2);
            Assert.IsTrue(nameFrequencies["B"] == 2);
            Assert.IsTrue(nameFrequencies["C"] == 1);
            Assert.IsTrue(nameFrequencies["D"] == 1);
            Assert.IsTrue(nameFrequencies["E"] == 1);
            Assert.IsTrue(nameFrequencies["F"] == 1);
        }

        [TestMethod]
        public void TestMergedNameCounts()
        {
            //Test first and last names where they will be merged
            List<Person> records = new List<Person>
            {
                new Person("A","B","C","D"),
                new Person("A","B","C","D"),
                new Person("B","A","C","D"),
                new Person("C","D","E","F"),
                new Person("E","F","G","H"),
            };
            Dictionary<string, int> nameFrequencies = records.GetNameFrequencies();
            Assert.IsTrue(nameFrequencies["A"] == 3);
            Assert.IsTrue(nameFrequencies["B"] == 3);
            Assert.IsTrue(nameFrequencies["C"] == 1);
            Assert.IsTrue(nameFrequencies["D"] == 1);
            Assert.IsTrue(nameFrequencies["E"] == 1);
            Assert.IsTrue(nameFrequencies["F"] == 1);
        }
    }
}