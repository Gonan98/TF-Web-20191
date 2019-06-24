
using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;
using System.Linq;
using Estacionamiento.Repository.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Repository.implementacion
{
    
    public class IngresoRepository : IIngresoRepository
    {
        private ApplicationDbContext context;
        public IngresoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
       public bool Delete(int id)
        {
            var rpta=false;
            
           try
           {
             var aux=context.Ingresos.Single(x=>x.Id==id);
             context.Ingresos.Remove(aux);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }

        public IngresoViewModel FindByPlaca(string Placa)
        {
            var ingreso = context.Ingresos.Include(m=>m.Tarifa).Include(m=>m.Espacio).
            SingleOrDefault(x=>x.Placa.Trim().ToLower()==Placa.Trim().ToLower());
            
            var dto=new IngresoViewModel{
                    Id=ingreso.Id,
                    ApellidoCajero="",
                    NombreCajero="",
                    Espacio=ingreso.Espacio,
                    Tarifa=ingreso.Tarifa,
                    Placa=ingreso.Placa,
                    HInicio=ingreso.HInicio
            };
            return dto;
            
        }

        public Ingreso Get(int id)
        {
             throw new System.NotImplementedException ();
        }

        public IEnumerable<Ingreso> GetAll()
        {
             throw new System.NotImplementedException ();
        }

        public IEnumerable<IngresoViewModel> Getall()
        {
            var ingreso=context.Ingresos.Include(m=>m.Cajero).Include(m=>m.Espacio.Estacionamientos.Localizacion)
            .Include(m=>m.Tarifa).ToList();
            return ingreso.Select(o=> new IngresoViewModel{
                Id=o.Id,
                ApellidoCajero=o.Cajero.ApellidoCajero,
                NombreCajero=o.Cajero.NombreCajero,
                Tarifa=o.Tarifa,
                HInicio=o.HInicio,
                Espacio=o.Espacio,
                Placa=o.Placa
            });
        }

        public IngresoViewModel Getid(int id)
        {
            var ingreso=context.Ingresos.Single(x=>x.Id==id);
            return  new IngresoViewModel{
                Id=ingreso.Id,
                ApellidoCajero=ingreso.Cajero.ApellidoCajero,
                NombreCajero=ingreso.Cajero.NombreCajero,
                Tarifa=ingreso.Tarifa,
                HInicio=ingreso.HInicio,
                Espacio=ingreso.Espacio,
                Placa=ingreso.Placa
            };
        }

        public bool Save(Ingreso entity)
        {
             var rpta=false;
            
           try
           {
            
             context.Ingresos.Add(entity);
             context.SaveChanges();  
             rpta=true; 
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }

        public bool Update(Ingreso entity)
        {
            var rpta=false;
            
           try
           {
            var IngresoAux=context.Ingresos.Single(x=>x.Id==entity.Id);
            IngresoAux.Id=entity.Id;
            IngresoAux.Placa=entity.Placa;
            IngresoAux.HInicio=entity.HInicio;

             context.Ingresos.Update(IngresoAux);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }
    }
}