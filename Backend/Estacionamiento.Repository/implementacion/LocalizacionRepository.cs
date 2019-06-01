using System.Collections.Generic;
using Estacionamiento.Domain;
using System.Linq;
using Estacionamiento.Repository.Context;

namespace Estacionamiento.Repository.implementacion
{
    public class LocalizacionRepository : ILocalizacionRepository
    {
        private ApplicationDbContext context;

        public LocalizacionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var local = context.Localizaciones.Single(x => x.Id == id);

                context.Update(local);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Localizacion Get(int id)
        {
            var result = new Localizacion();
            try
            {
                result = context.Localizaciones.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Localizacion> GetAll()
        {
            var result = new List<Localizacion>();
            try
            {
                result = context.Localizaciones.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Localizacion entity)
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

        public bool Update(Localizacion entity)
        {
            try
            {
                var local = context.Localizaciones.Single(x => x.Id == entity.Id);
                
                local.Id = entity.Id;
                local.Nombre_Localizacion = entity.Nombre_Localizacion;

                context.Update(local);
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