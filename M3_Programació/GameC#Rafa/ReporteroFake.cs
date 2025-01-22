public class ReporteroMentiroso : Enemigo
{
    public const string ReporteroMentirosoIcon = "📰🤥"; public const string mentira = "🤥"; public const string dice = "🎲";

    public ReporteroMentiroso() 
        : base($"Reportero Mentiroso {ReporteroMentirosoIcon}", 25, 8, 4)
    {
    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        
        int dado = rnd.Next(1, 7);


        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        if (rnd.Next(1, 7) > 5)
        {
        Console.WriteLine($"{Nombre} intenta engañarte con una noticia falsa {mentira}");
        
            if (rnd.Next(1, 3) == 1)
            {
                Console.WriteLine("¡El reportero mentiroso te hace creer que has perdido puntos de habilidad!");
                jugador.PuntosDeHabilidad -= 2; 
            }

        }
    }

    public override int TirarDados(Random rnd)
    {
        return base.TirarDados(rnd) + 1; 
    }
}