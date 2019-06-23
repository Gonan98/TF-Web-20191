using Estacionamiento.Domain;
using Microsoft.EntityFrameworkCore;
using System;

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
         public DbSet<Comprobante> Comprobantes {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //Write Fluent API configurations here

        //Property Configurations
        modelBuilder.Entity<Ingreso>().Property(s => s.Placa).IsRequired();
        modelBuilder.Entity<Ingreso>().Property(s => s.HInicio).IsRequired();
        modelBuilder.Entity<PuntoAtencion>().HasData(
            new PuntoAtencion{Id=1,Ubicacion="Nivel 1"},
            new PuntoAtencion{Id=2,Ubicacion="Nivel 2"}


        );
        modelBuilder.Entity<Cajero>().HasData(
             new Cajero{Id=1,NombreCajero="PEPE",PuntoAtencionId=1,TurnoCajero="Noche",ApellidoCajero="Luis",FechaIngreso=Convert.ToDateTime("2019-06-13")},
            new Cajero{Id=2,NombreCajero="LUCHO",PuntoAtencionId=1,TurnoCajero="Tarde",ApellidoCajero="Caldas",FechaIngreso=Convert.ToDateTime("2019-06-12")}


        );
        }

    

    }
}