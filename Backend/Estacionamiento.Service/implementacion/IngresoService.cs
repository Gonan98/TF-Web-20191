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
        private IEspacioRepository espacioRepository;
        public IngresoService(IIngresoRepository ingresoRepository, IEspacioRepository espacioRepository){
            this.espacioRepository=espacioRepository;
            this.ingresorepository=ingresoRepository;
        }
        public bool Delete(int id)
        {
           return ingresorepository.Delete(id);
        }

        public IngresoViewModel FindByPlaca(string Placa)
        {
            return ingresorepository.FindByPlaca(Placa);
        }

        public Ingreso Get(int id)
        {
             return ingresorepository.Get(id);
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
            try
            {
            var espacio=espacioRepository.Get(entity.EspacioId);
            
            if (espacio!=null && espacio.Disponible )
            {
                espacio.Disponible=false;
                espacioRepository.Update(espacio);
            return ingresorepository.Save(entity);
                
            }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
            return false;
            
        }

        public bool Update(Ingreso entity)
        {
            return ingresorepository.Update(entity);
        }
    }
}