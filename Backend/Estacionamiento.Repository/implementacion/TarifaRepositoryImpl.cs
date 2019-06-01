using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;

namespace Estacionamiento.Repository.implementacion
{
    public class TarifaRepositoryImpl : ITarifaRepository
    {
        private ApplicationDbContext context;

        public TarifaRepositoryImpl(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var tarifa = context.Tarifas.Single(x => x.TarifaId == id);
                context.Remove(tarifa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Tarifa Get(int id)
        {
            var result = new Tarifa();
            try
            {
                result = context.Tarifas.Single(x => x.TarifaId == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Tarifa> GetAll()
        {
            var result = new List<Tarifa>();
            try
            {
                result = context.Tarifas.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Tarifa entity)
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

        public bool Update(Tarifa entity)
        {
            try
            {
                var tarifa = context.Tarifas.Single(x => x.TarifaId == entity.TarifaId);
                tarifa.TarifaId = entity.TarifaId;
                tarifa.Monto = entity.Monto;
                tarifa.TipoVehiculo = entity.TipoVehiculo;

                context.Update(tarifa);
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