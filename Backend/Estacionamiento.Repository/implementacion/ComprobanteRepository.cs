using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;

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
            var result = new List<Comprobante>();
            try
            {
                result = context.Comprobantes.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Comprobante entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
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
                 var comprobanteOrigina = context.Comprobantes.Single(
                     x => x.Id == entity.Id
                 );

                 comprobanteOrigina.Id=entity.Id;
                 comprobanteOrigina.IngresoId=entity.IngresoId;
                 comprobanteOrigina.horaIni=entity.horaIni;
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