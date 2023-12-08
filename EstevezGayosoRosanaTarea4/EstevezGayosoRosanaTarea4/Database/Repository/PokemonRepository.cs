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
            var queryTodoPokemon = "SELECT * FROM pokemon";
            var queryTipos = "SELECT tipo.nombre from tipo INNER JOIN pokemon_tipo on tipo.id_tipo= pokemon_tipo.id_tipo  WHERE pokemon_tipo.numero_pokedex= @numero_pokedex";


            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemons = await connection.QueryAsync<Pokemon>(queryTodoPokemon);
                foreach (var pokemon in pokemons)
                {
                    pokemon.Tipos = (await connection.QueryAsync<Tipo>(queryTipos, new { pokemon.numero_pokedex })).ToList();
                }

                return pokemons;
            }
        }
        public async Task<Pokemon> GetPokemonById(int numero_pokedex)
        {
            var query = "SELECT * FROM pokemon WHERE numero_pokedex = @numero_pokedex";
            var queryTipos = "SELECT tipo.nombre from tipo INNER JOIN pokemon_tipo on tipo.id_tipo= pokemon_tipo.id_tipo  WHERE pokemon_tipo.numero_pokedex= @numero_pokedex";
            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemon = await connection.QuerySingleOrDefaultAsync<Pokemon>(query, new { numero_pokedex });
                pokemon.Tipos = (await connection.QueryAsync<Tipo>(queryTipos, new { pokemon.numero_pokedex })).ToList();
                return pokemon;
            }
        }
        public async Task<IEnumerable<Pokemon>> GetFilteredPokemons(int? tipo, double? peso, double? altura)
        {
            var query = @"SELECT DISTINCT p.*
           FROM pokemon p
           JOIN pokemon_tipo pt ON p.numero_pokedex = pt.numero_pokedex
           JOIN tipo t ON pt.id_tipo = t.id_tipo
           WHERE 1 = 1";

            var queryTipos = "SELECT tipo.nombre from tipo INNER JOIN pokemon_tipo on tipo.id_tipo= pokemon_tipo.id_tipo  WHERE pokemon_tipo.numero_pokedex= @numero_pokedex";

            if (tipo.HasValue)
            {
                query += " AND t.id_tipo = @tipo";
            }

            if (peso.HasValue)
            {
                query += " AND p.peso = @peso";
            }

            if (altura.HasValue)
            {
                query += " AND p.altura = @altura";
            }

            using (var connection = _conexion.ObtenerConexion())
            {
                var pokemons = await connection.QueryAsync<Pokemon>(query, new { tipo, peso, altura });

                foreach (var pokemon in pokemons)
                {
                    pokemon.Tipos = (await connection.QueryAsync<Tipo>(queryTipos, new { pokemon.numero_pokedex })).ToList();
                }

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
        public async Task<IEnumerable<Evoluciona_de>> GetEvoluciones(int numero_pokedex)
        {
            var query = "SELECT e.pokemon_evolucionado FROM evoluciona_de e " +
                "WHERE e.pokemon_origen = @numero_pokedex";
            using (var connection = _conexion.ObtenerConexion())
            {
                var evoluciones = await connection.QueryAsync<Evoluciona_de>(query, new { numero_pokedex });
                return evoluciones.ToList();
            }
        }
        public async Task<IEnumerable<Evoluciona_de>> GetInvoluciones(int numero_pokedex)
        {
            var query = "SELECT e.pokemon_origen FROM evoluciona_de e " +
                "WHERE e.pokemon_evolucionado = @numero_pokedex";
            using (var connection = _conexion.ObtenerConexion())
            {
                var involuciones = await connection.QueryAsync<Evoluciona_de>(query, new { numero_pokedex });
                return involuciones.ToList();
            }
        }    
        
        public async Task<IEnumerable<double>> GetPesos()
        {
            var query = "SELECT DISTINCT peso FROM pokemon";
            using (var connection = _conexion.ObtenerConexion())
            {
                var pesos = await connection.QueryAsync<double>(query);
                return pesos.ToList();
            }
        }

        public async Task<IEnumerable<double>> GetAlturas()
        {
            var query = "SELECT DISTINCT altura FROM pokemon";
            using (var connection = _conexion.ObtenerConexion())
            {
                var alturas = await connection.QueryAsync<double>(query);
                return alturas.ToList();
            }
        }

        public async Task<IEnumerable<Tipo>> GetTipos()
        {
            var query = "SELECT * FROM tipo";
            using (var connection = _conexion.ObtenerConexion())
            {
                var tipos = await connection.QueryAsync<Tipo>(query);
                return tipos.ToList();
            }
        }
    }
}

