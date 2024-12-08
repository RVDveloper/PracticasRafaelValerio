
public class Juego
{
    private int turnoActual;
    private int nivelActual;
    private int maxNiveles;
    private DateTime horaInicio;
    private Personaje jugador;
    private Random rnd;

    public const string VidaIcon = "❤️"; public const string Shield = "🛡️";public const string Start = "🌟"; public const string Sword = "⚔️";public const string Run = "🏃";public const string dead = "☠️";
    public const string Suviver = "🏊";public const string Wave = "🌊";public const string City = "🏬";public const string Warning = "⚠️";public const string dice = "🎲";public const string Medal = "🥇";


        public static void SetCustomColor(int r, int g, int b)
    {
        Console.Write($"\u001b[38;2;{r};{g};{b}m"); 
    }


        public static void SetTextColor(int r, int g, int b)
    {
        Console.Write($"\u001b[38;2;{r};{g};{b}m"); 
    }

    public static void SetBackgroundColor(int r, int g, int b)
    {
        Console.Write($"\u001b[48;2;{r};{g};{b}m"); 
    }


        public static void ResetColors()
    {
        Console.Write("\u001b[0m"); 
    }


    public static void ResetColor()
    {
        Console.Write("\u001b[0m"); 
    }



    public Juego(Personaje jugadorInicial)
    {
        jugador = jugadorInicial;
        turnoActual = 1;
        nivelActual = 1;
        maxNiveles = 10; 
        horaInicio = DateTime.Now;
        rnd = new Random();
    }

    public void Iniciar()
    {
        
        SetCustomColor(169, 164, 52);

        Console.Clear();
        Program.PrintWithDelay("Te encuentas en La ciudad Valenciana de Paiporta, el día 29 de octubre a las 19:00...",30);
        Program.PrintWithDelay($"De repente, se desata la desgracia de forma aplastante y arrolladora...{Warning}",30);
        Program.PrintWithDelay($"Toneladas de litros de agua y lodo de los ríos se desbordan de forma demoledora...{Wave}",30);
        Program.PrintWithDelay($"La situación es apocalíptica...{dead}",30);
        Program.PrintWithDelay($"La ciudad está siendo arrasada por la inundación...{Wave}{City}",30);
        Program.PrintWithDelay($"Tú eres uno de los pocos supervivientes...{Suviver}",30);
        Program.PrintWithDelay("Debes encontrar la forma de sobrevivir en este entorno hostil de Estilo Post-Apocaliptico...",30);
        Program.PrintWithDelay("¿Estás listo para comenzar tu Lucha Por Sobrevivir?",30);

        Program.PrintWithDelay("Presiona cualquier tecla para continuar...",20);
        Console.ReadKey();
       



        Program.PrintWithDelay(@" 
 ▄████▄   ▒█████   ███▄ ▄███▓ ██▓▓█████  ███▄    █ ▒███████▒ ▄▄▄                                             
▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓██▒▓█   ▀  ██ ▀█   █ ▒ ▒ ▒ ▄▀░▒████▄                                           
▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒██▒▒███   ▓██  ▀█ ██▒░ ▒ ▄▀▒░ ▒██  ▀█▄                                         
▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ░██░▒▓█  ▄ ▓██▒  ▐▌██▒  ▄▀▒   ░░██▄▄▄▄██                                        
▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░██░░▒████▒▒██░   ▓██░▒███████▒ ▓█   ▓██▒                                       
░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░▓  ░░ ▒░ ░░ ▒░   ▒ ▒ ░▒▒ ▓░▒░▒ ▒▒   ▓▒█░                                       
  ░  ▒     ░ ▒ ▒░ ░  ░      ░ ▒ ░ ░ ░  ░░ ░░   ░ ▒░░░▒ ▒ ░ ▒  ▒   ▒▒ ░                                       
░        ░ ░ ░ ▒  ░      ░    ▒ ░   ░      ░   ░ ░ ░ ░ ░ ░ ░  ░   ▒                                          
░ ░          ░ ░         ░    ░     ░  ░         ░   ░ ░          ░  ░                                       
░                                                  ░                                                         
 ██▓    ▄▄▄          ▄▄▄▄    ▄▄▄     ▄▄▄█████▓ ▄▄▄       ██▓     ██▓    ▄▄▄                                  
▓██▒   ▒████▄       ▓█████▄ ▒████▄   ▓  ██▒ ▓▒▒████▄    ▓██▒    ▓██▒   ▒████▄                                
▒██░   ▒██  ▀█▄     ▒██▒ ▄██▒██  ▀█▄ ▒ ▓██░ ▒░▒██  ▀█▄  ▒██░    ▒██░   ▒██  ▀█▄                              
▒██░   ░██▄▄▄▄██    ▒██░█▀  ░██▄▄▄▄██░ ▓██▓ ░ ░██▄▄▄▄██ ▒██░    ▒██░   ░██▄▄▄▄██                             
░██████▒▓█   ▓██▒   ░▓█  ▀█▓ ▓█   ▓██▒ ▒██▒ ░  ▓█   ▓██▒░██████▒░██████▒▓█   ▓██▒                            
░ ▒░▓  ░▒▒   ▓▒█░   ░▒▓███▀▒ ▒▒   ▓▒█░ ▒ ░░    ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▓  ░▒▒   ▓▒█░                            
░ ░ ▒  ░ ▒   ▒▒ ░   ▒░▒   ░   ▒   ▒▒ ░   ░      ▒   ▒▒ ░░ ░ ▒  ░░ ░ ▒  ░ ▒   ▒▒ ░                            
  ░ ░    ░   ▒       ░    ░   ░   ▒    ░        ░   ▒     ░ ░     ░ ░    ░   ▒                               
    ░  ░     ░  ░    ░            ░  ░              ░  ░    ░  ░    ░  ░     ░  ░                            
                          ░                                                                                  
 ██▓███   ▒█████   ██▀███      ██▓    ▄▄▄                                                                    
▓██░  ██▒▒██▒  ██▒▓██ ▒ ██▒   ▓██▒   ▒████▄                                                                  
▓██░ ██▓▒▒██░  ██▒▓██ ░▄█ ▒   ▒██░   ▒██  ▀█▄                                                                
▒██▄█▓▒ ▒▒██   ██░▒██▀▀█▄     ▒██░   ░██▄▄▄▄██                                                               
▒██▒ ░  ░░ ████▓▒░░██▓ ▒██▒   ░██████▒▓█   ▓██▒                                                              
▒▓▒░ ░  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░   ░ ▒░▓  ░▒▒   ▓▒█░                                                              
░▒ ░       ░ ▒ ▒░   ░▒ ░ ▒░   ░ ░ ▒  ░ ▒   ▒▒ ░                                                              
░░       ░ ░ ░ ▒    ░░   ░      ░ ░    ░   ▒                                                                 
             ░ ░     ░            ░  ░     ░  ░                                                              
                                                                                                             
  ██████  █    ██  ██▓███  ▓█████  ██▀███   ██▒   █▓ ██▓ ██▒   █▓▓█████  ███▄    █  ▄████▄   ██▓ ▄▄▄         
▒██    ▒  ██  ▓██▒▓██░  ██▒▓█   ▀ ▓██ ▒ ██▒▓██░   █▒▓██▒▓██░   █▒▓█   ▀  ██ ▀█   █ ▒██▀ ▀█  ▓██▒▒████▄       
░ ▓██▄   ▓██  ▒██░▓██░ ██▓▒▒███   ▓██ ░▄█ ▒ ▓██  █▒░▒██▒ ▓██  █▒░▒███   ▓██  ▀█ ██▒▒▓█    ▄ ▒██▒▒██  ▀█▄     
  ▒   ██▒▓▓█  ░██░▒██▄█▓▒ ▒▒▓█  ▄ ▒██▀▀█▄    ▒██ █░░░██░  ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒▒▓▓▄ ▄██▒░██░░██▄▄▄▄██    
▒██████▒▒▒▒█████▓ ▒██▒ ░  ░░▒████▒░██▓ ▒██▒   ▒▀█░  ░██░   ▒▀█░  ░▒████▒▒██░   ▓██░▒ ▓███▀ ░░██░ ▓█   ▓██▒   
▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ▒▓▒░ ░  ░░░ ▒░ ░░ ▒▓ ░▒▓░   ░ ▐░  ░▓     ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░   
░ ░▒  ░ ░░░▒░ ░ ░ ░▒ ░      ░ ░  ░  ░▒ ░ ▒░   ░ ░░   ▒ ░   ░ ░░   ░ ░  ░░ ░░   ░ ▒░  ░  ▒    ▒ ░  ▒   ▒▒ ░   
░  ░  ░   ░░░ ░ ░ ░░          ░     ░░   ░      ░░   ▒ ░     ░░     ░      ░   ░ ░ ░         ▒ ░  ░   ▒      
      ░     ░                 ░  ░   ░           ░   ░        ░     ░  ░         ░ ░ ░       ░        ░  ░   
                                                ░            ░                     ░                         
▓█████  ███▄    █                                                                                            
▓█   ▀  ██ ▀█   █                                                                                            
▒███   ▓██  ▀█ ██▒                                                                                           
▒▓█  ▄ ▓██▒  ▐▌██▒                                                                                           
░▒████▒▒██░   ▓██░                                                                                           
░░ ▒░ ░░ ▒░   ▒ ▒                                                                                            
 ░ ░  ░░ ░░   ░ ▒░                                                                                           
   ░      ░   ░ ░                                                                                            
   ░  ░         ░                                                                                            
                                                                                                             
 ██▒   █▓ ▄▄▄       ██▓    ▓█████  ███▄    █  ▄████▄   ██▓ ▄▄▄       ▐██▌                                    
▓██░   █▒▒████▄    ▓██▒    ▓█   ▀  ██ ▀█   █ ▒██▀ ▀█  ▓██▒▒████▄     ▐██▌                                    
 ▓██  █▒░▒██  ▀█▄  ▒██░    ▒███   ▓██  ▀█ ██▒▒▓█    ▄ ▒██▒▒██  ▀█▄   ▐██▌                                    
  ▒██ █░░░██▄▄▄▄██ ▒██░    ▒▓█  ▄ ▓██▒  ▐▌██▒▒▓▓▄ ▄██▒░██░░██▄▄▄▄██  ▓██▒                                    
   ▒▀█░   ▓█   ▓██▒░██████▒░▒████▒▒██░   ▓██░▒ ▓███▀ ░░██░ ▓█   ▓██▒ ▒▄▄                                     
   ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░░ ▒░ ░░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░ ░▀▀▒                                    
   ░ ░░    ▒   ▒▒ ░░ ░ ▒  ░ ░ ░  ░░ ░░   ░ ▒░  ░  ▒    ▒ ░  ▒   ▒▒ ░ ░  ░                                    
     ░░    ░   ▒     ░ ░      ░      ░   ░ ░ ░         ▒ ░  ░   ▒       ░                                    
      ░        ░  ░    ░  ░   ░  ░         ░ ░ ░       ░        ░  ░ ░     ", 1);

ResetColor();

           Console.Clear();
           while (jugador.Vida > 0 && nivelActual <= maxNiveles)
        {
            Console.Clear();
            Program.PrintWithDelay($"Turno - {turnoActual}:",40);
            Program.PrintWithDelay("Las Amenazas de peligro siguen aumentando mientras La inundación sigue avanzando...",40);
            Program.PrintWithDelay($"La ciudad está cada vez más inundada...{Wave}{City}",40);
            Program.PrintWithDelay($"Debes encontrar la forma de sobrevivir en esta Tragedia {Warning}...",40);
            Enemigo enemigo = GenerarEnemigo(nivelActual);

            Console.Clear();
            Program.PrintWithDelay($"\nNivel {nivelActual} - Turno {turnoActual}", 40);
            SetTextColor(57, 255, 20);
            Program.PrintWithDelay($"Jugador: {jugador.Nombre} - Vida {VidaIcon} {jugador.Vida}, Nivel: {jugador.Nivel}", 40);
            ResetColors();
            SetTextColor(255, 239, 61);
            Program.PrintWithDelay($"Enemigo: {enemigo.Nombre} - Vida {VidaIcon} {enemigo.Vida}, Nivel: {enemigo.Nivel}", 40);
            ResetColors();

            
            while (enemigo.Vida > 0 && jugador.Vida > 0)
                 
            {   
                
                SetTextColor(136, 17, 255);
                Console.WriteLine("\n╔═══════════════════════════════╗");
                Console.WriteLine("║      Acciones disponibles     ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                ResetColors();

                
                SetTextColor(255, 102, 0);
                Console.WriteLine($"  1. Usar habilidad {Sword}");
                Console.WriteLine($"  2. Huir {Run}");
                Console.WriteLine($"  3. Special Move {Start}");
                Console.WriteLine($"  4. Defensa Total {Shield}");
                ResetColors();
                

                string accion = Console.ReadLine()!;
                if (accion == "1")
                {
                    Console.Clear();
                    Console.ResetColor();
                    
                    jugador.UsarHabilidad(enemigo, rnd);

                    if (enemigo.Vida > 0)
                    {
                        
                        enemigo.UsarHabilidad(jugador, rnd);
                    }
                }
                else if (accion == "2")
                {
                    
                    Console.ResetColor();
                    Console.WriteLine($"{jugador.Nombre} intenta huir...{Run}");
                    int dadoHuir = rnd.Next(1, 7);


                    if (dadoHuir > 3)
                    {
                        int vidaRecuperada = rnd.Next(5, 11); 
                        jugador.Vida += vidaRecuperada;
                        SetTextColor(0, 153, 255);
                        Program.VibrarConColores($"{jugador.Nombre} ha huido con éxito y ha recuperado {vidaRecuperada}{VidaIcon} puntos de vida Jouu!!");
                        ResetColors();
                        break; 
                    }
                    else
                    {
                        
                        Program.VibrarConColores($"¡La huida ha fallado! El enemigo contraataca DANGER!!{Warning}");
                        enemigo.UsarHabilidad(jugador, rnd);
                        ResetColors();
                    }
                }
                else if (accion == "3")
                {
                    Console.Clear();
                    Console.ResetColor();

                    jugador.Special(enemigo, rnd);
                    if (enemigo.Vida > 0)
                    {
                        
                        enemigo.UsarHabilidad(jugador, rnd);
                    }
                }
                else if (accion == "4")
                {
                    Console.Clear();
                    Console.ResetColor();

                    jugador.Defender(enemigo, rnd);
                    if (enemigo.Vida > 0)
                    {
                        
                        enemigo.UsarHabilidad(jugador, rnd);
                    }
                
                }
                else
                {   
                    Console.ResetColor(); 
                    Console.WriteLine($"Accion invalida{Warning} Pierdes tu turno :/");
                }

                turnoActual++;
                
            }

                Console.Clear();
            if (jugador.Vida > 0 && enemigo.Vida <= 0)
            {
                SetTextColor(57, 255, 20);
                Program.PrintWithDelay($"{jugador.Nombre} ha derrotado a {enemigo.Nombre} y avanza al siguiente nivel", 40);
                jugador.Nivel++;
                nivelActual++;
                ResetColors();

                if (nivelActual <= maxNiveles)
                {
                    GenerarAyuda();
                }
            }
            else if (jugador.Vida <= 0)
            {
                SetTextColor(255, 94, 77);
                Program.PrintWithDelay($"{jugador.Nombre} ha caído en el nivel {nivelActual} ¡Fin del juego! GG! You are FINISHED {dead}!!", 40);
                ResetColors();


                Console.ForegroundColor = ConsoleColor.DarkBlue;
                
                
                Program.VibrarConColores((@" 
  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███   ▐██▌ 
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒ ▐██▌ 
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒ ▐██▌ 
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄   ▓██▒ 
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒ ▒▄▄  
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░ ░▀▀▒ 
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░ ░  ░ 
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░     ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░      ░    
                                                     ░                         "));
                    Console.ResetColor();
                    break;
            }
        
        }

        if (nivelActual > maxNiveles && jugador.Vida > 0)
        {
            Program.VibrarConColores($"¡Felicidades, {jugador.Nombre}! Has derrotado a todos los bosses y ganado el juego You are The CHAMPION SUVIVER{Medal}!!");
        }

        MostrarResumen();
    }

    private Enemigo GenerarEnemigo(int nivel)
    {
        if (nivel == 5 | nivel == 10) 
        {
            int bossesTipo = rnd.Next(1, 3); 
            return bossesTipo switch

            {
                1 => new Mazoff(),
                2 => new PerroSanchez(),
                3 => new DANA(),
                
            };
        }

        int enemigoTipo = rnd.Next(1, 5); 
        return enemigoTipo switch
        {
            1 => new Saqueador(),
            2 => new Tormenta(),
            3 => new Huracan(),
            4 => new ReporteroMentiroso(),
            _ => new ReporteroMentiroso()
        };
    }

    private void GenerarAyuda()
    {
        Program.PrintWithDelay("\nUn personaje aliado aparece para ayudarte...", 40);

        int ayudaTipo = rnd.Next(1, 4);
        switch (ayudaTipo)
        {
            case 1:
                SetTextColor(127, 255, 0);
                Program.PrintWithDelay("¡Has recibido un incremento de ataque! 🗡️", 40);
                jugador.PuntosDeHabilidad += 2;
                ResetColor();
                break;
            case 2:
                SetTextColor(255, 64, 129);
                Program.PrintWithDelay("¡Has recibido un aumento de vida! ❤️", 40);
                jugador.Vida += 3;
                ResetColor();
                break;
            case 3:
                SetTextColor(173, 216, 230);
                Program.PrintWithDelay($"Tu siguiente ataque será más fuerte.{Sword}", 40);
                jugador.AumentarPotenciaHabilidad(5);
                ResetColor();
                break;
            default:
                SetTextColor(96, 96, 96);
                Program.PrintWithDelay("El personaje aliado no tiene nada para ofrecerte esta vez :/ Bruh!!", 40);
                ResetColor();
                break;
        }
    }



    private static List<HighScore> highScores = new List<HighScore>();

        public class HighScore
    {
        public string Nombre { get; set; }
        public int NivelesCompletados { get; set; }
        public TimeSpan TiempoJugado { get; set; }
        public int NivelFinal { get; set; }
    }



    private void MostrarResumen()
    {
        TimeSpan tiempoJugado = DateTime.Now - horaInicio;
        Program.PrintWithDelay($"Resumen del juego:", 40);
        Program.PrintWithDelay($"- Niveles completados: {nivelActual - 1}", 40);
        Program.PrintWithDelay($"- Tiempo jugado: {tiempoJugado:hh\\:mm\\:ss}", 40);
        Program.PrintWithDelay($"- Nivel final del jugador: {jugador.Nivel}", 40);

        
        Program.VibrarConColores(@$"
        ╔═══════════════════════════════╗
        ║ === Save Your Score{Medal} ==== ║
        ╚═══════════════════════════════╝");

        Console.Write("\nPlayer name: ");
        string nombre = Console.ReadLine()!;

        HighScore highScore = new HighScore
        {
            Nombre = nombre,
            NivelesCompletados = nivelActual - 1,
            TiempoJugado = tiempoJugado,
            NivelFinal = jugador.Nivel
        };

        highScores.Add(highScore);
        OrdenarHighScores();

    }


        private void OrdenarHighScores()
    {
        for (int i = 0; i < highScores.Count - 1; i++)
        {
            for (int j = i + 1; j < highScores.Count; j++)
            {
                if (highScores[i].NivelesCompletados < highScores[j].NivelesCompletados)
                {
                    HighScore temp = highScores[i];
                    highScores[i] = highScores[j];
                    highScores[j] = temp;
                }
            }
        }
    }


        public static void MostrarHighScores()
    {
        SetTextColor(127, 255, 0);

        Program.PrintWithDelay("High Scores:", 40);
        for (int i = 0; i < highScores.Count; i++)
        {
            Program.PrintWithDelay($"- {highScores[i].Nombre}: {highScores[i].NivelesCompletados} niveles completados, {highScores[i].TiempoJugado:hh\\:mm\\:ss} de tiempo jugado, nivel final {highScores[i].NivelFinal}", 40);
        }
        ResetColor();
    }




}




