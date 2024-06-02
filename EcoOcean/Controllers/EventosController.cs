using EcoOcean.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoOcean.Models;
using EcoOcean.DTOs;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EcoOcean.Controllers
{
    public class EventosController : Controller
    {


        private readonly ILogger<EventosController> _logger;



        private readonly DataContext _dataContext;


        public EventosController(ILogger<EventosController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaDeEventos()
        {
            return View();
        }

        public IActionResult CadastrarEvento()
        {

            var ceps = _dataContext.Area.Select(a => a.Cep).ToList();
            ViewBag.CEPs = ceps;

            var id = HttpContext.Session.GetInt32("_Id");
            var idAdminitrador = _dataContext.Administrador.Find(id);
            ViewBag.IdAdministrador = idAdminitrador.Id;

            return View();
        }

        public IActionResult CadastroEvento(CadastroEventoDTO request)
        {

   
            return View();
        }
    }
}
