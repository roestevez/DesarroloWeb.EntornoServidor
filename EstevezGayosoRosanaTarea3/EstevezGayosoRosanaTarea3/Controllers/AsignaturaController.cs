using EstevezGayosoRosanaTarea3.Database;
using EstevezGayosoRosanaTarea3.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly InstitutoMontecasteloRepository _institutoMontecasteloRepository;

        public AsignaturaController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloRepository = new InstitutoMontecasteloRepository(context);
        }
        
        [Route("/asignatura")]
        [Route("/asignatura/index")]
        public IActionResult Index()
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var asignaturas = _institutoMontecasteloRepository.GetAllAsignaturas();

            return View(asignaturas);
        }
        [Route("/asignatura/{asignaturaId}")]
        public IActionResult VerAsignatura(int asignaturaId)
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var asignatura = _institutoMontecasteloRepository.GetAsignaturaById(asignaturaId);
            return View(asignatura);
        }
    }
}
