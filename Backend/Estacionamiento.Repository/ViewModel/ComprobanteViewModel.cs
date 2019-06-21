using System;

namespace Estacionamiento.Repository.ViewModel
{
    public class ComprobanteViewModel
    {
        public int Id {get; set;}
        public int IngresoId {get; set;}
        public string Placa {get; set;}
        public DateTime HInicio {get; set;}
        public DateTime horaFin {get; set;}
        public double Monto {get; set;}
    }
}