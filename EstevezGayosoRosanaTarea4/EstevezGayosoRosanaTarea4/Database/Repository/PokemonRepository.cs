using System.Threading.Tasks;
using Dapper;
using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly Conexion _conexion;
        public PokemonRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            var query = "SELECT * FROM pokemon";
            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemon = await connection.QueryAsync<Pokemon>(query);
                return pokemon.ToList();
            }
        }
        public async Task<Pokemon> GetPokemonById(int numero_pokedex)
        {
            var query = "SELECT * FROM pokemon WHERE numero_pokedex = @numero_pokedex";
            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemon = await connection.QuerySingleOrDefaultAsync<Pokemon>(query, new { numero_pokedex });
                return pokemon;
            }
        }
        public async Task<IEnumerable<Pokemon>> GetFilteredPokemons(string tipo, double? peso, double? altura)
        {
            var query = "SELECT * FROM pokemon WHERE 1 = 1";

            if (!string.IsNullOrEmpty(tipo))
            {
                query += " AND tipo = @tipo";
            }

            if (peso.HasValue)
            {
                query += " AND peso = @peso";
            }

            if (altura.HasValue)
            {
                query += " AND altura = @altura";
            }

            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemons = await connection.QueryAsync<Pokemon>(query, new { tipo, peso, altura });
                return pokemons.ToList();
            }


        }
        public async Task<IEnumerable<Movimiento>> GetMovimientos(int numero_pokedex)
        {
            var query = @"
            
           SELECT m.*
           FROM movimiento m
           JOIN tipo t ON m.id_tipo = t.id_tipo
           JOIN pokemon_tipo pt ON t.id_tipo = pt.id_tipo
           WHERE pt.numero_pokedex = @numero_pokedex";

            using (var connection = _conexion.ObtenerConexion())
            {
                var movimientos = await connection.QueryAsync<Movimiento>(query, new { numero_pokedex });
                return movimientos.ToList();
            }
        }




    }
}
