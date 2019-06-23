using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;
using Estacionamiento.Repository.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Repository.implementacion
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        private ApplicationDbContext context;
        public ComprobanteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            var objElim = new Comprobante();
            try{
                objElim=context.Comprobantes.Single(x => x.Id == id);
                context.Comprobantes.Remove(objElim);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Comprobante Get(int id)
        {
            var result = new Comprobante();
            try
            {
                result = context.Comprobantes.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Comprobante> GetAll()
        {
            throw new System.NotImplementedException ();
        }

        public IEnumerable<ComprobanteViewModel> GetAllComprobantes()
        {
            var comprobante = context.Comprobantes
            .Include(o=>o.Ingreso)
            .OrderByDescending (o => o.Id)
            .Take (10)
            .ToList ();

            return comprobante.Select (o => new ComprobanteViewModel {
                    Id = o.Id,
                    IngresoId = o.IngresoId,
                    Placa = o.Ingreso.Placa,
                    HInicio = o.Ingreso.HInicio,
                    horaFin = o.horaFin,
                    Monto = o.Monto
            });
        }

        public bool Save(Comprobante entity)
        {
            try
            {
                var ingreso=context.Ingresos.Single(x=>x.Id==entity.IngresoId);
                var tarifa=context.Tarifas.Single(x=>x.TarifaId==ingreso.TarifaId);

                entity.Monto=(entity.horaFin-ingreso.HInicio).Hours*tarifa.Monto;

                if(entity.horaFin>ingreso.HInicio){
                    context.Add(entity);
                    context.SaveChanges();
                }
                
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Comprobante entity)
        {
            try
            {
                var ingreso=context.Ingresos.Single(x=>x.Id==entity.IngresoId);
                var tarifa=context.Tarifas.Single(x=>x.TarifaId==ingreso.TarifaId);

                entity.Monto=(entity.horaFin-ingreso.HInicio).Hours*tarifa.Monto;

                 var comprobanteOrigina = context.Comprobantes.Single(
                     x => x.Id == entity.Id && entity.horaFin>ingreso.HInicio
                 );

                 comprobanteOrigina.Id=entity.Id;
                 comprobanteOrigina.IngresoId=entity.IngresoId;
                 comprobanteOrigina.horaFin=entity.horaFin;
                 comprobanteOrigina.Monto=entity.Monto;

                 context.Update(comprobanteOrigina);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}