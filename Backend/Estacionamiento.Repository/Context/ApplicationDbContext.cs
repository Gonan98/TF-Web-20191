using Estacionamiento.Domain;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Repository.Context
{
    public class ApplicationDbContext: DbContext
    {
         public DbSet<Estacionamientos> estacionamientos { get; set; }
          public DbSet<Localizacion> localizaciones { get; set; }

          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

    

    }
}