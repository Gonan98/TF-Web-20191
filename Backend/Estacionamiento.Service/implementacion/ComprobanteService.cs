using System.Collections.Generic;
using Estacionamiento.Domain;
using System;
using System.Linq;
using Estacionamiento.Repository;
using Estacionamiento.Repository.Context;
using Estacionamiento.Repository.ViewModel;

namespace Estacionamiento.Service.implementacion
{
    public class ComprobanteService : IComprobanteService
    {
        private IComprobanteRepository comprobanteRepository;
        //private IIngresoRepository ingresoRepository;
        private IEspacioRepository espacioRepository;     
        //private ITarifaRepository tarifaRepository;    
        private ApplicationDbContext context; 
        public ComprobanteService(IComprobanteRepository comprobanteRepository, ApplicationDbContext context,
         IEspacioRepository espacioRepository)
        {
            this.comprobanteRepository=comprobanteRepository;
            this.espacioRepository=espacioRepository;
            this.context = context;
            //this.ingresoRepository=ingresoRepository;
            //this.tarifaRepository=tarifaRepository;
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
            throw new System.NotImplementedException ();
        }

        public IEnumerable<ComprobanteViewModel> GetAllComprobantes()
        {
            return comprobanteRepository.GetAllComprobantes();
        }

        public bool Save(Comprobante entity)
        {
             entity.horaFin=DateTime.Now;
            
            var ingreso=context.Ingresos.Single(x=>x.Id==entity.IngresoId);
            var tarifa=context.Tarifas.Single(x=>x.TarifaId==ingreso.TarifaId);
            var espacio=espacioRepository.Get(ingreso.EspacioId);

            entity.horaFin=DateTime.Now;
                
            if(entity.horaFin.Subtract(ingreso.HInicio).Minutes<15){
                entity.Monto=tarifa.Monto;
            }else{
                entity.Monto=(entity.horaFin.Subtract(ingreso.HInicio).Minutes/60)*tarifa.Monto;
            }
            espacio.Disponible=true;
            espacioRepository.Update(espacio);
            //ingresoRepository.Delete(ingreso.Id);

            return comprobanteRepository.Save(entity);
        }

        public bool Update(Comprobante entity)
        {
            return comprobanteRepository.Update(entity);
        }
    }
}