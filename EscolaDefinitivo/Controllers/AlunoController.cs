using EscolaDefinitivo.Filters;
using EscolaDefinitivo.Models;
using EscolaDefinitivo.Models.ViewData;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EscolaDefinitivo.Controllers
{
    [PaginaApenasUsuarioLogado]
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ICursoRepositorio _cursoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio, ICursoRepositorio cursoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _cursoRepositorio = cursoRepositorio;
        }
        public IActionResult Index()
        {
            List<Aluno> alunos = _alunoRepositorio.ListarTodos();
            return View(alunos);
        }

        public IActionResult Criar()
        {


            return View();

        }

        public IActionResult Editar(int id)
        {
            List<Curso> cursos = _cursoRepositorio.ListarTodos();
            Aluno aluno = _alunoRepositorio.BuscarporId(id);
            var editaralunoviewdata = new EditarAlunoViewData()
            {
                Aluno = aluno,
                Cursos = cursos.Select(curso => new SelectListItem(curso.Nome, curso.Id.ToString())).ToList()

            };
            return View(editaralunoviewdata);
        }
        
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _alunoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Aluno removido com Sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possível remover o Aluno!";
                }

                return RedirectToAction("Index");
            }

            catch (Exception erro)

            {
                TempData["MensagemErro"] = $"Ops, não foi possível remover o Aluno, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {


            try
            {
                if (ModelState.IsValid)
                {


                    _alunoRepositorio.Adicionar(aluno);
                    TempData["MensagemSucesso"] = "Aluno cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }



                return View(aluno);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o Aluno, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(EditarAlunoViewData editarAlunoViewData)
        {
            try
            {
                var aluno = editarAlunoViewData.Aluno;
                if (aluno.CursoId == null)
                {
                    aluno.Curso = null;
                }
                else
                {
                    aluno.Curso = _cursoRepositorio.BuscarporId((int)aluno.CursoId);
                }


                if (ModelState.IsValid)
                {

                    _alunoRepositorio.Atualizar(aluno);
                    TempData["MensagemSucesso"] = "Aluno atualizado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", editarAlunoViewData);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o Aluno, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
