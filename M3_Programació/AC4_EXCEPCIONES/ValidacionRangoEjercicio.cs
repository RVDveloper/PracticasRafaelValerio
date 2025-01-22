public class ValidacionRangoEjercicio
{
    public static void ValidarNumeroRango()
    {
        try
        {
            Console.Write("dame un numero entre 0 y 1000: ");
            int numero = int.Parse(Console.ReadLine()!);

            if (numero < 0 || numero > 1000)
            {
                throw new ArgumentOutOfRangeException("tu numero debe estar entre 0 y 1000 :/ ");
            }

            Console.WriteLine("Numero valido");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Error!!: " + e.Message);
        }
    }
}