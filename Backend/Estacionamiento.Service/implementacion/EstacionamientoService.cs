using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class EstacionamientoService : IEstacionamientoService
    {
       private IEstacionamientoRepository estacionamientoRepository;
        public EstacionamientoService(IEstacionamientoRepository estacionamientoRepository)
        {
            this.estacionamientoRepository=estacionamientoRepository;
        }
        public bool Delete(int id)
        {
            return estacionamientoRepository.Delete(id);
        }

        public Estacionamientos Get(int id)
        {
            return estacionamientoRepository.Get(id);
        }

        public IEnumerable<Estacionamientos> GetAll()
        {
            return estacionamientoRepository.GetAll();
        }

        public bool Save(Estacionamientos entity)
        {
            return estacionamientoRepository.Save(entity);
        }

        public bool Update(Estacionamientos entity)
        {
            return estacionamientoRepository.Update(entity);
        }
    }
}