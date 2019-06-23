using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estacionamiento.Domain
{
    public class Ingreso
    {
         
        public int Id {get;set;}
        public int TarifaId {get; set;}
        public Tarifa Tarifa {get; set;}
        public int CajeroId {get; set;}
        public Cajero Cajero{get;set;}

        public string Placa{get;set;}
        public DateTime HInicio{get;set;}
        public int EspacioId {get; set;}
        public Espacio Espacio {get; set;}
    }
}