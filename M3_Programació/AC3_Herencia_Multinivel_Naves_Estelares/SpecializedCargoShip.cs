public class SpecializedCargoShip : CombatShip
{
    public double CargoCapacity { get; set; }

    public SpecializedCargoShip(string model, double cargoCapacity, int firePower, int battery, int maxSpeed)
        : base(model, firePower, battery, maxSpeed)
    {
        CargoCapacity = cargoCapacity;
    }

    public override void Activate()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("La nave de carga especializada ha activado sus sistemas.");
        Console.ResetColor();
    }

    public override void Attack()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"La nave de carga especializada está atacando con potencia de fuego nivel {FirePower}.");
        Console.ResetColor();
    }

    public void Defend()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("La nave de carga especializada esta defendiendo el espacio alrededor del planeta X.");
        Console.ResetColor();
    }

    public void ShowCargo()
    {
        double currentCargo = CalculateCargo();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"La nave de carga lleva una cantidad de carga de {currentCargo} Kg.");
        Console.ResetColor();
    }

    private double CalculateCargo()
    {
        Random random = new Random();
        return random.Next(0, 9001);
    }

    public override void Deactivate()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("La nave de carga especializada ha apagado sus sistemas.");
        Console.ResetColor();
    }
}
