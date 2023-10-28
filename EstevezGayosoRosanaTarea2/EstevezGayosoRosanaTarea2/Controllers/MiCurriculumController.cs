using EstevezGayosoRosanaTarea2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea2.Controllers
{
    //creo controlador MiCurriculum que devuelve la vista que recibe del modelo
    public class MiCurriculumController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new CurriculmViewModel();

            return View(viewModel);
        }
    }
}

