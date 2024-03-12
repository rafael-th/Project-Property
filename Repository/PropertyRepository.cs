using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Models;
using PropiedadesBlazor.Models.DTO;
using PropiedadesBlazor.Repository.IRepository;
using Property = PropiedadesBlazor.Models.Property;

namespace PropiedadesBlazor.Repository;

/// <summary>
/// Implementacion de los metodos la interface repositori
/// contiene los metodos de lectura y escritura
/// </summary>
public class PropertyRepository : IPropertyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor encargo de instanciar las dependencias del contexto
    /// y el mapper 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public PropertyRepository(ApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Instancia una propiedad pasando del modelo DTO al modelo en bd
    /// agrega la fecha de creacion al momento. y vuelve a mapear al DTO
    /// </summary>
    /// <param name="propertyDTO"></param>
    /// <returns>la propiedad agg Property en Bd ya mapeada</returns>
    public async Task<PropertyDTO> CreateProperty(PropertyDTO propertyDTO)
    {
        Property property = _mapper.Map<PropertyDTO,Property>(propertyDTO);
        property.CreationDate = DateTime.Now;
        var addProperty = await _context.AddAsync(property);
        await _context.SaveChangesAsync();
        return _mapper.Map<Property, PropertyDTO>(addProperty.Entity);        
    }

    /// <summary>
    /// Elimina una propiedad en base a su Id y las imagenes asociadas
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>la cantidad de entidades modificadas 
    /// en caso de no encontrar el id retorna 0</returns>
    public async Task<int> DeleteProperty(int propertyId)
    {
        var property = await _context.Property.FindAsync(propertyId);
        if (property != null)
        {
            var allImages = await _context.PropertyImage.Where(pi => pi.Id == propertyId).ToListAsync();
            _context.PropertyImage.RemoveRange(allImages);
            _context.Property.Remove(property);
            await _context.SaveChangesAsync();            
        }
        return 0;
    }


    /// <summary>
    /// Obtiene todas las propiedades como una coleccion incluyendo las imagenes 
    /// y las categorias 
    /// </summary>
    /// <returns>el conjunto de datos obtenidos. Nullo si no hay datos </returns>
    public async Task<IEnumerable<PropertyDTO>> GetAllProperties()
    {       
        try
        {
            IEnumerable<PropertyDTO> propertiesDTO =
                _mapper.Map<IEnumerable<Property>, IEnumerable<PropertyDTO>>(
                   await _context.Property.Include(i => i.PropertyImages)
                   .Include(c => c.category).ToListAsync());
            if (propertiesDTO != null)
                return propertiesDTO;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Obtiene una propiedad en base a su Id haciendo el mapeo para la obtencion
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>PropiedadDTO o nulo si no lo pudo encontrar</returns>
    public async Task<PropertyDTO> GetProperty(int propertyId)
    {
        try
        {
            PropertyDTO propertyDTO = _mapper.Map<Property, PropertyDTO>(
            await _context.Property.FirstOrDefaultAsync(p => p.Id == propertyId));
            
            if (propertyDTO != null)
                return propertyDTO;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Valida si ya existe una propiedad con el mismo nombre
    /// </summary>
    /// <param name="name"></param>
    /// <returns>el modelo DTO de Propiedad o Null si no existe </returns>
    public async Task<PropertyDTO> PropertyExists(string name)
    {
        try
        {
            PropertyDTO propertyDTO = _mapper.Map<Property, PropertyDTO>(
            await _context.Property.FirstOrDefaultAsync(
                p => p.Name.ToLower().Trim() == name.ToLower().Trim()));

            if (propertyDTO != null)
                return propertyDTO;
            else 
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Actualiza la propiedad por si coinciden el Id, agrega la fecha de actualizacion
    /// al momento y guarda los cambios
    /// </summary>
    /// <param name="propertyId"></param>
    /// <param name="propertyDTO"></param>
    /// <returns>la propiedad como entidad actualizada o nulo si no se pudo </returns>
    public async Task<PropertyDTO> UpdateProperty(int propertyId, PropertyDTO propertyDTO)
    {
        try
        {
            if(propertyId == propertyDTO.Id)
            {
                Property property = await _context.Property.FindAsync(propertyId);
                Property proper = _mapper.Map<PropertyDTO, Property>(propertyDTO,property);
                proper.UpdateDate = DateTime.Now;
                var updatedProperty = _context.Property.Update(proper);
                await _context.SaveChangesAsync();
                return _mapper.Map<Property, PropertyDTO>(updatedProperty.Entity);
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}
