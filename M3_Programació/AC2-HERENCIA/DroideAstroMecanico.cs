public class DroideAstroMecanico : BaseRobot
{
    public DateTime UltimaReparacion { get; }
    public int NavesReparadas { get; }

    public DroideAstroMecanico(string nombre, int tipoUnidad, int nivelBateria, DateTime ultimaReparacion)
        : base(nombre, tipoUnidad, nivelBateria)
    {
        UltimaReparacion = ultimaReparacion;
        NavesReparadas = new Random().Next(0, 100); 
    }

    public int ObtenerNavesReparadas()
    {
        return NavesReparadas;
    }
}