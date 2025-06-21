using System.ComponentModel.DataAnnotations;

namespace JugadorAPI.Models;

public class JugadorInsert
{
    [Required]
    [MaxLength(50)]
     public string Nombre { get; set; } = string.Empty;
     
    [Required]
    [MaxLength(50)]
    public string Raza { get; set; } = string.Empty;
}
