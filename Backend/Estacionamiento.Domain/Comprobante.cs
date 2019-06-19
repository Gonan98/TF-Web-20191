using System;

namespace Estacionamiento.Domain
{
    public class Comprobante
    {
        public int Id {get; set;}
        public int IngresoId {get; set;}
        public Ingreso Ingreso {get; set;}
        public DateTime horaIni {get; set;}
        public DateTime horaFin {get; set;}
        public double Monto {get; set;}

    }
}