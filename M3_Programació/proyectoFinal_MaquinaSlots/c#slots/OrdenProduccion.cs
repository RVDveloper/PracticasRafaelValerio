using System.Collections.Generic;
using System.Linq;
using System.IO;

public class OrdenProduccion<T> where T : Robot
{
    private List<T> ordenes;
    private string nombreJugador;
    private int puntosTotales;

    public OrdenProduccion(string nombreJugador)
    {
        ordenes = new List<T>();
        this.nombreJugador = nombreJugador;
        puntosTotales = 0;
    }

    public void AgregarOrden(T robot)
    {
        ordenes.Add(robot);
    }

    public void AgregarOrdenes(List<T> robots)
    {
        ordenes.AddRange(robots);
    }

    public int CalcularPuntos()
    {
        int puntos = 0;
        foreach (var robot in ordenes)
        {
            if (robot is R2D2) puntos += 3;
            else if (robot is C3PO) puntos += 2;
            else if (robot is BB8) puntos += 1;
        }
        return puntos;
    }

    public int PuntuacionMaxima()
    {
        return ordenes.Count * 3; 
    }

    public int PuntuacionMinima()
    {
        return ordenes.Count; 
    }

    public void MostrarOrdenes()
    {
        Console.WriteLine($"\nÓrdenes de producción para {nombreJugador}:");
        foreach (var robot in ordenes)
        {
            robot.ShowData();
        }
        Console.WriteLine($"Puntos totales: {CalcularPuntos()}");
        Console.WriteLine($"Puntuación máxima posible: {PuntuacionMaxima()}");
        Console.WriteLine($"Puntuación mínima posible: {PuntuacionMinima()}");
    }

    public void GuardarPuntuacion(int puntuacionTotal)
    {
        string datos = $"=== Partida de {nombreJugador} ===\n";
        datos += $"Fecha: {DateTime.Now}\n";
        datos += "Órdenes de producción:\n";
        
        int totalR2D2 = 0;
        int totalC3PO = 0;
        int totalBB8 = 0;
        int totalBatallas = 0;
        int totalReparaciones = 0;
        int totalVuelos = 0;
        
        foreach (var robot in ordenes)
        {
            if (robot is R2D2 r2d2)
            {
                datos += $"R2D2 #{r2d2.Id} - Version: {r2d2.NumeroVersion} - Batallas: {r2d2.NumberOfBattles()}\n";
                totalR2D2++;
                totalBatallas += r2d2.NumberOfBattles();
            }
            else if (robot is C3PO c3po)
            {
                datos += $"C3PO #{c3po.Id} - Reparaciones: {c3po.NumberOfRepairs()}\n";
                totalC3PO++;
                totalReparaciones += c3po.NumberOfRepairs();
            }
            else if (robot is BB8 bb8)
            {
                datos += $"BB8 #{bb8.Id} - Version: {bb8.NumeroVersion:F1} - Vuelos: {bb8.NumberOfFlights()} - Reparaciones: {bb8.NumberOfRepairs()}\n";
                totalBB8++;
                totalVuelos += bb8.NumberOfFlights();
                totalReparaciones += bb8.NumberOfRepairs();
            }
        }
        
        datos += $"\n=== TOTALES ===\n";
        datos += $"Total R2D2: {totalR2D2}\n";
        datos += $"Total C3PO: {totalC3PO}\n";
        datos += $"Total BB8: {totalBB8}\n";
        datos += $"Total Batallas: {totalBatallas}\n";
        datos += $"Total Reparaciones: {totalReparaciones}\n";
        datos += $"Total Vuelos: {totalVuelos}\n";
        datos += $"Puntos totales: {puntuacionTotal}\n\n";
        
        System.IO.File.AppendAllText("partidas.txt", datos);
    }

    public static void MostrarTop3()
    {
        if (!File.Exists("partidas.txt"))
        {
            Console.WriteLine("No hay puntuaciones guardadas.");
            return;
        }

        var lineas = File.ReadAllLines("partidas.txt");
        var partidas = new List<(string Nombre, int Puntos)>();
        string nombreActual = "";
        
        for (int i = 0; i < lineas.Length; i++)
        {
            if (lineas[i].StartsWith("=== Partida de"))
            {
                nombreActual = lineas[i].Replace("=== Partida de ", "").Replace(" ===", "");
            }
            else if (lineas[i].StartsWith("Puntos totales: ") && !string.IsNullOrEmpty(nombreActual))
            {
                int puntos = int.Parse(lineas[i].Replace("Puntos totales: ", ""));
                partidas.Add((nombreActual, puntos));
                nombreActual = "";
            }
        }

        var top3 = partidas
            .OrderByDescending(x => x.Puntos)
            .Take(3)
            .ToList();

        
        string mensajeAsciiTop3 = @"                                                             ________   ______   _______          ______  
                                                            |        \ /      \ |       \        /      \ 
                                                             \$$$$$$$$|  $$$$$$\| $$$$$$$\      |  $$$$$$\
                                                               | $$   | $$  | $$| $$__/ $$       \$$__| $$
                                                               | $$   | $$  | $$| $$    $$        |     $$
                                                               | $$   | $$  | $$| $$$$$$$        __\$$$$$\
                                                               | $$   | $$__/ $$| $$            |  \__| $$
                                                               | $$    \$$    $$| $$             \$$    $$
                                                                \$$     \$$$$$$  \$$              \$$$$$$ 
                                                                                                          
                                                                                                          
                                                                                                          ";
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensajeAsciiTop3);
        
        

        Console.WriteLine("\n╔═════════ TOP 3 PUNTUACIONES ═══════╗");
        for (int i = 0; i < top3.Count; i++)
        {
            string medalla = i switch
            {
                0 => Program._1StPlaceMedal,
                1 => Program._2NdPlaceMedal,
                2 => Program._3RdPlaceMedal,
                _ => " "
            };
            Console.WriteLine($"║ {medalla} {top3[i].Nombre.PadRight(20)} {top3[i].Puntos.ToString().PadLeft(6)} pts ║");
        }
        
        
        for (int i = top3.Count; i < 3; i++)
        {
            Console.WriteLine("║                                            ║");
        }
        
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();
    }

    
} 