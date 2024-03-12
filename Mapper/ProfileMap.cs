using AutoMapper;
using PropiedadesBlazor.Models;
using PropiedadesBlazor.Models.DTO;

namespace PropiedadesBlazor.Mapper;

/// <summary>
/// Mapeo de los modelos ej: modeloCategory con ModeloCategoryDTO y en reversa
/// </summary>
public class ProfileMap : Profile
{
    /// <summary>
    /// Constructor. se encarga de mapear los modelos 
    /// </summary>
    public ProfileMap()
    {
        CreateMap<CategoryDTO,Category>().ReverseMap();
        CreateMap<Property,PropertyDTO>().ReverseMap();
        CreateMap<Category, DropDownCategoryDTO>().ReverseMap();
        CreateMap<PropertyImage, PropertyImageDTO>().ReverseMap();
    }

}
