using Microsoft.AspNetCore.Mvc;

namespace EcoOcean.Controllers
{
    public class VoluntarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
