using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EscolaDefinitivo.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            
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

            Aluno aluno = _alunoRepositorio.BuscarporId(id);
            
            return View(aluno);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _alunoRepositorio.Apagar(id);
                if (apagado ) 
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
        public IActionResult Atualizar(Aluno aluno)
        {
            try
            { 

                if (ModelState.IsValid)
                {  
                    
                    _alunoRepositorio.Atualizar(aluno);
                    TempData["MensagemSucesso"] = "Aluno atualizado com Sucesso!";
                    return RedirectToAction("Index");
                }
                
                return View("Editar", aluno);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o Aluno, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }    
    }
}
