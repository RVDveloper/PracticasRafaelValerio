
public class CiudadanoValenciano : Personaje
{
    public const string Suviver = "🏊";
    public const string Cubo = "🪣";public const string Warning = "⚠️";public const string Axe = "🪓";public const string RescueHelmet = "⛑️";

    public CiudadanoValenciano()
        : base($"{Suviver} Khristofer", 10, 1, $"{Cubo} Cubo Enlodado Paiportenyo")
    {
    }

    public override void Special(Enemigo enemigo, Random rnd)
    {
        base.Special(enemigo, rnd);

        int dado = rnd.Next(1, 7);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();
        
        if (dado > 3){ Console.WriteLine($"{Nombre} realiza un rescate doble y gana puntos extra {RescueHelmet}{Axe}!!");
            PuntosDeHabilidad++;
            Vida += 4;

        }
         else { 
            Console.WriteLine($"{Warning} Fracaso el intento de Rescate Doble :/!!");

        }
        

    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 3; 
    }
}
