public class BaseShip
{
    public string Model { get; set; }
    public int Battery { get; set; }
    public int MaxSpeed { get; set; }

    public BaseShip(string model, int battery, int maxSpeed)
    {
        Model = model;
        Battery = battery;
        MaxSpeed = maxSpeed;
    }

    public virtual void Activate()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("La nave estelar basica ha activado sus sistemas");
        Console.ResetColor();
    }

    public virtual void Mission()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("La nave estelar basica esta realizando una mision de exploracion");
        Console.ResetColor();
    }

    public virtual void Deactivate()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("La nave estelar basica ha apagado sus sistemas");
        Console.ResetColor();
    }
}