using EstevezGayosoRosanaTarea4.Database.Models;



namespace EstevezGayosoRosanaTarea4.Models
{
    public class EquipoViewModel
    {
        
        public IEnumerable<Tipo> Tipos { get; set; }    
        public Equipo Equipo { get; set; }
      
        public string Predominate { get; set; }
        public double PesoPromedio { get; set; }    
        public double AlturaPromedio { get; set; }  
        public int Cantidad { get; set; }

        









    }

}
