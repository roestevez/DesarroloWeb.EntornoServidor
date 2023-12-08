using System.Reflection;
using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Models
{
    public class DetallesViewModel
    {
        public Pokemon Pokemon { get; set; }
        public IEnumerable<Movimiento> Movimientos { get; set; }
        public IEnumerable<string> Evoluciones { get; set; }
        public IEnumerable<string> Involuciones { get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }










    }
}
