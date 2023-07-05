using Microsoft.AspNetCore.Mvc;

namespace InmueblesWeb.Controllers
{
    public class InmuebleController : Controller
    {
        public IActionResult GetListInmuebles()
        {
            return View();
        }
    }
}
