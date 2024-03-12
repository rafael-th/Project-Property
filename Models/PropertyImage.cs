using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Models;

/// <summary>
/// relacion propiedades con las imagenes 
/// </summary>
public class PropertyImage
{
    /// <summary>
    /// PK autoincremental para relacionar las imagenes
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// FK con la tabla propiedad
    /// </summary>
    public int PropertyId { get; set; }
    
    /// <summary>
    /// ruta de la imagen que se guarda en un directorio
    /// </summary>
    public string UrlImageProperty { get; set; }

    /// <summary>
    /// relacion con la tabla propiedad
    /// </summary>
    [ForeignKey("PropertyId")]
    public virtual Property Property { get; set; }
}
