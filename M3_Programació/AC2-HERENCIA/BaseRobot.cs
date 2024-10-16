public class BaseRobot
{
    public string Nombre { get; set; }
    public int TipoUnidad { get; set; }
    public int NivelBateria { get; set; }

    public BaseRobot(string nombre, int tipoUnidad, int nivelBateria)
    {
        Nombre = nombre;
        TipoUnidad = tipoUnidad;
        NivelBateria = nivelBateria;
    }
}
