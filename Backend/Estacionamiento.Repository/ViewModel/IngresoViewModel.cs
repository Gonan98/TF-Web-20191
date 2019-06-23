using Estacionamiento.Domain;
using System;

namespace Estacionamiento.Repository.ViewModel
{
    public class IngresoViewModel
    {
        public int Id {get;set;}
        
        public Tarifa Tarifa {get; set;}

        public string NombreCajero{get;set;}

        public string ApellidoCajero{get;set;}

        public string Placa{get;set;}
        public  DateTime HInicio{get;set;}
        
        public Espacio Espacio {get; set;}
    }
}