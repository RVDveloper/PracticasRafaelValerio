
public class MedicoDeEmergencias : Personaje
{
    public const string Medico = "⚕️";
    public const string Pill = "💊";public const string dice = "🎲";

    public MedicoDeEmergencias()
        : base($"{Medico} Dr. PAIPER", 8, 1, $"{Pill} Medicamento Sospechoso")
    {
    }

    public override void Special(Enemigo enemigo, Random rnd)
    {
        base.Special(enemigo, rnd);

        int dado = rnd.Next(1, 7);

        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (dado > 3){ Console.WriteLine($"{Nombre} usa Curación Rápida y recupera 3 puntos de vida Con medicamento dudoso JOUU!!");
            Vida += 4;

        }
         else { 
            Console.WriteLine("¡Curacion Fallida!");

        }

       
    }

     public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 2; 
    }
}
