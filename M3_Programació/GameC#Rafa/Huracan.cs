public class Huracan : Enemigo
{
    public const string HuracanIcon = "🌪️";public const string dice = "🎲";

    public Huracan() 
        : base($"Huracan {HuracanIcon}", 40, 12, 8)
    {
    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        Console.WriteLine($"{Nombre} provoca un Huracan que Destruye la ciudad Con Vientos Huracanados del Copon!!!");

        int dado = TirarDados(rnd);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (rnd.Next(1, 7) > 4)
        {
            
            if (rnd.Next(1, 3) == 1)
            {
                Console.WriteLine("¡El Huracan debilita tu defensa!");
                jugador.PuntosDeHabilidad -= 2; 
            }

        }
    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}
