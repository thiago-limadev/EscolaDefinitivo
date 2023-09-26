namespace EscolaDefinitivo.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        

        public  List<Aluno> Alunos { get; set; } = new List<Aluno>();

       
    }
}
