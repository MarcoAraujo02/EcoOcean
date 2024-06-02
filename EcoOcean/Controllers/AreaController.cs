using EcoOcean.Data;
using EcoOcean.DTOs;
using EcoOcean.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoOcean.Controllers
{
    public class AreaController : Controller
    {


        private readonly ILogger<AreaController> _logger;



        private readonly DataContext _dataContext;


        public AreaController(ILogger<AreaController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarArea()
        {
            return View();
        }


        public IActionResult Home()
        {
            return View();
        }


        public IActionResult CadastroArea(CadastroAreaDTO request)
        {
            Area novaArea = new Area
            {
              Cep = request.Cep,
              Estado = request.Estado,
              Cidade = request.Cidade,
              Rua = request.Rua,
              Descricao = request.Descricao
            };

            _dataContext.Add(novaArea);
            _dataContext.SaveChanges();
            return View("~/Views/Area/Home.cshtml");
        }

        public async Task<IActionResult> ListaDeArea()
        {
            var Area = await _dataContext.Area.ToListAsync();

            return View(Area);
        }


        public async Task<IActionResult> EditarPage(int id)
        {

            var Area = await _dataContext.Area.FindAsync(id);
            return View(Area);
        }


        public IActionResult EditarArea(int id, CadastroAreaDTO request)
        {
            var Area = _dataContext.Area.Find(id);

            Area.Cep = request.Cep;
            Area.Estado = request.Estado;
            Area.Cidade = request.Cidade;
            Area.Rua = request.Rua;
            Area.Descricao = request.Descricao;


            _dataContext.Update(Area);
            _dataContext.SaveChanges();

            return RedirectToAction("ListaDeArea", "Area");
        }

     

        public IActionResult DeletarArea(int id)
        {
            var Area = _dataContext.Area.Find(id);

            _dataContext.Remove(Area);
            _dataContext.SaveChanges();
            return RedirectToAction("ListaDeArea");
        }

    }
}
