public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public LinkedList<VideoGame> RentedGames { get; set; }

        public Person(string firstName, string lastName, int age, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
            RentedGames = new LinkedList<VideoGame>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Age} years old | Address: {Address} | Phone: {PhoneNumber}";
        }
    }