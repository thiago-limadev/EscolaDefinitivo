using EscolaDefinitivo.Models;
using EscolaDefinitivo.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
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
