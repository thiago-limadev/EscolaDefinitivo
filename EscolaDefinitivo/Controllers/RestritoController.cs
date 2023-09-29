using EscolaDefinitivo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaApenasUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
