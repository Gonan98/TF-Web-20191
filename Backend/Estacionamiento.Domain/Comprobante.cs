using System;

namespace Estacionamiento.Domain
{
    public class Comprobante
    {
        public int id {get; set;}
        public int ingresoId {get; set;}
        public Ingreso Ingreso {get; set;}
        public DateTime horaIni {get; set;}
        public DateTime horaFin {get; set;}
        public double monto {get; set;}

    }
}