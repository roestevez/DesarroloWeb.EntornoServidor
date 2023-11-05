using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstevezGayosoRosanaTarea3.Database.Models

{
    
    public class Asignatura
    {
        [Key]
        [Column("Id")]
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
