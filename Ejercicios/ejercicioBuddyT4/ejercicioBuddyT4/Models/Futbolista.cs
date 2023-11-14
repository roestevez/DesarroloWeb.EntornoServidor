using System.ComponentModel.DataAnnotations;

namespace ejercicioBuddyT4.Models
{
    [MetadataType(typeof(FutbolistaMetadata))]
    public class Futbolista
    {
        public int Codigo { get; set; } 
        public string Nombre { get; set; }  
        public  string Equipo { get; set; } 
        public string CodigoEquipo { get; set; }
        public string Posicion { get; set; }    
        public int Edad { get; set; }   
        public int Goles { get; set; }
        public int TA { get; set; } 
        public int TR { get; set; } 
        public int Minutos { get; set; }    
        public string PrecioMercado { get; set; } 
        public int Dorsal { get; set; } 
        public int Peso { get; set; }   

    }
    
}
