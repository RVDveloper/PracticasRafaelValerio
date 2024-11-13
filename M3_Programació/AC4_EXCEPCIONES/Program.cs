
internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2=[];

        string cadena = "ethereum to the moon";
        string cadenaNula =null!;

        Console.ForegroundColor = ConsoleColor.DarkBlue;

        Console.WriteLine("Ejecutando ejercicios de excepciones Division de numeros, valor no numericos:");
        
        DivisionEjercicio.DividirNumeros();
        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;

        
        Console.WriteLine("Ejecutando ejercicios de excepciones Validacion de numero:");

        VerificacionNumeroEjercicio.Ejecutar();

        Console.WriteLine("\n------------------------------------------------");
        
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        ArchivoEjercicio.AbrirArchivo();

        Console.WriteLine("\n------------------------------------------------");
        
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        ValidacionRangoEjercicio.ValidarNumeroRango();

        Console.WriteLine("\n------------------------------------------------");
        
        Console.ResetColor();
        

        Console.ForegroundColor = ConsoleColor.Gray; 

        Console.WriteLine("Ejecutando ejercicios de excepciones Calcular Promedio de array:");

        foreach(var item in array){

                Console.WriteLine(item);
        }

        Console.WriteLine("\n================================================");
        Console.WriteLine("Ejecutando ejercicios de excepciones Calcular Promedio de array");

        PromedioArrayEjercicio.CalcularPromedio(array);
        PromedioArrayEjercicio.CalcularPromedio(array2);


        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        
        ParseEnteroEjercicio.ConvertirCadenaAEntero();

        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();


        Console.ForegroundColor = ConsoleColor.DarkCyan;

        Console.WriteLine("Ejecutando ejercicios de excepciones Lista de enteros, Excepcion si es fuera de rango de Int32:");
        
         ListaEnteros.LeerListaEnteros();
        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();


          
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Ejecutando ejercicios de excepciones Division de numeros, valor denominador es cero:");
        
        DivisionEjercicioExcepcionCero.DividirNumeros2();
        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();




        Console.ForegroundColor=ConsoleColor.DarkGreen;

        Console.WriteLine("Ejecutando ejercicios de excepciones Calcular Raiz cuadrada:");

        RaizCuadradaEjercicio.CalcularRaizCuadrada();

        Console.WriteLine("\n------------------------------------------------");
        Console.ResetColor();




        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("Covierte en mayuscula la cadena y envia una cadena nula para verificar que detecta una cadena nula");

        
        NullReferenceEjercicio.ConvertirAMayusculas(cadena);
        NullReferenceEjercicio.ConvertirAMayusculas(cadenaNula);

        Console.ResetColor();

    }
}