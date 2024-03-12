using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Models;

namespace PropiedadesBlazor.Data;
/// <summary>
/// contiene las clases/tablas que se van a usar para las consultas
/// </summary>
public class ApplicationDbContext : IdentityDbContext
{
    /// <summary>
    /// Contexto de datos para la aplicacion
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //ADD Models

    /// <summary>
    /// Contexto de la tabla/modelo Categoria
    /// </summary>
    public DbSet<Category> Category { get; set; }

    /// <summary>
    /// Contexto de la tabla/modelo Propiedad
    /// </summary>
    public DbSet<Property> Property { get; set; }

    /// <summary>
    /// contexto de la tabla/modelo Imagen propiedad
    /// </summary>
    public DbSet<PropertyImage> PropertyImage {  get; set; }

}
