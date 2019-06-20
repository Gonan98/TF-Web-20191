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
            return localizacionRepository.Delete(id);
        }

        public Localizacion Get(int id)
        {
            return localizacionRepository.Get(id);
        }

        public IEnumerable<Localizacion> GetAll()
        {
            return localizacionRepository.GetAll();
        }

        public bool Save(Localizacion entity)
        {
            return localizacionRepository.Save(entity);
        }

        public bool Update(Localizacion entity)
        {
            return localizacionRepository.Update(entity);
        }
    }
}