using System;

namespace Estacionamiento.Domain
{
    public class Cajero
    {
        public int Id { get; set; }
        public string NombreCajero { get; set; }
        public string ApellidoCajero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TurnoCajero { get; set; }
        public int PuntoAtencionId { get; set; }
        public PuntoAtencion PuntoAtencion { get; set; }
    }
}
