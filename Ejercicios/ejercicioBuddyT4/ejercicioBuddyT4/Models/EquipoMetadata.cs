using System.ComponentModel.DataAnnotations;

namespace ejercicioBuddyT4.Models
{
    public class EquipoMetadata
    {
        [Required, StringLength(50)]
        public string Codigo { get; set; }
        [Required, StringLength(50)]
        public string Nombre { get; set; }
        [Required, StringLength(50)]
        public string Pais { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Goles { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Puntos { get; set; }
        [Required, Range(0, int.MaxValue)]
        public string PJ { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int PG { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int PE { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int PP { get; set; }
        [Required, StringLength(50)]
        public string Estadio { get; set; }
        [Required, StringLength(50)]
        public string Ciudad { get; set; }
    }
}
