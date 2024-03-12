using Microsoft.JSInterop;

namespace PropiedadesBlazor.Helpers;

/// <summary>
/// ayuda con las notificaciones globales de la app
/// </summary>
public static class IJsHelper
{
    /// <summary>
    /// muestra un mensaje satisfactorio despues de realizar alguna operacion
    /// </summary>
    /// <param name="JSRuntime"></param>
    /// <param name="message"></param>
    /// <returns>el mensaje satisfactorio en notificacion</returns>
    public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr","success",message);
    }

    /// <summary>
    /// muestra un mensaje de error despues de realizar alguna operacion
    /// </summary>
    /// <param name="JSRuntime"></param>
    /// <param name="message"></param>
    /// <returns>el mensaje de error en notificacion</returns>
    public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }
}
