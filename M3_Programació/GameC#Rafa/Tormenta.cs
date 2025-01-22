public class Tormenta : Enemigo
{
    public const string TormentaIcon = "⛈️";public const string Rayo = "⚡";public const string dice = "🎲";

    public Tormenta() 
        : base($"Tormenta {TormentaIcon}", 30, 8, 5)
    {
    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        Console.WriteLine($"{Nombre} crea una tormenta feroz, reduciendo tu visión y golpeandote Con Rayos Que Incineran tu Cuerpo {Rayo}!!");
       
        
        int dado = TirarDados(rnd);


        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (rnd.Next(1, 7) > 5)
        {
            if (rnd.Next(1, 3) == 1)
            {
                Console.WriteLine("¡La tormenta reduce tu precisión GG FAIL!");
                jugador.PuntosDeHabilidad -= 2; 
            }
        }
        else
        {
            Console.WriteLine($"{TormentaIcon}La tormenta no te afecta!");
        }
    }


    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
    
}
