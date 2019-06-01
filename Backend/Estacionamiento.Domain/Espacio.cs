using System;

namespace Estacionamiento.Domain
{
    public class Espacio
    {
        public int EspacioId {get; set;}
        public bool Disponible {get; set;}
        public int EstacionamientosId {get; set;}
        public Estacionamientos Estacionamientos { get; set; }
    }
}