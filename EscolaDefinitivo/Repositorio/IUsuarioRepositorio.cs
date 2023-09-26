using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin (string login );
        Usuario BuscarporId(int id);
        List<Usuario> ListarTodos();
        Usuario Adicionar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        bool Apagar(int id);
    }
}
