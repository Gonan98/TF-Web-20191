using System.Collections.Generic;
using Estacionamiento.Domain;
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
            throw new System.NotImplementedException();
        }

        public Localizacion Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Localizacion> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Localizacion entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Localizacion entity)
        {
            throw new System.NotImplementedException();
        }
    }
}