using EscolaDefinitivo.Enums;
using EscolaDefinitivo.Helpper;
using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaDefinitivo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite o Login do Usuario")]
        public string Login { get; set;}
        
        [Required(ErrorMessage = "Digite o e-mail do Usuário")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set;}
        
        [Required(ErrorMessage = "Digite a senha do Usuario")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Selecione o perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
        public  DateTime DatadeCadastro { get; set; }
        public DateTime? DatadeAtualizacao { get; set; }


        public Usuario()
        {
            
        }

        public Usuario(string nome, string login, string email, string senha, PerfilEnum? perfil)
        {
            Nome = nome;
            Login = login; 
            Email = email; 
            Senha = senha;    
            Perfil = perfil;
            DatadeCadastro = DateTime.Now;
        }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash() 
        {
            Senha = Senha.GerarHash();
        }

    }
}
