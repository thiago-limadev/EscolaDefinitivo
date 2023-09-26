using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    public interface ICursoRepositorio
    {
        Curso BuscarporId(int id);
        List<Curso> ListarTodos();
        Curso Adicionar(Curso curso);
        Curso Atualizar(Curso curso);
        bool Apagar(int id);

    }
}
