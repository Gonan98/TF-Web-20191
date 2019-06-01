using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class PuntoAtencionService : IPuntoAtencionService
    {
        private IPuntoAtencionRepository puntoAtencionRepository;

        public PuntoAtencionService(IPuntoAtencionRepository puntoAtencionRepository) {

            this.puntoAtencionRepository = puntoAtencionRepository;
        }
        public bool Delete(int id)
        {
            return puntoAtencionRepository.Delete(id);
        }

        public PuntoAtencion Get(int id)
        {
            return puntoAtencionRepository.Get(id);
        }

        public IEnumerable<PuntoAtencion> GetAll()
        {
            return puntoAtencionRepository.GetAll();
        }

        public bool Save(PuntoAtencion entity)
        {
            return puntoAtencionRepository.Save(entity);
        }

        public bool Update(PuntoAtencion entity)
        {
            return puntoAtencionRepository.Update(entity);
        }
    }
}
