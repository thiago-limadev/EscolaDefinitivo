using EscolaDefinitivo.Filters;
using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    [PaginaApenasAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private object usarioSemSenha;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios= _usuarioRepositorio.ListarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o Usuario, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            Usuario usuario = _usuarioRepositorio.BuscarporId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioSemSenha usuarioSemSenha)
        {
            try
            {
                Usuario usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new Usuario()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario atualizado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o Usuario, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario removido com Sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possível remover o Usuario!";
                }

                return RedirectToAction("Index");
            }

            catch (Exception erro)

            {
                TempData["MensagemErro"] = $"Ops, não foi possível remover o Usuario, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
