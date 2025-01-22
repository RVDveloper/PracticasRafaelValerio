
public class RentalSystem
{
    private LinkedList<Person> users;
    private LinkedList<Employee> employees;
    private LinkedList<VideoGame> videoGames;

    public const string Juego = "🎮"; public const string Joystick = "🕹️";

    public RentalSystem()
    {
        users = new LinkedList<Person>();
        employees = new LinkedList<Employee>();
        videoGames = new LinkedList<VideoGame>();
    }

    public void AddUser(Person user)
    {
        users.AddLast(user);
        Console.WriteLine($"User {user.FirstName} {user.LastName} registered.");
    }

    public void RemoveUser(string firstName, string lastName)
    {
        Console.BackgroundColor = ConsoleColor.Red;

        var node = users.First;
        while (node != null)
        {
            if (node.Value.FirstName == firstName && node.Value.LastName == lastName)
            {
                users.Remove(node);
                Console.WriteLine($"User {firstName} {lastName} removed.");
                Console.ResetColor();
                return;
            }
            node = node.Next;
        }
        Console.WriteLine($"User {firstName} {lastName} not found not exist in the system.");

        Console.ResetColor();
    }

    public void AddEmployee(Employee employee)
    {
        employees.AddLast(employee);
        Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} registered.");
    }

    public void RemoveEmployee(string firstName, string lastName)
    {
        Console.BackgroundColor = ConsoleColor.Red;

        var node = employees.First;
        while (node != null)
        {
            if (node.Value.FirstName == firstName && node.Value.LastName == lastName)
            {
                employees.Remove(node);
                Console.WriteLine($"Employee {firstName} {lastName} removed.");

                Console.ResetColor();

                return;
            }
            node = node.Next;
        }
        Console.WriteLine($"Employee {firstName} {lastName} not found.");

        Console.ResetColor();


    }

    public void AddVideoGame(VideoGame videoGame)
    {
        videoGames.AddLast(videoGame);
        Console.WriteLine($"{Juego}Video game {videoGame.Title} registered.");
    }

    public void RemoveVideoGame(string title)
    {
        Console.BackgroundColor = ConsoleColor.Red;

        var node = videoGames.First;
        while (node != null)
        {
            if (node.Value.Title == title)
            {
                videoGames.Remove(node);
                Console.WriteLine($"Video game {title} removed.");
                Console.ResetColor();
                return;
            }
            node = node.Next;
        }
        Console.WriteLine($"Video game {title} not found not exist in the system.");

        Console.ResetColor();
    }

    public void RentGame(string title, string firstName, string lastName)
    {
        var gameNode = videoGames.First;
        while (gameNode != null)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            if (gameNode.Value.Title == title && !gameNode.Value.IsRented)
            {
                var userNode = users.First;
                while (userNode != null)
                {
                    if (userNode.Value.FirstName == firstName && userNode.Value.LastName == lastName)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine("Available employees to associate with this rental:");
                        var employeeList = new List<Employee>(employees);
                        for (int i = 0; i < employeeList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {employeeList[i]}");
                        }

                        Console.Write("Select an employee by entering the corresponding number: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedEmployeeIndex) &&
                            selectedEmployeeIndex > 0 &&
                            selectedEmployeeIndex <= employeeList.Count)
                        {
                            var selectedEmployee = employeeList[selectedEmployeeIndex - 1];
                            Console.WriteLine($"Employee {selectedEmployee.FirstName} {selectedEmployee.LastName} is associated with this rental.");

                            gameNode.Value.IsRented = true;
                            gameNode.Value.TimesRented++;
                            gameNode.Value.RentedByEmployee = selectedEmployee;
                            userNode.Value.RentedGames.AddLast(gameNode.Value);

                            Console.WriteLine($"{Juego}Game {title} rented to {firstName} {lastName}.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Rental canceled.");
                            Console.ResetColor();
                        }
                        return;
                    }
                    userNode = userNode.Next;
                }
                Console.WriteLine($"User {firstName} {lastName} not found not exist in the system.");
                Console.ResetColor();
                return;
            }
            gameNode = gameNode.Next;
            Console.ResetColor();
        }
        Console.WriteLine($"Game {title} is not available.");
        Console.ResetColor();
    }

    public void ReturnGame(string title, string firstName, string lastName)
    {
        var userNode = users.First;
        while (userNode != null)
        {
            if (userNode.Value.FirstName == firstName && userNode.Value.LastName == lastName)
            {
                var rentedGameNode = userNode.Value.RentedGames.First;
                while (rentedGameNode != null)
                {
                    if (rentedGameNode.Value.Title == title)
                    {
                        rentedGameNode.Value.IsRented = false;
                        rentedGameNode.Value.RentedByEmployee = null;
                        userNode.Value.RentedGames.Remove(rentedGameNode);
                        Console.WriteLine($"Game {title} returned by {firstName} {lastName}.");
                        return;
                    }
                    rentedGameNode = rentedGameNode.Next;
                }
                Console.WriteLine($"User {firstName} {lastName} does not have the game {title}.");
                return;
            }
            userNode = userNode.Next;
        }
        Console.WriteLine($"User {firstName} {lastName} not found not exist in the system.");
    }

    public void ListAvailableGames()
    {
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Available video games:");
        foreach (var game in videoGames)
        {
            if (!game.IsRented)
                Console.WriteLine(game);
        }
        Console.ResetColor();
    }


        public void ListRentedGames()
    {
        Console.WriteLine("Rented video games:");
        foreach (var game in videoGames)
        {
            if (game.IsRented)
            {
                string rentedBy = game.RentedByEmployee != null
                    ? $"Rented by employee: {game.RentedByEmployee.FirstName} {game.RentedByEmployee.LastName}"
                    : "No employee associated";
                Console.WriteLine($"{Juego}{game} | {rentedBy}");
            }
        }
    }
    

        public void ListGamesByUser(string firstName, string lastName)
    {
        foreach (var user in users)
        {
            if (user.FirstName == firstName && user.LastName == lastName)
            {
                Console.WriteLine($"Games rented by {user.FirstName} {user.LastName}:");
                foreach (var game in user.RentedGames)
                {
                    string rentedBy = game.RentedByEmployee != null
                        ? $"Rented by employee: {game.RentedByEmployee.FirstName} {game.RentedByEmployee.LastName}"
                        : "No employee associated";
                    Console.WriteLine($"{Juego}{game} | {rentedBy}");
                }
                return;
            }
        }
        Console.WriteLine($"User {firstName} {lastName} not found.");
    }

      public void ListUsersWithRentedGames()
    {
        Console.WriteLine("Users with rented games:");
        foreach (var user in users)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            if (user.RentedGames.Count > 0)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}:");
                foreach (var game in user.RentedGames)
                {
                    string rentedBy = game.RentedByEmployee != null
                        ? $"Rented by employee: {game.RentedByEmployee.FirstName} {game.RentedByEmployee.LastName}"
                        : "No employee associated";
                    Console.WriteLine($" {Juego} - {game} | {rentedBy}");
                }
            }
            Console.ResetColor();
        }
    }

        public void ListAllUsers()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;

        if (users.Count == 0)
        {
            Console.WriteLine("No users registered.");
            return;
        }

        Console.WriteLine("Registered users:");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.ResetColor();
    }
    public void ListEmployees()
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine("Registered employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }

        Console.ResetColor();
    }
}
