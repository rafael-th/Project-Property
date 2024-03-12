namespace PropiedadesBlazor.Models.DTO;

/// <summary>
/// Lista desplegable que muestra las categorias en la seccion propiedades 
/// </summary>
public class DropDownCategoryDTO
{
    /// <summary>
    /// identificador unico sirve como value en el option de un select
    /// debe tener el mismo nombre que en la entidad Category
    /// representa el Id de la categoria
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// nombre a mostrar de la categoria en la etiqueta option
    /// debe tener el mismo nombre que en la entidad Category
    /// </summary>
    public string CategoryName { get; set; }
}
