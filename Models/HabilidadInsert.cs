using static JugadorAPI.Models.Habilidad;

namespace JugadorAPI.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
}
