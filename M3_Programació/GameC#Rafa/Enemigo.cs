
public class Enemigo
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Nivel { get; set; }
    public int Resistencia { get; set; }

    public const string dead = "☠️";public const string VidaIcon = "❤️";public const string dice = "🎲";

    public Enemigo(string nombre, int vida, int nivel, int resistencia)
    {
        Nombre = nombre;
        Vida = vida;
        Nivel = nivel;
        Resistencia = resistencia;
    }

    public virtual void UsarHabilidad(Personaje jugador, Random rnd)
    {
        if (Vida <= 0)
        {
            throw new InvalidOperationException($"{Nombre} no puede usar habilidades porque está derrotado FATALITY DEATH!{dead}");
        }

        int ataque = TirarDados(rnd) - Resistencia;
        if (ataque < 0) ataque = 0;

        Console.WriteLine($"{Nombre} ataca a {jugador.Nombre}. Daño infligido: {ataque}{VidaIcon}");
        jugador.RecibirAtaque(ataque);
    }



    public virtual int TirarDados(Random rnd)
    {
        return rnd.Next(1, 7) + rnd.Next(1, 7);  
    }

    public void RecibirAtaque(int ataque)
    {
        Vida -= ataque;
        if (Vida < 0) Vida = 0;
        Juego.SetTextColor(255, 36, 36);
        Console.WriteLine($"{Nombre} ahora tiene {Vida} puntos de vida {VidaIcon}");
        Juego.ResetColor();
    }
}
