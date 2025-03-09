using System.Collections.Generic;
using System.Linq;

namespace UF2AC5_Clases_Genericas
{
    public class Api<T>
    {
        private List<T> elementos;

        public Api()
        {
            elementos = new List<T>();
        }

        public void AgregarElemento(T elemento)
        {
            elementos.Add(elemento);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ el elemento se agrego correctamente");
            Console.ResetColor();
        }

        public void ActualizarElemento(int id, T elementoActualizado)
        {
            var indice = elementos.FindIndex(e => GetId(e) == id);
            if (indice != -1)
            {
                elementos[indice] = elementoActualizado;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ el elemento se actualizo correctamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ no se encontro el elemento con el ID que has colocado");
                Console.ResetColor();
            }
        }

        public void EliminarElemento(int id)
        {
            var elemento = elementos.FirstOrDefault(e => GetId(e) == id);
            if (elemento != null)
            {
                elementos.Remove(elemento);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("❌ el Elemento se elimino correctamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ no se encontro el elemento con el ID que has colocado");
                Console.ResetColor();
            }
        }

        public T ObtenerElemento(int id)
        {
            var elemento = elementos.FirstOrDefault(e => GetId(e) == id);
            if (elemento != null)
            {
                return elemento;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ no se encontro el elemento con el ID que has colocado");
                Console.ResetColor();
                return default(T)!;
            }
        }

        public void MostrarElementos()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (elementos.Count == 0)
            {
                Console.WriteLine("No hay elementos para mostrar");
            }
            else
            {
                foreach (var elemento in elementos)
                {
                    Console.WriteLine(elemento.ToString());
                }
            }
            Console.ResetColor();
        }

        private int GetId(T elemento)
        {
            if (elemento is Producto producto) return producto.Id;
            if (elemento is Persona persona) return persona.Id;
            return -1;
        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Persona(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}";
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Precio { get; set; }

        public Producto(int id, string name, decimal precio)
        {
            Id = id;
            Name = name;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}, Precio: €{Precio}";
        }
    }

    public class Cliente : Persona
    {
        public string Email { get; set; }

        public Cliente(int id, string name, string email) : base(id, name)
        {
            Email = email;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Email: {Email}";
        }
    }

    public class Empleado : Persona
    {
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

        public Empleado(int id, string name, string cargo, decimal salario) : base(id, name)
        {
            Cargo = cargo;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Cargo: {Cargo}, Salario: €{Salario}";
        }
    }
} 