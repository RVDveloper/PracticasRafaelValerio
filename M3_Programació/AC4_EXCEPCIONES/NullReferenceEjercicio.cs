public class NullReferenceEjercicio
{
    public static void ConvertirAMayusculas(string texto)
    {
        try
        {
            if (texto == null)
            {
                throw new NullReferenceException("La cadena es nula :/");
            }

            Console.WriteLine("Convertido En mayusculas: " + texto.ToUpper());
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Error!!: " + e.Message);
        }
    }
}