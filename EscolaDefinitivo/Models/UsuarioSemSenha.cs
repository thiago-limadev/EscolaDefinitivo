using EscolaDefinitivo.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaDefinitivo.Models
{
    public class UsuarioSemSenha
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite o Login do Usuario")]
        public string Login { get; set;}
        
        [Required(ErrorMessage = "Digite o e-mail do Usuário")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set;}
        
        [Required(ErrorMessage = "Selecione o perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
      
    }
}
