namespace PropiedadesBlazor.Services;

/// <summary>
/// interfaz para la siembra de datos contiene el metodo para inicializar
/// </summary>
public interface IDBInitializer
{
    /// <summary>
    /// se encarga de set los campos de un administrador para la siembra de datos
    /// </summary>
    void initialize();
}