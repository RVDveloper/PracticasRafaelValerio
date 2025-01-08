internal class Program
{
    private static void Main(string[] args)
    {

        RentalSystem system = new RentalSystem();
        bool exit = false;

        var employee1 = new Employee("Albert", "Guardiola", 40, "carrer gran gracia Barcelona", "642-56782", "Manager", 5000);
        system.AddEmployee(employee1);
        system.AddVideoGame(new VideoGame("The Witcher 3", 2015, "RPG", "CD Projekt Red"));
        system.AddVideoGame(new VideoGame("Minecraft", 2011, "Sandbox", "Mojang"));
        system.AddVideoGame(new VideoGame("The Elder Scrolls V: Skyrim", 2011, "Open World", "Bethesda Softworks"));
        system.AddVideoGame(new VideoGame("Red Dead Redemption 2", 2018, "Open World", "Rockstar Games"));
        system.AddVideoGame(new VideoGame("Fifa 23", 2023, "Sports", "EA Sports"));
        system.AddVideoGame(new VideoGame("Borderlands 3", 2012, "Open World", "Bethesda Softworks"));
        system.AddVideoGame(new VideoGame("Cyberpunk 2077", 2020, "Open World", "CD Projekt Red"));

        
        var user1 = new Person("Rafael", "Valerio", 28, "Carrer major sarria Barcelona", "623-638472");
        system.AddUser(user1);
        var user2 = new Person("Cristian", "Gutierrez", 20, "Carrer Julia Barcelona", "623-634978");
        system.AddUser(user2);

        




        while (!exit)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("=== Rental System Menu ===");
            Console.WriteLine("1) Add User");
            Console.WriteLine("2) Remove User");
            Console.WriteLine("3) Add Employee");
            Console.WriteLine("4) Remove Employee");
            Console.WriteLine("5) Add Video Game");
            Console.WriteLine("6) Remove Video Game");
            Console.WriteLine("7) Rent Video Game");
            Console.WriteLine("8) Return Video Game");
            Console.WriteLine("9) List Available Games");
            Console.WriteLine("10) List Rented Games");
            Console.WriteLine("11) List Games by User");
            Console.WriteLine("12) List Users with Rented Games");
            Console.WriteLine("13) List All Users");
            Console.WriteLine("14) List Employees");
            Console.WriteLine("15) Exit");
            Console.Write("Select an option: ");

            Console.ResetColor();

            
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                    Console.Write("Enter first name: ");
                    string userFirstName = Console.ReadLine()!;
                    Console.Write("Enter last name: ");
                    string userLastName = Console.ReadLine()!;
                    Console.Write("Enter age: ");
                    int userAge = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter address: ");
                    string userAddress = Console.ReadLine()!;
                    Console.Write("Enter phone number: ");
                    string userPhone = Console.ReadLine()!;
                    system.AddUser(new Person(userFirstName, userLastName, userAge, userAddress, userPhone));
                    break;

                case "2":
                    Console.Write("Enter first name: ");
                    string removeUserFirstName = Console.ReadLine()!;
                    Console.Write("Enter last name: ");
                    string removeUserLastName = Console.ReadLine()!;
                    system.RemoveUser(removeUserFirstName, removeUserLastName);
                    break;

                case "3":
                    Console.Write("Enter first name: ");
                    string employeeFirstName = Console.ReadLine()!;
                    Console.Write("Enter last name: ");
                    string employeeLastName = Console.ReadLine()!;
                    Console.Write("Enter age: ");
                    int employeeAge = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter address: ");
                    string employeeAddress = Console.ReadLine()!;
                    Console.Write("Enter phone number: ");
                    string employeePhone = Console.ReadLine()!;
                    Console.Write("Enter category: ");
                    string employeeCategory = Console.ReadLine()!;
                    Console.Write("Enter salary: ");
                    decimal employeeSalary = decimal.Parse(Console.ReadLine()!);
                    system.AddEmployee(new Employee(employeeFirstName, employeeLastName, employeeAge, employeeAddress, employeePhone, employeeCategory, employeeSalary));
                    break;

                case "4":
                    Console.Write("Enter first name: ");
                    string removeEmployeeFirstName = Console.ReadLine()!;
                    Console.Write("Enter last name: ");
                    string removeEmployeeLastName = Console.ReadLine()!;
                    system.RemoveEmployee(removeEmployeeFirstName, removeEmployeeLastName);
                    break;

                case "5":
                    Console.Write("Enter game title: ");
                    string gameTitle = Console.ReadLine()!;
                    Console.Write("Enter release year: ");
                    int releaseYear = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter genre: ");
                    string genre = Console.ReadLine()!;
                    Console.Write("Enter developer: ");
                    string developer = Console.ReadLine()!;
                    system.AddVideoGame(new VideoGame(gameTitle, releaseYear, genre, developer));
                    break;

                case "6":
                    Console.Write("Enter game title: ");
                    string removeGameTitle = Console.ReadLine()!;
                    system.RemoveVideoGame(removeGameTitle);
                    break;

                case "7":
                    Console.Write("Enter game title: ");
                    string rentGameTitle = Console.ReadLine()!;
                    Console.Write("Enter user first name: ");
                    string rentUserFirstName = Console.ReadLine()!;
                    Console.Write("Enter user last name: ");
                    string rentUserLastName = Console.ReadLine()!;
                    system.RentGame(rentGameTitle, rentUserFirstName, rentUserLastName);
                    break;

                case "8":
                    Console.Write("Enter game title: ");
                    string returnGameTitle = Console.ReadLine()!;
                    Console.Write("Enter user first name: ");
                    string returnUserFirstName = Console.ReadLine()!;
                    Console.Write("Enter user last name: ");
                    string returnUserLastName = Console.ReadLine()!;
                    system.ReturnGame(returnGameTitle, returnUserFirstName, returnUserLastName);
                    break;

                case "9":
                    system.ListAvailableGames();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "10":
                    system.ListRentedGames();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "11":
                    Console.Write("Enter user first name: ");
                    string listUserFirstName = Console.ReadLine()!;
                    Console.Write("Enter user last name: ");
                    string listUserLastName = Console.ReadLine()!;
                    system.ListGamesByUser(listUserFirstName, listUserLastName);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "12":
                    system.ListUsersWithRentedGames();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                    
                case "13":
                    system.ListAllUsers();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "14":
                    
                    system.ListEmployees();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;


                case "15":
                    Console.WriteLine("Exiting...");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }


    
    }
}