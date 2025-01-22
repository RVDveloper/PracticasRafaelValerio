public class VoluntarioComunidad : Personaje
{
    public const string dice = "🎲"; public const string Box = "📦";public const string rescatista ="🧑‍🚒";


    public VoluntarioComunidad() : base($"Andros el madrileño{rescatista}", 10,10,$"Golpea con Fuerza Caja de Donaciones{Box}") { }

    public override void Special(Enemigo enemigo, Random rnd)
    {
        base.Special(enemigo, rnd);

        int dado = rnd.Next(1, 7);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (dado > 3){ Console.WriteLine("¡Solidaridad activa!");
        PuntosDeHabilidad+=2;
        Vida += 5;
        }
        else { 
            Console.WriteLine("¡Solidaridad fallida no Tenias donaciones!");

        }

    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}
