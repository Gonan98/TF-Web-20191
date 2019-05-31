using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;

namespace Estacionamiento.Repository.implementacion
{
    public class PuntoAtencionRepository : IPuntoAtencionRepository
    {
        private ApplicationDbContext context;

        public PuntoAtencionRepository(ApplicationDbContext context) {

            this.context = context;
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
