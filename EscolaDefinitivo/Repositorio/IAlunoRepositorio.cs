using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    public interface IAlunoRepositorio
    {
        Aluno BuscarporId(int id);
        List<Aluno> ListarTodos();  
        Aluno Adicionar(Aluno aluno);

        Aluno Atualizar(Aluno aluno);

        bool Apagar(int id);
    }
}
