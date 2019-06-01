using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class ComprobanteService : IComprobanteService
    {
        private IComprobanteRepository comprobanteRepository;
        public ComprobanteService(IComprobanteRepository comprobanteRepository)
        {
            this.comprobanteRepository=comprobanteRepository;
        }
        public bool Delete(int id)
        {
            return comprobanteRepository.Delete(id);
        }

        public Comprobante Get(int id)
        {
            return comprobanteRepository.Get(id);
        }

        public IEnumerable<Comprobante> GetAll()
        {
            return comprobanteRepository.GetAll();
        }

        public bool Save(Comprobante entity)
        {
            return comprobanteRepository.Save(entity);
        }

        public bool Update(Comprobante entity)
        {
            return comprobanteRepository.Update(entity);
        }
    }
}