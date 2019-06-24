using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;
using Microsoft.EntityFrameworkCore;
namespace Estacionamiento.Repository.implementacion
{
    public class EstacionamientoRepository : IEstacionamientoRepository

    {
        private ApplicationDbContext context;
        public EstacionamientoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Estacionamientos Get(int id)
        {
            
            var result = new Estacionamientos();
            try
            {
                result = context.estacionamientos.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Estacionamientos> GetAll()
        {
            var result = new List<Estacionamientos>();
            try
            {
                result = context.estacionamientos.Include(x=>x.Localizacion).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Estacionamientos entity)
        {
             try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Estacionamientos entity)
        {
            try
            {
                 var estacionamientoOrigina = context.estacionamientos.Single(
                     x => x.Id == entity.Id
                 );

                 estacionamientoOrigina.Id=entity.Id;
                 estacionamientoOrigina.Nombre_Estacionamiento=entity.Nombre_Estacionamiento;
                 estacionamientoOrigina.Numero_Espacios=entity.Numero_Espacios;
                 estacionamientoOrigina.Direccion=entity.Direccion;
                 estacionamientoOrigina.LocalizacionId=entity.LocalizacionId;
                 context.Update(estacionamientoOrigina);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}