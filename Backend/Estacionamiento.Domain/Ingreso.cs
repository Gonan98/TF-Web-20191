using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estacionamiento.Domain
{
    public class Ingreso
    {
         
        public int Id{get;set;}
       /* Tarifa cod_tarifa;*/ 

        public int CajeroId;
        public Cajero Cajero{get;set;}
        

        public string Placa{get;set;}
         public  DateTime HInicio{get;set;}
       /*Espacio cod_espacio; */ 

    }
}