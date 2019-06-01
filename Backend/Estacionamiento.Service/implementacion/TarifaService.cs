

using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class TarifaService : ITarifaService
    {
        private ITarifaRepository tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            this.tarifaRepository=tarifaRepository;
        }
        public bool Delete(int id)
        {
            return tarifaRepository.Delete(id);
        }

        public Tarifa Get(int id)
        {
            return tarifaRepository.Get(id);
        }

        public IEnumerable<Tarifa> GetAll()
        {
            return tarifaRepository.GetAll();
        }

        public bool Save(Tarifa entity)
        {
            return tarifaRepository.Save(entity);
        }

        public bool Update(Tarifa entity)
        {
            return tarifaRepository.Update(entity);
        }
    }
}