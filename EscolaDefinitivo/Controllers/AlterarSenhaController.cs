using EscolaDefinitivo.Helpper;
using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    public class AlterarSenhaController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                      ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar(AlterarSenhaModel alterarSenha)
        {
            try
            {
                Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
                alterarSenha.Id = usuarioLogado.Id; 
                if(ModelState.IsValid) 
                {

                    _usuarioRepositorio.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Senha Alterada com Sucesso !";
                    return RedirectToAction("Index");
                }

                throw new Exception("Confirmação de Senha não confere com Nova Senha informada!");
                return View("Index", alterarSenha);
            }

            catch (Exception erro) 
            {

                TempData["MensagemErro"] = $"Ops, não foi possível alterar a senha do Usuario, por favor tente novamente. Detalhes do erro: {erro.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
