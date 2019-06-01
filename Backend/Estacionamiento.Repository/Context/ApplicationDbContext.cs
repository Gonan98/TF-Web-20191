using Estacionamiento.Domain;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Repository.Context
{
    public class ApplicationDbContext: DbContext
    {
         public DbSet<Estacionamientos> estacionamientos { get; set; }
          public DbSet<Localizacion> localizaciones { get; set; }
            public DbSet<Cajero> cajeros { get; set; }
            public DbSet<Ingreso> Ingresos{get;set;}
            public DbSet<Comprobante> Comprobantes{get; set;}

          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Write Fluent API configurations here

        //Property Configurations
        modelBuilder.Entity<Ingreso>().Property(s => s.Placa).IsRequired();
        modelBuilder.Entity<Ingreso>().Property(s => s.HInicio).IsRequired();

        modelBuilder.Entity<Comprobante>().Property(s => s.cod_ingreso).IsRequired();
        modelBuilder.Entity<Comprobante>().Property(s => s.horaFin).IsRequired();
    }

    

    }
}