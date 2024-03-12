using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Models.DTO;

/// <summary>
/// clase que sirve como intermediaria para no exponer el modelo y hacer validaciones
/// </summary>
public class CategoryDTO
{
    /// <summary>
    /// campo id de la categoria valor int
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// campo nombre de la categoria valor string
    /// </summary>
    [Required(ErrorMessage = "name is required")]
    public string CategoryName { get; set; }
    /// <summary>
    /// campo descripcion de la categoria valor string
    /// </summary>
    public string Description { get; set; }
}
