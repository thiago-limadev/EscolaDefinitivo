using EscolaDefinitivo.Filters;
using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    [PaginaApenasUsuarioLogado]
    public class CursoController : Controller
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public CursoController(ICursoRepositorio cursoRepositorio,
                               IAlunoRepositorio alunoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
            _alunoRepositorio = alunoRepositorio;
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

        public IActionResult ListarAlunosPorId(int id)
        {
            List<Aluno> alunos = _alunoRepositorio.BuscarTodos(id);
            return PartialView("_AlunosCurso", alunos);
        }

    }
}
