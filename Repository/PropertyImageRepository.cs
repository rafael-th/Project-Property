using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Models;
using PropiedadesBlazor.Models.DTO;
using PropiedadesBlazor.Repository.IRepository;

namespace PropiedadesBlazor.Repository;

/// <summary>
/// implementacion de los metodos de lectura y escritura 
/// sobre la entidad propiedaImagenes
/// </summary>
public class PropertyImageRepository : IPropertyImageRepository
{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// constructor encargado de inyectar las dependencias de la bd y automapper
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public PropertyImageRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// mapeo la imagen del DTO al modelo real y se agrega a bd
    /// </summary>
    /// <param name="propertyImageDTO"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public async Task<int> CreatePropertyWithImage(PropertyImageDTO propertyImageDTO)
    {
        var createdImage = _mapper.Map<PropertyImageDTO,PropertyImage>(propertyImageDTO);
        
        if (createdImage != null)
        {
            await _context.PropertyImage.AddAsync(createdImage);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }

    /// <summary>
    /// Elimina la imagen de la propiedad por Id 
    /// si el objeto encontrado no se nulo y guarda cambios en bd
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public async Task<int> DeleteImagePropertyByImageId(int imageId)
    {
        var deletedImageById = await _context.PropertyImage.FindAsync(imageId);

        if (deletedImageById != null)
        {
            _context.PropertyImage.Remove(deletedImageById);
            return await _context.SaveChangesAsync();
        }
        return 0;    
    }

    /// <summary>
    /// Elimina la lista de imagenes asociadas a una propiedad
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public async Task<int> DeleteImagePropertyByPropertyId(int propertyId)
    {
        var imagesAssociatedWithProperty = await _context.PropertyImage.Where(
            i => i.PropertyId == propertyId).ToListAsync();

        if (imagesAssociatedWithProperty != null)
        {
            _context.PropertyImage.RemoveRange(imagesAssociatedWithProperty);
            return await _context.SaveChangesAsync();
        }
        return 0;   
    }

    /// <summary>
    /// Elimina la imagen de la propiedad por su Url 
    /// si el objeto encontrado no se nulo y guarda cambios en bd
    /// </summary>
    /// <param name="urlImage"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public async Task<int> DeleteImagePropertyByUrlImage(string urlImage)
    {
        var deletedImageByUrl = await _context.PropertyImage.FirstOrDefaultAsync(
            i => i.UrlImageProperty.ToLower().Trim() == urlImage.ToLower().Trim());
        
        if(deletedImageByUrl != null)
        {
            _context.PropertyImage.Remove(deletedImageByUrl);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }

    /// <summary>
    /// Obtiene una lista de imagenesPropiedadDTO 
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>la lista de imagenes encontradas o null en caso contrario</returns>
    public async Task<IEnumerable<PropertyImageDTO>> GetPropertyImages(int propertyId)
    {
        var propertyImagesList = await _context.PropertyImage.Where(i => i.PropertyId == propertyId).ToListAsync();

        if (propertyImagesList != null)
            return _mapper.Map<IEnumerable<PropertyImage>, IEnumerable<PropertyImageDTO>>(propertyImagesList);
        return null;

        //otra forma de hacer 
        //return _mapper.Map<IEnumerable<PropertyImage>, IEnumerable<PropertyImageDTO>>(await _context.PropertyImage.Where(i => i.PropertyId == propertyId).ToListAsync());
    }
}
