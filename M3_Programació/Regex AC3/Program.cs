using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
        //? Rafael Valerio Practica Regex 2 29-01-2025

        
        // Valida una dirección de correo electrónico (ej. usuario@dominio.com).

        string email = "usuario@dominio.com";
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        bool isValid = Regex.IsMatch(email, pattern);
        Console.WriteLine(isValid ? "Email válido" : "Email inválido");
        
        // Valida un número de teléfono con formato de 10 dígitos (ej. 123-456-7890).

        string phone = "123-456-7890";
        string patternmovil = @"^\d{3}-\d{3}-\d{4}$";
        bool isValidphone = Regex.IsMatch(phone, patternmovil);
        Console.WriteLine(isValidphone ? "Teléfono válido" : "Teléfono inválido");

        // Valida una fecha en formato día/mes/año ej. 29/02/2024).
        string data = "29/02/2024";
        string patterndate = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12]\d{3}$";
        bool isValiddate = Regex.IsMatch(data, patterndate);
        Console.WriteLine(isValiddate ? "Fecha valida" : "Fecha inválida");

        // Valida una dirección IP en formato IPv4 (ej. 192.168.1.1).
        string ip = "192.168.1.1";
        string patternip = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        bool isValidip = Regex.IsMatch(ip, patternip);
        Console.WriteLine(isValidip? "IP válida" : "IP inválida");

        // Valida un código postal de 5 dígitos (ej. 12345).
        string postalCode ="12345";
        string patternpostal = @"^\d{5}$";
        bool isValidpostalcode = Regex.IsMatch(postalCode,patternpostal);
        Console.WriteLine(isValidpostalcode? "Código postal válido" : "Código postal inválido");

        //Valida una palabra que contenga solo letras, sin números ni caracteres especiales (ej. "Hola").

        string word = "Hola";
        string patternword = @"^[a-zA-Z]+$";
        bool isValidword = Regex.IsMatch(word, patternword);
        Console.WriteLine(isValidword? "Palabra válida" : "Palabra inválida");

        //Valida un número entero positivo, que puede tener más de un dígito (ej. 123).

        string number = "123";
        string patternnumber = @"^[1-9]\d*$";
        bool isValidnumber = Regex.IsMatch(number, patternnumber);
        Console.WriteLine(isValidnumber? "Número válido" : "Número inválido");

        //Valida una URL (ej. http://www.ejemplo.com/).

        string url = "http://www.ejemplo.com/";
        string patternurl = @"^(https?:\/\/)?([\da-z.-]+)\.([a-z.]{2,6})([\/\w .-]*)*\/?$";
        bool isValidurl = Regex.IsMatch(url, patternurl);
        Console.WriteLine(isValidurl? "URL válida" : "URL inválida");


        // Valida un código de color hexadecimal (ej. #A3C1D7).
        string color = "#A3C1D7";
        string patternhex = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
        bool isValidhexa = Regex.IsMatch(color, patternhex);
        Console.WriteLine(isValidhexa ? "Color válido" : "Color inválido");

        //Valida un número decimal con punto (ej. 12.23)

        string decimalnumber = "12.23";
        string patterndecimal = @"^\d+(?:\.\d+)?$";
        bool isValiddecimal = Regex.IsMatch(decimalnumber, patterndecimal);
        Console.WriteLine(isValiddecimal? "Número decimal válido" : "Número decimal inválido");


    }
}