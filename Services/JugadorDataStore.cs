using JugadorAPI.Models;

namespace JugadorAPI.Services;

public class JugadorDataStore
{
    public List<Jugador> Jugadores { get; set; }

    public static JugadorDataStore Current { get; } = new JugadorDataStore();

    public JugadorDataStore()
    {
        Jugadores = new List<Jugador>()
        {
            new Jugador()
            {
                ID = 1,
                Nombre = "Zarduk",
                Raza = "Orco",
                Habilidades = new List<Habilidad>()
                {
                    new Habilidad()
                    {
                        ID = 1,
                        Nombre = "Golpe Brutal",
                        Potencia = Habilidad.EPotencia.Alto
                    }
                }
            },
            new Jugador()
            {
                ID = 2,
                Nombre = "Aeliria",
                Raza = "Elfa",
                Habilidades = new List<Habilidad>()
                {
                    new Habilidad()
                    {
                        ID = 1,
                        Nombre = "Flecha de Luz",
                        Potencia = Habilidad.EPotencia.Moderado
                    },
                    new Habilidad()
                    {
                        ID = 2,
                        Nombre = "Curación Rápida",
                        Potencia = Habilidad.EPotencia.Bajo
                    },
                    new Habilidad()
                    {
                        ID = 3,
                        Nombre = "Escudo Arcano",
                        Potencia = Habilidad.EPotencia.Moderado
                    }
                }
            },
            new Jugador()
            {
                ID = 3,
                Nombre = "Thorg",
                Raza = "Humano",
                Habilidades = new List<Habilidad>()
                {
                    new Habilidad()
                    {
                        ID = 1,
                        Nombre = "Espadazo",
                        Potencia = Habilidad.EPotencia.Moderado
                    },
                    new Habilidad()
                    {
                        ID = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.EPotencia.Bajo
                    },
                    new Habilidad()
                    {
                        ID = 3,
                        Nombre = "Empuje",
                        Potencia = Habilidad.EPotencia.Moderado
                    }
                }
            }
        };
    }
}
