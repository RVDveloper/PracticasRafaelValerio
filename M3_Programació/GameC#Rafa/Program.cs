internal class Program
{

    public const string Suviver = "🏊";public const string Warning = "⚠️"; public const string Run ="🏃";public const string saqueador ="🥷"; public const string rescatista ="🧑‍🚒";public const string medico ="🧑‍⚕️";public const string Tormenta_Viento ="🌪️";public const string Tormenta ="⛈️";public const string Rayo = "⚡";public const string vida ="❤️";public const string cubo = "🪣";
    public const string Pill = "💊";public const string dice = "🎲";public const string Medal = "🥇";

    private static void Main(string[] args)
    {


        while (true)
        {
            int userOption = ShowMainMenu();

            if (userOption == 1)
            {
                Personaje personaje = ElegirPersonaje();
                if (personaje != null)
                {
                    Juego juego = new Juego(personaje);
                    juego.Iniciar();
                }
            }
            else if (userOption == 2)
            {
                PrintWithDelay($"Showing Top Highscores{Medal}...", 40);
                Juego.MostrarHighScores();
            }
            else if (userOption == 3)
            {
                PrintWithDelay($"¡Gracias por jugar! Saliendo del juego...{Warning}", 40);
                break;
            }
        }
    }

    public static int ShowMainMenu()
    {
        
      
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

        VibrarConColores((@"
   .---.  _______  .---.  ,---.               .---. .-. .-..-.   .-.,-.,---..-.   .-.,---.   
  ( .-._)|__   __|/ .-. ) | .-.\  |\    /|   ( .-._)| | | | \ \ / / |(|| .-.\\ \ / / | .-'   
 (_) \     )| |   | | |(_)| `-'/  |(\  / |  (_) \   | | | |  \ V /  (_)| `-'/ \ V /  | `-.   
 _  \ \   (_) |   | | | | |   (   (_)\/  |  _  \ \  | | | |   ) /   | ||   (   ) /   | .-'   
( `-'  )    | |   \ `-' / | |\ \  | \  / | ( `-'  ) | `-')|  (_)    | || |\ \ (_)    |  `--. 
 `----'     `-'    )---'  |_| \)\ | |\/| |  `----'  `---(_)         `-'|_| \)\       /( __.' 
                  (_)         (__)'-'  '-'                                 (__)     (__)     "));

        Console.WriteLine();

        Console.WriteLine();




        
        Juego.SetTextColor(255, 20, 147);
                PrintWithDelay("\n╔═══════════════════════════════╗", 40);
                PrintWithDelay("║======== Menú Principal =======║",40);
                PrintWithDelay("╚═══════════════════════════════╝",40);
                Juego.ResetColors();

        Juego.SetTextColor(0, 204, 255);
        PrintWithDelay("1. Iniciar el juego", 30);
        PrintWithDelay($"2. Ver Highscores{Medal}", 30);
        PrintWithDelay($"3. Salir{Warning}", 30);
        PrintWithDelay("\nSeleccione una opción: ", 30, false);
        Juego.ResetColors();

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

    public static Personaje ElegirPersonaje()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;

        Juego.SetTextColor(255, 0, 204);
                PrintWithDelay("\n╔═══════════════════════════════╗", 40);
                PrintWithDelay("║==== Selección de Personaje ===║",40);
                PrintWithDelay("╚═══════════════════════════════╝",40);
                Juego.ResetColors();

        Juego.SetTextColor(127, 255, 0);
        PrintWithDelay("\n1) Ciudadano Valenciano 🏊", 40);
        PrintWithDelay("2) Médico de Emergencias ⚕️", 40);
        PrintWithDelay("3) Voluntario de Patrulla Ciudadana 💪", 40);
        PrintWithDelay("4) Reportero Honesto 📰", 40);
        PrintWithDelay($"5) Voluntario De Otra Comunidad {rescatista}", 40);

        PrintWithDelay("\nSeleccione el personaje con el que desea jugar (1-4): ", 40, false);

        string opcion = Console.ReadLine()!;
        Juego.ResetColors(); 
        switch (opcion)
        {
            case "1":
                return new CiudadanoValenciano();
            case "2":
                return new MedicoDeEmergencias();
            case "3":
                return new VoluntarioDePatrullaCiudadana();

            case "4":
                return new ReporteroHonesto();

            case "5":
                return new VoluntarioComunidad();

            default:
                PrintWithDelay($"Opción inválida{Warning} Volviendo al menú principal...", 40);
                return null!;
        
        }
        
        
    }

    public static void PrintWithDelay(string message, int delay, bool newLine = true)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }

        if (newLine)
        {
            Console.WriteLine();
        }



    }

   




    public static void VibrarConColores(string texto)
    {
        Console.CursorVisible = false;
        Random random = new Random();

        for (int i = 0; i < 30; i++) 
        {
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 16);

            Console.Clear();
            Console.WriteLine(texto);

            if (i % 2 == 0)
            {
                Thread.Sleep(100); 
            }
            else
            {
                Console.Clear(); 
                Thread.Sleep(100);
            }
        }

        Console.ResetColor(); 
        Console.CursorVisible = true;
    }


}




