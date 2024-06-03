using EcoOcean.Data;
using EcoOcean.DTOs;
using EcoOcean.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoOcean.Controllers
{
    public class VoluntarioController : Controller
    {

        private readonly ILogger<VoluntarioController> _logger;


        private readonly DataContext _dataContext;


        public VoluntarioController(ILogger<VoluntarioController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> HomeComEventos()
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


        public IActionResult LoginPage()
        {
            return View();
        }


        public IActionResult Home()
        {
            return View();
        }

        public IActionResult LogarVoluntario(LoginVoluntarioDTO request)
        {

            var voluntario = _dataContext.Voluntario.FirstOrDefault(x => x.Email == request.Email);

            if (voluntario == null)
            {
                return BadRequest("Email invalido");
            }

            if (voluntario.Senha != request.Senha)
            {
                return BadRequest("Senha Invalida");
            }


            HttpContext.Session.SetInt32("_Id", voluntario.Id);

            return RedirectToAction("HomeComEventos");
        }


        public IActionResult CadastrarVoluntario()
        {
            return View();
        }
        


        public IActionResult CadastroVoluntario(CadastroVoluntrioDTO request)
        {
            var voluntario = _dataContext.Voluntario.FirstOrDefault(x => x.Email == request.Email);

            if(voluntario != null)
            {
                return BadRequest("Voluntario ja existe");
            }

            Voluntario novovoluntario = new Voluntario
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Email = request.Email,
                Sexo = request.Sexo,
                Senha = request.Senha,
                UserName = request.UserName,
            };

            _dataContext.Add(novovoluntario);
            _dataContext.SaveChanges();

            return RedirectToAction("LoginPage");
        }





    }
}
