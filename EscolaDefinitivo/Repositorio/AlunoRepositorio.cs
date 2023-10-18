using EscolaDefinitivo.Data;
using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly EscolaContext _escolaContext;
        public AlunoRepositorio(EscolaContext escolaContext) 
        {
            _escolaContext = escolaContext;
        }

        public Aluno BuscarporId(int id)
        {
            return _escolaContext.Alunos.FirstOrDefault(x => x.Id == id);
        }

        public List<Aluno> ListarTodos()
        {
            return _escolaContext.Alunos.ToList();
        }
        public Aluno Adicionar(Aluno aluno)
        {
            // Grava no banco
            _escolaContext.Alunos.Add(aluno);
            _escolaContext.SaveChanges(); 
           
            return(aluno); 
           
        }

        public Aluno Atualizar(Aluno aluno)
        {
            Aluno alunoDB = BuscarporId(aluno.Id);

            if (alunoDB == null) throw new Exception("Houve um erro ao tentar atualizar o Aluno");

            alunoDB.Nome = aluno.Nome;
            alunoDB.Telefone = aluno.Telefone;
            alunoDB.Email = aluno.Email;
            alunoDB.CursoId = aluno.CursoId;
            alunoDB.Cep = aluno.Cep;
            alunoDB.Logradouro = aluno.Logradouro;
            alunoDB.Complemento = aluno.Complemento;
            alunoDB.Bairro = aluno.Bairro;
            alunoDB.Localidade = aluno.Localidade;    
            alunoDB.Uf = aluno.Uf;
            alunoDB.Numero = aluno.Numero;
            _escolaContext.Alunos.Update(alunoDB);
            _escolaContext.SaveChanges();
            return alunoDB;
            
        }

        public bool Apagar(int id)
        {
            Aluno alunoDB = BuscarporId(id);

            if (alunoDB == null) throw new Exception("Houve um erro ao tentar excluir o Aluno");

            
            _escolaContext.Alunos.Remove(alunoDB);
            _escolaContext.SaveChanges();

            return true;

        }

        public List<Aluno> BuscarTodos(int cursoId)
        {
            return _escolaContext.Alunos.Where(x => x.CursoId == cursoId).ToList();
        }
    }
}
