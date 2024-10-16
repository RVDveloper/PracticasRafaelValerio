public class DroideCombate : BaseRobot
{
    public int NivelPotenciaFuego { get; set; }
    public int CombatesParticipados { get; }

    public DroideCombate(string nombre, int tipoUnidad, int nivelBateria, int nivelPotenciaFuego)
        : base(nombre, tipoUnidad, nivelBateria)
    {
        NivelPotenciaFuego = nivelPotenciaFuego;
        CombatesParticipados = new Random().Next(0, 100); 
    }

    public int ObtenerCombates()
    {
        return CombatesParticipados;
    }
}