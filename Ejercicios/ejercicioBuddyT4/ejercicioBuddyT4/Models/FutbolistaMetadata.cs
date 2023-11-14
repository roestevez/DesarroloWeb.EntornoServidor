using System.ComponentModel.DataAnnotations;

namespace ejercicioBuddyT4.Models
{
    public class FutbolistaMetadata
    {
        [Required, StringLength(50)]
        public int Codigo { get; set; }
        [Required, StringLength(50)]
        public string Nombre { get; set; }
        [Required, StringLength(50)]
        public string Equipo { get; set; }
        [Required, StringLength(50)]
        public string CodigoEquipo { get; set; }
        [Required, StringLength(50)]
        public string Posicion { get; set; }
        [Required, Range(0, 100)]
        public int Edad { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Goles { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int TA { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int TR { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Minutos { get; set; }
        [Required, Range(1, int.MaxValue)]
        public string PrecioMercado { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Dorsal { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Peso { get; set; }
    }
}
