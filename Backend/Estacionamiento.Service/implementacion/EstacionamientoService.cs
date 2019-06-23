using System.Collections.Generic;
using System.Linq;
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
            var list=(List<Estacionamientos>)estacionamientoRepository.GetAll();
            var result=list.FirstOrDefault(x=>x.Nombre_Estacionamiento.Trim().ToLower()==entity.Nombre_Estacionamiento.Trim().ToLower());
             var result2=list.FirstOrDefault(x=>x.Direccion.Trim().ToLower()==entity.Direccion.Trim().ToLower());
            if (result==null || result2 ==null)
            {
                return estacionamientoRepository.Save(entity);
            }
            return false;
        }

        public bool Update(Estacionamientos entity)
        {   var list=(List<Estacionamientos>)estacionamientoRepository.GetAll();
            var result=list.FirstOrDefault(x=>x.Numero_Espacios==entity.Numero_Espacios);
            if (result !=null){
                return estacionamientoRepository.Update(entity);
            }else{
                return false;
            }
           
        }
    }
}