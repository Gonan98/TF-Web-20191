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
            throw new System.NotImplementedException();
        }

        public PuntoAtencion Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PuntoAtencion> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(PuntoAtencion entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(PuntoAtencion entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
