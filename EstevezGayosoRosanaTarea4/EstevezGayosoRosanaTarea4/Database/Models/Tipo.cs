namespace EstevezGayosoRosanaTarea4.Database.Models
{
    public class Tipo
    {

        public int id_tipo { get; set; }
        public string nombre { get; set; }
        public int id_tipo_ataque { get; set; }

        public override string ToString()
        {
            nombre = nombre + " ";
            return nombre;
            
        }



    }
}
