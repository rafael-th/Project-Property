using Microsoft.AspNetCore.Components.Forms;

namespace PropiedadesBlazor.Services;

/// <summary>
/// Implementa los metodos para subir archivo y eliminarlos
/// </summary>
public class UploadFiles : IUploadFiles
{
    private readonly IWebHostEnvironment _webHostenvironment;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// inyecta los servicios IWebHostEnvironment e IConfiguration 
    /// </summary>
    /// <param name="webHostenvironment"></param>
    /// <param name="configuration"></param>
    public UploadFiles(IWebHostEnvironment webHostenvironment, IConfiguration configuration)
    {
        _webHostenvironment = webHostenvironment;
        _configuration = configuration;
    }

    /// <summary>
    /// elimina el archivo mediante la ruta 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>true si la operacion fue exitosa o false caso contrario</returns>
    public bool DeleteFile(string fileName)
    {
        try
        {
            var path = $"{_webHostenvironment.WebRootPath}\\{fileName}";
            
            if (File.Exists(path)) 
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Guarda el nombre del archivo mas su extension concatenandole
    /// un guid, evitando nombres repetidos
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<string> uploadFiles(IBrowserFile file)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var folderDirectory = $"{_webHostenvironment.WebRootPath}\\PropertiesImages";
            var path = Path.Combine(_webHostenvironment.WebRootPath, "PropertiesImages", fileName);

            MemoryStream memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);

            //si no existiera el directorio lo crea en tiempo de ejecucion
            if(!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            
            await using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }

            var url = $"{_configuration.GetValue<string>("ServerUrl")}";
            var fullPath = $"{url}PropertiesImages/{fileName}";
            return fullPath;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
