using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.ViewModel;

namespace Estacionamiento.Service
{
    public interface IIngresoService:IService<Ingreso>
    {
        IEnumerable <IngresoViewModel> Getall ();

        IngresoViewModel Getid(int id);  
    }
}