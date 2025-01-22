public class CombatShip : BaseShip
{
    public int FirePower { get; set; }

    public CombatShip(string model, int firePower, int battery, int maxSpeed)
        : base(model, battery, maxSpeed)
    {
        FirePower = firePower;
    }

    public override void Activate()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("La nave de combate ha activado sus sistemas de combate.");
        Console.ResetColor();
    }

    public virtual void Attack() 
    {
        int intensity = GenerateAttackIntensity();
        Console.ForegroundColor = ConsoleColor.Red;
        if (intensity == 0)
        {
            Console.WriteLine("La nave de combate no ha disparado, no hay cargas por ahora.");
        }
        else
        {
            Console.WriteLine($"La nave de combate esta atacando con potencia de fuego nivel {FirePower}.");
        }
        Console.ResetColor();
    }

    private int GenerateAttackIntensity()
    {
        Random random = new Random();
        return random.Next(0, 2);
    }

    public override void Deactivate()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("La nave de combate ha apagado sus sistemas.");
        Console.ResetColor();
    }
}
