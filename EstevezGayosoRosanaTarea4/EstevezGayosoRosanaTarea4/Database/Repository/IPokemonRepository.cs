using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Repository
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();
        Task<Pokemon>GetPokemonById(int numero_pokedex);  
        Task<IEnumerable<Pokemon>> GetFilteredPokemons(int? tipo, double? peso, double? altura);
        Task<IEnumerable<Movimiento>> GetMovimientos(int numero_pokedex);
        Task<IEnumerable<Evoluciona_de>> GetEvoluciones(int numero_pokedex);
        Task<IEnumerable<Evoluciona_de>> GetInvoluciones(int numero_pokedex);
        Task<IEnumerable<double>> GetPesos();
        Task<IEnumerable<double>> GetAlturas();
        Task<IEnumerable<Tipo>> GetTipos();
    }
}
