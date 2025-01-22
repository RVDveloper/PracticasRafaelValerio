//! Rafael Valerio 2 Daw
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {

        string text = "Los correos electrónicos son una forma común de comunicación en la era digital. Un correo electrónico consta de varias partes, como el remitente, el destinatario, el asunto y el cuerpo del mensaje. Algunos ejemplos de direcciones de correo electrónico son: usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210. En el ámbito de la programación, las expresiones regulares son útiles para validar y buscar patrones en direcciones de correo electrónico. Las expresiones regulares se pueden utilizar en muchos lenguajes de programación, incluyendo Python, JavaScript y Java.";


        //? 1)Identificar y mostrar todas las palabras que contienen la letra "e"

        Console.WriteLine("Ejercicio 1: Palabras que contienen la letra 'e':");
        string pattern = @"\b[Ee]\w*\b";
        foreach (Match m in Regex.Matches(text, pattern))
        {
            Console.WriteLine(m.Value);
        }

        //? 2)Buscar y mostrar todas las palabras que finalizan con la sílaba "dad".

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Ejercicio 2: Palabras que finalizan con 'dad':");
        string pattern2 = @"\b\w*dad\b";
        foreach (Match m in Regex.Matches(text, pattern2))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();


        //? 3)Localizar y mostrar todas las apariciones de la palabra "lenguajes" en el texto.

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" Ejercicio 3: Apariciones de la palabra 'lenguajes':");
        string pattern3 = @"\blenguajes\b";
        foreach (Match m in Regex.Matches(text, pattern3))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();

        //? 4) Identificar y mostrar todas las palabras que inician con la letra "s" y finalizan con la letra "n".

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Ejercicio 4: Palabras que inician con 's' y finalizan con 'n':");
        string pattern4 = @"\b[Ss]\w*n\b";
        foreach (Match m in Regex.Matches(text, pattern4))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();

        //? 5) Buscar y mostrar todas las coincidencias con el formato de número de teléfono "9876543210".

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" Ejercicio 5: Coincidencias con el formato de número de teléfono:");
        string pattern5 = @"\b[0-9]{10}\b";
        foreach (Match m in Regex.Matches(text, pattern5))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();


        //? 6) Identificar y mostrar todas las direcciones de correo electrónico que finalizan con el dominio ".es".

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Ejercicio 6:Direcciones de correo electrónico que finalizan con '.es':");
        string pattern6 = @"\b[A-Za-z0-9]+@[A-Za-z0-9]+\.es\b";
        foreach (Match m in Regex.Matches(text, pattern6))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();


        //? 7) Buscar y mostrar todas las palabras que inician con la letra "a" y poseen una longitud mínima de 5 caracteres.

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Ejercicio 7: Palabras que inician con 'a' y poseen una longitud mínima de 5 caracteres:");
        string pattern7 = @"\b[Aaá]\w{5,}\b";
        foreach (Match m in Regex.Matches(text, pattern7))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();

        //? 8) Identificar y mostrar todas las palabras que están compuestas únicamente por letras en minúscula.

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ejercicio 8: Todas las Palabras que están compuestas únicamente por letras en minúscula:");
        string pattern8 = @"\b[a-z]+\b";
        foreach (Match m in Regex.Matches(text, pattern8))
        {
            
            Console.WriteLine(m.Value);
            
        }
        Console.ResetColor();

        //? 9) Sustituye Python por C#

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Ejercicio 9 : Sustituye Python por C#:");
        string pattern9 = @"\bPython\b";
        string replacement = "C#";
        string result = Regex.Replace(text, pattern9, replacement);
        Console.WriteLine($"Texto Modificado : {result}");
        Console.ResetColor();



    }
}