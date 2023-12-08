namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Batalla
    {
        public List<Combate> Combates { get; set; }
        public Equipo EquipoUno { get; set; }
        public Equipo EquipoDos { get; set; }   
        public Equipo EquipoGanador { get; set; }

    }
}
