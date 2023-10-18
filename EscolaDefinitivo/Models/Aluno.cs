using System.ComponentModel.DataAnnotations;

namespace EscolaDefinitivo.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage = "Digite o nome do Aluno")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite o e-mail do Aluno")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Digite um telefone válido")]
        public string Telefone { get; set; }

        public int? CursoId { get; set; }
        public virtual Curso? Curso { get; set; }

        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Numero { get; set; } 

    }
}
