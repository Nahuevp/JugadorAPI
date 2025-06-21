namespace JugadorAPI.Models;

public class Habilidad
{
    public int ID { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }

    public enum EPotencia
    {
        Bajo,
        Moderado,
        Alto,
        Épico,
        Legendario
    }
}
