using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class LocalizacionService : ILocalizacionService
    {
        private ILocalizacionRepository localizacionRepository;
        public LocalizacionService(ILocalizacionRepository localizacionRepository)
        {
            this.localizacionRepository = localizacionRepository;
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