using InmueblesWeb.Data;
using InmueblesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InmueblesWeb.Controllers
{
    public class InternalLoginController : Controller
    {
        UsuarioData usuarioData = new UsuarioData();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel usuarioModel)
        {
            var response = usuarioData.ValidaUsuario(usuarioModel);

            
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
