using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Models.DTO;

/// <summary>
/// DTO del modelo propiedad con los atributos a mostrar al cliente
/// </summary>
public class PropertyDTO
{
    /// <summary>
    /// Campo Id clave foranea auto-incremental
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Campo Nombre de la Propiedad
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30,MinimumLength =5, ErrorMessage = "The name must be between 5 and 30 characters")]
    public string Name { get; set; }

    /// <summary>
    /// Campo descripcion de la propiedad
    /// </summary>
    [Required(ErrorMessage = "Description is mandatory")]
    [StringLength(300, MinimumLength = 20, ErrorMessage = "The description must be between 20 and 300 characters")]
    public string Description { get; set; }

    /// <summary>
    /// Campo Area m2 de la propiedad
    /// </summary>
    [Required(ErrorMessage = "The area is mandatory")]
    [Range(1, 5000, ErrorMessage = "you must enter a valid number")]
    public int Area { get; set; }

    /// <summary>
    /// Campo Habitaciones de la propiedad
    /// </summary>
    [Required(ErrorMessage = "The bedrooms is mandatory")]
    [Range(1, 10, ErrorMessage = "you must enter a valid number")]

    public int bedrooms { get; set; }

    /// <summary>
    /// Campo Baños que tiene la propiedad
    /// </summary>
    [Required(ErrorMessage = "Bathrooms are mandatory")]
    [Range(1, 5, ErrorMessage = "you must enter a valid number")]
    public int bathrooms { get; set; }

    /// <summary>
    /// Campo Parqueadero que tiene de la propiedad
    /// </summary>
    [Required(ErrorMessage = "Parkin is mandatory")]
    [Range(1, 20, ErrorMessage = "you must enter a valid number")]
    public int parking { get; set; }

    /// <summary>
    /// Campo precio de la propiedad
    /// </summary>
    [Required(ErrorMessage ="The price is mandatory")]
    public double Price { get; set; }

    /// <summary>
    /// Campo Activo de la propiedad
    /// </summary>
    [Required]
    public bool Active { get; set; }

    /// <summary>
    /// Campo fecha de actualizacion de la propiedad
    /// </summary>    
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Campo que sirve como FK con la tabla Categoria
    /// </summary>
    public int CategoriaId { get; set; }

    /// <summary>
    /// acceso a la categoria desde el DTO para el Dropdown
    /// </summary>
    public virtual Category category { get; set; }


    /// <summary>
    /// lista de imagenes de una propiedad
    /// </summary>
    public virtual ICollection<PropertyImage> PropertyImages { get; set; }

    /// <summary>
    /// la direccion de la ubicacion de las imagenes
    /// </summary>
    public List<string> UrlImages { get; set; }
}
