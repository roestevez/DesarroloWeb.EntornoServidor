using EstevezGayosoRosanaTarea3.Database;
using EstevezGayosoRosanaTarea3.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly InstitutoMontecasteloRepository _institutoMontecasteloRepository;

        public ProfesorController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloRepository = new InstitutoMontecasteloRepository(context);
        }

        [Route("/profesor")]
        [Route("/profesor/index")]
        public IActionResult Index()
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var profesores = _institutoMontecasteloRepository.GetAllProfesores();

            return View(profesores);
        }
        [Route("/profesor/{profesorId}")]
        public IActionResult VerProfesor(int profesorId)
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var profesor = _institutoMontecasteloRepository.GetProfesorById(profesorId);
            return View(profesor);
        }
    }
}
