using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin (string login );
        Usuario BuscarPorEmailELogin (string email, string login);
        Usuario BuscarporId(int id);
        List<Usuario> ListarTodos();
        Usuario Adicionar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel);

        bool Apagar(int id);
    }
}
