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

        [HttpPost]
        public IActionResult EfetuarColeta(CadastroColetaDTO request)
        {
            
            var participacao = _dataContext.Participacao.FirstOrDefault(p => p.Id == request.ParticipacaoId);

            if (participacao == null)
            {
                
                return NotFound();
            }

            int pontuacao = CalcularPontuacao(request.TipoDoLixo, request.Quantidade);

            
            var novaColeta = new Coleta
            {
                ParticipacaoId = request.ParticipacaoId,
                TipoDoLixo = request.TipoDoLixo,
                Quantidade = request.Quantidade
            };

            
            _dataContext.Coleta.Add(novaColeta);

            
            participacao.Pontuacao += pontuacao;

            
            _dataContext.SaveChanges();

            
            return RedirectToAction("Home", "Administrador");
        }

        
        private int CalcularPontuacao(string tipoDoLixo, int quantidade)
        {
            int pontuacao = 0;

            
            switch (tipoDoLixo.ToLower())
            {
                case "vidro":
                    pontuacao = quantidade * 5;
                    break;
                case "papel":
                    pontuacao = quantidade * 1;
                    break;
                case "plástico":
                    pontuacao = quantidade * 2;
                    break;
                case "metal":
                    pontuacao = quantidade * 3;
                    break;
                case "organico":
                    pontuacao = quantidade * 4;
                    break;
                default:
                    pontuacao = quantidade * 1; 
                    break;
            }

            return pontuacao;
        }
    }
 }

