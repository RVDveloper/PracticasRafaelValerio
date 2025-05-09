# API Web con ASP.NET Core y Persistencia en SQLite

## Descripción

Este proyecto es una API web desarrollada con ASP.NET Core, que utiliza **persistencia de datos con SQLite** y expone un modelo personalizado llamado `Producto`. La API permite gestionar productos mediante endpoints RESTful y está documentada y testeable a través de Swagger.

---

## Modelo de datos

El modelo principal del proyecto es `Producto`, definido en `Models/Producto.cs`:

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
}
```

---

## Endpoints disponibles

El controlador principal es `ProductoController` (`Controllers/ProductoController.cs`). Los endpoints implementados son:

- **GET /api/producto**  
  Obtiene la lista de todos los productos.

- **GET /api/producto/{id}**  
  Obtiene un producto por su identificador.

- **POST /api/producto**  
  Crea un nuevo producto.  
  Requiere un objeto JSON con los campos: `nombre`, `descripcion`, `precio`.

- **PUT /api/producto/{id}**  
  Actualiza un producto existente.  
  Requiere un objeto JSON con los campos a modificar.

- **DELETE /api/producto/{id}**  
  Elimina un producto por su identificador.

---

## Configuración de la base de datos y servicios

En `Program.cs` se ha configurado la inyección de dependencias y la persistencia con SQLite:

```csharp
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

La cadena de conexión se encuentra en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "DataSource=todo.db"
}
```

---

## Uso de Swagger

La API está documentada y puede probarse fácilmente accediendo a la interfaz Swagger en:

```
http://localhost:5063/swagger/index.html
```

---

## Cómo ejecutar el proyecto

1. Restaura los paquetes y dependencias:

   ```
   dotnet restore
   ```

2. Ejecuta las migraciones (si no lo has hecho):

   ```
   dotnet-ef database update
   ```

3. Inicia la API:

   ```
   dotnet run
   ```

4. Accede a Swagger para probar los endpoints.
