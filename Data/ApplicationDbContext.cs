using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trabajo.Models;

namespace Trabajo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

      public DbSet<Contacto> DataContactos { get; set; }
      public DbSet<Producto> DataProductos { get; set; }
}
