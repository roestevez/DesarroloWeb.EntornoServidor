using EstevezGayosoRosanaTarea3.Database;
using EstevezGayosoRosanaTarea3.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly InstitutoMontecasteloRepository _institutoMontecasteloRepository;

        public EstudianteController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloRepository = new InstitutoMontecasteloRepository(context);
        }
        [Route("/estudiante")]
        [Route("/estudiante/index")]
        public IActionResult Index()
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var estudiantes = _institutoMontecasteloRepository.GetAllEstudiantes();

            return View(estudiantes);
        }
        [Route("/estudiante/{estudianteId}")]
        public IActionResult VerEstudiante(int estudianteId)
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var estudiante = _institutoMontecasteloRepository.GetEstudianteById(estudianteId);
            return View(estudiante);
        }
    }
}
