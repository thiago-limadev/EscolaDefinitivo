using EscolaDefinitivo.Helpper;
using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;   

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se usuario estiver logado, leva para home.
            if(_sessao.BuscarSessaoUsuario() != null)   return RedirectToAction("Index", "Home");

            return View();
        }


        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
        
        
        
        [HttpPost]
        public IActionResult Logar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Usuario usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null && usuario.SenhaValida(loginModel.Senha))
                    {
                        _sessao.CriarSessaoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }

                    else if (usuario != null)
                    {   

                        TempData["MensagemErro"] = "Senha inválida, verifique e tente novamente.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Login inválido, verifique e tente novamente.";
                    }
                                       
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível realizar o login, por favor tente novamente. Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }        
        }

    }
}
