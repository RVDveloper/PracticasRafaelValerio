internal class Program
{

        public const string Rocket = "🚀"; public const string FlyingSaucer = "🛸"; public const string Collision = "💥";public const string Warning = "⚠️";public const string CheckMark = "✅";
    private static void Main(string[] args)
    {
         bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\n**************************MENU**********************************");
            Console.WriteLine($"| 1) {Rocket}{CheckMark}Mostrar Todas las Naves Estelares                     |");
            Console.WriteLine($"| 2) {FlyingSaucer}Mostrar Nave Basica                                     |");
            Console.WriteLine($"| 3) {Collision}Mostrar Nave de Combate                                 |");
            Console.WriteLine($"| 4) {Rocket}Mostrar Nave de Carga Especializada                     |");
            Console.WriteLine($"| 5) {Warning}Salir                                                    |");
            Console.WriteLine("****************************************************************");
            Console.Write("\nSeleccione una opción: ");
            
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    PrintAllShips();
                    break;
                case "2":
                    PrintBasicShip();
                    break;
                case "3":
                    PrintCombatShip();
                    break;
                case "4":
                    PrintSpecializedCargoShip();
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Saliendo del menú...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static void PrintBasicShip()
    {
        BaseShip basicShip = new BaseShip("Model B-1", 85, 20000);
        basicShip.Activate();
        basicShip.Mission();
        basicShip.Deactivate();
    }

    static void PrintCombatShip()
    {
        CombatShip combatShip = new CombatShip("Model C-7", 8, 90, 40000);
        combatShip.Activate();
        combatShip.Attack();
        combatShip.Deactivate();
    }

    static void PrintSpecializedCargoShip()
    {
        SpecializedCargoShip cargoShip = new SpecializedCargoShip("Model E-9", 2400, 20, 95, 70000);
        cargoShip.Activate();
        cargoShip.Attack();
        cargoShip.Defend();
        cargoShip.ShowCargo();
        cargoShip.Deactivate();
    }

    static void PrintAllShips()
    {
        PrintBasicShip();
        Console.WriteLine();
        PrintCombatShip();
        Console.WriteLine();
        PrintSpecializedCargoShip();
    }
}
