using EstevezGayosoRosanaTarea3.Database.Models;

namespace EstevezGayosoRosanaTarea3.Database.Repositories
{
    public class InstitutoMontecasteloRepository : IDisposable
    {
        private readonly InstitutoMontecasteloContext _context;
        public InstitutoMontecasteloRepository(InstitutoMontecasteloContext context)
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
        //mostrar todos los login
        public IEnumerable<Login> GetAllLogin()
        {
            return _context.Logins;
        }
        //mostrar login por id y asi mostrar detalles
        public Login GetLoginById(int id)
        {
            return _context.Logins.FirstOrDefault(login => login.LoginId == id);
        }
        
        public void Delete(Login login)
        {
           
            _context.Logins.Remove(login);
            _context.SaveChanges();
        }


        public void Update()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
