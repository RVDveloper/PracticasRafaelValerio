internal class Program
{

    public const string Robot_Face = "🤖";public const string Warning = "⚠️";
    private static void Main(string[] args)
    {
        List<BaseRobot> robotsList = new List<BaseRobot>();
        InitializeRobots(robotsList);

        while (true)
        {
            int userOption = ShowMainMenu();

            if (userOption == 1)
            {
                string robotType = ShowCategoryMenu();
                AddRobot(robotsList, robotType);
            }
            else if (userOption == 2)
            {
                string robotType = ShowCategoryMenu();
                ShowRobotsByCategory(robotsList, robotType);
            }
            else if (userOption == 3)
            {
                break; 
            }
        }
    }

   

    public static void InitializeRobots(List<BaseRobot> robotsList)
    {
        robotsList.Add(new DroideProtocolo("ServidroidC3P", 1, 90)); 
        robotsList.Add(new DroideAstroMecanico("Bolt0AD", 2, 75, DateTime.Now)); 
        robotsList.Add(new DroideCombate("TitanR2D", 3, 60, 15)); 
    }

    public static int ShowMainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("--------------------------");  
        Console.WriteLine($"Welcome to Random Robots{Robot_Face}");
        Console.WriteLine($"1. Insert Robot{Robot_Face}");
        Console.WriteLine($"2. Show robots by category{Robot_Face}");
        Console.WriteLine($"3. Exit{Warning}");
        Console.WriteLine("--------------------------");
        Console.Write("Choose an option: ");

        string input = Console.ReadLine()!;
        int option = int.Parse(input); 

        while (option < 1 || option > 3)
        {
            Console.WriteLine("Invalid option. Please try again:");
            input = Console.ReadLine()!;
            option = int.Parse(input); 
        }

        Console.ResetColor(); 
        return option;
    }

    public static string ShowCategoryMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;  
        Console.WriteLine("Select a category:");
        Console.WriteLine("1. Protocol Droid");
        Console.WriteLine("2. Astromech Droid");
        Console.WriteLine("3. Combat Droid");
        Console.Write("Choose an option: ");

        string input = Console.ReadLine()!;
        int option = int.Parse(input); 

        while (option < 1 || option > 3)
        {
            Console.WriteLine("Invalid option. Please try again:");
            input = Console.ReadLine()!;
            option = int.Parse(input); 
        }

        Console.ResetColor(); 
        if (option == 1) return "DroideProtocolo";
        if (option == 2) return "DroideAstroMecanico";
        return "DroideCombate";
    }

    public static void ShowRobotsByCategory(List<BaseRobot> robotsList, string robotType)
    {
        Console.Clear();
        foreach (BaseRobot robot in robotsList)
        {
            if (IsMatchingType(robot, robotType))
            {
                Console.WriteLine($"Type: {robotType}");
                Console.WriteLine($"Name: {robot.Nombre}");
                Console.WriteLine($"Battery: {robot.NivelBateria}%");
                Console.WriteLine($"Unit: {robot.TipoUnidad}");

                if (robot is DroideAstroMecanico astroDroid)
                {
                    Console.WriteLine($"Repaired Ships: {astroDroid.ObtenerNavesReparadas()}");
                }
                else if (robot is DroideCombate combatDroid)
                {
                    Console.WriteLine($"Combat Participation: {combatDroid.ObtenerCombates()}");
                }

                Console.WriteLine("--------------------------");
            }
        }
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }

    public static bool IsMatchingType(BaseRobot robot, string robotType)
    {
        if (robotType == "DroideProtocolo" && robot is DroideProtocolo) return true;
        if (robotType == "DroideAstroMecanico" && robot is DroideAstroMecanico) return true;
        if (robotType == "DroideCombate" && robot is DroideCombate) return true;

        return false;
    }

    public static void AddRobot(List<BaseRobot> robotsList, string robotType)
    {
        Console.Clear();
        Console.Write("Enter the robot's name: ");
        string name = Console.ReadLine()!;

        int id = robotsList.Count + 1;
        int initialBattery = 100;

        if (robotType == "DroideProtocolo")
        {
            robotsList.Add(new DroideProtocolo(name, id, initialBattery));
        }
        else if (robotType == "DroideAstroMecanico")
        {
            robotsList.Add(new DroideAstroMecanico(name, id, initialBattery, DateTime.Now));
        }
        else if (robotType == "DroideCombate")
        {
            robotsList.Add(new DroideCombate(name, id, initialBattery, 10));
        }

        Console.WriteLine("Robot added successfully. Press ENTER to continue...");
        Console.ReadLine();
    }

}