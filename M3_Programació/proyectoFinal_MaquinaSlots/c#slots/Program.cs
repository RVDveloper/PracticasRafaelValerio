using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using System.Net.Http;

class Program
{
    public const string RobotEmoji = "🤖"; public const string RobotEmoji2 = "👾"; public const string RobotEmoji3 = "⚙️";public const string Warning = "⚠️"; public const string board = "📋"; public const string Scroll = "📜";public const string SlotM = "🎰";
    public const string _1StPlaceMedal = "🥇";public const string _2NdPlaceMedal = "🥈";public const string _3RdPlaceMedal = "🥉";
    private static readonly Random random = new Random();
    private static async Task<int[]> GetRandomNumbers()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync("randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3");
            return JsonSerializer.Deserialize<int[]>(response)!;
        }
    }
    private static readonly string[] simbolos = { $"{RobotEmoji}R2D2", $"{RobotEmoji2}C3PO", $"{RobotEmoji3}BB8" };
    private static readonly ConsoleColor[] coloresSimbolos = { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Cyan };

    static void Main(string[] args)
    {
        while (true)
        {
            Apertura();
            MostrarTitulo();
            MostrarMenu();
            
            Console.Write("\nSelecciona una opción (1-4): ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    JugarPartida().Wait();
                    break;
                case "2":
                    MostrarPartidas();
                    break;
                case "3":
                    OrdenProduccion<Robot>.MostrarTop3();
                    break;
                case "4":
                    Console.WriteLine("\n¡Gracias por jugar! ¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Por favor, selecciona 1, 2, 3 o 4.");
                    break;
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MostrarTitulo()
    {
        Console.Clear();
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@" ______    ______    _______   ______   _________  ______       ______   __       ______   _________  ______       
/_____/\  /_____/\ /_______/\ /_____/\ /________/\/_____/\     /_____/\ /_/\     /_____/\ /________/\/_____/\      
\:::_ \ \ \:::_ \ \\::: _  \ \\:::_ \ \\__.::.__\/\::::_\/_    \::::_\/_\:\ \    \:::_ \ \\__.::.__\/\::::_\/_     
 \:(_) ) )_\:\ \ \ \\::(_)  \/_\:\ \ \ \  \::\ \   \:\/___/\    \:\/___/\\:\ \    \:\ \ \ \  \::\ \   \:\/___/\    
  \: __ `\ \\:\ \ \ \\::  _  \ \\:\ \ \ \  \::\ \   \_::._\:\    \_::._\:\\:\ \____\:\ \ \ \  \::\ \   \_::._\:\   
   \ \ `\ \ \\:\_\ \ \\::(_)  \ \\:\_\ \ \  \::\ \    /____\:\     /____\:\\:\/___/\\:\_\ \ \  \::\ \    /____\:\  
    \_\/ \_\/ \_____\/ \_______\/ \_____\/   \__\/    \_____\/     \_____\/ \_____\/ \_____\/   \__\/    \_____\/  
                                     ______   ______   ______   ______   __                                        
                                    /_____/\ /_____/\ /_____/\ /_____/\ /__/\                                      
                                    \:::_:\ \\:::_ \ \\:::_ \ \\:::_ \ \\.:\ \                                     
                                       /_\:\ \\:\ \ \ \\:\ \ \ \\:\ \ \ \\::\ \                                    
                                       \::_:\ \\:\ \ \ \\:\ \ \ \\:\ \ \ \\__\/_                                   
                                       /___\:\ '\:\_\ \ \\:\_\ \ \\:\_\ \ \ /__/\                                  
                                       \______/  \_____\/ \_____\/ \_____\/ \__\/                                  
                                                                                                                   ");
        Console.ResetColor();
    }

    
    static void MostrarMenu()
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        
        Console.WriteLine(@"
╔═══════════ MENÚ PRINCIPAL ═══════════╗
║                                      ║
║  1) Jugar una partida        " + $"{SlotM}" + @"      ║
║  2) Ver historial de partidas " + $"{board}" + @"     ║
║  3) Ver Top 3 puntuaciones    " + $"{Scroll}" + @"     ║
║  4) Salir del juego          " + $"{Warning}" + @"       ║
║                                      ║
╚══════════════════════════════════════╝");
        
        Console.ResetColor();
    }

    static void MostrarPartidas()
    {
        if (!System.IO.File.Exists("partidas.txt"))
        {
            Console.WriteLine("\nNo hay partidas guardadas.");
            return;
        }

        Console.WriteLine("\n=== HISTORIAL DE PARTIDAS ===");
        string[] partidas = System.IO.File.ReadAllLines("partidas.txt");
        foreach (string partida in partidas)
        {
            Console.WriteLine(partida);
        }
    }


    static int CalcularBonus(string[] resultado)
    {
        int bonus = 0;
        bool hayJackpot = false;
        int lineasR2D2 = 0;
        int lineasC3PO = 0;
        int lineasBB8 = 0;
        
        
        for (int fila = 0; fila < 3; fila++)
        {
            var linea = new[] { resultado[fila * 3], resultado[fila * 3 + 1], resultado[fila * 3 + 2] };
            if (linea.All(s => s.Contains("R2D2")))
            {
                bonus += 10;
                lineasR2D2++;
                hayJackpot = true;
            }
            else if (linea.All(s => s.Contains("C3PO")))
            {
                bonus += 8;
                lineasC3PO++;
            }
            else if (linea.All(s => s.Contains("BB8")))
            {
                bonus += 6;
                lineasBB8++;
            }
            else if (linea.Count(s => s == linea[0]) == 2)
            {
                bonus += 5;
            }
        }

        
        var diagonal1 = new[] { resultado[0], resultado[4], resultado[8] };
        var diagonal2 = new[] { resultado[2], resultado[4], resultado[6] };

        if (diagonal1.All(s => s.Contains("R2D2")))
        {
            bonus += 10;
            if (!hayJackpot) MostrarJackpot();
        }
        else if (diagonal1.All(s => s.Contains("C3PO")))
        {
            bonus += 8;
        }
        else if (diagonal1.All(s => s.Contains("BB8")))
        {
            bonus += 6;
        }
        else if (diagonal1.Count(s => s == diagonal1[0]) == 2)
        {
            bonus += 5;
        }

        if (diagonal2.All(s => s.Contains("R2D2")))
        {
            bonus += 10;
            if (!hayJackpot) MostrarJackpot();
        }
        else if (diagonal2.All(s => s.Contains("C3PO")))
        {
            bonus += 8;
        }
        else if (diagonal2.All(s => s.Contains("BB8")))
        {
            bonus += 6;
        }
        else if (diagonal2.Count(s => s == diagonal2[0]) == 2)
        {
            bonus += 5;
        }

        
        if (lineasR2D2 >= 2)
        {
            bonus += 30; 
            MostrarDoubleJackpot("R2D2");
        }
        else if (lineasC3PO >= 2)
        {
            bonus += 24; 
            MostrarDoubleJackpot("C3PO");
        }
        else if (lineasBB8 >= 2)
        {
            bonus += 18; 
            MostrarDoubleJackpot("BB8");
        }
        else if (hayJackpot)
        {
            MostrarJackpot();
        }

        return bonus;
    }

    static void MostrarDoubleJackpot(string robot)
    {
        ConsoleColor[] colores = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
        string mensajeAscii = @"
 _______    ______   __    __  _______   __        ________              
|       \  /      \ |  \  |  \|       \ |  \      |        \             
| $$$$$$$\|  $$$$$$\| $$  | $$| $$$$$$$\| $$      | $$$$$$$$             
| $$  | $$| $$  | $$| $$  | $$| $$__/ $$| $$      | $$__                 
| $$  | $$| $$  | $$| $$  | $$| $$    $$| $$      | $$  \                
| $$  | $$| $$  | $$| $$  | $$| $$$$$$$\| $$      | $$$$$                
| $$__/ $$| $$__/ $$| $$__/ $$| $$__/ $$| $$_____ | $$_____              
| $$    $$ \$$    $$ \$$    $$| $$    $$| $$     \| $$     \             
 \$$$$$$$   \$$$$$$   \$$$$$$  \$$$$$$$  \$$$$$$$$ \$$$$$$$$             
    _____   ______    ______   __    __  _______    ______  ________  __ 
   |     \ /      \  /      \ |  \  /  \|       \  /      \|        \|  \
    \$$$$$|  $$$$$$\|  $$$$$$\| $$ /  $$| $$$$$$$\|  $$$$$$\\$$$$$$$$| $$
      | $$| $$__| $$| $$   \$$| $$/  $$ | $$__/ $$| $$  | $$  | $$   | $$
 __   | $$| $$    $$| $$      | $$  $$  | $$    $$| $$  | $$  | $$   | $$
|  \  | $$| $$$$$$$$| $$   __ | $$$$$\  | $$$$$$$ | $$  | $$  | $$    \$$
| $$__| $$| $$  | $$| $$__/  \| $$ \$$\ | $$      | $$__/ $$  | $$    __ 
 \$$    $$| $$  | $$ \$$    $$| $$  \$$\| $$       \$$    $$  | $$   |  \
  \$$$$$$  \$$   \$$  \$$$$$$  \$$   \$$ \$$        \$$$$$$    \$$    \$$";

        string mensajeBonus = $@"
    ╔════════════════════════════════════╗
    ║        ¡¡¡ DOUBLE JACKPOT !!!      ║
    ║     ¡DOS LÍNEAS DE {robot}!        ║
    ║        ¡BONUS ESPECIAL!            ║
    ╚════════════════════════════════════╝";

        for (int i = 0; i < 8; i++)
        {
            Console.Clear();
            Console.ForegroundColor = colores[i % colores.Length];
            Console.WriteLine(mensajeAscii);
            Console.WriteLine(mensajeBonus);
            Thread.Sleep(300);
            
            if (i % 2 == 0)
            {
                Console.Clear();
                Thread.Sleep(150);
            }
        }
        Console.ResetColor();
    }

    static void MostrarJackpot()
    {
        ConsoleColor[] colores = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
        string mensajeAscii = @"
    _____   ______    ______   __    __  _______    ______  ________  __ 
   |     \ /      \  /      \ |  \  /  \|       \  /      \|        \|  \
    \$$$$$|  $$$$$$\|  $$$$$$\| $$ /  $$| $$$$$$$\|  $$$$$$\\$$$$$$$$| $$
      | $$| $$__| $$| $$   \$$| $$/  $$ | $$__/ $$| $$  | $$  | $$   | $$
 __   | $$| $$    $$| $$      | $$  $$  | $$    $$| $$  | $$  | $$   | $$
|  \  | $$| $$$$$$$$| $$   __ | $$$$$\  | $$$$$$$ | $$  | $$  | $$    \$$
| $$__| $$| $$  | $$| $$__/  \| $$ \$$\ | $$      | $$__/ $$  | $$    __ 
 \$$    $$| $$  | $$ \$$    $$| $$  \$$\| $$       \$$    $$  | $$   |  \
  \$$$$$$  \$$   \$$  \$$$$$$  \$$   \$$ \$$        \$$$$$$    \$$    \$$";

        string mensajeBonus = @"
     ╔═══════════════════════════════╗
     ║    3 R2D2 EN LÍNEA = x10      ║
     ╚═══════════════════════════════╝";

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.ForegroundColor = colores[i % colores.Length];
            Console.WriteLine(mensajeAscii);
            Console.WriteLine(mensajeBonus);
            Thread.Sleep(300);
            
            if (i % 2 == 0)
            {
                Console.Clear();
                Thread.Sleep(150);
            }
        }
        Console.ResetColor();
    }

    static ConsoleColor GetColorForNumber(int number)
    {
        return number switch
        {
            1 => ConsoleColor.Red,
            2 => ConsoleColor.Green,
            3 => ConsoleColor.Blue,
            4 => ConsoleColor.Yellow,
            _ => ConsoleColor.White
        };
    }

    static void MostrarMaquinaCompleta(string[] simbolosRodillos = null!)
    {
        Console.Clear();
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        
        
        string[] emojisIzquierda = { "🍒", "🍋", "🍊", "🍇", "💎" };
        string[] emojisDerecha = { "7️⃣", "🍀", "💰", "🎰", "🔔" };
        
        
        Console.WriteLine("     ╔════════════════════════════════════╗");
        
        
        Console.Write("     ║ ");
        Console.Write($"{emojisIzquierda[0]} ");
        Console.Write("     MÁQUINA TRAGAPERRAS     ");
        Console.Write($"{emojisDerecha[0]} ");
        Console.WriteLine(" ║");
        
        Console.Write("     ║ ");
        Console.Write($"{emojisIzquierda[1]} ");
        Console.Write("        ROBOTS 3000          ");
        Console.Write($"{emojisDerecha[1]} ");
        Console.WriteLine("║");
        
        Console.Write("     ║ ");
        Console.Write($"{emojisIzquierda[2]} ");
        Console.Write("                             ");
        Console.Write($"{emojisDerecha[2]} ");
        Console.WriteLine("║");
        
        
        Console.Write("     ║ ");
        Console.Write($"{emojisIzquierda[3]} ");
        Console.Write("╔════════╦════════╦════════╗ ");
        Console.Write($"{emojisDerecha[3]} ");
        Console.WriteLine("║");
        
        
        for (int row = 0; row < 3; row++)
        {
            if (row == 0)
            {
                Console.Write("     ║ ");
                Console.Write($"{emojisIzquierda[0]} "); 
                Console.Write("║");
            }
            else if (row == 2)
            {
                Console.Write("     ║ ");
                Console.Write($"{emojisIzquierda[2]} "); 
                Console.Write("║");
            }
            else
            {
                Console.Write("     ║ ");
                Console.Write(row == 1 ? $"{emojisIzquierda[4]} " : "  ");
                Console.Write("║");
            }
            
            for (int col = 0; col < 3; col++)
            {
                int index = row * 3 + col;
                if (simbolosRodillos != null && index < simbolosRodillos.Length)
                {
                    string simbolo = simbolosRodillos[index];
                    Console.ForegroundColor = simbolo.Contains("R2D2") ? ConsoleColor.Red :
                                           simbolo.Contains("C3PO") ? ConsoleColor.Magenta :
                                           ConsoleColor.Cyan;
                    Console.Write($" {simbolo} ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.Write("       ");
                }
                Console.Write(" ║");
            }
            
            if (row == 0)
            {
                Console.Write($" {emojisDerecha[0]}"); 
                Console.WriteLine(" ║");
            }
            else if (row == 2)
            {
                Console.Write($" {emojisDerecha[2]}"); 
                Console.WriteLine("║");
            }
            else
            {
                Console.Write(row == 1 ? $" {emojisDerecha[4]}" : "  ");
                Console.WriteLine("║");
            }
            
            if (row < 2)
            {
                Console.WriteLine("     ║    ╠════════╬════════╬════════╣    ║");
            }
            else
            {
                Console.Write("     ║    ");
                 // Emoji izquierdo última fila
                Console.Write("╚════════╩════════╩════════╝");
                
                Console.WriteLine("    ║");
            }
        }
        
        Console.WriteLine("     ║                                    ║");
        Console.WriteLine("     ║     Presione ESPACIO para detener  ║");
        Console.WriteLine("     ║                                    ║");
        Console.WriteLine("     ╚════════════════════════════════════╝");
        Console.ResetColor();
    }

    static async Task<string[]> RealizarTiradaConAnimacion()
    {
        var resultadoFinal = new string[9];
        bool detener = false;
        int velocidad = 50; 
        
        Task.Run(() => {
            while (!detener) {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) {
                    detener = true;
                }
                Thread.Sleep(30);
            }
        });

        MostrarMaquinaCompleta();
        Console.SetCursorPosition(0, Console.CursorTop);
        
        try {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3");
            var numeros = JsonSerializer.Deserialize<int[]>(response)!;
            // Convertimos los 3 números en 9 para la matriz 3x3
            resultadoFinal = new string[9];
            for (int i = 0; i < 9; i++)
            {
                resultadoFinal[i] = simbolos[numeros[i % 3] - 1];
            }
        }
        catch {
            resultadoFinal = Enumerable.Range(0, 9).Select(_ => simbolos[random.Next(0, 3)]).ToArray();
        }

        int frame = 0;
        while (!detener)
        {
            var animacion = new string[9];
            for (int i = 0; i < 9; i++)
            {
                int simboloIndex = (frame + i) % simbolos.Length;
                animacion[i] = simbolos[simboloIndex];
            }
            MostrarMaquinaCompleta(animacion);
            Thread.Sleep(velocidad);
            frame++;
            
            
            if (frame % 5 == 0 && velocidad < 160)
            {
                velocidad += 10;
            }
        }

        
        for (int i = 0; i < 5; i++)
        {
            MostrarMaquinaCompleta(resultadoFinal);
            Thread.Sleep(100);
            MostrarMaquinaCompleta(Enumerable.Range(0, 9).Select(_ => simbolos[random.Next(0, 3)]).ToArray());
            Thread.Sleep(70);
        }

        
        MostrarMaquinaCompleta(resultadoFinal);
        return resultadoFinal;
    }

    

    static async Task JugarPartida()
    {
        Console.Clear();
        Console.WriteLine("\n¡Bienvenido a Robots Slots 3000!");
        Console.Write("\nPor favor, introduce tu nombre: ");
        string nombreJugador = Console.ReadLine()!;
        
        int turnosRestantes = 10;
        int puntuacionTotal = 0;
        var ordenProduccion = new OrdenProduccion<Robot>(nombreJugador);
        
        while (turnosRestantes > 0)
        {
            MostrarMaquinaCompleta();
            Console.WriteLine($"\n     Jugador: {nombreJugador}");
            Console.WriteLine($"     Tirada actual: {11 - turnosRestantes} de 10");
            Console.WriteLine($"     Tiradas restantes: {turnosRestantes}");
            Console.WriteLine($"     Puntuación actual: {puntuacionTotal}");
            
            Console.WriteLine("\n     ¡Iniciando nueva tirada! Presiona ESPACIO para detener...");
            
            var resultado = await RealizarTiradaConAnimacion();
            
            var bonus = CalcularBonus(resultado);
            int puntuacionTirada = bonus * 100;
            puntuacionTotal += puntuacionTirada;
            
            Console.WriteLine($"\n     ¡Bonus: {bonus}x!");
            Console.WriteLine($"     Puntuación de la tirada: {puntuacionTirada}");
            Console.WriteLine($"     Puntuación total: {puntuacionTotal}");
            Console.WriteLine($"     Tiradas restantes: {turnosRestantes - 1}");
            
            // Guardar robots
            var robots = CrearRobots(resultado);
            ordenProduccion.AgregarOrdenes(robots);
            
            turnosRestantes--;
            
            if (turnosRestantes > 0)
            {
                Console.Write("\n     ¿Quieres continuar jugando? (S/N): ");
                if (Console.ReadLine()?.ToUpper() != "S") break;
            }
            else
            {
                MostrarMensajeFinal(puntuacionTotal);
            }
        }
        
        ordenProduccion.GuardarPuntuacion(puntuacionTotal);
    }

    static void MostrarMensajeFinal(int puntuacionTotal)
    {
        ConsoleColor[] colores = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
        string mensajeAscii = @"
    ╔═══════════════════════════════════════════╗
    ║         ¡FIN DE LA PARTIDA!               ║
    ║                                           ║
    ║      ¡GRACIAS POR JUGAR!                  ║
    ║                                           ║
    ║      Puntuación Final: " + $"{puntuacionTotal}".PadRight(16) + @"   ║
    ║                                           ║
    ║   Presiona una tecla para volver al menú  ║
    ╚═══════════════════════════════════════════╝";

        for (int i = 0; i < 8; i++)
        {
            Console.Clear();
            Console.ForegroundColor = colores[i % colores.Length];
            Console.WriteLine(mensajeAscii);
            Thread.Sleep(300);
            
            if (i % 2 == 0)
            {
                Console.Clear();
                Thread.Sleep(150);
            }
        }
        Console.ResetColor();
        Console.ReadKey(true);
    }

    static List<Robot> CrearRobots(string[] resultado)
    {
        var robots = new List<Robot>();
        foreach (var simbolo in resultado)
        {
            if (simbolo.Contains("R2D2"))
            {
                robots.Add(new R2D2());
            }
            else if (simbolo.Contains("C3PO"))
            {
                robots.Add(new C3PO());
            }
            else if (simbolo.Contains("BB8"))
            {
                robots.Add(new BB8());
            }
        }
        return robots;
    }

    static void Apertura()
    {
        Console.Clear();
        Console.Title = "Robots Slots 3000";
        Console.CursorVisible = false;
        
        string titulo = @"
    ╔══════════════════════════════╗
    ║      ROBOTS SLOTS 3000       ║
    ╚══════════════════════════════╝";
        
        ConsoleColor[] colores = { ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red };
        string[] simbolos = { "♠", "♥", "♦", "♣", "★", "◆", "●", "■" };
        
        for (int i = 0; i < 10; i++)
        {
            Console.Clear();
            Console.ForegroundColor = colores[i % colores.Length];
            Console.WriteLine(titulo);
            
            
            Console.WriteLine("    ╔══════════════════════════════╗");
            Console.WriteLine("    ║          ┌─────────┐         ║");
            for (int fila = 0; fila < 3; fila++)
            {
                Console.Write("    ║          │");
                for (int col = 0; col < 3; col++)
                {
                    int simboloIndex = (i + col + fila) % simbolos.Length;
                    Console.Write($" {simbolos[simboloIndex]} ");
                }
                Console.WriteLine("│         ║");
            }
            Console.WriteLine("    ║          └─────────┘         ║");
            Console.WriteLine("    ╚══════════════════════════════╝");
            
            Thread.Sleep(200);
        }
        
        Console.ResetColor();
        Thread.Sleep(500);
    }
    
   
}