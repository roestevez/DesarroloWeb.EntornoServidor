﻿using System.Diagnostics;
using EstevezGayosoRosanaTarea3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstevezGayosoRosanaTarea3.Controllers
{
    //creacion homeController con el action result para index y su routing

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            // Verificar si el usuario ha iniciado sesión
            if (!LoginController.IsUserLoggedIn)
            {
                // Redirigir al usuario a la página de inicio de sesión
                return Redirect("~/login/logueate");
            }

            return View();
            
            
        }
        
        

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}