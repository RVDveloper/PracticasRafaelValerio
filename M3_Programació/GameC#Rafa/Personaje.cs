
public class Personaje
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Nivel { get; set; }
    public string Skill { get; set; }
    public int PuntosDeHabilidad { get; set; }


    public const string Shield = "🛡️";public const string dead = "☠️";public const string VidaIcon = "❤️";public const string dice = "🎲";


    public Personaje(string nombre, int vida, int nivel, string skill)
    {
        Nombre = nombre;
        Vida = vida;
        Nivel = nivel;
        Skill = skill;
        PuntosDeHabilidad = 0;
    }



    
    public void RecibirAtaque(int ataque)
    {
        if (ataque < 0) ataque = 0;
        Vida -= ataque;
        if (Vida < 0) Vida = 0;
        Juego.SetTextColor(255, 36, 36);
        Console.WriteLine($"{Nombre} ha recibido {ataque} puntos de daño. Vida restante: {Vida}{VidaIcon}");
        Juego.ResetColor();
    }

    
    public virtual void UsarHabilidad(Enemigo enemigo, Random rnd)
    {
        if (Vida <= 0)
        {
            throw new InvalidOperationException($"{Nombre} no puede usar habilidades porque está sin vida YOU ARE DEAD BRUH! :/ {dead}");
        }

        
        int dado = TirarDados(rnd);
        
        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);
        Juego.ResetColors();

        
        if (dado > 3)
        {
            Juego.SetTextColor(0, 204, 255);
            int ataque = dado + PuntosDeHabilidad;  
            Console.WriteLine($"{Nombre} usa {Skill} contra {enemigo.Nombre}. Daño infligido: {ataque} {VidaIcon}");
            enemigo.RecibirAtaque(ataque);
            Juego.ResetColor();
        }
        else
        {
            Juego.SetTextColor(255, 128, 0);
            Console.WriteLine($"{Nombre} falla su habilidad :/");
            Juego.ResetColor();
        }
    }

    
    public virtual int TirarDados(Random rnd)
    {
        return rnd.Next(1, 7) + rnd.Next(1, 7); 
    }

    
    public void AumentarPotenciaHabilidad(int incremento)
    {
        PuntosDeHabilidad += incremento;
        Juego.SetTextColor(0, 255, 255);
        Console.WriteLine($"{Nombre} ha aumentado sus puntos de habilidad en {incremento}. Total: {PuntosDeHabilidad}");
        Juego.ResetColor();
    }


    public virtual void Special(Enemigo enemigo, Random rnd)
    {
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre}");
        int dado = rnd.Next(1, 7);
        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado: {dado}", 40);
        Juego.ResetColors();


        int dano = (dado > 3) ? 20 : 10;
        enemigo.RecibirAtaque(dano);
        // enemigo.Vida -= dano;
        Console.WriteLine($"Inflige {dano} de daño {VidaIcon}");
    }

    public virtual void Defender(Enemigo enemigo, Random rnd)
    {
        int dado = rnd.Next(1, 7);
        Juego.SetBackgroundColor(240, 255, 128);
        Program.PrintWithDelay($"Tirada de dado{dice}: {dado}", 40);

        Juego.ResetColors();

        if (dado > 5)
        {
            Console.WriteLine($"{Nombre} ha bloqueado el ataque completamente {Shield}");
            return;
        }
        else
        {
            Program.VibrarConColores("Bruh!! Has fallado tu defensa");
            Console.WriteLine($"{Nombre} No Ha podido Defenserderse Resulto Cutre La defensa :/  {Shield}");
            
        }
    }
}
