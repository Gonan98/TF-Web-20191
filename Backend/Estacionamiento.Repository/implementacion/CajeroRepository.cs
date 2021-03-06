﻿using System;
using System.Collections.Generic;
using System.Linq;
using Estacionamiento.Domain;
using Estacionamiento.Repository.Context;
using Microsoft.EntityFrameworkCore;
namespace Estacionamiento.Repository.implementacion
{
    public class CajeroRepository : ICajeroRepository
    {
        private ApplicationDbContext context;

        public CajeroRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var cajero = context.Cajeros.Single(x => x.Id == id);
                context.Remove(cajero);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Cajero Get(int id)
        {
            var result = new Cajero();
            try
            {
                result = context.Cajeros.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Cajero> GetAll()
        {
            var result = new List<Cajero>();
            try
            {
                result = context.Cajeros.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Cajero entity)
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

        public bool Update(Cajero entity)
        {
            try
            {
               
                if ( entity.FechaIngreso<=DateTime.Today)
                {
                    var cajero = context.Cajeros.Single(x => x.Id == entity.Id );
                    cajero.Id = entity.Id;
                    cajero.NombreCajero = entity.NombreCajero;
                    cajero.ApellidoCajero = entity.ApellidoCajero;
                    cajero.FechaIngreso = entity.FechaIngreso;
                    cajero.TurnoCajero = entity.TurnoCajero;
                    cajero.PuntoAtencionId = entity.PuntoAtencionId;

                    context.Update(cajero);
                    context.SaveChanges();
                }
               
            }
            catch (System.Exception)
            {
                
               return false;
            }
            return true;
        }
    }
}
