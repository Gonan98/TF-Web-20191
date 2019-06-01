using System.Collections.Generic;

namespace Estacionamiento.Domain
{
   public class PuntoAtencion
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; }
        public IList<Cajero> Cajeros { get; set; }
    }
}
