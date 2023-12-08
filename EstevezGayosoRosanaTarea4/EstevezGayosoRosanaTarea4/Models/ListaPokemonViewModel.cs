using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Models
{
    public class ListaPokemonViewModel
    {
        public IEnumerable<Pokemon> Pokemons { get; set; }
        public IEnumerable<double> Pesos {  get; set; }
        public IEnumerable<double> Alturas {  get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }
    }
}
