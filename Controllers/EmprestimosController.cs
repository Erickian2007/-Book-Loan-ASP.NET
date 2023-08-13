using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmprestimosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                emprestimos.Id = _db.Emprestimos.Count<EmprestimosModel>() + 1;
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
