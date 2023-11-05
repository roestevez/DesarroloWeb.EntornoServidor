using EstevezGayosoRosanaTarea3.Controllers;
using EstevezGayosoRosanaTarea3.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea2.Controllers
{
    //creo controlador MiCurriculum que devuelve la vista que recibe del modelo
    public class MiCurriculumController : Controller
    {
        
        [Route("/login/MiCurriculum")]
        public IActionResult Index()

        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }
            var viewModel = new CurriculmViewModel();

            return View(viewModel);
        }
    }
}

