using EstevezGayosoRosanaTarea3.Database;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    //creacion profesorController con los action result para index y detalles y el routing correspondiente en cada caso
    public class ProfesorController : Controller
    {
        private readonly InstitutoMontecasteloManager _institutoMontecasteloManager;

        public ProfesorController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloManager = new InstitutoMontecasteloManager(context);
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
            var profesores = _institutoMontecasteloManager.GetAllProfesores();

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
            var profesor = _institutoMontecasteloManager.GetProfesorById(profesorId);
            return View(profesor);
        }
    }
}
