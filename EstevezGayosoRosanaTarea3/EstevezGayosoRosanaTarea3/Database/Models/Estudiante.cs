using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EstevezGayosoRosanaTarea3.Database.Models
{
    public class Estudiante
    {
        [Key]
        [Column("Id")]
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Curso { get; set; }

    }
}
