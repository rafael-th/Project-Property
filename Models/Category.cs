using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Models;

/// <summary>
/// clase categoria contiene solo los atributos sin mensajes 
/// </summary>
public class Category
{
    /// <summary>
    /// campo id de la categoria valor int
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// campo nombre de la categoria valor string
    /// </summary>
    [Required]
    public string CategoryName { get; set; }
    /// <summary>
    /// campo descripcion de la categoria valor string
    /// </summary>
    
    //[Required]

    public string Description { get; set; }
    /// <summary>
    /// campo fecha de creacion se instancia al momento en que se crea una categoria
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.Now;
    /// <summary>
    /// campo fecha de actualizacion se instancia al momento de hacer una actualizacion
    /// </summary>
    public DateTime CreationUpdate { get; set; } 

    /// <summary>
    /// relacion con tabla/modelo Property 
    /// </summary>
    public virtual ICollection<Property> Property { get; set; }
}
