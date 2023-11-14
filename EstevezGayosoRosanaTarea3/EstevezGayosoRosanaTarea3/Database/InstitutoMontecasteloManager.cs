using EstevezGayosoRosanaTarea3.Database.Models;

namespace EstevezGayosoRosanaTarea3.Database
{
    //creo un institutoMontecasteloManager que gestiona las querys a la base de datos
    public class InstitutoMontecasteloManager : IDisposable
    {
        private readonly InstitutoMontecasteloContext _context;
        public InstitutoMontecasteloManager(InstitutoMontecasteloContext context)
        {
            _context = context;
        }
        //mostrar todoas las asignaturas
        public IEnumerable<Asignatura> GetAllAsignaturas()
        {
            return _context.Asignaturas;
        }
        //mostrar asignatura por id y asi mostrar detalles
        public Asignatura GetAsignaturaById(int id)
        {
            return _context.Asignaturas.FirstOrDefault(asignatura => asignatura.AsignaturaId == id);
        }
        //mostrar todos los estudiantes
        public IEnumerable<Estudiante> GetAllEstudiantes()
        {
            return _context.Estudiantes;
        }
        //mostrar estudiante por id y asi mostrar detalles
        public Estudiante GetEstudianteById(int id)
        {
            return _context.Estudiantes.FirstOrDefault(estudiante => estudiante.EstudianteId == id);
        }
        //mostrar todos los profesores
        public IEnumerable<Profesor> GetAllProfesores()
        {
            return _context.Profesores;
        }
        //mostrar profesor por id y asi mostrar detalles
        public Profesor GetProfesorById(int id)
        {
            return _context.Profesores.FirstOrDefault(profesor => profesor.ProfesorId == id);
        }
        //buscar usuario por username y password
        public Login GetLoginByUser(string username, string password)
        {
            
            return _context.Logins.FirstOrDefault(l => l.Username == username && l.Password == password); ;
        }


        

       

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
