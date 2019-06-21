using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;
using System.Linq;

namespace Estacionamiento.Service.implementacion
{
    public class IngresoService : IIngresoService
    {
        private IIngresoRepository ingresorepository;
        public IngresoService(IIngresoRepository ingresoRepository){
            this.ingresorepository=ingresoRepository;
        }
        public bool Delete(int id)
        {
           return ingresorepository.Delete(id);
        }

        public Ingreso Get(int id)
        {
            return ingresorepository.Get(id);
        }

        public IEnumerable<Ingreso> GetAll()
        {
            return ingresorepository.GetAll();
        }

        public bool Save(Ingreso entity)
        {
            
            var list=(List<Ingreso>)ingresorepository.GetAll();
            var result=list.FirstOrDefault(x=>x.Placa.Trim().ToLower()==entity.Placa.Trim().ToLower());
            if (result==null)
            {
            return ingresorepository.Save(entity);
                
            }
            return false;
            
        }

        public bool Update(Ingreso entity)
        {
            return ingresorepository.Update(entity);
        }
    }
}