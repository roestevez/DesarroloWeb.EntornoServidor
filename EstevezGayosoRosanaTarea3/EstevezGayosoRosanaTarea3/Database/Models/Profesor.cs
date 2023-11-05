using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EstevezGayosoRosanaTarea3.Database.Models
{
    public class Profesor
    {
        [Key]
        [Column("Id")]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Materia { get; set; }
    }
}
