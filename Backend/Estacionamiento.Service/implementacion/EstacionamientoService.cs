using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository;

namespace Estacionamiento.Service.implementacion
{
    public class EstacionamientoService : IEstacionamientoService
    {
       private IEstacionamientoRepository estacionamientoRepository;
        private IEspacioRepository espacioRepository;
        public EstacionamientoService(IEstacionamientoRepository estacionamientoRepository,IEspacioRepository espacioRepository)
        {
            this.estacionamientoRepository=estacionamientoRepository;
            this.espacioRepository=espacioRepository;
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
            if (result==null )
            {
                if (estacionamientoRepository.Save(entity))
                {
                    var list2=(List<Estacionamientos>)estacionamientoRepository.GetAll();
                    for (int i = 0; i <= entity.Numero_Espacios; i++)
                    {
                            var nuevo= new Espacio{
                            Disponible=true,
                            EstacionamientosId= list2.Last().Id
                            };
                            espacioRepository.Save(nuevo);
                 } 
                    
                }
                //return estacionamientoRepository.Save(entity);
             
            }
            return false;
        }

        public bool Update(Estacionamientos entity)
        {   
                return estacionamientoRepository.Update(entity);
           
        }
    }
}