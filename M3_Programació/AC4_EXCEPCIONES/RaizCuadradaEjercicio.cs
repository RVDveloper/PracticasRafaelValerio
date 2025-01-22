public class RaizCuadradaEjercicio
{
    public static void CalcularRaizCuadrada()
    {
        try
        {
            Console.Write("Introduce un número: ");
            double numero = double.Parse(Console.ReadLine()!);

            if (numero < 0)
            {
                throw new ArgumentOutOfRangeException("No se puede calcular la raiz cuadrada de un numero negativo, Es IMPOSIBLE dame un numero positivo");
            }

            double raiz = Math.Sqrt(numero);
            Console.WriteLine("el calculo dela Raiz cuadrada es: " + raiz);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Error!!: " + e.Message);
        }
    }
}