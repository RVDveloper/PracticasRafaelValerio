public class ListaEnteros
{
    public static void LeerListaEnteros()
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Introduce una lista de números enteros (escribe 'fin' o 'FIN' para terminar):");

        while (true)
        {
            Console.Write("Número: ");
            string entrada = Console.ReadLine()!;

            
            if (entrada == "fin" || entrada == "FIN")
            {
                break;
            }

            try
            {
                int numero = Convert.ToInt32(entrada);
                numeros.Add(numero);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error!!: El numero esta fuera del rango de Int32 tienes que colocar un numero (menor que -2147483648 o mayor que 2147483647) ;/");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error!!: Entrada no valida Coloca un numero entero :/");
            }
        }

        Console.WriteLine("\nLista de numeros ingresados:");
        foreach (int num in numeros)
        {
            Console.WriteLine(num);
        }
    }
}