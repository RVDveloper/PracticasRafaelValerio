
public class Saqueador : Enemigo
{
    public const string SaqueadorIcon = "🥷"; public const string segarro = "🚬";public const string dice = "🎲";

    public Saqueador() 
        : base($"Saqueador {SaqueadorIcon}", 20, 5, 3)
    {
    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        
        int dado = rnd.Next(1, 7);


        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (rnd.Next(1, 7) > 10)
        {
        Console.WriteLine($"{Nombre} intenta robar recursos durante el ataque con su Tactica Amego Segarro {segarro}");
        
            if (rnd.Next(1, 3) == 1)
            {
                Console.WriteLine("¡El saqueador roba algo de tus recursos!");
                jugador.PuntosDeHabilidad -= 1; 
            }

        }
    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}
