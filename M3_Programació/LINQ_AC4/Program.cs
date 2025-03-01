using System.Linq;
internal class Program
{
    
    private static void Main(string[] args)
    {
        // Lista de personas
        List<Persona> personas = new List<Persona>
        {
            new Persona("Juan", 30),
            new Persona("Pedro", 31),
            new Persona("Miguel", 25),
            new Persona("Luís", 36),
            new Persona("José", 25)
        };

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|=== Consultas SIN usar expresiones lambda ===|");
        Console.ResetColor();

        // 1) Encuentra el nombre de la persona mas joven
        Console.ForegroundColor = ConsoleColor.Yellow;
        var personasMasJovenes = (from p in personas
                                orderby p.Edad
                                select p).TakeWhile(p => p.Edad == personas.Min(p2 => p2.Edad)).ToList();
        Console.WriteLine("1) Las personas mas jovenes son estas:");
        foreach (var p in personasMasJovenes)
        {
            Console.WriteLine($"- {p.Nombre} ({p.Edad} años)");
        }
        Console.ResetColor();

        // 2) Calcula la edad promedio
        Console.ForegroundColor = ConsoleColor.Green;
        var edades = from p in personas
                     select p.Edad;
        double edadPromedio = edades.Average();
        Console.WriteLine($"2) La edad promedio de todas las personas es: {edadPromedio}");
        Console.ResetColor();

        // 3) Personas mayores de 25 años ordenadas alfabeticamente
        Console.ForegroundColor = ConsoleColor.Magenta;
        var mayoresDe25 = from p in personas
                          where p.Edad > 25
                          orderby p.Nombre
                          select p;
        Console.WriteLine("3) Lista de personas mayores de 25 años (ordenadas por nombre):");
        foreach (var p in mayoresDe25)
        {
            Console.WriteLine($"- {p.Nombre} ({p.Edad} años)");
        }
        Console.ResetColor();

        // 4) Personas cuyo nombre comienza con "M", ordenadas por edad descendente
        Console.ForegroundColor = ConsoleColor.Blue;
        var nombresConM = from p in personas
                          where p.Nombre.StartsWith("M")
                          orderby p.Edad descending
                          select p;
        Console.WriteLine("4) Personas que el nombre empieza con 'M' (ordenadas por edad de mayor a menor):");
        foreach (var p in nombresConM)
        {
            Console.WriteLine($"- {p.Nombre} ({p.Edad} años)");
        }
        Console.ResetColor();

        // 5) Verifica si todas las personas son mayores de 18 años
        Console.ForegroundColor = ConsoleColor.Red;
        bool todosMayoresDe18 = (from p in personas
                                 where p.Edad <= 18
                                 select p).Count() == 0;
        Console.WriteLine($"5) ¿Son todas las personas mayores de 18 años?: {(todosMayoresDe18 ? "Sí" : "No")}");
        Console.ResetColor();

        // 6) Persona mas joven cuyo nombre contiene la letra "a"
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        var personaMasJovenConA = (from p in personas
                                   where p.Nombre.Contains("a")
                                   orderby p.Edad
                                   select p).First();
        Console.WriteLine($"6) La persona mas joven cuyo nombre contiene la letra 'a' es: {personaMasJovenConA.Nombre}");
        Console.ResetColor();

        // 7) Agrupa personas por la primera letra del nombre y cuenta cuantas hay en cada grupo
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        var gruposPorLetra = from p in personas
                             group p by p.Nombre[0] into g
                             select new { Letra = g.Key, Cantidad = g.Count() };
        Console.WriteLine("7) Personas agrupadas por la primera letra de su nombre:");
        foreach (var grupo in gruposPorLetra)
        {
            Console.WriteLine($"- Letra '{grupo.Letra}': {grupo.Cantidad} persona(s)");
        }
        Console.ResetColor();



        //? con expresiones lambda:

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n|=== Consultas usando expresiones lambda ===|");
        Console.ResetColor();

        // 8) Encuentra el nombre de la persona mas joven que tenga una edad impar
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        var personasMasJovenesImpares = personas
            .Where(p => p.Edad % 2 != 0)
            .OrderBy(p => p.Edad)
            .TakeWhile(p => p.Edad == personas.Where(p2 => p2.Edad % 2 != 0).Min(p2 => p2.Edad)).ToList();
        Console.WriteLine("8) Las personas mas jovenes con una edad impar son estos:");
        foreach (var p in personasMasJovenesImpares)
        {
            Console.WriteLine($"- {p.Nombre} ({p.Edad} años)");
        }
        Console.ResetColor();

        // 9) Elimina a todas las personas cuyas edades sean multiplos de 5
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        personas.RemoveAll(p => p.Edad % 5 == 0);
        Console.WriteLine("9) Despues de eliminar a las personas con edades multiplos de 5, la lista queda asi:");
        foreach (var p in personas)
        {
            Console.WriteLine($"- {p.Nombre} ({p.Edad} años)");
        }
        Console.ResetColor();

        // 10) Calcula la diferencia de edad entre la persona mas joven y la mas vieja
        Console.ForegroundColor = ConsoleColor.DarkRed;
        int edadMasJoven = personas.Min(p => p.Edad);
        int edadMasVieja = personas.Max(p => p.Edad);
        int diferenciaEdad = edadMasVieja - edadMasJoven;
        Console.WriteLine($"10) La diferencia de edad entre la persona mas joven y la mas vieja es: {diferenciaEdad} años");
        Console.ResetColor();
        
    }


    }

    

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

