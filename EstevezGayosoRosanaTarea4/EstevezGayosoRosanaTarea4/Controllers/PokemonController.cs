using EstevezGayosoRosanaTarea4.Database.Models;
using EstevezGayosoRosanaTarea4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea4.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        
        [Route("/pokemon")]
        [Route("/pokemon/index")]
        public IActionResult Index()
        {
            return View();  
        }
        public async Task<IActionResult> ListaPokemon()
        {
            return RedirectToAction("GetAll");
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = await _pokemonRepository.GetAllPokemons();
            return View("ListaPokemon",Data);  
        }
        
        [HttpGet]
        public async Task<IActionResult> VerPokemon(int numero_pokedex)
        {
            var pokemon = await _pokemonRepository.GetPokemonById(numero_pokedex);
            return View("VerPokemon", pokemon);
        }
        [HttpGet]
        public async Task<IActionResult> GetFilteredPokemons(string tipo, double? peso, double? altura)
        {
            var filteredPokemons = await _pokemonRepository.GetFilteredPokemons(tipo, peso, altura);
            return View("ListaPokemon", filteredPokemons);
        }
        [HttpGet]
        [Route("Pokemon/VerMovimiento")]
        public async Task<IActionResult> GetMovimientos(int numero_pokedex)
        {
            var movimientos = await _pokemonRepository.GetMovimientos(numero_pokedex);

            
            return View("VerMovimiento", movimientos);
        }


    }
}
