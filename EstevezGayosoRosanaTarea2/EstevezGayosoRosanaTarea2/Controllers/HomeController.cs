using System.Diagnostics;
using EstevezGayosoRosanaTarea2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //anhadir directorio mi curricum a homeCONTROLLER
        public IActionResult MiCurriculum()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}