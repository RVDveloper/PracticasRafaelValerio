public class ParseEnteroEjercicio
{
    public static void ConvertirCadenaAEntero()
    {
        try
        {
            Console.Write("coloca un numero entero: ");
            int numero = int.Parse(Console.ReadLine()!);
            Console.WriteLine("el numero que colocaste: " + numero);
        }
        catch (FormatException)
        {
            Console.WriteLine("Oddio!: no es valida la entrada,No es un entero dame :/");
        }
    }
}