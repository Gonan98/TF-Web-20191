namespace Estacionamiento.Domain
{
    public class Estacionamientos
    {
        
        public int Id { get; set; }

        public string Nombre_Estacionamiento { get; set; }
        
        public int Numero_Espacios { get; set; }
        public string Direccion { get; set; }
        public int LocalizacionId { get; set; }
        public Localizacion Localizacion {get; set;}
    }
}
