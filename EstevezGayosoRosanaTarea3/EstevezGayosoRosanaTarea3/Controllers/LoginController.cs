using EstevezGayosoRosanaTarea3.Database;
using EstevezGayosoRosanaTarea3.Models;
using Microsoft.AspNetCore.Mvc;



namespace EstevezGayosoRosanaTarea3.Controllers
{
    //y el routing correspondiente en cada caso
    public class LoginController : Controller
    {
        private readonly InstitutoMontecasteloManager _institutoMontecasteloManager;

        public LoginController(InstitutoMontecasteloContext context)
        {
            _institutoMontecasteloManager = new InstitutoMontecasteloManager(context);
        }
        //declaramos la variable booleana para saber si el usuario esta logueado 
        public static bool IsUserLoggedIn = false;

        

        [HttpGet]
        [Route("/login")]
        [Route("/login/logueate")]
        public IActionResult Logueate()
        {
            return View();
        }
        [HttpPost]
        [Route("/login/logueate")]

        public IActionResult Logueate(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _institutoMontecasteloManager.GetLoginByUser(username,password);
                 // Si el usuario existe, redirigir a la página de inicio
                if ( user!= null)
                {
                    //declaramos usuariologueado a true
                    IsUserLoggedIn = true;
                    return Redirect("~/Home/Index");
                }

                // Si el usuario no existe, mostrar un mensaje de error
                return View("Error");

            }

            // Volver a mostrar la vista de inicio de sesión

            return Redirect("~/login/logueate");
        }
        //si el usuario cancela sesion es redirigido a la pagina de login
        [Route("/login/deslogueate")]
        [HttpGet]
        public IActionResult Deslogueate()
        {
            IsUserLoggedIn = false;
            return Redirect("~/login/logueate");

        }


        

       
    }
}
