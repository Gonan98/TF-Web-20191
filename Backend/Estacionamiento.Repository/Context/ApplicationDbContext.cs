using Estacionamiento.Domain;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Repository.Context
{
    public class ApplicationDbContext: DbContext
    {
         public DbSet<Estacionamientos> estacionamientos { get; set; }
         public DbSet<Localizacion> Localizaciones { get; set; }
         public DbSet<Cajero> Cajeros { get; set; }
         public DbSet<Ingreso> Ingresos{get;set;}
         public DbSet<Tarifa> Tarifas {get; set;}
         public DbSet<Espacio> Espacios {get; set;}
         public DbSet<PuntoAtencion> PuntoAtenciones {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //Write Fluent API configurations here

        //Property Configurations
        modelBuilder.Entity<Ingreso>().Property(s => s.Placa).IsRequired();
        modelBuilder.Entity<Ingreso>().Property(s => s.HInicio).IsRequired();
        }

    

    }
}