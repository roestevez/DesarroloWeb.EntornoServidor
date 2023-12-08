using EstevezGayosoRosanaTarea4.Database.Models;

namespace EstevezGayosoRosanaTarea4.Database.Repository
{
    public interface IEquipoRepository
    {
        bool Add(Pokemon pokemon);
        Equipo GetMiEquipo();
        Equipo GetEquipoAleatorio(List<Pokemon> allPokemons,int ? maxPokemons=null);
    }
}
