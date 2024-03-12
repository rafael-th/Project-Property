using Microsoft.AspNetCore.Components.Forms;

namespace PropiedadesBlazor.Services;

/// <summary>
/// servicio para subir o eliminar los archivos
/// </summary>
public interface IUploadFiles
{
    /// <summary>
    /// sube las imagenes-archivos a la propiedad
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<string> uploadFiles(IBrowserFile file);

    /// <summary>
    /// elimina el archivo-imagen por el nombre del archivo
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    bool DeleteFile(string fileName);
}
