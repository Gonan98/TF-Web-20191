using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;

namespace Estacionamiento.Repository.implementacion
{
    public class CajeroRepository : ICajeroRepository
    {
        private ApplicationDbContext context;

        public CajeroRepository(ApplicationDbContext context) {

            this.context = context;
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
