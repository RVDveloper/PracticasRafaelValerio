namespace UF2AC5_Clases_Genericas
{
    class Program
    {
        static void Main(string[] args)
        {
            //? Rafael Valerio UF2 AC5

            var apiProductos = new Api<Producto>();
            var apiClientes = new Api<Cliente>();
            var apiEmpleados = new Api<Empleado>();
            bool continuar = true;

            
            int nextProductoId = 1;
            int nextClienteId = 1;
            int nextEmpleadoId = 1;

            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n|=== MENU PRINCIPAL ===|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1) Gestionar Productos");
                Console.WriteLine("2) Gestionar Clientes");
                Console.WriteLine("3) Gestionar Empleados");
                Console.WriteLine("0) Salir⚠️");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nSelecciona una opcion: ");
                Console.ResetColor();
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        GestionarProductos(apiProductos, ref nextProductoId);
                        break;
                    case "2":
                        GestionarClientes(apiClientes, ref nextClienteId);
                        break;
                    case "3":
                        GestionarEmpleados(apiEmpleados, ref nextEmpleadoId);
                        break;
                    case "0":
                        continuar = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGracias por usar el sistema Arrivederci!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida Intenta nuevamente⚠️");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void GestionarProductos(Api<Producto> api, ref int nextId)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n|=== GESTION DE PRODUCTOS ===|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1) Agregar Producto");
                Console.WriteLine("2) Listar Productos");
                Console.WriteLine("3) Buscar Producto");
                Console.WriteLine("4) Actualizar Producto");
                Console.WriteLine("5) Eliminar Producto❌");
                Console.WriteLine("0) Volver al Menu⚠️");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nSelecciona una opcion: ");
                Console.ResetColor();
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine()!;
                        Console.Write("Precio del producto: ");
                        decimal precio = decimal.Parse(Console.ReadLine()!);
                        api.AgregarElemento(new Producto(nextId++, nombre, precio));
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nListado de Productos:");
                        Console.ResetColor();
                        api.MostrarElementos();
                        break;
                    case "3":
                        Console.Write("coloca el ID del producto que quieres buscar: ");
                        int idBuscar = int.Parse(Console.ReadLine()!);
                        var producto = api.ObtenerElemento(idBuscar);
                        if (producto != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"Producto encontrado: {producto}");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        Console.Write("coloca el ID del producto que quieres actualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine()!);
                        Console.Write("Nuevo nombre del producto: ");
                        string nuevoNombre = Console.ReadLine()!;
                        Console.Write("Nuevo precio del producto: ");
                        decimal nuevoPrecio = decimal.Parse(Console.ReadLine()!);
                        api.ActualizarElemento(idActualizar, new Producto(idActualizar, nuevoNombre, nuevoPrecio));
                        break;
                    case "5":
                        Console.Write("coloca el ID del producto que quieres eliminar❌: ");
                        int idEliminar = int.Parse(Console.ReadLine()!);
                        api.EliminarElemento(idEliminar);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida Intenta nuevamente⚠️");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void GestionarClientes(Api<Cliente> api, ref int nextId)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n|=== GESTION DE CLIENTES ===|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1) Agregar Cliente");
                Console.WriteLine("2) Listar Clientes");
                Console.WriteLine("3) Buscar Cliente");
                Console.WriteLine("4) Actualizar Cliente");
                Console.WriteLine("5) Eliminar Cliente❌");
                Console.WriteLine("0) Volver al Menu⚠️");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nSelecciona una opcion: ");
                Console.ResetColor();
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del cliente: ");
                        string nombre = Console.ReadLine()!;
                        Console.Write("Email del cliente: ");
                        string email = Console.ReadLine()!;
                        api.AgregarElemento(new Cliente(nextId++, nombre, email));
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nListado de Clientes:");
                        Console.ResetColor();
                        api.MostrarElementos();
                        break;
                    case "3":
                        Console.Write("coloca el ID del cliente que quieres buscar: ");
                        int idBuscar = int.Parse(Console.ReadLine()!);
                        var cliente = api.ObtenerElemento(idBuscar);
                        if (cliente != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"Cliente encontrado: {cliente}");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        Console.Write("coloca el ID del cliente que quieresactualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine()!);
                        Console.Write("Nuevo nombre del cliente: ");
                        string nuevoNombre = Console.ReadLine()!;
                        Console.Write("Nuevo email del cliente: ");
                        string nuevoEmail = Console.ReadLine()!;
                        api.ActualizarElemento(idActualizar, new Cliente(idActualizar, nuevoNombre, nuevoEmail));
                        break;
                    case "5":
                        Console.Write("coloca el ID del cliente que quieres eliminar❌: ");
                        int idEliminar = int.Parse(Console.ReadLine()!);
                        api.EliminarElemento(idEliminar);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida Intenta nuevamente⚠️");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void GestionarEmpleados(Api<Empleado> api, ref int nextId)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n|=== GESTION DE EMPLEADOS ===|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1) Agregar Empleado");
                Console.WriteLine("2) Listar Empleados");
                Console.WriteLine("3) Buscar Empleado");
                Console.WriteLine("4) Actualizar Empleado");
                Console.WriteLine("5) Eliminar Empleado❌");
                Console.WriteLine("0) Volver al Menu⚠️");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nSelecciona una opcion: ");
                Console.ResetColor();
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del empleado: ");
                        string nombre = Console.ReadLine()!;
                        Console.Write("Cargo del empleado: ");
                        string cargo = Console.ReadLine()!;
                        Console.Write("Salario del empleado: ");
                        decimal salario = decimal.Parse(Console.ReadLine()!);
                        api.AgregarElemento(new Empleado(nextId++, nombre, cargo, salario));
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nListado de Empleados:");
                        Console.ResetColor();
                        api.MostrarElementos();
                        break;
                    case "3":
                        Console.Write("coloca el ID del empleado que quieres buscar: ");
                        int idBuscar = int.Parse(Console.ReadLine()!);
                        var empleado = api.ObtenerElemento(idBuscar);
                        if (empleado != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"Empleado encontrado: {empleado}");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        Console.Write("coloca el ID del empleado que quieres actualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine()!);
                        Console.Write("Nuevo nombre del empleado: ");
                        string nuevoNombre = Console.ReadLine()!;
                        Console.Write("Nuevo cargo del empleado: ");
                        string nuevoCargo = Console.ReadLine()!;
                        Console.Write("Nuevo salario del empleado: ");
                        decimal nuevoSalario = decimal.Parse(Console.ReadLine()!);
                        api.ActualizarElemento(idActualizar, new Empleado(idActualizar, nuevoNombre, nuevoCargo, nuevoSalario));
                        break;
                    case "5":
                        Console.Write("coloca el ID del empleado que qiueres eliminar❌: ");
                        int idEliminar = int.Parse(Console.ReadLine()!);
                        api.EliminarElemento(idEliminar);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida Intenta nuevamente⚠️");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}