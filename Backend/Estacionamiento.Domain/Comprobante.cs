using System;

namespace Estacionamiento.Domain
{
    public class Comprobante
    {
        public int id {get; set;}
        public Ingreso cod_ingreso {get; set;}
        public DateTime horaIni {get; set;}
        public DateTime horaFin {get; set;}
        public double monto {get; set;}

    }
}