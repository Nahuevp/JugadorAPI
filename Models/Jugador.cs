namespace JugadorAPI.Models;

public class Jugador
{
    public int ID { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Raza { get; set; } = string.Empty;

    public List<Habilidad>? Habilidades { get; set; } = new List<Habilidad>();
}
