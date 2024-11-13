public class DivisionEjercicioExcepcionCero
{
    public static void DividirNumeros2()
    {
        try
        {
            Console.Write("dame el primer numero: ");
            int num1 = int.Parse(Console.ReadLine()!);

            Console.Write("dame el segundo numero: ");
            int num2 = int.Parse(Console.ReadLine()!);

            int resultado = num1 / num2;
            Console.WriteLine("Resultado: " + resultado);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error!!: Debes colocar un valor numerico :/");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error!!: No se puede dividir entre cero debes colocar otro denominador :/");
        }
    }
}