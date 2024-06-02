using EcoOcean.Data;
using EcoOcean.DTOs;
using EcoOcean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcoOcean.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly ILogger<AdministradorController> _logger;



        private readonly DataContext _dataContext;


        public AdministradorController(ILogger<AdministradorController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

    
        public IActionResult LogarAdministrador(LoginAdmDTO request)
        {
            var find = _dataContext.Administrador.FirstOrDefault(x => x.Email == request.Email);

            if (find == null)
            {
                return BadRequest("Email Invalido");
            }

            if (find.Password != request.Password)
            {
                return BadRequest("Password inválida");
            }


            HttpContext.Session.SetInt32("_Id", find.Id);

            return View("~/Views/Administrador/Home.cshtml");
        }




    
    }
}
