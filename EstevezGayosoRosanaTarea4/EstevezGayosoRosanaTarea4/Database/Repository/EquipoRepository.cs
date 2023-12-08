using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Database.Repository

{
    public class EquipoRepository : IEquipoRepository

    {
        private Equipo MiEquipo { get; set; }
        private const int _maxPokemons = 6;
        public EquipoRepository()
        {
            MiEquipo = new Equipo
            {
                nombre ="Mi Equipo",
                Pokemons = new List<Pokemon>()
            };
        }
        public bool Add(Pokemon pokemon)
        {
            if (MiEquipo.Pokemons.Count >= _maxPokemons) return false;
            MiEquipo.Pokemons.Add(pokemon);
            return true;    
        }
        public Equipo GetMiEquipo()
        {
            return MiEquipo;
        }
        public Equipo GetEquipoAleatorio(List<Pokemon> allPokemons, int ? maxPokemon=null)
        {
            Equipo equipo = new Equipo()
            {
                nombre = "Equipo Aleatorio",
                Pokemons = new List<Pokemon>()
            };
            Random random = new Random();

            var max = maxPokemon ?? _maxPokemons;
            for(int i = 0;i< max;i++)
            {
                var posicion= random.Next(allPokemons.Count);
                equipo.Pokemons.Add(allPokemons[posicion]);
            }
            return equipo;

        }
    }
}

