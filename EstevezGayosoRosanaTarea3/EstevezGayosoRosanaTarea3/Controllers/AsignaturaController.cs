using EstevezGayosoRosanaTarea3.Database;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    //creacion asignaturaController con los action result para index y detalles y el routing correspondiente en cada caso
    public class AsignaturaController : Controller
    {
        private readonly InstitutoMontecasteloManager _institutoMontecasteloManager;

        public AsignaturaController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloManager = new InstitutoMontecasteloManager(context);
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
            var asignaturas = _institutoMontecasteloManager.GetAllAsignaturas();

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
            var asignatura = _institutoMontecasteloManager.GetAsignaturaById(asignaturaId);
            return View(asignatura);
        }
    }
}
