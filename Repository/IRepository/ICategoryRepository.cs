using PropiedadesBlazor.Models.DTO;

namespace PropiedadesBlazor.Repository.IRepository;

/// <summary>
/// contiene los metodos de consultas al modelo categoria
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// metodo que obtiene la lista de todas las categorias
    /// </summary>
    /// <returns>lista de categoriasDTO o null si no hay</returns>
    public Task<IEnumerable<CategoryDTO>> GetAllCategories();

    /// <summary>
    /// obtiene una categoria por el id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns>un objeto de categoria o null</returns>
    public Task<CategoryDTO> GetCategory(int categoryId);

    /// <summary>
    /// Crea categoria recibiendo un objeto de categoriaDTO
    /// </summary>
    /// <param name="categoryDTO"></param>
    /// <returns>la categoria creada o null</returns>
    public Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
    
    /// <summary>
    /// Actualiza una categoria recibiendo su id y el objeto con los cambios
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="categoryDTO"></param>
    /// <returns>la categoria actualizada</returns>
    public Task<CategoryDTO> UpdateCategory(int categoryId,CategoryDTO categoryDTO);

    /// <summary>
    /// valida si la categoria existe por el nombre
    /// </summary>
    /// <param name="name"></param>
    /// <returns>la categoria existente o null si no se encuentra </returns>
    public Task<CategoryDTO> CategoryExists(string name);

    /// <summary>
    /// Elimina la categoria por el id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns>la categoria eliminada o 0 si no se pudo eliminar </returns>
    public Task<int> DeleteCategory(int categoryId);

    /// <summary>
    /// muestra en la lista desplegable todas las categorias
    /// </summary>
    /// <returns>la lista de categoriasDTO o nulo si no existen categorias</returns>
    public Task<IEnumerable<DropDownCategoryDTO>> GetDropDownCategories();
}
