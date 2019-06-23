using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;
using System.Linq;
using System;
using Estacionamiento.Repository.ViewModel;

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
             throw new System.NotImplementedException ();
        }

        public IEnumerable<Ingreso> GetAll()
        {
             throw new System.NotImplementedException ();
        }

        public IEnumerable<IngresoViewModel> Getall()
        {
            return ingresorepository.Getall();
        }

        public IngresoViewModel Getid(int id)
        {
            return ingresorepository.Getid(id);
        }

        public bool Save(Ingreso entity)
        {
        
            entity.HInicio= DateTime.Now;
            var list=ingresorepository.Getall();
            
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