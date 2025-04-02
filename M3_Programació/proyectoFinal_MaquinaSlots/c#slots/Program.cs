using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using System.Net.Http;

class Program
{
    public const string RobotEmoji = "🤖"; public const string RobotEmoji2 = "👾"; public const string RobotEmoji3 = "⚙️";public const string Warning = "⚠️"; public const string board = "📋"; public const string Scroll = "📜";public const string SlotM = "🎰";
    public const string _1StPlaceMedal = "🥇";
    public const string _2NdPlaceMedal = "🥈";
    public const string _3RdPlaceMedal = "🥉";
    private static readonly Random random = new Random();
    private static async Task<int[]> GetRandomNumbers()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync("randomnumberapi.com/api/v1.0/random?min=1&max=3&count=9");
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
        // Console.BackgroundColor = ConsoleColor.DarkMagenta;
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
        
        // Verificar líneas horizontales
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

        // Verificar diagonales
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

        // Verificar Double Jackpot
        if (lineasR2D2 >= 2)
        {
            bonus += 30; // Bonus extra por Double Jackpot
            MostrarDoubleJackpot("R2D2");
        }
        else if (lineasC3PO >= 2)
        {
            bonus += 24; // Bonus extra por Double Jackpot
            MostrarDoubleJackpot("C3PO");
        }
        else if (lineasBB8 >= 2)
        {
            bonus += 18; // Bonus extra por Double Jackpot
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

    static void MostrarMaquinaCompleta(string[] simbolosRodillos = null)
    {
        Console.Clear();
        Console.WriteLine("\n");
        Console.WriteLine("      ╔══════════════════════════════════════════╗");
        Console.WriteLine("      ║           MÁQUINA TRAGAPERRAS           ║");
        Console.WriteLine("      ║              ROBOTS 3000                ║");
        Console.WriteLine("      ║                                        ║");
        Console.WriteLine("      ║  ╔══════════╦══════════╦══════════╗   ║");
        
        // Área de rodillos (3x3)
        for (int row = 0; row < 3; row++)
        {
            Console.Write("      ║  ║");
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
                }
                else
                {
                    Console.Write("        ");
                }
                Console.Write(col < 2 ? "║" : "║");
            }
            Console.WriteLine("  ║");
            if (row < 2) Console.WriteLine("      ║  ╠══════════╬══════════╬══════════╣  ║");
        }
        
        Console.WriteLine("      ║  ╚══════════╩══════════╩══════════╝  ║");
        Console.WriteLine("      ║                                        ║");
        Console.WriteLine("      ║     Presione ESPACIO para detener     ║");
        Console.WriteLine("      ║                                        ║");
        Console.WriteLine("      ╚══════════════════════════════════════════╝");
    }

    static async Task<string[]> RealizarTiradaConAnimacion()
    {
        var resultadoFinal = new string[9];
        bool detener = false;
        int velocidad = 50; // Velocidad inicial de la animación
        
        // Configurar listener para tecla espacio
        Task.Run(() => {
            while (!detener) {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) {
                    detener = true;
                }
                Thread.Sleep(50);
            }
        });

        // Animación inicial
        MostrarMaquinaCompleta();
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.WriteLine("      ¡Girando rodillos! Presiona ESPACIO para detener...");
        
        // Obtener resultado final al inicio
        try {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("randomnumberapi.com/api/v1.0/random?min=1&max=3&count=9");
            var numeros = JsonSerializer.Deserialize<int[]>(response)!;
            resultadoFinal = numeros.Select(n => simbolos[n - 1]).ToArray();
        }
        catch {
            resultadoFinal = Enumerable.Range(0, 9).Select(_ => simbolos[random.Next(0, 3)]).ToArray();
        }

        // Animación de giro
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
            
            // Aumentar gradualmente la velocidad
            if (frame % 5 == 0 && velocidad < 200)
            {
                velocidad += 10;
            }
        }

        // Mostrar resultado final con efecto de desaceleración
        for (int i = 0; i < 5; i++)
        {
            MostrarMaquinaCompleta(resultadoFinal);
            Thread.Sleep(200);
            MostrarMaquinaCompleta(Enumerable.Range(0, 9).Select(_ => simbolos[random.Next(0, 3)]).ToArray());
            Thread.Sleep(100);
        }

        // Mostrar resultado final definitivo
        MostrarMaquinaCompleta(resultadoFinal);
        return resultadoFinal;
    }

    static void MostrarRodillosEnMaquina(string[] simbolosRodillos)
    {
        int[] posX = { 14, 25, 36 }; // Ajustadas las posiciones X
        int[] posY = { 8, 10, 12 };  // Posiciones Y de las filas
        
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                int index = row * 3 + col;
                Console.SetCursorPosition(posX[col], posY[row]);
                
                string simbolo = simbolosRodillos[index];
                Console.ForegroundColor = simbolo.Contains("R2D2") ? ConsoleColor.Red :
                                       simbolo.Contains("C3PO") ? ConsoleColor.Magenta :
                                       ConsoleColor.Cyan;
                Console.Write($" {simbolo} ");
                Console.ResetColor();
            }
        }
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
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Jugador: {nombreJugador}");
            Console.WriteLine($"Turnos restantes: {turnosRestantes}");
            Console.WriteLine($"Puntuación actual: {puntuacionTotal}");
            Console.WriteLine("\n¡Iniciando nueva tirada! Presiona ESPACIO para detener...");
            
            // Realizar tirada con animación
            var resultado = await RealizarTiradaConAnimacion();
            
            // Mostrar resultados
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 20);
            
            var bonus = CalcularBonus(resultado);
            int puntuacionTirada = bonus * 100;
            puntuacionTotal += puntuacionTirada;
            
            Console.WriteLine($"¡Bonus: {bonus}x!");
            Console.WriteLine($"Puntuación de la tirada: {puntuacionTirada}");
            Console.WriteLine($"Puntuación total: {puntuacionTotal}");
            
            // Guardar robots
            var robots = CrearRobots(resultado);
            ordenProduccion.AgregarOrdenes(robots);
            
            turnosRestantes--;
            
            if (turnosRestantes > 0)
            {
                Console.Write("\n¿Quieres continuar jugando? (S/N): ");
                if (Console.ReadLine()?.ToUpper() != "S") break;
            }
        }
        
        ordenProduccion.GuardarPuntuacion(puntuacionTotal);
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
    
    static void DrawAnimatedReel(string[] symbols, int frame, int position, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        int index = (frame + position * 3) % symbols.Length;
        Console.Write(symbols[index]);
    }
    
    static void DrawRobot(int frame)
    {
        string[] robotFrames = new string[]
        {
            @"    /^\___/^\    ",
            @"   /  |   |  \   ",
            @"  /   |   |   \  ",
            @" /    |   |    \ ",
            @"|     |   |     |",
            @" \    |   |    / ",
            @"  \   |   |   /  ",
            @"   \  |   |  /   ",
            @"    \/___\/    "
        };
        Console.WriteLine(robotFrames[frame]);
    }
}