using InmueblesWeb.Data;
using InmueblesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InmueblesWeb.Controllers
{
    public class InternalLoginController : Controller
    {
        LoginData loginData = new LoginData();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = loginData.ValidaUsuario(usuarioModel);

            
            if (response == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return View();
            }
        }
    }
}
