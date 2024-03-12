using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Models.DTO;

/// <summary>
/// 
/// </summary>
public class PropertyImageDTO
{
    /// <summary>
    /// PK autoincremental para relacionar las imagenes DTO
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// FK con la tabla propiedad DTO
    /// </summary>
    public int PropertyId { get; set; }

    /// <summary>
    /// ruta de la imagen que se guarda en un directorio DTO
    /// </summary>
    public string UrlImageProperty { get; set; }
   
}
