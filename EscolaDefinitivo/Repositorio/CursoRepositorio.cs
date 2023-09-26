using EscolaDefinitivo.Data;
using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{

    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly EscolaContext _escolaContext;
        public CursoRepositorio(EscolaContext escolaContext)
        {
            _escolaContext = escolaContext;
        }

        public Curso BuscarporId(int id)
        {
            return _escolaContext.Cursos.FirstOrDefault(x => x.Id == id);
        }

        public List<Curso> ListarTodos()
        {
            return _escolaContext.Cursos.ToList();
        }
        public Curso Adicionar(Curso curso)
        {
            // Grava no banco
            _escolaContext.Cursos.Add(curso);
            _escolaContext.SaveChanges();

            return (curso);
        }

        public Curso Atualizar(Curso curso)
        {
            Curso cursoDB= BuscarporId(curso.Id);

            if (cursoDB == null) throw new Exception("Houve um erro ao tentar atualizar o Curso");

            cursoDB.Nome = curso.Nome;
            _escolaContext.Cursos.Update(cursoDB);
            _escolaContext.SaveChanges();

            return cursoDB;

        }

        public bool Apagar(int id)
        {
            Curso cursoDB = BuscarporId(id);

            if (cursoDB == null) throw new Exception("Houve um erro ao tentar excluir o Curso");


            _escolaContext.Cursos.Remove(cursoDB);
            _escolaContext.SaveChanges();

            return true;

        }

    }
}
