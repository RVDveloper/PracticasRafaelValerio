public class PromedioArrayEjercicio
{
    public static void CalcularPromedio(int[] array)
    {
        try
        {
            
            if (array.Length == 0)
            {
                throw new IndexOutOfRangeException("Error!!: El índice está fuera de rango.");
            }

            int suma = 0;
            for (int i = 0; i < array.Length; i++)
            {
                suma += array[i];
            }

            int promedio = suma / array.Length;
            Console.WriteLine("Promedio: " + promedio);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error!!: No se puede dividir entre cero ;/ Tu array esta vacia");
        }
        
    }
}