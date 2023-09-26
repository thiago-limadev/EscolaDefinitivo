using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public CursoController(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        public IActionResult Index()
        {
            List<Curso> cursos = _cursoRepositorio.ListarTodos();
            return View(cursos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var curso = _cursoRepositorio.BuscarporId(id);
            return View(curso);
        }

        public IActionResult Apagar(int id)
        {
            _cursoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Curso curso)
        {
            _cursoRepositorio.Adicionar(curso);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Atualizar(Curso curso)
        {
            _cursoRepositorio.Atualizar(curso);
            return RedirectToAction("Index");
        }
    }
}
