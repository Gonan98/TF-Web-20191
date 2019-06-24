﻿using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository;
using System;

namespace Estacionamiento.Service.implementacion
{
    public class CajeroService : ICajeroService
    {
        private ICajeroRepository cajeroRepository;

        public CajeroService(ICajeroRepository cajeroRepository) {

            this.cajeroRepository = cajeroRepository;
        }
        public bool Delete(int id)
        {
            return cajeroRepository.Delete(id);
        }

        public Cajero Get(int id)
        {
            return cajeroRepository.Get(id);
        }

        public IEnumerable<Cajero> GetAll()
        {
            return cajeroRepository.GetAll();
        }

        public bool Save(Cajero entity)
        {
           entity.FechaIngreso=DateTime.Now;
            return cajeroRepository.Save(entity);
        }

        public bool Update(Cajero entity)
        {
            return cajeroRepository.Update(entity);
        }
    }
}
