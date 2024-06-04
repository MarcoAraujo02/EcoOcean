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


        public async Task<IActionResult> ListaDeEventos()
        {
            // Recupere os dados das tabelas de área e eventos
            var areas = await _dataContext.Area.ToListAsync();
            var eventos = await _dataContext.Evento.ToListAsync();

            // Combine os dados em uma única estrutura de dados
            var listaCombinada = areas.Select(area => new
            {
                Area = area,
                Evento = eventos.FirstOrDefault(e => e.AreaId == area.Id)
            }).ToList();

            return View(listaCombinada);
        }

        public async Task<IActionResult> ListaDeEventosEncerrados()
        {
            // Recupere os dados das tabelas de área e eventos
            var areas = await _dataContext.Area.ToListAsync();
            var eventos = await _dataContext.Evento.ToListAsync();

            // Combine os dados em uma única estrutura de dados
            var listaCombinada = areas.Select(area => new
            {
                Area = area,
                Evento = eventos.FirstOrDefault(e => e.AreaId == area.Id)
                
            }).ToList();

            return View(listaCombinada);
        }


        public IActionResult FinalizarEvento(int eventoId)
        {
            var evento = _dataContext.Evento.FirstOrDefault(e => e.Id == eventoId);

            if (evento != null)
            {
                evento.Status = "Encerrado";
                _dataContext.SaveChanges();
            }

            return View("~/Views/Administrador/Home.cshtml"); 
        }


        public IActionResult CadastrarEvento()
        {

            var areas = _dataContext.Area.ToList();
            ViewBag.Areas = areas;


            var id = HttpContext.Session.GetInt32("_Id");
            var idAdministrador = _dataContext.Administrador.Find(id);
            ViewBag.IdAdministrador = idAdministrador.Id;

            return View();
        }


        public IActionResult CadastroEvento(CadastroEventoDTO request, int idAdministrador, int areaid)
        {

            Evento evento = new Evento
            {
                AdministradorId = idAdministrador,
                AreaId = areaid,
                NomeEvento =  request.NomeEvento,
                DataInicio = System.DateTime.Now,
                DataFim = DateTime.MinValue,
                Status = "Andamento",
            };


            _dataContext.Add(evento);
            _dataContext.SaveChanges();
             
            return View("~/Views/Administrador/Home.cshtml");
        }
    }
}
