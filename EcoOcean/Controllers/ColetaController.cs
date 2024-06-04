using EcoOcean.Data;
using Microsoft.AspNetCore.Mvc;
using EcoOcean.Models;
using EcoOcean.DTOs;

namespace EcoOcean.Controllers
{
    public class ColetaController : Controller
    {

        private readonly ILogger<ColetaController> _logger;


        private readonly DataContext _dataContext;


        public ColetaController(ILogger<ColetaController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Coleta()
        {
            var participacoes =  _dataContext.Participacao.ToList();
            ViewBag.participacoes = participacoes;
            
            return View();
        }

        public IActionResult EfetuarColeta()
        {
            return View();
        }
    }
}
