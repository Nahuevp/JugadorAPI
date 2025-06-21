using JugadorAPI.Helpers;
using JugadorAPI.Models;
using JugadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JugadorAPI.Controllers;

[ApiController]
[Route("api/jugador/{jugadorID}/[controller]")]
public class HabilidadController : ControllerBase
{
    // GET: api/jugador/1/habilidad
    // Devuelve todas las habilidades del jugador indicado por ID
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int jugadorID)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        return Ok(jugador.Habilidades);
    }

    // GET: api/jugador/1/habilidad/2
    // Devuelve una habilidad específica de un jugador
    [HttpGet("{habilidadID}")]
    public ActionResult<Habilidad> GetHabilidad(int jugadorID, int habilidadID)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        var habilidad = jugador.Habilidades?.FirstOrDefault(h => h.ID == habilidadID);
        if (habilidad == null)
            return NotFound(Mensajes.Habilidad.NotFound);

        return Ok(habilidad);
    }

    // POST: api/jugador/1/habilidad
    // Crea una nueva habilidad para un jugador
    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int jugadorID, HabilidadInsert habilidadInsert)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        // Validar si ya existe una habilidad con el mismo nombre
        var habilidadExistente = jugador.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);
        if (habilidadExistente != null)
            return BadRequest(Mensajes.Habilidad.NombreExistente);

        // Obtener nuevo ID
        var maxHabilidad = jugador.Habilidades.Any() ? jugador.Habilidades.Max(h => h.ID) : 0;

        var habilidadNueva = new Habilidad()
        {
            ID = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia
        };

        jugador.Habilidades.Add(habilidadNueva);

        return CreatedAtAction(nameof(GetHabilidad),
            new { jugadorID = jugadorID, habilidadID = habilidadNueva.ID },
            habilidadNueva
        );
    }

    // PUT: api/jugador/1/habilidad/2
    // Actualiza una habilidad existente del jugador
    [HttpPut("{habilidadID}")]
    public ActionResult<Habilidad> PutHabilidad(int jugadorID, int habilidadID, HabilidadInsert habilidadInsert)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        // Buscar la habilidad a actualizar
        var habilidadExistente = jugador.Habilidades?.FirstOrDefault(h => h.ID == habilidadID);
        if (habilidadExistente == null)
            return BadRequest(Mensajes.Habilidad.NotFound);

        // Validar si hay otra habilidad con el mismo nombre (distinto ID)
        var habilidadMismoNombre = jugador.Habilidades?.FirstOrDefault(h => h.ID != habilidadID && h.Nombre == habilidadInsert.Nombre);
        if (habilidadMismoNombre != null)
            return BadRequest(Mensajes.Habilidad.NombreExistente);

        // Actualizar valores
        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

        return NoContent();
    }

    // DELETE: api/jugador/1/habilidad/2
    // Elimina una habilidad específica de un jugador
    [HttpDelete("{habilidadID}")]
    public ActionResult<Habilidad> DeleteHabilidad(int jugadorID, int habilidadID)
    {
        var jugador = JugadorDataStore.Current.Jugadores.FirstOrDefault(x => x.ID == jugadorID);

        if (jugador == null)
            return NotFound(Mensajes.Jugador.NotFound);

        var habilidadExistente = jugador.Habilidades?.FirstOrDefault(h => h.ID == habilidadID);
        if (habilidadExistente == null)
            return BadRequest(Mensajes.Habilidad.NotFound);

        jugador.Habilidades?.Remove(habilidadExistente);

        return NoContent();
    }
}
