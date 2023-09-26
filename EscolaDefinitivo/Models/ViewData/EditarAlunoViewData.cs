using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDefinitivo.Models.ViewData
{
    public class EditarAlunoViewData
    {
        public Aluno Aluno {  get; set; }
        public List<SelectListItem> Cursos { get; set; }
    }
}
