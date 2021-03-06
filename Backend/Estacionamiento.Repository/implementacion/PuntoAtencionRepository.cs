﻿using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;
using System.Linq;

namespace Estacionamiento.Repository.implementacion
{
    public class PuntoAtencionRepository : IPuntoAtencionRepository
    {
        private ApplicationDbContext context;

        public PuntoAtencionRepository(ApplicationDbContext context) {

            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var pa = context.PuntoAtenciones.Single(x => x.Id == id);
                context.Remove(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public PuntoAtencion Get(int id)
        {
            var result = new PuntoAtencion();
            try
            {
                result = context.PuntoAtenciones.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<PuntoAtencion> GetAll()
        {
            var result = new List<PuntoAtencion>();
            try
            {
                result = context.PuntoAtenciones.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(PuntoAtencion entity)
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

        public bool Update(PuntoAtencion entity)
        {
            try
            {
                var pa = context.PuntoAtenciones.Single(x => x.Id == entity.Id);

                pa.Id = entity.Id;
                pa.Ubicacion = entity.Ubicacion;

                context.Update(pa);
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
