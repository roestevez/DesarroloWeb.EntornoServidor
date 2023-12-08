namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Equipo
    {
        public List<Pokemon> Pokemons { get; set; } = default!;
        public string nombre { get; set; }  
        public int ContadorVictorias { get; set; }
       

    }
}
