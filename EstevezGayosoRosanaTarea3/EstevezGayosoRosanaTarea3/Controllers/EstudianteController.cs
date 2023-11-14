using EstevezGayosoRosanaTarea3.Database;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers

{
    //creacion estudianteController con los action result para index y detalles y el routing correspondiente en cada caso
    public class EstudianteController : Controller
    {
        private readonly InstitutoMontecasteloManager _institutoMontecasteloManager;

        public EstudianteController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloManager = new InstitutoMontecasteloManager(context);
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
            var estudiantes = _institutoMontecasteloManager.GetAllEstudiantes();

            return View(estudiantes);
        }
        [Route("/estudiante/{estudianteId}")]
        public IActionResult VerEstudiante(int estudianteId)
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión si no ha iniciado sesion
                return Redirect("~/login/logueate");
            }
            var estudiante = _institutoMontecasteloManager.GetEstudianteById(estudianteId);
            return View(estudiante);
        }
    }
}
