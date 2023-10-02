using System.ComponentModel.DataAnnotations;

namespace EscolaDefinitivo.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = " Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = " Informe o e-mail de cadastro")]
        public string Email { get; set; }
    }
}
