using System;

namespace Estacionamiento.Domain
{
    public class Tarifa
    {
        public int TarifaId { get; set;}
        public double Monto {get; set;}
        public String TipoVehiculo {get; set;}
    }
}