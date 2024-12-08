public class ReporteroHonesto : Personaje
{
    public const string dice = "🎲";

    public ReporteroHonesto() : base("Alvardross jimenez", 10,10,"Golpea con microfono Informador de la verdad") { }

    public override void Special(Enemigo enemigo, Random rnd)
    {
        base.Special(enemigo, rnd);

        int dado = rnd.Next(1, 7);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (dado > 3){ Console.WriteLine("¡Ataque honesto potente!");
            PuntosDeHabilidad++;
            Vida += 2;

        }
         else { 
            Console.WriteLine("¡Ataque honesto fracasó no estas en LiveStream!");

        }

    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}