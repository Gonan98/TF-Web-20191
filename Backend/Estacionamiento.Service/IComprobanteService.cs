using System.Collections.Generic;
using Estacionamiento.Domain;
using Estacionamiento.Repository.ViewModel;

namespace Estacionamiento.Service
{
    public interface IComprobanteService :  IService<Comprobante>
    {
         IEnumerable<ComprobanteViewModel> GetAllComprobantes ();
    }
}