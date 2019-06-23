using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.ViewModel;

namespace Estacionamiento.Repository
{
    public interface IComprobanteRepository : IRepository<Comprobante>
    {
         IEnumerable<ComprobanteViewModel> GetAllComprobantes ();
    }
}