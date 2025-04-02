using System;

public class Robot
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public DateTime FechaCreacion { get; set; }

    protected static int contadorId = 1;

    public Robot(string modelo)
    {
        Id = contadorId++;
        Modelo = modelo;
        FechaCreacion = DateTime.Now.AddDays(new Random().Next(-365, 0));
    }

    public virtual void ShowData()
    {
        Console.WriteLine($"Robot #{Id} - Modelo: {Modelo} - Fecha: {FechaCreacion:dd/MM/yyyy}");
    }
}

public class R2D2 : Robot
{
    public int NumeroVersion { get; set; }

    public R2D2() : base("R2D2")
    {
        NumeroVersion = new Random().Next(1, 10);
    }

    public int NumberOfBattles()
    {
        return new Random().Next(1, 100);
    }

    public override void ShowData()
    {
        Console.WriteLine($"R2D2 #{Id} - Version: {NumeroVersion} - Fecha: {FechaCreacion:dd/MM/yyyy} - Batallas: {NumberOfBattles()}");
    }
}

public class C3PO : Robot
{
    public C3PO() : base("C3PO")
    {
    }

    public int NumberOfRepairs()
    {
        return new Random().Next(1, 50);
    }

    public override void ShowData()
    {
        Console.WriteLine($"C3PO #{Id} - Fecha: {FechaCreacion:dd/MM/yyyy} - Reparaciones: {NumberOfRepairs()}");
    }
}

public class BB8 : Robot
{
    public float NumeroVersion { get; set; }

    public BB8() : base("BB8")
    {
        NumeroVersion = (float)(new Random().Next(1, 10) + new Random().NextDouble());
    }

    public int NumberOfFlights()
    {
        return new Random().Next(1, 200);
    }

    public int NumberOfRepairs()
    {
        return new Random().Next(1, 30);
    }

    public override void ShowData()
    {
        Console.WriteLine($"BB8 #{Id} - Version: {NumeroVersion:F1} - Fecha: {FechaCreacion:dd/MM/yyyy} - Vuelos: {NumberOfFlights()} - Reparaciones: {NumberOfRepairs()}");
    }
} 