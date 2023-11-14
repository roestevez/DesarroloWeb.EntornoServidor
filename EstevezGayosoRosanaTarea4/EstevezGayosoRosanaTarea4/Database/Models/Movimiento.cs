using System.ComponentModel.DataAnnotations;

namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Movimiento
    {
        [Key]
        public int id_movimiento { get; set; }
        public string nombre { get; set; }
        public int potencia { get; set; }   
        public int precion_mov { get; set; }    
        public string descripcion { get; set; } 
        public int pp { get; set; } 
        public int id_tipo { get; set; }    
        public int prioridad { get; set; }  


    }
}
