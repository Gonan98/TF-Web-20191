using Estacionamiento.Domain;
using System.Collections.Generic;
using Estacionamiento.Repository.ViewModel;
namespace Estacionamiento.Repository
{
    public interface IIngresoRepository:IRepository<Ingreso>
    {
        IEnumerable <IngresoViewModel> Getall ();

        IngresoViewModel Getid(int id);

    }
}