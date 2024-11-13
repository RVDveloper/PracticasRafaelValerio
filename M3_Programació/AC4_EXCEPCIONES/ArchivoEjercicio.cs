public class ArchivoEjercicio
{
    public static void AbrirArchivo()
    {
        try
        {
            Console.Write("coloca la ruta del archivo: ");
            string ruta = Console.ReadLine()!;
            using (StreamReader sr = new StreamReader(ruta))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error!!: El archivo no existe!! ");
        }
    }
}