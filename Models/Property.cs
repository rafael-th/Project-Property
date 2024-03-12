using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Models;

/// <summary>
/// Tabla de Propiedades en la bd
/// </summary>
public class Property
{
    /// <summary>
    /// Campo Id clave foranea auto-incremental
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Campo Nombre de la Propiedad
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Campo descripcion de la propiedad
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Campo Area de la propiedad
    /// </summary>
    [Required]
    public int Area { get; set; }

    /// <summary>
    /// Campo Habitaciones de la propiedad
    /// </summary>
    [Required]
    public int bedrooms { get; set; }

    /// <summary>
    /// Campo Baños que tiene la propiedad
    /// </summary>
    [Required]
    public int bathrooms{ get; set; }

    /// <summary>
    /// Campo Parqueadero que tiene de la propiedad
    /// </summary>
    [Required]
    public int parking { get; set; }

    /// <summary>
    /// Campo precio de la propiedad
    /// </summary>
    [Required]
    public double Price { get; set; }

    /// <summary>
    /// Campo Activo de la propiedad
    /// </summary>
    [Required]
    public bool Active { get; set; }

    /// <summary>
    /// Campo fecha de creacion de la propiedad
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Campo fecha de actualizacion de la propiedad
    /// </summary>
    public DateTime UpdateDate { get; set; }


    /// <summary>
    /// Campo que sirve como FK con la tabla Categoria
    /// </summary>
    public int CategoriaId { get; set; }
    /// <summary>
    /// campo relacionado con la tabla Categoria
    /// </summary>
    [ForeignKey("CategoriaId")]
    public virtual Category category { get; set; }

    /// <summary>
    /// lista de imagenes de una propiedad
    /// </summary>
    public virtual ICollection<PropertyImage> PropertyImages { get; set; }
}
