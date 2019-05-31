using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class CajeroService : ICajeroService
    {
        private ICajeroRepository cajeroRepository;
        private IPuntoAtencionRepository puntoAtencionRepository;

        public CajeroService(ICajeroRepository cajeroRepository) {

            this.cajeroRepository = cajeroRepository;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Cajero Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cajero> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Cajero entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Cajero entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
