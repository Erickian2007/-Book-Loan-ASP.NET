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

        [HttpGet]
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
                try
                {
                    _db.Emprestimos.Add(emprestimos);
                    _db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel? emprestimos = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimos == null)
            {
                return NotFound();
            }
            return View(emprestimos);
        }
        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            EmprestimosModel? emprestimos = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimos == null)
            {
                return NotFound();
            }
            return View(emprestimos);
        }
        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Remove(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimos);
        }
    }
}
