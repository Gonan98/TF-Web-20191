

using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class EspacioService : IEspacioService
    {
        private IEspacioRepository espacioRepository;

        public EspacioService(IEspacioRepository espacioRepository)
        {
            this.espacioRepository=espacioRepository;
        }
        public bool Delete(int id)
        {
            return espacioRepository.Delete(id);
        }

        public Espacio Get(int id)
        {
            return espacioRepository.Get(id);
        }

        public IEnumerable<Espacio> GetAll()
        {
            return espacioRepository.GetAll();
        }

        public bool Save(Espacio entity)
        {
            return espacioRepository.Save(entity);
        }

        public bool Update(Espacio entity)
        {
            return espacioRepository.Update(entity);
        }
    }
}