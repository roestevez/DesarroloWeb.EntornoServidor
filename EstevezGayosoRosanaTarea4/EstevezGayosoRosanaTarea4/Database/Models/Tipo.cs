using System.ComponentModel.DataAnnotations;

namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Tipo
    {
        [Key]
        public int id_tipo { get; set; }   
        public string nombre { get; set; } 
        public int id_tipo_ataque { get; set; } 

    }
}
