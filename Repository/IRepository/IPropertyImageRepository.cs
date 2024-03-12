using PropiedadesBlazor.Models.DTO;

namespace PropiedadesBlazor.Repository.IRepository;
/// <summary>
/// 
/// </summary>
public interface IPropertyImageRepository
{
    /// <summary>
    /// Añade la imagen a la creacion de la propiedad
    /// </summary>
    /// <param name="propertyImageDTO"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public Task<int> CreatePropertyWithImage(PropertyImageDTO propertyImageDTO);

    /// <summary>
    /// elimina una imagen por su id eliminando unicamente esa imagen
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public Task<int> DeleteImagePropertyByImageId(int imageId);

    /// <summary>
    /// elimina una imagen por el id de la propiedad si elimina la propiedad
    /// las imagenes tambien deben ser eliminadas
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public Task<int> DeleteImagePropertyByPropertyId(int propertyId);

    /// <summary>
    /// elimina una imagen por su url
    /// </summary>
    /// <param name="urlImage"></param>
    /// <returns>cantidad de entradas escritas en bd o 0 caso contrario</returns>
    public Task<int> DeleteImagePropertyByUrlImage(string urlImage);

    /// <summary>
    /// trae la lista de imagenes de la propiedad
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns>la lista de imagenes encontradas o null en caso contrario</returns>
    public Task<IEnumerable<PropertyImageDTO>> GetPropertyImages(int propertyId);
}