using EstevezGayosoRosanaTarea3.Database;
using EstevezGayosoRosanaTarea3.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using EstevezGayosoRosanaTarea3.Models;


namespace EstevezGayosoRosanaTarea3.Controllers
{
    public class LoginController : Controller
    {
        private readonly InstitutoMontecasteloRepository _institutoMontecasteloRepository;

        public LoginController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloRepository = new InstitutoMontecasteloRepository(context);
        }
        //declaramos la variable booleana para saber si el usuario esta logueado 
        public static bool IsUserLoggedIn = false;

        

        [HttpGet]
        [Route("/")]
        [Route("/login/logueate")]
        public IActionResult Logueate()
        {
            return View();
        }

        
        [HttpPost]
        [Route("/")]
        [Route("/login/logueate")]

        public IActionResult Logueate(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Buscar el usuario en la base de datos
                var user = _institutoMontecasteloRepository.GetAllLogin().FirstOrDefault(l => l.Username == model.Username && l.Password == model.Password);

                // Si el usuario existe, redirigir a la página de inicio
                if (user != null)
                {
                    //declaramos usuariologueado a true
                    LoginController.IsUserLoggedIn = true;
                    return Redirect("~/Home/Index");
                }

                // Si el usuario no existe, mostrar un mensaje de error
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            }

            // Volver a mostrar la vista de inicio de sesión

            return Redirect("~/login/logueate");
        }

        

       
    }
}
