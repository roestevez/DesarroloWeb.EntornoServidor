using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstevezGayosoRosanaTarea4.Database.Models
{

   
    public class Pokemon
    {
       
        
        public int numero_pokedex { get; set; }
        public string nombre { get; set; }
        public List<Tipo>Tipos { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
