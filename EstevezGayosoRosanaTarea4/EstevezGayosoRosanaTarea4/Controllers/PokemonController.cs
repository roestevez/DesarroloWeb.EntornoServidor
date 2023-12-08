
using EstevezGayosoRosanaTarea4.Database.Models;
using EstevezGayosoRosanaTarea4.Database.Repository;
using EstevezGayosoRosanaTarea4.Models;
using EstevezGayosoRosanaTarea4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea4.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IEquipoRepository _equipoRepository;

        public PokemonController(IPokemonRepository pokemonRepository, IEquipoRepository equipoRepository)
        {
            _pokemonRepository = pokemonRepository;
            _equipoRepository = equipoRepository;


        }

        [Route("Pokemon/ListaPokemon")]
        public async Task<IActionResult> ListaPokemon()
        {
            var pokemons = await _pokemonRepository.GetAllPokemons();
            var alturas = await _pokemonRepository.GetAlturas();
            var pesos = await _pokemonRepository.GetPesos();
            var tipos = await _pokemonRepository.GetTipos();

            var viewModel = new ListaPokemonViewModel
            {
                Pokemons = pokemons,
                Alturas = alturas,
                Pesos = pesos,
                Tipos = tipos
            };

            return View("ListaPokemon", viewModel);
        }

        [Route("Pokemon/EquipoIndex")]
        public async Task<IActionResult> EquipoIndex()
        {
            return View(new EquipoViewModel());
        }

        [Route("Pokemon/BatallaIndex")]
        public async Task<IActionResult> BatallaIndex()
        {

            return View(new BatallaViewModel());
        }

        [Route("Pokemon/EmpezarBatallaAleatoria")]
        [HttpPost]
        public async Task<IActionResult> EmpezarBatallaAleatoria()

        {
            var todosPokemons = await _pokemonRepository.GetAllPokemons();
            var equipoUno = _equipoRepository.GetEquipoAleatorio(todosPokemons.ToList());
            var equipoDos = _equipoRepository.GetEquipoAleatorio(todosPokemons.ToList());
            var batalla = CalcularGanador.Simulador(equipoUno, equipoDos);
            var equipoGanador = CalcularGanador.DeterminarEquipoGanador(equipoUno, equipoDos);
            
            var viewModel = new BatallaViewModel
            {

                Batalla = batalla,
                
                EquipoGanador = equipoGanador,
            };
            return View("Batalla", viewModel);


        }

        [Route("Pokemon/EmpezarMiEquipoBatalla")]
        [HttpPost]
        public async Task<IActionResult> EmpezarMiEquipoBatalla()
        {
            var todosPokemons = await _pokemonRepository.GetAllPokemons();
            var equipoUno = _equipoRepository.GetMiEquipo();
            var equipoDos = _equipoRepository.GetEquipoAleatorio(todosPokemons.ToList(), equipoUno.Pokemons.Count);
            var batalla = CalcularGanador.Simulador(equipoUno, equipoDos);
            var equipoGanador = CalcularGanador.DeterminarEquipoGanador(equipoUno, equipoDos);
            var viewModel = new BatallaViewModel
            {
                Batalla = batalla,
                EquipoGanador = equipoGanador,
            };

            return View("Batalla", viewModel);
        }

        [Route("Pokemon/{tipoEquipo}")]
        public async Task<IActionResult> Equipo(string tipoEquipo)
        {
            var equipo = new Equipo();

            if (tipoEquipo == "miequipo")
            {
                equipo = _equipoRepository.GetMiEquipo();
            }
            else
            {
                var allPokemon = await _pokemonRepository.GetAllPokemons();
                equipo = _equipoRepository.GetEquipoAleatorio(allPokemon.ToList());
            }

            var predominante = string.Empty;
            if (equipo.Pokemons.Any())
            {
                      predominante = equipo.Pokemons
                     .SelectMany(pokemon => pokemon.Tipos)
                     .GroupBy(tipo => tipo.nombre)
                     .OrderByDescending(grupo => grupo.Count())
                     .Select(grupo => grupo.Key)
                     .First();
            }

            var viewModel = new EquipoViewModel
            {
                Equipo = equipo,
                Predominate = predominante,
                AlturaPromedio = equipo.Pokemons.Sum(x => x.Altura) / equipo.Pokemons.Count,
                PesoPromedio = equipo.Pokemons.Sum(x => x.Peso) / equipo.Pokemons.Count,
                Cantidad = equipo.Pokemons.Count
            };

            return View(viewModel);
        }

        [Route("Pokemon/AgregarAMiEquipo")]
        public async Task<IActionResult> AgregarAMiEquipo(int numero_pokedex)
        {
            var pokemon = await _pokemonRepository.GetPokemonById(numero_pokedex);

            if (!_equipoRepository.Add(pokemon))
            {
                return View("Error");
            }

            return Redirect("~/pokemon/ListaPokemon");
        }

        [HttpGet]
        [Route("Pokemon/GetFilteredPokemons")]
        public async Task<IActionResult> GetFilteredPokemons(int? tipo, double? peso, double? altura)
        {
            var filteredPokemons = await _pokemonRepository.GetFilteredPokemons(tipo, peso, altura);
            var alturas = await _pokemonRepository.GetAlturas();
            var pesos = await _pokemonRepository.GetPesos();
            var tipos = await _pokemonRepository.GetTipos();

            var viewModel = new ListaPokemonViewModel
            {
                Pokemons = filteredPokemons,
                Alturas = alturas,
                Pesos = pesos,
                Tipos = tipos
            };

            return View("ListaPokemon", viewModel);
        }

        [HttpGet]
        [Route("Pokemon/VerDetalles")]
        public async Task<IActionResult> VerDetalles(int numero_pokedex)
        {
            var pokemon = await _pokemonRepository.GetPokemonById(numero_pokedex);
            var movimientos = await _pokemonRepository.GetMovimientos(numero_pokedex);
            var evoluciones = await _pokemonRepository.GetEvoluciones(numero_pokedex);
            var involuciones = await _pokemonRepository.GetInvoluciones(numero_pokedex);
            var evolucionadosNombres = new List<string>();
            var involucionadosNombres = new List<string>();
            if (evoluciones.Any())
            {
                foreach (var evolucionado in evoluciones)
                {
                    var evolucionadoPokemon = await _pokemonRepository.GetPokemonById(evolucionado.pokemon_evolucionado);
                    if (evolucionadoPokemon != null)
                    {
                        evolucionadosNombres.Add(evolucionadoPokemon.nombre);
                    }
                }

            }

            if (involuciones.Any())
            {
                foreach (var involucionado in involuciones)
                {
                    var involucionadoPokemon = await _pokemonRepository.GetPokemonById(involucionado.pokemon_origen);
                    if (involucionadoPokemon != null)
                    {
                        involucionadosNombres.Add(involucionadoPokemon.nombre);
                    }
                }
            }

            var viewModel = new DetallesViewModel
            {
                Pokemon = pokemon,
                Movimientos = movimientos,
                Evoluciones = evolucionadosNombres,
                Involuciones = involucionadosNombres,
                
            };

            return View(viewModel);
        }
    }
}





