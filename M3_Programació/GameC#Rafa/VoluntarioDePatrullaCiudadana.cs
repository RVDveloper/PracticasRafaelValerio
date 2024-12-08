public class VoluntarioDePatrullaCiudadana : Personaje
{
    public const string Warning = "⚠️";public const string punch = "💪";
    
    public VoluntarioDePatrullaCiudadana() : base($"Voluntario de Patrulla Ciudadana{punch}", 10, 1, "Apalear a Toda Hostia"){}

    public override void Special(Enemigo enemigo, Random rnd)
    {
        base.Special(enemigo, rnd);

        int dado = rnd.Next(1, 7);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();
        
        
        if (dado > 3){ Console.WriteLine($"{Nombre}{punch} apalea a un delincuente y gana puntos de habilidad Que Crack!!");
        PuntosDeHabilidad += 2;
        Vida += 2;
        enemigo.Vida-=2;
        }
        else { 
            Console.WriteLine($"{Warning} Fracaso el intento de apaleo :/!!");

        }
    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}
