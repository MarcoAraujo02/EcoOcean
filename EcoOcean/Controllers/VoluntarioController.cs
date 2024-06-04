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

      

            var id = HttpContext.Session.GetInt32("_Id");
            var IdVoluntario = _dataContext.Voluntario.Find(id);
            ViewBag.IdVoluntario = IdVoluntario.Id;

            
            var areas = await _dataContext.Area.ToListAsync();
            var eventos = await _dataContext.Evento.ToListAsync();



            var listaCombinada = areas.Select(area => new
            {
                Area = area,
                Evento = eventos.FirstOrDefault(e => e.AreaId == area.Id)
            }).ToList();

            return View(listaCombinada);
        }


        public IActionResult ParticiparEvento(int VoluntarioId, int EventoId)
        {
            // Verifica se já existe uma participação para esse voluntário e evento
            var participacaoExistente = _dataContext.Participacao
                .FirstOrDefault(p => p.VoluntarioId == VoluntarioId && p.EventoId == EventoId);

            // Se já existe uma participação, redirecione sem adicionar uma nova entrada
            if (participacaoExistente != null)
            {
                // Você pode lidar com isso de várias maneiras, como exibir uma mensagem de erro
                // ou redirecionar com uma mensagem informativa

                return BadRequest("Opss voce ja esta participando a esse evento se atente a sua data de inicio para nao perder, ou espere o adm Inicir um novo :)");
            }

            // Se não existe uma participação, crie uma nova
            Participacao participacao = new Participacao
            {
                VoluntarioId = VoluntarioId,
                EventoId = EventoId,
                Pontuacao = 0
            };

            _dataContext.Add(participacao);
            _dataContext.SaveChanges();
            return RedirectToAction("HomeComEventos");
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
