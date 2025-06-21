using JugadorAPI.Helpers;
using JugadorAPI.Models;
using JugadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JugadorAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JugadorController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Jugador>> GetJugadores()
    {
        return JugadorDataStore.Current.Jugadores;
    }

    [HttpGet("{jugadorID}")]
    public ActionResult<Jugador> GetJugador(int jugadorID)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        return Ok(jugador);
    }

    [HttpPost]
    public ActionResult<Jugador> PostJugador(JugadorInsert jugadorInsert)
    {
        var maxJugadorID = JugadorDataStore.Current.Jugadores.Max(x => x.ID);

        var jugadorNuevo = new Jugador()
        {
            ID = maxJugadorID + 1,
            Nombre = jugadorInsert.Nombre,
            Raza = jugadorInsert.Raza
        };

        JugadorDataStore.Current.Jugadores.Add(jugadorNuevo);

        return CreatedAtAction(nameof(GetJugador),
        new { jugadorID = jugadorNuevo.ID },
        jugadorNuevo
        );
    }

    [HttpPut("{jugadorID}")]
    public ActionResult<Jugador> PutJugador(int jugadorID, JugadorInsert jugadorInsert)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        jugador.Nombre = jugadorInsert.Nombre;
        jugador.Raza = jugadorInsert.Raza;

        return NoContent();
    }

    [HttpDelete("{jugadorID}")]
    public ActionResult<Jugador> DeleteJugador(int jugadorID)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        JugadorDataStore.Current.Jugadores.Remove(jugador);

        return NoContent();
    }
}
