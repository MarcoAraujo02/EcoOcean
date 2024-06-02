using Microsoft.AspNetCore.Mvc;

namespace EcoOcean.Controllers
{
    public class ColetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Coleta()
        {
            return View();
        }
    }
}
