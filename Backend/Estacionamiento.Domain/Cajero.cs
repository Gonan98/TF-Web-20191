﻿namespace Estacionamiento.Domain
{
    public class Cajero
    {
        public int Id { get; set; }

        public string Nombre_Cajero { get; set; }

        public string Turno_Cajero { get; set; }


        public int PuntoAtencion_Id { get; set; }
        public PuntoAtencion puntoAtencion { get; set; }

    }
}
