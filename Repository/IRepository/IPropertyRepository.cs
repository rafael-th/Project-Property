using PropiedadesBlazor.Models.DTO;

namespace PropiedadesBlazor.Repository.IRepository;

/// <summary>
/// contiene los metodos de consultas al modelo propiedad
/// </summary>
public interface IPropertyRepository
{
    /// <summary>
    /// metodo que obtiene la lista de todas las propiedads
    /// </summary>
    /// <returns>lista de propiedadsDTO o null si no hay</returns>
    public Task<IEnumerable<PropertyDTO>> GetAllProperties();

    /// <summary>
    /// obtiene una propiedad por el id
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>un objeto de propiedad o null</returns>
    public Task<PropertyDTO> GetProperty(int propertyId);

    /// <summary>
    /// Crea propiedad recibiendo un objeto de propiedadDTO
    /// </summary>
    /// <param name="propertyDTO"></param>
    /// <returns>la propiedad creada o null</returns>
    public Task<PropertyDTO> CreateProperty(PropertyDTO propertyDTO);
    
    /// <summary>
    /// Actualiza una propiedad recibiendo su id y el objeto con los cambios
    /// </summary>
    /// <param name="propertyId"></param>
    /// <param name="propertyDTO"></param>
    /// <returns>la propiedad actualizada o null</returns>
    public Task<PropertyDTO> UpdateProperty(int propertyId,PropertyDTO propertyDTO);

    /// <summary>
    /// valida si la propiedad existe por el nombre
    /// </summary>
    /// <param name="name"></param>
    /// <returns>la propiedad existente o null si no se encuentra </returns>
    public Task<PropertyDTO> PropertyExists(string name);

    /// <summary>
    /// Elimina la propiedad por el id
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>la propiedad eliminada o 0 si no se pudo eliminar </returns>
    public Task<int> DeleteProperty(int propertyId);
}
