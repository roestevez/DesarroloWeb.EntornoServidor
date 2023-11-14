using System.ComponentModel.DataAnnotations;


namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Pokemon_tipo
    {
        [Key]
        public int numero_pokedex { get; set; }
        [Key]
        public int id_tipo { get; set; }    


    }
}
