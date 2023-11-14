using System.ComponentModel.DataAnnotations;

namespace ejercicioBuddyT4.Models
{
    public class FutbolistaManager: IValidatableObject
    {
        public string CodigoEquipo { get; set; }
        public int Edad { get; set; }
        public int Minutos { get; set; }
        public int Dorsal { get; set; }
        public string PrecioMercado { get; set; }

        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CodigoEquipo))
            {
                yield return new ValidationResult("Este campo no puede estar vacio");
            }
            if(Edad > 45)
            {
                yield return new ValidationResult("Esta edad no es valida");

            }
            if (Minutos < 0)
            {
                yield return new ValidationResult("Este jugador no ha tocado redonda");

            }
            if(Dorsal < 1 && Dorsal > 25)
            {
                yield return new ValidationResult("Este jugador no esta en activo");

            }
            if(PrecioMercado is null)
            {
                yield return new ValidationResult("Este campo no puede estar vacio");
            }
        }

    }
}
