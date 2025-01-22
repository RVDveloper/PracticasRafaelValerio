public class Employee : Person
    {
        public string Category { get; set; }
        public decimal Salary { get; set; }

        public const string Juego = "🎮"; public const string Joystick = "🕹️";

        public Employee(string firstName, string lastName, int age, string address, string phoneNumber, string category, decimal salary)
            : base(firstName, lastName, age, address, phoneNumber)
        {
            Category = category;
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Category: {Category} | Salary: {Salary:C}";
        }
    }