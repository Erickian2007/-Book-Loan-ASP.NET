using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmprestimoLivros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(RegistroModel registro)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in _db.Registro)
                {
                    if (item.Email == registro.Email)
                    {
                        if (item.Password == registro.Password)
                            return RedirectToAction("Index", "Emprestimos");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(RegistroModel registro)
        {
            if (ModelState.IsValid)
            {
                _db.Registro.Add(registro);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}