using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstevezGayosoRosanaTarea3.Database.Models

{
    //Creacion de una carpeta de baseDeDatos donde se encuentran los modelos correspondientes
    //a la misma, el context y el manager
    
    public class Asignatura
    {
        [Key]
        [Column("Id")]
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
