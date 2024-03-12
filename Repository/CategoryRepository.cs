using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Mapper;
using PropiedadesBlazor.Models;
using PropiedadesBlazor.Models.DTO;
using PropiedadesBlazor.Repository.IRepository;

namespace PropiedadesBlazor.Repository;

/// <summary>
/// Clase encargada de aplicar los metodos de la interfaz para las operaciones de consultas
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// inyecta el contexto y el mapper en el ctor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public CategoryRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// valida que el nombre en bd coincida con el parametro recibido para ver si existe la categoria
    /// </summary>
    /// <param name="name"></param>
    /// <returns>la categoria encontrada o null</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<CategoryDTO> CategoryExists(string name)
    {
        try
        {
            CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(
                await _context.Category.FirstOrDefaultAsync(
                    c => c.CategoryName.ToLower().Trim() == name.ToLower().Trim()));
            if (categoryDTO != null)
                return categoryDTO;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// crea una categoria a partir del objeto dto y pasando el mapper
    /// </summary>
    /// <param name="categoryDTO"></param>
    /// <returns></returns>
    public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
    {
        Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
        category.CreationDate = DateTime.Now;
        var createdCategory = await _context.Category.AddAsync(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDTO>(createdCategory.Entity);
    }

    /// <summary>
    /// elimina una categoria en base a su Id 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns>la categoria eliminada o nulll</returns>
    public async Task<int> DeleteCategory(int categoryId)
    {
        var category = await _context.Category.FindAsync(categoryId);
        if(category != null)
        {
            _context.Remove(category);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }

    /// <summary>
    /// obtiene una lista de categorias
    /// </summary>
    /// <returns>una lista de categorias o null</returns>
    public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
    {
        try
        {
            IEnumerable<CategoryDTO> categoriesDTO =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(await _context.Category.ToListAsync());
            
            if (categoriesDTO != null)
                return categoriesDTO;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Obtine la categoria unica mediante el su Id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns>la categoria encontrada o null</returns>
    public async Task<CategoryDTO> GetCategory(int categoryId)
    {
        try
        {
            CategoryDTO categoryDTO =
                _mapper.Map<Category, CategoryDTO>(await _context.Category.
                FirstOrDefaultAsync(c => c.Id == categoryId));
            if(categoryDTO != null)
                return categoryDTO;
            else 
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    /// <summary>
    /// muestra la lista de categorias en un dropdown
    /// </summary>
    /// <returns>la lista de categorias o nulo si no tiene registros</returns>
    public async Task<IEnumerable<DropDownCategoryDTO>> GetDropDownCategories()
    {
        try
        {
            IEnumerable<DropDownCategoryDTO> dropDownCategoryDTO =
                _mapper.Map<IEnumerable<Category>, IEnumerable<DropDownCategoryDTO>>(await _context.Category.ToListAsync());
            
            if (dropDownCategoryDTO != null)
                return dropDownCategoryDTO;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// si se encuentra la categoria con el id actualiza el objeto Categoria haciendo el autoMapeo
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="categoryDTO"></param>
    /// <returns>la entidad actualizada o null</returns>
    public async Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDTO)
    {
        try
        {
            if (categoryId == categoryDTO.Id)
            {
                Category category = await _context.Category.FindAsync(categoryId);
                Category cate = _mapper.Map<CategoryDTO, Category>(categoryDTO, category);
                cate.CreationUpdate = DateTime.Now;
               
                var updatedCategory = _context.Category.Update(cate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(updatedCategory.Entity);
            }
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    
}
