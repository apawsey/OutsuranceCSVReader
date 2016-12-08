using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVReader
{
    public static class PersonCollectionExtensions
    {
        public static Dictionary<string, int> GetNameFrequencies(this IEnumerable<Person> persons)
        {
            //Avoid multiple enumeration
            persons = persons as IList<Person> ?? persons.ToList();
            //Get unique first names with count.
            Dictionary<string, int> names = persons.GroupBy(x => x.FirstName).ToDictionary(x => x.Key, x => x.Count());
            //Get unique last names with count.
            Dictionary<string, int> lastNames = persons.GroupBy(x => x.LastName).ToDictionary(x => x.Key, x => x.Count());

            //Merge last name and first name counts
            foreach (KeyValuePair<string, int> keyValuePair in lastNames)
            {
                if (names.ContainsKey(keyValuePair.Key))
                    //Name already exists, so add the counts.
                    names[keyValuePair.Key] = names[keyValuePair.Key] + keyValuePair.Value;
                else
                    //Name doesn't exist so add to the list
                    names.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return names;
        }

        public static IEnumerable<Person> OrderedByStreetName(this IEnumerable<Person> persons)
        {
            return persons.OrderBy(x => x.Address.Substring(x.Address.IndexOf(" ", StringComparison.Ordinal) + 1));
        }
    }
}