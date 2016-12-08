namespace CSVReader
{
    public class Person
    {
        //Constructor for CSV Parsing Library
        private Person()
        {
        }

        public Person(string firstName, string lastName, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}