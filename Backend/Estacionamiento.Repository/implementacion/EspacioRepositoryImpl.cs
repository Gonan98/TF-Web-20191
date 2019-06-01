using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;

namespace Estacionamiento.Repository.implementacion
{
    public class EspacioRepositoryImpl : IEspacioRepository
    {
        private ApplicationDbContext context;

        public EspacioRepositoryImpl(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.Espacios.Single(x => x.EspacioId == id);
                context.Remove(result);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Espacio Get(int id)
        {
            var result = new Espacio();
            try
            {
                result = context.Espacios.Single(x => x.EspacioId == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Espacio> GetAll()
        {
            var result = new List<Espacio>();
            try
            {
                result = context.Espacios.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Espacio entity)
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

        public bool Update(Espacio entity)
        {
            try
            {
                 var espacio = context.Espacios.Single(
                     x => x.EspacioId == entity.EspacioId
                 );

                espacio.EspacioId = entity.EspacioId;
                espacio.Disponible = entity.Disponible;
                espacio.EstacionamientosId = entity.EstacionamientosId;

                 context.Update(espacio);
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