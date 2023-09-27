using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Helpper
{
    public interface ISessao
    {
        void CriarSessaoUsuario (Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoUsuario();
    }
}
