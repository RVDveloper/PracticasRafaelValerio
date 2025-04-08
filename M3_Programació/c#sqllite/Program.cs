using System.Data.SQLite;


internal class Program
{
    private static string dbPath = "productos.db";
    private static string connectionString = $"Data Source={dbPath};Version=3;";

    private static void Main(string[] args)
    {
        
        if (!File.Exists(dbPath))
        {
            SQLiteConnection.CreateFile(dbPath);
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string sql = @"
                CREATE TABLE Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Precio REAL NOT NULL,
                    Cantidad INTEGER NOT NULL
                )";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("la Base de datos se ha creado correctamente :)");
        }

        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    CrearProducto();
                    break;
                case "2":
                    ListarProductos();
                    break;
                case "3":
                    BuscarProducto();
                    break;
                case "4":
                    ActualizarProducto();
                    break;
                case "5":
                    EliminarProducto();
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("Hasta luego!...");
                    break;
                default:
                    Console.WriteLine("la opcion no es valida intentalo de nuevo");
                    break;
            }
        }
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("\n===== MENU DE PRODUCTOS =====");
        Console.WriteLine("1. Crear un Producto");
        Console.WriteLine("2. Listar los Productos");
        Console.WriteLine("3. Buscar Producto por el Nombre");
        Console.WriteLine("4. Actualizar un Producto");
        Console.WriteLine("5. Eliminar un Producto");
        Console.WriteLine("6. Salir");
        Console.Write("Selecciona una opcion: ");
    }

    private static void CrearProducto()
    {
        Console.WriteLine("\n===== CREAR PRODUCTO =====");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;
        
        Console.Write("Precio: ");
        string precioStr = Console.ReadLine()!;
        double precio;
        try
        {
            precio = Convert.ToDouble(precioStr);
        }
        catch
        {
            Console.WriteLine("el Precio no es valido tiene que ser un numero");
            return;
        }
        
        Console.Write("Cantidad: ");
        string cantidadStr = Console.ReadLine()!;
        int cantidad;
        try
        {
            cantidad = Convert.ToInt32(cantidadStr);
        }
        catch
        {
            Console.WriteLine("la Cantidad no es valida tiene que ser un numero entero :(");
            return;
        }

        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "INSERT INTO Productos (Nombre, Precio, Cantidad) VALUES (@Nombre, @Precio, @Cantidad)";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@Nombre", nombre);
        command.Parameters.AddWithValue("@Precio", precio);
        command.Parameters.AddWithValue("@Cantidad", cantidad);
        command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine("el Producto se ha creado correctamente :)");
    }

    private static void ListarProductos()
    {
        Console.WriteLine("\n===== LISTA DE PRODUCTOS =====");
        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "SELECT * FROM Productos";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        
        if (!reader.HasRows)
        {
            Console.WriteLine("No hay productos en la base de datos.");
            connection.Close();
            return;
        }

        Console.WriteLine("ID\tNombre\t\tPrecio\tCantidad");
        Console.WriteLine("----------------------------------------");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]}\t{reader["Nombre"]}\t{reader["Precio"]}\t{reader["Cantidad"]}");
        }
        reader.Close();
        connection.Close();
    }

    private static void BuscarProducto()
    {
        Console.WriteLine("\n===== BUSCAR PRODUCTO =====");
        Console.Write("coloca Nombre del producto que quieres buscar: ");
        string nombre = Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "SELECT * FROM Productos WHERE Nombre LIKE @Nombre";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@Nombre", $"%{nombre}%");
        SQLiteDataReader reader = command.ExecuteReader();
        
        if (!reader.HasRows)
        {
            Console.WriteLine("No se encontraron productos con ese nombre.");
            connection.Close();
            return;
        }

        Console.WriteLine("ID\tNombre\t\tPrecio\tCantidad");
        Console.WriteLine("----------------------------------------");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]}\t{reader["Nombre"]}\t{reader["Precio"]}\t{reader["Cantidad"]}");
        }
        reader.Close();
        connection.Close();
    }

    private static void ActualizarProducto()
    {
        Console.WriteLine("\n===== ACTUALIZAR PRODUCTO =====");
        Console.Write("coloca el id del producto que quieres actualizar: ");
        string idStr = Console.ReadLine()!;
        int id;
        try
        {
            id = Convert.ToInt32(idStr);
        }
        catch
        {
            Console.WriteLine("el id no es valido tiene que ser un numero entero");
            return;
        }

        
        if (!ProductoExiste(id))
        {
            Console.WriteLine("No existe ningun producto con ese id");
            return;
        }

        Console.Write("Nuevo nombre (dejalo en blanco para mantener el actual): ");
        string nombre = Console.ReadLine()!;
        
        Console.Write("Nuevo precio (dejalo en blanco para mantener el actual): ");
        string precioStr = Console.ReadLine()!;
        double? precio = null;
        
        if (precioStr != "")
        {
            try
            {
                precio = Convert.ToDouble(precioStr);
            }
            catch
            {
                Console.WriteLine("el Precio no es valido tiene que ser un numero");
                return;
            }
        }
        
        Console.Write("Nueva cantidad (dejalo en blanco para mantener la actual): ");
        string cantidadStr = Console.ReadLine()!;
        int? cantidad = null;
        
        if (cantidadStr != "")
        {
            try
            {
                cantidad = Convert.ToInt32(cantidadStr);
            }
            catch
            {
                Console.WriteLine("Cantidad no valida tiene que ser un numero entero :(");
                return;
            }
        }

        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        
        
        string sql = "UPDATE Productos SET ";
        List<string> updates = new List<string>();
        
        if (nombre != "")
        {
            updates.Add("Nombre = @Nombre");
        }
        
        if (precio.HasValue)
        {
            updates.Add("Precio = @Precio");
        }
        
        if (cantidad.HasValue)
        {
            updates.Add("Cantidad = @Cantidad");
        }
        
        if (updates.Count == 0)
        {
            Console.WriteLine("No se hizo ningun cambio");
            connection.Close();
            return;
        }
        
        sql += string.Join(", ", updates);
        sql += " WHERE Id = @Id";
        
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);
        
        if (nombre != "")
        {
            command.Parameters.AddWithValue("@Nombre", nombre);
        }
        
        if (precio.HasValue)
        {
            command.Parameters.AddWithValue("@Precio", precio.Value);
        }
        
        if (cantidad.HasValue)
        {
            command.Parameters.AddWithValue("@Cantidad", cantidad.Value);
        }
        
        command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine("el Producto se actualizo correctamente :)");
    }

    private static void EliminarProducto()
    {
        Console.WriteLine("\n===== ELIMINAR PRODUCTO =====");
        Console.Write("colocael id del producto que quieres eliminar: ");
        string idStr = Console.ReadLine()!;
        int id;
        try
        {
            id = Convert.ToInt32(idStr);
        }
        catch
        {
            Console.WriteLine("id no es valido X .. tiene que ser un numero entero");
            return;
        }

        
        if (!ProductoExiste(id))
        {
            Console.WriteLine("No existe un producto con ese id");
            return;
        }

        Console.Write("¿Estas seguro de que que quieres eliminar este producto? (S/N): ");
        string confirmacion = Console.ReadLine()!.ToUpper();
        
        if (confirmacion != "S")
        {
            Console.WriteLine("Operacion cancelada X");
            return;
        }

        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "DELETE FROM Productos WHERE Id = @Id";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine("Producto eliminado correctamente.");
    }

    private static bool ProductoExiste(int id)
    {
        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "SELECT COUNT(*) FROM Productos WHERE Id = @Id";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);
        int count = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();
        return count > 0;
    }
}