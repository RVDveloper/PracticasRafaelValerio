public class VerificacionNumeroEjercicio
{
    public static void VerificarNumero(int numero)
    {
        if (numero < 0)
        {
            throw new ArgumentException("El numero no puede ser negativo!! :/");
        }
    }

    public static void Ejecutar()
    {
        try
        {
            Console.Write("Dime un numero: ");
            int numero = int.Parse(Console.ReadLine()!);
            VerificarNumero(numero);
            Console.WriteLine("numero valido");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}