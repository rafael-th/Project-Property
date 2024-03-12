using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;

namespace PropiedadesBlazor.Services;

/// <summary>
/// Clase encargada de implementar los metodos para inicializar
/// los roles y las credenciales de los usuarios para la siembra de datos
/// </summary>
public class DBInitializer : IDBInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    /// <summary>
    /// constructor de la clase Initializer, inyecta las dependencias 
    /// del contexto, el user y el rol.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userManager"></param>
    /// <param name="roleManager"></param>
    public DBInitializer(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// se encarga de validar primero si hay migraciones pendientes.
    /// setea las propiedades del usuario en la simebra de datos
    /// </summary>
    public void initialize()
    {
        try
        {
            if (_context.Database.GetPendingMigrations().Count() > 0)
                _context.Database.Migrate();
        }
        catch (Exception)
        {

        }

        if (_context.Roles.Any(r => r.Name == Settings.Rol_Administrator)) return;

        _roleManager.CreateAsync(new IdentityRole(Settings.Rol_Administrator)).GetAwaiter().GetResult();

        _userManager.CreateAsync(new IdentityUser
        {
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true,
        }, "Sadmin123$").GetAwaiter().GetResult();

        IdentityUser user = _context.Users.FirstOrDefault(u => u.Email == "superadmin@gmail.com");
        _userManager.AddToRoleAsync(user, Settings.Rol_Administrator).GetAwaiter().GetResult();
    }
}
