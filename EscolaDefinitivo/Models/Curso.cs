namespace EscolaDefinitivo.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //public string Periodo { get; set;}

        public virtual List<Aluno> AlunosMatriculados { get; set;  }

       
    }
}
